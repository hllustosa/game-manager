using Dapper;
using GameManagement.Domain;
using GameManagement.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GameManagement.Repositories
{
    public class BaseRepository<T> where T : class
    {
        private static readonly string ID_FILTER = @"WHERE {0} = :id ";

        private static readonly string LIKE_FILTER = @"WHERE {0} LIKE :param ";

        private static readonly string BETWEEN_FILTER = @"WHERE {0} BETWEEN :initial AND :final";

        private static readonly string ORDER_BY = @"ORDER BY {0}";

        private static readonly string PAGINATION = @"LIMIT :limit offset :offset";

        ApplicationDbContext ApplicationDbContext { get; set; }

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        protected T FindById(string query, string idColumn, long id)
        {
            var whereClause = String.Format(ID_FILTER, idColumn);
            var connection = ApplicationDbContext.Database.GetDbConnection();
            return connection.Query<T>(query + whereClause, new { id }).FirstOrDefault();
        }

        protected PagedResult<T> FindLike(string query, string likeColumn, string param, int page, int pageSize)
        {
            var limit = (page - 1) * pageSize;
            var offset = pageSize;
            var totalCount = 0;
            
            if (!String.IsNullOrEmpty(param))
            {
                query += String.Format(LIKE_FILTER, likeColumn); ;
            }
            query += PAGINATION;

            var connection = ApplicationDbContext.Database.GetDbConnection();
            var models = connection.Query<T, int, T>(query,
                (model, count) =>
                {
                    totalCount = count;
                    return model;
                },
                new { param = "%"+param+"%", limit, offset },
                splitOn: "count").AsList();

            return new PagedResult<T>(models, page, totalCount);
        }

        protected PagedResult<T> FindByDateRange(string query, 
            string betweenColumn, 
            int page, 
            int pageSize, 
            DateTime? initial, 
            DateTime? final, 
            string orderByColumn)
        {
            var limit = (page - 1) * pageSize;
            var offset = pageSize;
            var totalCount = 0;
            var whereClause = "";

            if (initial != null && final != null)
            {
                whereClause = String.Format(BETWEEN_FILTER, betweenColumn);
            }

            query += whereClause;
            query += String.Format(ORDER_BY, orderByColumn);
            query += PAGINATION;

            var connection = ApplicationDbContext.Database.GetDbConnection();
            var models = connection.Query<T, int, T>(query,
                (model, count) =>
                {
                    totalCount = count;
                    return model;
                },
                new { initial, final, limit, offset },
                splitOn: "count").AsList();

            return new PagedResult<T>(models, page, totalCount);
        }

        protected void Save(T entity)
        {
            ApplicationDbContext.Add<T>(entity);
            ApplicationDbContext.SaveChanges();
        }

        protected void Update(T entity)
        {
            ApplicationDbContext.Update<T>(entity);
            ApplicationDbContext.SaveChanges();
        }

        protected void Delete(T entity)
        {
            ApplicationDbContext.Remove<T>(entity);
            ApplicationDbContext.SaveChanges();
        }
    }
}
