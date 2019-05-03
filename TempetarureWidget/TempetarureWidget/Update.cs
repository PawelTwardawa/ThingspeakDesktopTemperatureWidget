using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetAutoUpdate.Framework;
using DotNetAutoUpdate.Sources;

namespace TempetarureWidget
{
    class Update
    {
        private static UpdateManager _manager;

        public static void Start()
        {
            Thread thread = new Thread(new ThreadStart(() =>
           {
               _manager = UpdateManager.Instance;
               _manager.Source = new WebSource(new Uri("https://github.com/PawelTwardawa/ThingspeakDesktopTemperatureWidget/releases/download/AutoUpdate/UpdateInfo.json"));

               _manager.ExitApp += () => System.Environment.Exit(0);
               _manager.SuccessUpdated += (s) => MessageBox.Show(s);

               if (_manager.CheckForUpdate())
               {
                   if (MessageBox.Show("New update available. \r\n\r\n" +
                       _manager.UpdateDescription +
                       "\r\n\r\n" +
                       "Do you want update now?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                   {
                       _manager.PrepareUpdate();
                       _manager.ApplyUpdate();
                   }

               }

           }));

            thread.Start();
            
        }
        

    }
}
