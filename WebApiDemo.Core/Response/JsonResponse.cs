using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Core.Response
{
    public class JsonResponse<T>
    {
        public string ErrorCode { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public JsonResponse(T data)
        {
            this.IsSuccess = true;
            this.Data = data;
        }

        public JsonResponse(T data,string message)
        {
            this.IsSuccess = true;
            this.Message = message;
            this.Data = Data;
        }

        public JsonResponse(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public JsonResponse(string errorCode, string message)
        {
            this.IsSuccess = false;
            this.ErrorCode = errorCode;
            this.Message = message;
        }
    }
}
