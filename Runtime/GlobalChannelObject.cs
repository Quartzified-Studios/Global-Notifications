using UnityEngine;

namespace Quartzified.Notifications
{
    [CreateAssetMenu(menuName = "Quartzified/Notifications/Channel", fileName = "New Channel")]
    public class GlobalChannelObject : ScriptableObject
    {
        public string id = "default";

        [Space]
        public string channelName = "Default Reminders";
        public string description = "Default Notification Channel";

        [Space]
        public int importance = 3;
    }
}