using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LogSystem;
namespace WeaponGeneratorApp
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    
    public partial class LogWindow : Window
    {
        Log logFile = new Log("logFile.txt", true);
        public LogWindow()
        {
            logFile.Clear();
            InitializeComponent();
            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.Header = "Severity";
        }
        public void Clear()
        {
            logFile.Clear();
            logView.Items.Clear();
        }
        private void Clear_Click(object sender, EventArgs ev)
        {
            Clear();
        }
        public void LogText(string msg)
        {
            logFile.LogText(msg);
            ListViewItem item = new ListViewItem();
            item.Content = $"          || {msg}";
            logView.Items.Add(item);
        }
        public void LogInfo(string msg)
        {
            logFile.LogInfo(msg);
            ListViewItem item = new ListViewItem();
            item.Content = $"Info      || {msg}";
            ViewBase view = logView.View;
        }
        public void LogWarning(string msg)
        {
            logFile.LogWarning(msg);
            ListViewItem item = new ListViewItem();
            item.Content = $"Warning   || {msg}";
            logView.Items.Add(item);
        }
        public void LogError(string msg)
        {
            logFile.LogError(msg);
            ListViewItem item = new ListViewItem();
            item.Content = $"Error     || {msg}";
            logView.Items.Add(item);
        }
        public void LogFatal(string msg)
        {
            logFile.LogFatal(msg);
            ListViewItem item = new ListViewItem();
            item.Content = $"Fatal     || {msg}";
            logView.Items.Add(item);
        }
    }
}
