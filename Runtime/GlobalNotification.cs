using System;

namespace Quartzified.Notifications
{
    [Serializable]
    public class GlobalNotification
    {
        /// <summary> 
        /// Notification Identifier 
        /// [Set to a random string by default]
        /// </summary>
        public string id;

        /// <summary>
        /// Notification Group Identifier 
        /// </summary>
        public string groupName;

        /// <summary>
        /// Notification Title
        /// </summary>
        public string title;

        /// <summary>
        /// Notification Content Text
        /// </summary>
        public string text;

        /// <summary>
        /// Time at which the notification should appear.
        /// </summary>
        public DateTime fireTime;

        /// <summary>
        /// Notification Repeat Interval (Set to allow the notification to repeat)
        /// </summary>
        public TimeSpan repeatInterval;

        /// <summary>
        /// Show time since notification appeared.
        /// </summary>
        public bool showTime;

        /// <summary>
        /// Notification Icon Type Small Identifier [Default "small"]
        /// </summary>
        public string smallIcon = "small";

        /// <summary>
        /// Notification Icon Type Large Identifier [Default "large"]
        /// </summary>
        public string largeIcon = "large";

        public GlobalNotification() { }
        public GlobalNotification(GlobalNotificationObject notificationObject)
        {
            id = notificationObject.id;
            groupName = notificationObject.groupName;

            title = notificationObject.title;
            text = notificationObject.text;

            fireTime = DateTime.Now.AddSeconds(notificationObject.fireTime);

            if(notificationObject.repeatInterval > 0)
                repeatInterval = new TimeSpan(0, 0, notificationObject.repeatInterval);

            showTime = notificationObject.showTime;

            smallIcon = notificationObject.smallIcon;
            largeIcon = notificationObject.largeIcon;
        }
        public GlobalNotification(string _title, string _text, DateTime _fireTime, bool _showTime = false, string _smallIcon = "small", string _largeIcon = "large")
        {
            title = _title;
            text = _text;
            fireTime = _fireTime;
            showTime = _showTime;
            smallIcon = _smallIcon;
            largeIcon = _largeIcon;
        }
        public GlobalNotification(string _title, string _text, DateTime _fireTime, TimeSpan _repeatInterval, bool _showTime = false, string _smallIcon = "small", string _largeIcon = "large")
        {
            title = _title;
            text = _text;
            fireTime = _fireTime;
            repeatInterval = _repeatInterval;
            showTime = _showTime;
            smallIcon = _smallIcon;
            largeIcon = _largeIcon;
        }
        public GlobalNotification(string _groupName, string _title, string _text, DateTime _fireTime, bool _showTime = false, string _smallIcon = "small", string _largeIcon = "large")
        {
            groupName = _groupName;
            title = _title;
            text = _text;
            fireTime = _fireTime;
            showTime = _showTime;
            smallIcon = _smallIcon;
            largeIcon = _largeIcon;
        }
        public GlobalNotification(string _id, string _groupName, string _title, string _text, DateTime _fireTime, bool _showTime = false, string _smallIcon = "small", string _largeIcon = "large")
        {
            id = _id;
            groupName = _groupName;
            title = _title;
            text = _text;
            fireTime = _fireTime;
            showTime = _showTime;
            smallIcon = _smallIcon;
            largeIcon = _largeIcon;
        }
    }

}

