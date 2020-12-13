using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace TestApplicationElcomPlus.Model
{
    public class FileDispatcher
    {
        public FileDispatcher(string[] filePathes)
        {
            this.filePathes = filePathes;
            valuesFromFile = new ValuesFromFile();
            fileNamesWithValues = new Dictionary<string, ValuesFromFile>();
        }
        private string[] filePathes;
        private ValuesFromFile valuesFromFile;
        private Dictionary<string, ValuesFromFile> fileNamesWithValues;

        public Dictionary<string, ValuesFromFile> HandleFile()
        {
            GetFileExtension();            
            return fileNamesWithValues;
        }        

        private void GetFileExtension()
        {
            foreach(var filePath in filePathes)
            {
                var extension = Path.GetExtension(filePath);
                var name = Path.GetFileName(filePath);
                GetFileData(filePath, extension);
                fileNamesWithValues.Add(name, valuesFromFile);
            }
        }

        private void GetFileData(string filePath, string extension)
        {
            try
            {
                switch (extension)
                {
                    case ".json":
                        var jsonHandler = new JsonHandler(filePath);
                        valuesFromFile = jsonHandler.Handle();
                        break; 
                    case ".xml":
                        var xmlHandler = new XmlHandler(filePath);
                        valuesFromFile = xmlHandler.Handle();
                        break;
                    default:
                        throw new Exception("Данный тип файла не поддерживается");
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                valuesFromFile = null;
            }
            
        }

        
    }

}

