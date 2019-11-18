using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hunter.Api.Helpers
{
    public class ApiResponse
    {
        public static object Send(string message, int code)
        {
            return new
            {
                Message = message,
                StatusCode = code
            };
        }
        public static object Send<T>(T Data, string message, int code)
        {
            return new
            {
                Body = Data,
                Message = message,
                StatusCode = code
            };
        }

        public static object Send<T>(T Data)
        {
            return Send(Data, 200);
        }

        public static object Send<T>(T Data, int code)
        {
            return new
            {
                Body = Data,
                StatusCode = code
            };
        }
    }

}
