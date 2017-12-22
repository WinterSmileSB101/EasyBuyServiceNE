using Newegg.API.Interfaces;
using Easybuyservicene.Service.Dtos;

using System.Reflection;

namespace Easybuyservicene.Service.Services
{
    public class VersionService : RestServiceBase<Version>
    {

        public override object OnGet(Version request)
        {
            return new Version
            {
                No = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            };
        }


    }
}
