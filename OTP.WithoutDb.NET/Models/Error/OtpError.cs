using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.WithoutDb.NET.Models.Error
{
    public class OtpError
    {
        public OtpError()
        {
        }

        public OtpError(string code, string description)
        {
            SetCode(code);
            SetDescription(description);
        }

        public string Code { get; private set; }
        public string Description { get; private set; }

        public void SetCode(string code)
        {
            Code = code;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
