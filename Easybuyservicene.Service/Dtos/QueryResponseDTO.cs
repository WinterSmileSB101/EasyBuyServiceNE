using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos
{
    public class QueryResponseDTO<T> where T:new()
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T ResultEntity { get; set; }
        public int? TotalCount { get; set; }
    }
}
