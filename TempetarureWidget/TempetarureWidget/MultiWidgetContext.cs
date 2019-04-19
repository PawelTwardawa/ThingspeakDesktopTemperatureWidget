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
        //private int openForms;
        private static int openForms;

        public MultiWidgetContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach(var form in forms)
            {
                //form.FormClosed += Close;
                form.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref openForms) == 0)
                        System.Environment.Exit(0);
                };

                form.Show();
            }
        }

        public static void AddForm(Form form)
        {
            Interlocked.Increment(ref openForms);

            form.FormClosed += (s, args) =>
            {
                if (Interlocked.Decrement(ref openForms) == 0)
                    System.Environment.Exit(0);
            };
        }
    }
}
