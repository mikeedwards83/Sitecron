﻿using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecron.SitecronSettings;
using System;
using Sitecore.Data.Events;

namespace Sitecron.Events
{
    public class SitecronSavedHandler
    {
        public void OnItemSaved(object sender, EventArgs args)
        {
            Item savedItem = null;
            ItemSavedRemoteEventArgs remoteArgs = args as ItemSavedRemoteEventArgs;
            
            if (remoteArgs != null)
            {
                savedItem = remoteArgs.Item;
            }
            else
            {
                savedItem = Event.ExtractParameter(args, 0) as Item;
            }

            if (savedItem != null && SitecronConstants.Templates.SitecronJobTemplateID == savedItem.TemplateID) //matched Sitecron job template
            {
                    ScheduleHelper scheduler = new ScheduleHelper();
                    scheduler.InitializeScheduler();
            }
        }

    }
}