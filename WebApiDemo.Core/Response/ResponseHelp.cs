using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Core.Response
{
    public class ResponseHelp
    {
        public static JsonResponse<T> Success<T>(T data)
        {
            return new JsonResponse<T>(data);
        }

        public static EmptyResponse Success()
        {
            return new EmptyResponse();
        }

        public static EmptyResponse Success(string message)
        {
            return new EmptyResponse(message);
        }

        public static JsonResponse<T> Error<T>(string message)
        {
            return new JsonResponse<T>(false, message);
        }

        public static JsonResponse<T> Error<T>(string errorCode, string message)
        {
            return new JsonResponse<T>(errorCode, message);
        }

        public static EmptyResponse ErrorEmpty(string message)
        {
            return new EmptyResponse(false, message);
        }
    }
}
