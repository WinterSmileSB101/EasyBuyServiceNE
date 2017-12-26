using Easybuyservicene.Service.Dtos;
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

        public static QueryResponseDTO<string> SUCCESS_MODEL = new QueryResponseDTO<string>
        {
            Code = Code.OK,
            Message = Message.OK
        };

        public static QueryResponseDTO<string> FAILED_MODEL = new QueryResponseDTO<string>
        {
            Code = Code.FAILED,
            Message = Message.FAILED
        };

        public static QueryResponseDTO<string> PARAM_ERROR_MODEL = new QueryResponseDTO<string>
        {
            Code = Code.PARAM_ERROR,
            Message = Message.PARAM_ERROR
        };

        public static QueryResponseDTO<string> SERVER_ERROR_MODEL = new QueryResponseDTO<string>
        {
            Code = Code.SERVER_ERROR,
            Message = Message.SERVER_ERROR
        };
    }
}
