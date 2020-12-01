using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.WithoutDb.NET.Models.Inputs
{
    public class ValidateOtpInput
    {
        public ValidateOtpInput(string key, string password, string generatedFor)
        {
            SetKey(key);
            SetPassword(password);
            SetGeneratedFor(generatedFor);
        }

        public string Key { get; private set; }
        public string Password { get; private set; }
        public string GeneratedFor { get; private set; }

        public void SetKey(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public void SetPassword(string password)
        {
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void SetGeneratedFor(string generatedFor)
        {
            GeneratedFor = generatedFor ?? throw new ArgumentNullException(nameof(generatedFor));
        }
    }
}
