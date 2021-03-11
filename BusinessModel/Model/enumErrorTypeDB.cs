using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
	public partial class enumErrorType
	{
		public static readonly enumErrorType InvalidParameter = new enumErrorType(1, "InvalidParameter", 400);
		public static readonly enumErrorType NotUnique = new enumErrorType(4, "NotUnique", 420);
		public static readonly enumErrorType NotFound = new enumErrorType(5, "NotFound", 404);
		public static readonly enumErrorType InvalidRequest = new enumErrorType(25, "InvalidRequest", 400);
		public static readonly enumErrorType EmptyResult = new enumErrorType(26, "EmptyResult", 404);
		public static readonly enumErrorType ProcessError = new enumErrorType(27, "ProcessError", 420);

	}
}
