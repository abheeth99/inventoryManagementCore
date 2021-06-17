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

        public MessagingClient()
        {
            MobileMessagingClient();
        }

        private void MobileMessagingClient()
        {
            var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("key.json") });
            _messaging = FirebaseMessaging.GetMessaging(app);
        }

        private Message CreateNotification(FireBaseNotification notification)
        {
            var inventoryLog = new Dictionary<string, string>();
            inventoryLog = notification.Data;

            return new Message()
            {
                Token = notification.DeviceToken,
                Data = inventoryLog,
                Notification = new Notification()
                {
                    Body = notification.Body,
                    Title = notification.Title
                },

            };
        }

        public async Task SendNotification(FireBaseNotification notification)
        {
            var result = await _messaging.SendAsync(CreateNotification(notification));

        }
    }
}
