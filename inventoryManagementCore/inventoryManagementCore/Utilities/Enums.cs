using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace inventoryManagementCore.Utilities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum reorderLevel
    {
        low,
        medium,
        critical
    }
}
