using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public partial class enumErrorType : EnumBaseType<enumErrorType>
    {
        public readonly int StatusCode;
        public HttpStatusCode HttpStatus
        {
            get
            {
                return (HttpStatusCode)StatusCode;
            }
        }

        public enumErrorType(int key, string value, int statusCode = 401) : base(key, value)
        {
            this.StatusCode = statusCode;
        }

        public static ReadOnlyCollection<enumErrorType> GetValues()
        {
            return GetBaseValues();
        }

        public static enumErrorType GetByKey(int key)
        {
            return GetBaseByKey(key);
        }
    }


	
}
