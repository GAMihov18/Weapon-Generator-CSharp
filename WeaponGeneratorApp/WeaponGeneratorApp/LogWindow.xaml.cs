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
        }
        public void Clear()
        {
            logFile.Clear();
            logView.Items.Clear();
        }
        public void Clear_Click(object sender, EventArgs ev)
        {
            Clear();
        }
        public void LogText(string msg)
        {
        }
        public void LogInfo(string msg)
        {

        }
        public void LogWarning(string msg)
        {

        }
        public void LogError(string msg)
        {

        }
        public void LogFatal(string msg)
        {

        }
    }
}
