using System;
using System.Collections.Generic;
using System.Text;

namespace LoopUp.Services
{
    public interface IPhoneNumberFormattingService
    {
        string FormatPhoneNumber(string unformattedPhoneNumber);
    }
}
