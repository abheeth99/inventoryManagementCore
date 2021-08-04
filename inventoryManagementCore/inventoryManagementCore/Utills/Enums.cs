using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace inventoryManagementCore.Utills
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum reorderLevel
    {
        low,
        medium,
        critical
    }
    public enum notificationAction
    {
        Added,
        Updated,
        Deleted
    }
}
