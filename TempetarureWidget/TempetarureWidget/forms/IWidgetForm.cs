using System;

namespace TempetarureWidget
{
    public interface IWidgetForm
    {
        event Action<string> UpdateToolStripMenuItemText;
        event Action RemoveToolStripMenuItem;

        void ExitWidget();
        void ShowSettings();
        string Name { get; set; }
    }
}