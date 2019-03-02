using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempetarureWidget
{
    class MultiWidgetContext : ApplicationContext
    {
        private int openForms;

        public MultiWidgetContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach(var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref openForms) == 0)
                        //ExitThread();
                        System.Environment.Exit(0);
                };

                form.Show();
                //new Thread(() => form.Show()).Start();
                //new Thread(new ThreadStart(() => form.Show())).Start();
            }
        }
    }
}
