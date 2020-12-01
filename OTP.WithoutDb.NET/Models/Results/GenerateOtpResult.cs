using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.WithoutDb.NET.Models.Results
{
    public class GenerateOtpResult
    {
        public GenerateOtpResult(string key, DateTime expiresAt)
        {
            SetKey(key);
            SetExpiresAt(expiresAt);
        }

        public string Key { get; set; }
        public DateTime ExpiresAt { get; set; }

        private void SetKey(string key)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        private void SetExpiresAt(DateTime expiresAt)
        {
            ExpiresAt = expiresAt;
        }
    }
}
