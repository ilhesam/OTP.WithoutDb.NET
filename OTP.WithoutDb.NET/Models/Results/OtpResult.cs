using System;
using System.Collections.Generic;
using System.Text;
using OTP.WithoutDb.NET.Models.Error;

namespace OTP.WithoutDb.NET.Models.Results
{
    public class OtpResult
    {
        private OtpResult()
        {
        }

        private OtpResult(IList<OtpError> errors)
        {
            SetErrors(errors);
        }

        public bool IsSucceeded { get; private set; }
        public IList<OtpError> Errors { get; private set; } = new List<OtpError>();

        public static OtpResult Success() => new OtpResult { IsSucceeded = true };
        public static OtpResult Fail(IList<OtpError> errors) => new OtpResult(errors);

        private void SetErrors(IList<OtpError> errors)
        {
            Errors = errors;
        }
    }
}
