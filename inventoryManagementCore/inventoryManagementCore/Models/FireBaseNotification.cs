using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Models
{
    public class FireBaseNotification
    {
        public string DeviceToken { get; set; } = "fVIjcaXeMRPQccXmeCmjSV:APA91bHCViSIZ-IqnaV9nhkEM2DjF9jkAl5Yg7je4mcBaSamPO2BUGVYtGfQbiZhx61Ci_DOOrd_L93-K-W-TUOb5X6QUY3gVxAr-ZK5sdh84-mJm0F8I4UDft8CQVRyGlfJl6lw2S6n";
        public string Title { get; set; }
        public string Body { get; set; }
        public Dictionary<string, string> Data { get; set; }

    }
}
