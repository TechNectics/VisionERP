using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
//using Microsoft.Extensions.Configuration.Json;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Services.Constants
{
    public class ApplicationConstants
    {
        public static readonly DateTime CurrentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        
    }
}
