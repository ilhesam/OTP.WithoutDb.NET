using System;
using System.Collections.Generic;
using System.Text;
using OTP.WithoutDb.NET.Models.Error;

namespace OTP.WithoutDb.NET.Models.ErrorDescribers
{
    public class OtpErrorDescriber
    {
        public virtual OtpError OtpIsInvalid() => new OtpError(nameof(OtpIsInvalid), "OTP is invalid");
        public virtual OtpError PasswordIsExpired() => new OtpError(nameof(PasswordIsExpired), "Password is expired");
    }
}
