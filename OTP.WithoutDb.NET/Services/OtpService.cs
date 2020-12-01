using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OTP.WithoutDb.NET.Helpers;
using OTP.WithoutDb.NET.Models;
using OTP.WithoutDb.NET.Models.Error;
using OTP.WithoutDb.NET.Models.ErrorDescribers;
using OTP.WithoutDb.NET.Models.Inputs;
using OTP.WithoutDb.NET.Models.Results;
using OTP.WithoutDb.NET.Services.Interfaces;
using OTP.WithoutDb.NET.Settings;

namespace OTP.WithoutDb.NET.Services
{
    public class OtpService : IOtpService
    {
        protected readonly OtpSettings Settings;
        protected readonly OtpErrorDescriber ErrorDescriber;

        public OtpService(OtpSettings settings, OtpErrorDescriber errorDescriber)
        {
            Settings = settings;
            ErrorDescriber = errorDescriber;
        }

        public GenerateOtpResult GenerateOtp(GenerateOtpInput input)
        {
            var expireDateTime = DateTime.Now.AddSeconds(Settings.ExpirationInSeconds);
            var password = RandomCodeGenerator.GenerateRandomCode(Settings.Length, Settings.PermittedLetters);

            var otpJsonObj = CreateOtpJsonObject(input, password, expireDateTime);

            var serializedOtpJsonObj = SerializeOtpJsonObject(otpJsonObj);
            var encryptedOtpJsonObj = EncryptOtpJsonObject(serializedOtpJsonObj);

            return new GenerateOtpResult(encryptedOtpJsonObj, expireDateTime);
        }

        public OtpResult VerifyOtp(ValidateOtpInput input)
        {
            var decryptedOtpJsonObj = DecryptOtpJsonObject(input.Key);

            if (decryptedOtpJsonObj == null)
            {
                var errors = new List<OtpError> { ErrorDescriber.OtpIsInvalid() };
                return OtpResult.Fail(errors);
            }

            var otpJsonObject = DeserializeOtpJsonObject(decryptedOtpJsonObj);

            if (otpJsonObject == null || !otpJsonObject.IsValid())
            {
                var errors = new List<OtpError> { ErrorDescriber.OtpIsInvalid() };
                return OtpResult.Fail(errors);
            }

            if (otpJsonObject.Issuer != Settings.Issuer)
            {
                var errors = new List<OtpError> { ErrorDescriber.OtpIsInvalid() };
                return OtpResult.Fail(errors);
            }

            if (otpJsonObject.GeneratedFor != input.GeneratedFor)
            {
                var errors = new List<OtpError> { ErrorDescriber.OtpIsInvalid() };
                return OtpResult.Fail(errors);
            }

            if (otpJsonObject.Password != input.Password)
            {
                var errors = new List<OtpError> { ErrorDescriber.OtpIsInvalid() };
                return OtpResult.Fail(errors);
            }

            if (otpJsonObject.IsExpired())
            {
                var errors = new List<OtpError> { ErrorDescriber.PasswordIsExpired() };
                return OtpResult.Fail(errors);
            }

            return OtpResult.Success();
        }

        protected OtpJsonObject CreateOtpJsonObject(GenerateOtpInput input, string password, DateTime expireDateTime)
            => new OtpJsonObject(Settings.Issuer, input.GeneratesFor, password, expireDateTime);

        protected string SerializeOtpJsonObject(OtpJsonObject otpJsonObject)
            => JsonConvert.SerializeObject(otpJsonObject);

        protected OtpJsonObject DeserializeOtpJsonObject(string serializedOtpJsonObj)
            => JsonConvert.DeserializeObject<OtpJsonObject>(serializedOtpJsonObj);

        protected string EncryptOtpJsonObject(string serializedOtpJsonObj)
            => AesCryptography.EncryptText(serializedOtpJsonObj, Settings.SecretKey);

        protected string DecryptOtpJsonObject(string encryptedOtpJsonObj)
            => AesCryptography.DecryptText(encryptedOtpJsonObj, Settings.SecretKey);
    }
}