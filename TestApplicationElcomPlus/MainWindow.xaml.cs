using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestApplicationElcomPlus.Model;

namespace TestApplicationElcomPlus
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }

        private string[] filePathes;
        private Dictionary<string, ValuesFromFile> fileNamesWithValueCollection;
        private Dictionary<string, Dictionary<string, int>> resultOfSort;

        private void HandleFile(object sender, RoutedEventArgs e)
        {
            SelectFiles();
            LoadFile();
            SortValues();
            ShowSortedData();
        }

        private void SelectFiles()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                filePathes = openFileDialog.FileNames;
            }
        }

        private void LoadFile()
        {
            var fileDispactcher = new FileDispatcher(filePathes);
            fileNamesWithValueCollection = fileDispactcher.HandleFile();

        }

        private void SortValues()
        {
            DataSorter dataSorter = new DataSorter(fileNamesWithValueCollection);
            resultOfSort = dataSorter.Sort();
        }

        private void ShowSortedData()
        {
            string resultString = "";
            foreach (var result in resultOfSort)
            {
                try
                {
                    string fileName = result.Key;
                    int maxCount = result.Value.Values.Max();
                    string maxValue = result.Value.FirstOrDefault(x => x.Value == maxCount).Key;
                    if (maxCount > 1)
                        resultString += String.Format("В файле {0} \n самый повторяющийся элемент: \"{1}\", количество повторений: {2} \n", fileName, maxValue, maxCount);
                    else
                        resultString += String.Format("В файле {0} \n нет повоторяющихся символов.\n", fileName);                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
                

            }
            SortedValueTextBlock.Text = resultString;
        }
    }
}
