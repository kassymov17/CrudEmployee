using System.Collections.Generic;
using System.Linq;

namespace CrudEmployee.Web.Models
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }
        
        public int Count
        {
            get
            {
                return (null != this.Items) ? this.Items.Count() : 0;
            }
        }

        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}