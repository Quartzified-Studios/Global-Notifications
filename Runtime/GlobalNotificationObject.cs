using UnityEngine;

namespace Quartzified.Notifications
{
    [CreateAssetMenu(menuName = "Quartzified/Notifications/Notification", fileName = "New Notification")]
    public class GlobalNotificationObject : ScriptableObject
    {
        [Tooltip("Notification Identifier\n[Set to a random string by default]\n\n iOS Specific")]
        public string id;

        [Tooltip("Notification Group Identifier")]
        public string groupName;

        [Space]

        [Tooltip("Notification Title")]
        public string title;

        [Tooltip("Notification Content Text")]
        public string text;

        [Space]

        [Tooltip("Time at which the notification should appear.\nTime untill it should fire in seconds\nDateTime.Now.AddSeconds(fireTime)")]
        public int fireTime;

        [Tooltip("Notification Repeat Interval (Set to allow the notification to repeat)\nTime untill notification should repeat\nTimeSpan(0,0, repeatInterval)")]
        public int repeatInterval;

        [Space]

        [Tooltip("Show time since notification appeared.")]
        public bool showTime;

        [Space]

        [Tooltip("Notification Icon Type Small Identifier [Default 'small']")]
        public string smallIcon = "small";

        [Tooltip("Notification Icon Type Large Identifier [Default ''large'']")]
        public string largeIcon = "large";

#if UNITY_EDITOR
        private void OnValidate()
        {
            fireTime = Mathf.Clamp(fireTime, 0, int.MaxValue);
            repeatInterval = Mathf.Clamp(repeatInterval, 0, int.MaxValue);
        }
#endif

    }

}

