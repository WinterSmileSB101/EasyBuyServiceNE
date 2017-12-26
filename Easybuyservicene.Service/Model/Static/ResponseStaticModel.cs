using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easybuyservicene.Service.Model.Static
{
    public class ResponseStaticModel
    {
        public class Code
        {
            public const int OK = 200;
            public const int PARAM_ERROR = 303;
            public const int SUCCESS = 200;
            public const int FAILED = 504;
            public const int SERVER_ERROR = 500;
        }

        public class Message
        {
            public const string OK = "OK";
            public const string PARAM_ERROR = "There are some errors in params";
            public const string SUCCESS = "SUCCESS";
            public const string FAILED = "FAILED";
            public const string SERVER_ERROR = "SERVERERROR";
        }
    }
}
