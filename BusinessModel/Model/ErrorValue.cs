using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class ErrorValue
    {
        public enumErrorType ErrorText { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Parameters { get; set; }

        public ErrorValue(enumErrorType errorText, params string[] parameters)
        {
            ErrorText = errorText;
            Parameters = parameters?.ToList();
        }

        public ErrorValue(enumErrorType errorText)
        {
            ErrorText = errorText;
        }

        public ErrorValue(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
