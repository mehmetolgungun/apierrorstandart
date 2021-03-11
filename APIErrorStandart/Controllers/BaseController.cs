using Business.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIErrorStandart.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<T> ApiResult<T>(Result<T> result)
        {
            if (result.Status)
                return result.Value;

            ValidationProblemDetails error = new ValidationProblemDetails()
            {
                Type = result.ErrorResult.ErrorCode.ToString(),
                Status = result.ErrorResult.ErrorCode.StatusCode,
                Title = GetMessageTranslation(result.ErrorResult, "EN")
            };

            throw new HttpStatusCodeException(error);
        }

        private string GetMessageTranslation(Problem problem,string Language)
        {
            if (Translations.Any(x => x.Code == problem.ErrorCode.Value))
            {
                return Translations.FirstOrDefault(x => x.Code == problem.ErrorCode.Value && x.Language == Language).Text;
            }
            else
                return problem.ErrorCode.Value;
        }
        public class ProblemTranslation
        {
            public string Code { get; set; }
            public string Language { get; set; }
            public string Text { get; set; }
        }
        public List<ProblemTranslation> Translations = new List<ProblemTranslation>()
        {
            new ProblemTranslation() { Code= "InvalidParameter",Language="EN",Text="Invalid Parameter" },
            new ProblemTranslation() { Code= "InvalidParameter",Language="TR",Text="Hatalı Parametre" },
            new ProblemTranslation() { Code= "NotUnique",Language="EN",Text="Record already Exists" },
            new ProblemTranslation() { Code= "NotUnique",Language="TR",Text="Kayıt Zaten Mevcut" },
            new ProblemTranslation() { Code= "NotFound",Language="EN",Text="Record Not Found" },
            new ProblemTranslation() { Code= "NotFound",Language="TR",Text="Kayıt Bulunamadı" },
            new ProblemTranslation() { Code= "EmptyResult",Language="EN",Text="No Records Found" },
            new ProblemTranslation() { Code= "EmptyResult",Language="TR",Text="Hiç ayt Bulunamadı" },
            new ProblemTranslation() { Code= "ProcessError",Language="EN",Text="General Error" },
            new ProblemTranslation() { Code= "ProcessError",Language="TR",Text="Genel Hata" }

        };
    }
}
