using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakeUpStoreApplication.Common.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Brands
    {
        maybelline,
        annabelle,
        suncoat,
        nyx,
        clinique,
        dior


    }
}
