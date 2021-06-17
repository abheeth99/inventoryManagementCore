using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using inventoryManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.Firebase
{
    public class MessagingClient : IMessagingClient
    {
        private FirebaseMessaging _messaging;

        private void MobileMessagingClient()
        {
            var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("key.json") });
            _messaging = FirebaseMessaging.GetMessaging(app);
        }

        private Message CreateNotification(FireBaseNotification notification)
        {

            return new Message()
            {
                Token = notification.DeviceToken,
                Data = new Dictionary<string, string>()
                {
                    {"Id", "01"}
                },
                Notification = new Notification()
                {
                    Body = notification.Body,
                    Title = notification.Title
                },

            };
        }

        public async Task SendNotification(FireBaseNotification notification)
        {
            MobileMessagingClient();
            var result = await _messaging.SendAsync(CreateNotification(notification));

        }
    }
}
