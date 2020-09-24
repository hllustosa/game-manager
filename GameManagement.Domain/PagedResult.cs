using System;
using System.Collections.Generic;
using System.Text;

namespace GameManagement.Domain
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }

        public int Page { get; set; }

        public long TotalItensCount { get; set; }

        public PagedResult(List<T> data, int page, long totalItensCount)
        {
            Data = data;
            Page = page;
            TotalItensCount = totalItensCount;
        }
    }
}
