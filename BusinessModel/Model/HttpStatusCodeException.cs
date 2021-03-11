using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class HttpStatusCodeException :
        Exception
    {
        public ValidationProblemDetails ResponseModel = new ValidationProblemDetails();

        public void AddDetail(string error, params string[] details)
        {
            ResponseModel.Errors.Add(error, details);
        }
        public HttpStatusCodeException(ValidationProblemDetails problem) : base(problem.Title)
        {
            ResponseModel = problem;
        }
        public HttpStatusCodeException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.ResponseModel.Title = message;
            this.ResponseModel.Status = (int)statusCode;
        }

        public HttpStatusCodeException(HttpStatusCode statusCode, Exception message) : base(message.Message, message)
        {
            this.ResponseModel.Title = message.Message;
            this.ResponseModel.Status = (int)statusCode;
        }


        public HttpContent GetMessageContent()
        {
            return new StringContent(JsonConvert.SerializeObject(ResponseModel), System.Text.Encoding.UTF8, "application/json");
        }

        public HttpResponseMessage GetMessage()
        {
            HttpResponseMessage m = new HttpResponseMessage();
            m.StatusCode = (HttpStatusCode)this.ResponseModel.Status;
            m.Content = new StringContent(JsonConvert.SerializeObject(ResponseModel), System.Text.Encoding.UTF8, "application/json");
            return m;
        }

    }
}
