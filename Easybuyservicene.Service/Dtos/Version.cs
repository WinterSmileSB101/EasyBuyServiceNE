using Newegg.API.Attributes;

namespace Easybuyservicene.Service.Dtos
{
    [RestService("/version")]
    public class Version
    {
        public string No { get; set; }
    }
}
