using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.SimpleAndroidNotifications
{

    public class NotifScript : MonoBehaviour
    {


        public void SendNotif()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(10), "PhonM", "An intruder is partying hard in your phone, you should check what is going on", Color.cyan, NotificationIcon.Star);
        }


        void Update()
        {



        }

    }
}
