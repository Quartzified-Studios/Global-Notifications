using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

#if UNITY_IOS
using Unity.Notifications.iOS;
#endif


namespace Quartzified.Notifications
{
    public class NotificationHandler
    {
        public static void ScheduleNotification(GlobalNotification notification, string channelID = "default")
        {
            string title = notification.title;
            if (string.IsNullOrEmpty(title))
            {
                title = Application.productName;
            }

            if (string.IsNullOrEmpty(notification.text))
            {
                Debug.LogWarning("[Notifications] Tried scheduling a notification without text!\nSchedule was canceled.");
                return;
            }

            if (notification.fireTime < DateTime.Now)
            {
                Debug.LogWarning("[Notifications] Tried scheduling a notification in the past!\nSchedule was canceled.");
                return;
            }


#if UNITY_ANDROID
            var androidNotification = new AndroidNotification();

            if(!string.IsNullOrEmpty(notification.groupName))
                androidNotification.Group = notification.groupName;

            androidNotification.Title = title;
            androidNotification.Text = notification.text;

            if(!string.IsNullOrEmpty(notification.smallIcon))
                androidNotification.SmallIcon = notification.smallIcon;

            if (!string.IsNullOrEmpty(notification.largeIcon))
                androidNotification.LargeIcon = notification.largeIcon;

            if (notification.repeatInterval.TotalSeconds > 0)
                androidNotification.RepeatInterval = notification.repeatInterval;

            androidNotification.ShowTimestamp = notification.showTime;


            AndroidNotificationCenter.SendNotification(androidNotification, channelID);
#endif

#if UNITY_IOS
            var iOSNotification = new iOSNotification();

            if (!string.IsNullOrEmpty(notification.id))
                iOSNotification.Identifier = notification.id;

            if (!string.IsNullOrEmpty(notification.groupName))
                iOSNotification.ThreadIdentifier = notification.groupName;

            iOSNotification.Title = title;
            iOSNotification.Body = notification.text;

            var timeTrigger = new iOSNotificationTimeIntervalTrigger();
            if(notification.repeatInterval.TotalSeconds > 0)
            {
                timeTrigger.TimeInterval = notification.repeatInterval;
                timeTrigger.Repeats = true;
            }
            else
            {
                timeTrigger.TimeInterval = new TimeSpan(0, 0, (int)(notification.fireTime - DateTime.Now).TotalSeconds);
                timeTrigger.Repeats = false;
            }

            iOSNotification.Trigger = timeTrigger;

            iOSNotificationCenter.ScheduleNotification(iOSNotification);
#endif
        }

        public static void ScheduleNotifications(List<GlobalNotification> notifications, string channelID = "default")
        {
            foreach(var notification in notifications)
            {
                ScheduleNotification(notification, channelID);
            }
        }

        /// <summary>
        /// Use this method to register android specific notification channels
        /// </summary>
        /// <param name="_id">Channel Identifier</param>
        /// <param name="_name">Channel Name</param>
        /// <param name="_description">Channel Description</param>
        /// <param name="_importance">Channel Importance [None = 1, Low = 2, Default = 3, High = 4]</param>
        public static void RegisterAndroidChannel(string _id, string _name, string _description, int _importance = 3)
        {
#if UNITY_ANDROID
            var channel = new AndroidNotificationChannel()
            {
                Id = _id,
                Name = _name,
                Importance = (Importance)_importance,
                Description = _description,
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);
#endif
        }

        /// <summary>
        /// Use this method to request permission to send/recieve notifications on iOS.
        /// </summary>
        /// <returns></returns>
        public static IEnumerator RequestIOSAuthorization()
        {
#if UNITY_IOS
            var authorizationOption = AuthorizationOption.Alert | AuthorizationOption.Badge;
            using (var req = new AuthorizationRequest(authorizationOption, true))
            {
                while (!req.IsFinished)
                {
                    yield return null;
                };

                string res = "\n RequestAuthorization:";
                res += "\n finished: " + req.IsFinished;
                res += "\n granted :  " + req.Granted;
                res += "\n error:  " + req.Error;
                res += "\n deviceToken:  " + req.DeviceToken;
                Debug.Log(res);
            }
#endif
            yield return null;
        }
    }
}

