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
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace PowerShell_Studio_Free
{
    /// <summary>
    /// Логика взаимодействия для NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        private FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
        public NewProjectWindow()
        {
            InitializeComponent();
            ProjectPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        private void Path_Click(object sender, RoutedEventArgs e)
        {
            folderBrowser.ShowDialog();
            ProjectPath.Text = folderBrowser.SelectedPath;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
