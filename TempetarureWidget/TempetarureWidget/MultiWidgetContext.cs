using System;
using System.Threading;
using System.Windows.Forms;

namespace TempetarureWidget
{
    class MultiWidgetContext : ApplicationContext
    {
        //private int openForms;
        private static int _openForms;

        public MultiWidgetContext(params Form[] forms)
        {
            _openForms = forms.Length;

            foreach(var form in forms)
            {
                //form.FormClosed += Close;
                form.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref _openForms) == 0)
                        Environment.Exit(0);
                };

                form.Show();
            }
        }

        public static void AddForm(Form form)
        {
            Interlocked.Increment(ref _openForms);

            form.FormClosed += (s, args) =>
            {
                if (Interlocked.Decrement(ref _openForms) == 0)
                    Environment.Exit(0);
            };
        }
    }
}
