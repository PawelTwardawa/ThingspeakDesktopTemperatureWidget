using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public class WidgetNotifyIcon
    {
        private List<WidgetForm> _forms;
        private NotifyIcon _notifyIcon;

        public Icon Icon
        {
            get
            {
                return _notifyIcon.Icon;
            }
            set
            {
                _notifyIcon.Icon = value;
            }
        }
        public string Text
        {
            get
            {
                return _notifyIcon.Text;
            }
            set
            {
                _notifyIcon.Text = value;
            }
        }
        public bool Visible {
            get
            {
                return _notifyIcon.Visible;
            }
            set
            {
                _notifyIcon.Visible = value;
            }
        }


        public WidgetNotifyIcon(List<WidgetForm> forms)
        {
            _notifyIcon = new NotifyIcon();
            _forms = forms;

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            for (int i = 0; i < forms.Count; i++)
            {
                //WidgetToolStripMenuItem exitWidgetMenuItem = new WidgetToolStripMenuItem();
                //exitWidgetMenuItem.Text = "Exit";
                //exitWidgetMenuItem.WidgetForm = forms[i];
                //exitWidgetMenuItem.Click += (sender, e) =>
                //{

                //    ((WidgetToolStripMenuItem)sender).WidgetForm.ExitWidget();
                //};


                //WidgetToolStripMenuItem settingWidgetMenuItem = new WidgetToolStripMenuItem();
                //settingWidgetMenuItem.Text = "Settings";
                //settingWidgetMenuItem.WidgetForm = forms[i];
                //settingWidgetMenuItem.Click += (sender, e) =>
                //{

                //    ((WidgetToolStripMenuItem)sender).WidgetForm.ShowSettings();
                //};

                //WidgetToolStripMenuItem widgetToolStripMenuItem = new WidgetToolStripMenuItem();
                //widgetToolStripMenuItem.Text = forms[i].Name;             
                //widgetToolStripMenuItem.DropDown.Items.AddRange(new WidgetToolStripMenuItem[] { exitWidgetMenuItem, settingWidgetMenuItem });

                //forms[i].UpdateToolStripMenuItemText += (name) => widgetToolStripMenuItem.Text = name;

                //contextMenu.Items.Add(widgetToolStripMenuItem);
                contextMenu.Items.Add(addWidget(forms[i]));

                
                
            }

            ToolStripMenuItem AddWidgetToolStripMenuItem = new ToolStripMenuItem();
            AddWidgetToolStripMenuItem.Text = "Add Widget";
            AddWidgetToolStripMenuItem.Click += (sender, e) =>
            {
                WidgetForm form = new WidgetForm(new Settings());
                contextMenu.Items.Insert(0, addWidget(form));
                form.Show();
            };
            contextMenu.Items.Add(AddWidgetToolStripMenuItem);


            ToolStripMenuItem exitToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += (sender, e) =>
            {
                System.Environment.Exit(0);
            };
            contextMenu.Items.Add(exitToolStripMenuItem);

            _notifyIcon.ContextMenuStrip = contextMenu;
            //NotifyIcon notifyIcon1 = new NotifyIcon();
            //ContextMenu contextMenu1 = new ContextMenu();
            //MenuItem menuItem1 = new MenuItem();
            //contextMenu1.MenuItems.AddRange(new MenuItem[] { menuItem1 });
            //menuItem1.Index = 0;
            //menuItem1.Text = "ddddd";
            //notifyIcon1.ContextMenu = contextMenu1;
        }

        private WidgetToolStripMenuItem addWidget(WidgetForm form)
        {
            WidgetToolStripMenuItem exitWidgetMenuItem = new WidgetToolStripMenuItem();
            exitWidgetMenuItem.Text = "Exit";
            exitWidgetMenuItem.WidgetForm = form;
            exitWidgetMenuItem.Click += (sender, e) =>
            {

                ((WidgetToolStripMenuItem)sender).WidgetForm.ExitWidget();
            };


            WidgetToolStripMenuItem settingWidgetMenuItem = new WidgetToolStripMenuItem();
            settingWidgetMenuItem.Text = "Settings";
            settingWidgetMenuItem.WidgetForm = form;
            settingWidgetMenuItem.Click += (sender, e) =>
            {

                ((WidgetToolStripMenuItem)sender).WidgetForm.ShowSettings();
            };

            WidgetToolStripMenuItem widgetToolStripMenuItem = new WidgetToolStripMenuItem();
            widgetToolStripMenuItem.Text = form.Name;
            widgetToolStripMenuItem.DropDown.Items.AddRange(new WidgetToolStripMenuItem[] { exitWidgetMenuItem, settingWidgetMenuItem });

            form.UpdateToolStripMenuItemText += (name) => widgetToolStripMenuItem.Text = name;
            //form.RemoveToolStripMenuItem += () => RemoveMenuItem(widgetToolStripMenuItem);
            form.RemoveToolStripMenuItem += () =>
            {
                _notifyIcon.ContextMenuStrip.Items.Remove(widgetToolStripMenuItem);
            };

            return widgetToolStripMenuItem;
        }

        //private void RemoveMenuItem(WidgetToolStripMenuItem widgetToolStripMenuItem)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
