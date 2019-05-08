using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TempetarureWidget.SettingsApp;
using TempetarureWidget.forms;

namespace TempetarureWidget
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Update.Start();

            int openWidget = 0;

            SettingsManager settings = new SettingsManager();
            var appSettings = settings.Load();
            List<WidgetForm> forms = new List<WidgetForm>();
            if (appSettings.settings.Count > 0)
            {
                for (int i = 0; i < appSettings.settings.Count; i++)
                {
                    if (appSettings.settings[i] != null)
                    {
                        //forms.Add(new WidgetForm(s.settings[i]));
                        forms.Add(new WidgetForm(ref appSettings, appSettings.settings[i]));
                        openWidget++;
                    }
                }
                if (openWidget == 0)
                    forms.Add(new WidgetForm(ref appSettings, new Settings()));
                //forms.Add(new WidgetForm(new Settings()));
            }
            else
            {
                forms.Add(new WidgetForm(ref appSettings, new Settings()));
                //forms.Add(new WidgetForm(new Settings()));
            }

            WidgetNotifyIcon notifyIcon = new WidgetNotifyIcon(forms, ref appSettings);
            notifyIcon.Icon = new Icon("icons/app.ico");
            notifyIcon.Text = "Temperature Widget";
            notifyIcon.Visible = true;

            //notifyIcon.ShowBalloonTip(1, "tytul", "1\n 2 \n 3\n 4\n 5", ToolTipIcon.Warning);

            Application.Run(new MultiWidgetContext( forms.ToArray()));
        }
    }
}
