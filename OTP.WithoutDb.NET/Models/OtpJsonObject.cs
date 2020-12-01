using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.WithoutDb.NET.Models
{
    public class OtpJsonObject
    {
        public OtpJsonObject(string issuer, string generatedFor, string password, DateTime expiresAt)
        {
            UniqueIdentifier = Guid.NewGuid().ToString();
            SetIssuer(issuer);
            SetGeneratedFor(generatedFor);
            SetPassword(password);
            SetExpiresAt(expiresAt);
        }

        public string Issuer { get; private set; }
        public string UniqueIdentifier { get; }
        public string GeneratedFor { get; private set; }
        public string Password { get; private set; }
        public DateTime ExpiresAt { get; private set; }

        public void SetGeneratedFor(string generatedFor)
        {
            GeneratedFor = generatedFor ?? throw new ArgumentNullException(nameof(generatedFor));
        }

        public void SetPassword(string password)
        {
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void SetExpiresAt(DateTime expiresAt)
        {
            ExpiresAt = expiresAt;
        }

        public void SetIssuer(string issuer)
        {
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }

        public bool IsValid() => Issuer != null && UniqueIdentifier != null && GeneratedFor != null && Password != null;

        public bool IsExpired() => ExpiresAt.CompareTo(DateTime.Now) == -1;
    }
}