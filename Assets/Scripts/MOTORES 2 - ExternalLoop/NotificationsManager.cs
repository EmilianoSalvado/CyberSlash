using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Notifications.Android;
using UnityEngine.Playables;

public class NotificationsManager : MonoBehaviour
{
    public static NotificationsManager instance { get; private set; }

    AndroidNotificationChannel _energyNotif;
    AndroidNotificationChannel _reminderNotif;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        _energyNotif = new AndroidNotificationChannel()
        {
            Id = "energy_notif_channel",
            Name = "Energy Notifications",
            Description = "Tell the user when he gets energy points",
            Importance = Importance.High
        };

        _reminderNotif = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_channel",
            Name = "Reminder Notifications",
            Description = "Tell the user to come back to play",
            Importance = Importance.High
        };

        AndroidNotificationCenter.RegisterNotificationChannel(_energyNotif);
        AndroidNotificationCenter.RegisterNotificationChannel(_reminderNotif);

        DisplayNotification("What the f*** are you doing?!", "Come and play, let's kick some a**!!", DateTime.Now.AddDays(1));
    }

    public int DisplayNotification(string title, string text, DateTime fireTime)
    {
        var notif = new AndroidNotification();
        notif.Title = title;
        notif.Text = text;
        notif.SmallIcon = "icon_small";
        notif.LargeIcon = "icon_large";
        notif.FireTime = fireTime;

        return AndroidNotificationCenter.SendNotification(notif, _energyNotif.Id);
    }

    public void CancelNotification(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
}
