using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TempetarureWidget.forms;
using TempetarureWidget.SettingsApp;

namespace TempetarureWidget
{
    public class WidgetNotifyIcon
    {
        private NotifyIcon _notifyIcon;
        private AppSettings _appSettings;

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

        public WidgetNotifyIcon(List<WidgetForm> forms, ref AppSettings appSettings) : this(forms)
        {
            _appSettings = appSettings;
        }

        public WidgetNotifyIcon(List<WidgetForm> forms)
        {
            _notifyIcon = new NotifyIcon();

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            for (int i = 0; i < forms.Count; i++)
            {
                contextMenu.Items.Add(AddWidget(forms[i])); 
            }

            ToolStripMenuItem addWidgetToolStripMenuItem = new ToolStripMenuItem();
            addWidgetToolStripMenuItem.Text = @"Add Widget";
            addWidgetToolStripMenuItem.Click += (sender, e) =>
            {
                //MultiWidgetContext.AddForms();
                //WidgetForm form = new WidgetForm(new Settings());
                WidgetForm form = new WidgetForm(ref _appSettings, new Settings());
                MultiWidgetContext.AddForm(form);
                contextMenu.Items.Insert(0, AddWidget(form));
                form.Show();
            };
            contextMenu.Items.Add(addWidgetToolStripMenuItem);


            ToolStripMenuItem exitToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem.Text = @"Exit";
            exitToolStripMenuItem.Click += (sender, e) =>
            {
                System.Environment.Exit(0);
            };
            contextMenu.Items.Add(exitToolStripMenuItem);

            _notifyIcon.ContextMenuStrip = contextMenu;
        }

        private WidgetToolStripMenuItem AddWidget(IWidgetForm form)
        {
            WidgetToolStripMenuItem exitWidgetMenuItem = new WidgetToolStripMenuItem();
            exitWidgetMenuItem.Text = @"Exit";
            exitWidgetMenuItem.WidgetForm = form;
            exitWidgetMenuItem.Click += (sender, e) =>
            {

                ((WidgetToolStripMenuItem)sender).WidgetForm.ExitWidget();
            };


            WidgetToolStripMenuItem settingWidgetMenuItem = new WidgetToolStripMenuItem();
            settingWidgetMenuItem.Text = @"Settings";
            settingWidgetMenuItem.WidgetForm = form;
            settingWidgetMenuItem.Click += (sender, e) =>
            {

                ((WidgetToolStripMenuItem)sender).WidgetForm.ShowSettings();
            };

            WidgetToolStripMenuItem widgetToolStripMenuItem = new WidgetToolStripMenuItem();
            //widgetToolStripMenuItem.Text = form.Name;
            widgetToolStripMenuItem.Text = form.Name;
            widgetToolStripMenuItem.DropDown.Items.AddRange(new WidgetToolStripMenuItem[] { exitWidgetMenuItem, settingWidgetMenuItem });

            form.UpdateToolStripMenuItemText += (name) => widgetToolStripMenuItem.Text = name;
            form.RemoveToolStripMenuItem += () =>
            {
                _notifyIcon.ContextMenuStrip.Items.Remove(widgetToolStripMenuItem);
            };

            return widgetToolStripMenuItem;
        }

        public void ShowBalloonTip(int timeout, string tipTitle, string tipText, ToolTipIcon tipIcon)
        {
            _notifyIcon.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
        }
    }
}
