using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using inventoryManagementCore.Models;
using inventoryManagementCore.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inventoryManagementCore.Services.Firebase
{
    public class MessagingClient : IMessagingClient
    {
        private FirebaseMessaging _messaging;
        private readonly IUtilities _utilities;
        private FirebaseApp firebaseApp;

        public MessagingClient(IUtilities utilities)
        {
            _utilities = utilities;
        }

        private void MobileMessagingClient()
        {
            firebaseApp = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("key.json") });
            _messaging = FirebaseMessaging.GetMessaging(firebaseApp);
        }

        private Message CreateNotification(FireBaseNotification notification)
        {

            return new Message()
            {
                Token = notification.DeviceToken,
                Data = notification.Data,
                Notification = new Notification()
                {
                    Body = notification.Body,
                    Title = notification.Title
                },

            };
        }

        public async Task SendNotification(FireBaseNotification notification)
        {
            var token = _utilities.GetToken("Token");
            notification.DeviceToken = await token;

            if (notification.DeviceToken != "")
            {
                MobileMessagingClient();
                var result = await _messaging.SendAsync(CreateNotification(notification));

                firebaseApp.Delete();
            }
        }
    }
}
