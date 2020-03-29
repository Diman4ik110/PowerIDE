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
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Xml.Linq;


namespace PowerShell_Studio_Free
{
    /// <summary>
    /// Логика взаимодействия для NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        private bool isPressedButton = false;
        private Point position1;
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
        
        private void NewProjectBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            position1 = e.GetPosition(NewProjectWind);
            isPressedButton = true;
        }

        private void NewProjectBorder_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && isPressedButton == true)
            {
                NewProjectWind.Top += (e.GetPosition(NewProjectWind).Y - position1.Y);
                NewProjectWind.Left += (e.GetPosition(NewProjectWind).X - position1.X);
            }
        }

        private void NewProjectBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isPressedButton = false;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(ProjectPath.Text))
            {
                DirectoryInfo directory = new DirectoryInfo(ProjectPath.Text);
                directory.CreateSubdirectory(ProjectName.Text);

                File.Create(ProjectPath.Text + @"\" + ProjectName.Text + @"\" + ProjectName.Text + ".ps1");
                File.Create(ProjectPath.Text + @"\" + ProjectName.Text + @"\" + ProjectName.Text + ".xaml");

                XDocument ProjectSettingFile = new XDocument(new XElement("PowerIDEProject",
                    new XElement("Properties",
                    new XElement("ProjectName", ProjectName.Text),
                    new XElement("ProjectPath", ProjectPath.Text),
                    new XElement("ProjectFormFile", ProjectName.Text + ".xaml"),
                    new XElement("ProjectScriptFile", ProjectName.Text + ".ps1"))));
                ProjectSettingFile.Save(ProjectPath.Text + @"\" + ProjectName.Text + @"\" + ProjectName.Text + ".psproject");
                this.Close();
            }
        }
    }
}
