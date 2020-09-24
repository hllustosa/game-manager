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

        private static readonly string PAGINATION = @"LIMIT :limit offset :offset";

        protected ApplicationDbContext ApplicationDbContext { get; set; }

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

        protected T FindById(string query, string idColumn, string id)
        {
            var whereClause = String.Format(ID_FILTER, idColumn);
            var connection = ApplicationDbContext.Database.GetDbConnection();
            return connection.Query<T>(query + whereClause, new { id }).FirstOrDefault();
        }

        protected PagedResult<T> FindLike(string query, string likeColumn, string param, int page, int pageSize)
        {
            var limit = pageSize;
            var offset = (page - 1) * pageSize;
            long totalCount = 0;
            
            if (!String.IsNullOrEmpty(param))
            {
                query += String.Format(LIKE_FILTER, likeColumn); ;
            }
            query += PAGINATION;

            var connection = ApplicationDbContext.Database.GetDbConnection();
            var models = connection.Query<T, long, T>(query,
                (model, count) =>
                {
                    totalCount = count;
                    return model;
                },
                new { param = "%"+param+"%", limit, offset },
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
