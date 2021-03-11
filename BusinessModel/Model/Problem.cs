using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class Problem
    {
        public enumErrorType ErrorCode { get; set; }
        public Exception Exception { get; set; }

        public readonly Dictionary<string, List<ErrorValue>> ErrorDetails = new Dictionary<string, List<ErrorValue>>();

        public string[] Parameters { get; set; }

        public Problem()
        { }

        public Problem(enumErrorType errorCode)
        {
            ErrorCode = errorCode;
        }

        public Problem(enumErrorType errorCode, Exception exception)
        {
            ErrorCode = errorCode;
            Exception = exception;
        }

        public Problem(enumErrorType errorCode, params string[] parameters)
        {
            ErrorCode = errorCode;
            Parameters = parameters;
        }

        public Problem(enumErrorType errorCode, Exception exception, params string[] parameters)
        {
            ErrorCode = errorCode;
            Exception = exception;
            Parameters = parameters;
        }

        public Problem AddErrorDetail(string key, params string[] detail)
        {
            ErrorDetails.Add(key, detail?.Select(x => new ErrorValue(x)).ToList());
            return this;
        }

        public Problem AddErrorDetail(string key, params ErrorValue[] detail)
        {
            ErrorDetails.Add(key, detail?.ToList());
            return this;
        }

        public Problem AddParameters(params string[] parameters)
        {
            Parameters = parameters;
            return this;
        }
    }
}
