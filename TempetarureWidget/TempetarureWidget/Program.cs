using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempetarureWidget.SettingsApp;

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

            int openWidget = 0;

            SettingsManager settings = new SettingsManager();
            var s = settings.Load();
            List<WidgetForm> forms = new List<WidgetForm>();
            if (s.settings.Count > 0)
            {
                for (int i = 0; i < s.settings.Count; i++)
                {
                    if (s.settings[i] != null)
                    {
                        forms.Add(new WidgetForm(s.settings[i]));
                        openWidget++;
                    }
                }
                if (openWidget == 0)
                    forms.Add(new WidgetForm(new Settings()));
            }
            else
            {
                forms.Add(new WidgetForm(new Settings()));
            }

            WidgetNotifyIcon notifyIcon = new WidgetNotifyIcon(forms);
            notifyIcon.Icon = new Icon("icons/app.ico");
            notifyIcon.Text = "Temperature Widget";
            notifyIcon.Visible = true;

            Application.Run(new MultiWidgetContext( forms.ToArray()));
        }
    }
}
