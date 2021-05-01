using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //constructors
        public ErrorResult(string message) : base(false, message)//true ise mesajı döndür
        {

        }
        public ErrorResult() : base(false)//sadece success döndür
        {

        }
    }
}
