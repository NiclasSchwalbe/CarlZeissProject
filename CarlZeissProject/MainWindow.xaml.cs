using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarlZeissProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool outputFileSpecified = false;
        bool inputFileSpecified = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void updateProcessButton()
        {
            processButton.IsEnabled = outputFileSpecified && inputFileSpecified;
        }

        private void Button_Click_InputFile(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV files|*.csv";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                inputFileSpecified = true;
                // Open document 
                string filename = dlg.FileName;
                inputTextBox.Text = filename;

            }
            else
            {
                //In case it was true before
                inputFileSpecified = false;

            }

            updateProcessButton();
        }


        private void Button_Click_OutputFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.Title = "Save text Files";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                outputFileSpecified = true;
                outputTextBox.Text = saveFileDialog.FileName;
            } else
            {
                //In case it was true before
                outputFileSpecified = false;

            }
            updateProcessButton();
        }

        private void processButton_Click(object sender, RoutedEventArgs e)
        {
            process(inputTextBox.Text, outputTextBox.Text);
        }

        private void process(string input, string output)
        {
           if(File.Exists(input) == false)
           {
                return;
           }


        }
    }
}
