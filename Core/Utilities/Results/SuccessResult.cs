using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //constructors
        public SuccessResult(string message) : base(true,message)//true ise mesajı döndür
        {

        }
        public SuccessResult() : base(true)//sadece success olduğunda döner
        {

        }
    }
}
