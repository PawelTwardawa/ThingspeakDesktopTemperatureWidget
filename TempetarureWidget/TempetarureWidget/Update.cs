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
               _manager.Source = new WebSource(new Uri("http://localhost/UpdateInfo.json"));

               _manager.ExitApp += () => System.Environment.Exit(0);

               if (_manager.CheckForUpdate())
               {
                   if (MessageBox.Show("New update available. Do you want update now?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
