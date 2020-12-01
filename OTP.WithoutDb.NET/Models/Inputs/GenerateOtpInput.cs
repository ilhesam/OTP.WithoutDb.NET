using System;
using System.Collections.Generic;
using System.Text;

namespace OTP.WithoutDb.NET.Models.Inputs
{
    public class GenerateOtpInput
    {
        public GenerateOtpInput(string generatesFor)
        {
            SetGeneratesFor(generatesFor);
        }
        
        public string GeneratesFor { get; private set; }

        public void SetGeneratesFor(string generatesFor)
        {
            GeneratesFor = generatesFor ?? throw new ArgumentNullException(nameof(generatesFor));
        }
    }
}
