using Business.Model;
using Business.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location

{
    public class CountryBusiness
    {
        public static Result<List<Model.Location.Country>> GetCountry(string code)
        {
            Result<List<Model.Location.Country>> result;

            try
            {
                if (!string.IsNullOrWhiteSpace(code))
                {
                    if (SampleData.CountryList.Any(x=>x.Code==code))
                    {
                        result= SampleData.CountryList.Where(x => x.Code == code).ToList();
                    }
                    else
                    {
                        result = new Problem(enumErrorType.NotFound,"Parameter:"+code);
                    }
                }
                else
                {
                    if (SampleData.CountryList.Count==0)
                    {
                        result = new Problem(enumErrorType.EmptyResult);
                    }
                    else
                    {
                        result = SampleData.CountryList;
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                result = new Problem(enumErrorType.ProcessError,ex);
            }

            return result;
        }
        public static Result<bool> NewCountry(Country country)
        {
            Result<bool> result;

            try
            {
                if (string.IsNullOrWhiteSpace(country.Code))
                {
                    result = new Problem(enumErrorType.InvalidParameter,"Parameter Name : Code","Value can not be empty");
                }
                else if (string.IsNullOrWhiteSpace(country.Name))
                {
                    result = new Problem(enumErrorType.InvalidParameter, "Parameter Name : Name", "Value can not be empty");
                }
                else
                {
                    if (SampleData.CountryList.Any(x => x.Code == country.Code))
                    {
                        result = new Problem(enumErrorType.NotUnique, "Existing Country : " + SampleData.CountryList.FirstOrDefault(x => x.Code == country.Code).Name);
                    }
                    else
                    {
                        SampleData.CountryList.Add(new Model.Location.Country() { Code = country.Code, Name = country.Name });
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = new Problem(enumErrorType.ProcessError, ex);
            }

            return result;
        }
    }
}
