using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
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

        private Message CreateNotification(string title, string notificationBody, string token)
        {
            return new Message()
            {
                Token = token,
                Notification = new Notification()
                {
                    Body = notificationBody,
                    Title = title
                }
            };
        }

        public async Task SendNotification(string token, string title, string body)
        {
            MobileMessagingClient();
            var result = await _messaging.SendAsync(CreateNotification(title, body, token));

        }
    }
}
