using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.WithoutDb.NET.Settings
{
    public class OtpSettings
    {
        public OtpSettings(string issuer, string secretKey, int expirationInSeconds)
        {
            SetIssuer(issuer);
            SetSecretKey(secretKey);
            SetExpirationInSeconds(expirationInSeconds);
        }

        public OtpSettings(string issuer, string secretKey, int expirationInSeconds, IList<char> permittedLetters)
            : this(issuer, secretKey, expirationInSeconds)
        {
            SetPermittedLetters(permittedLetters);
        }

        public OtpSettings(string issuer, string secretKey, int expirationInSeconds, int length)
            : this(issuer, secretKey, expirationInSeconds)
        {
            SetLength(length);
        }

        public OtpSettings(string issuer, string secretKey, int expirationInSeconds, IList<char> permittedLetters,
            int length)
            : this(issuer, secretKey, expirationInSeconds, permittedLetters)
        {
            SetLength(length);
        }

        public string Issuer { get; private set; }
        public string SecretKey { get; private set; }
        public int ExpirationInSeconds { get; private set; }
        public int Length { get; private set; } = 5;

        public IList<char> PermittedLetters { get; private set; } = new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public void SetIssuer(string issuer)
        {
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }

        public void SetSecretKey(string secretKey)
        {
            SecretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
        }

        public void SetExpirationInSeconds(int expirationInSeconds)
        {
            if (expirationInSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(expirationInSeconds));
            }

            ExpirationInSeconds = expirationInSeconds;
        }

        public void SetPermittedLetters(IList<char> permittedLetters)
        {
            if (permittedLetters == null)
            {
                throw new ArgumentNullException(nameof(permittedLetters));
            }

            if (permittedLetters.Count <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(permittedLetters));
            }

            PermittedLetters = permittedLetters;
        }

        public void SetLength(int length)
        {
            if (length <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            Length = length;
        }
    }
}