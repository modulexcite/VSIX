﻿using Bridge;
using Bridge.Html5;
using System;

namespace $safeprojectname$
{
    public class App
    {
        [Ready]
        public static void Main()
        {
            // Create a new Button
            var button = new ButtonElement
            {
                InnerHTML = "Submit",
                OnClick = (ev) =>
                {
                    // When Button is clicked, popup a message
                    Global.Alert("Success!");
                }
            };

            // Add the Button to the page
            Document.Body.AppendChild(button);

            // To confirm Bridge.NET is working: 
            // 1. Build this project (Ctrl + Shift + B)
            // 2. Browse to file /Bridge/www/demo.html
            // 3. Right-click on file and select "View in Browser" (Ctrl + Shift + W)
            // 4. File should open in a browser, click the "Submit" button
            // 5. Success!
        }
    }
}