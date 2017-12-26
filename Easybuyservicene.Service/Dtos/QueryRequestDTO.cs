using Newegg.API.Attributes;
using Newegg.Oversea.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos
{
    public class QueryRequestDTO<T> where T :new()
    {
        public T RequestEntity { get; set; }
        
    }
}
