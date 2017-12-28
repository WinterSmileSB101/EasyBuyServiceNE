using Easybuyservicene.Service.Dtos;
using Newegg.Oversea.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Easybuyservicene.Service.Services.Test
{
    class TestService : ModuleServiceBases<TestDTO>
    {
        public override object OnGet(TestDTO request)
        {
            var dataCommand = DataCommandManager.GetDataCommand("TestTable");
            var testTable = dataCommand.ExecuteEntityList<TestDTO>();

            foreach (var item in testTable)
            {
                var bulletDescription = "a\rb\rc";

                var text = bulletDescription.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var textEditor = bulletDescription.Trim().Split(new string[] { "\r\n\t", "\t\r\n","\r\n","\r","\n" }, StringSplitOptions.RemoveEmptyEntries);
                var textNeweggCom = Regex.Split(bulletDescription, @"\r\n");
            }
            
            return base.OnGet(request);
        }
    }
}
