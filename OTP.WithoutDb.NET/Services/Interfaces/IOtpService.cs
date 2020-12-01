using System;
using System.Collections.Generic;
using System.Text;
using OTP.WithoutDb.NET.Models.Inputs;
using OTP.WithoutDb.NET.Models.Results;

namespace OTP.WithoutDb.NET.Services.Interfaces
{
    public interface IOtpService
    {
        GenerateOtpResult GenerateOtp(GenerateOtpInput input);
        OtpResult VerifyOtp(ValidateOtpInput input);
    }
}
