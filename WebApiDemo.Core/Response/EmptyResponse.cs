using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Core.Response
{
    public class EmptyResponse : JsonResponse<string>
    {
        public EmptyResponse() : base(true, string.Empty)
        {

        }

        public EmptyResponse(string message) : base(true, message)
        {

        }

        public EmptyResponse(bool isSuccess, string message) : base(isSuccess, message)
        {

        }

        public EmptyResponse(string errorCode, string message)
            : base(errorCode, message)
        {

        }

    }
}
