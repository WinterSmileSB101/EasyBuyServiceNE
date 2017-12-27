using Newegg.API.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Dtos
{
    [RestService("api/test")]
    public class TestDTO:BaseDTO
    {
        public int ID { get; set; }

        public string Bullertdes { get; set; }
    }
}
