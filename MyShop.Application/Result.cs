using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        private Result(bool Issuccess,String errormessage)
        {
            IsSuccess = Issuccess;
            ErrorMessage = errormessage;    
        }
        public static Result Success() => new Result(true, string.Empty);
        public static Result Failure(string errormessage)=>new Result(false, string.Empty);
       
    }
}
