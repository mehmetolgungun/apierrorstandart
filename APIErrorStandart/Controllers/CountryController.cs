using Business.Location;
using Business.Model.Location;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIErrorStandart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : BaseController
    {
        [HttpGet]
        public ActionResult<List<Country>> GetCountry(string code)
        {
            return ApiResult(CountryBusiness.GetCountry(code));
        }

        [HttpPost]
        public ActionResult<bool> NewCountry(Country country)
        {
            return ApiResult(CountryBusiness.NewCountry(country));
        }
    }
}
