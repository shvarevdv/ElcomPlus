using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestApplicationElcomPlus.Model
{
    public class DataSorter
    {
        private Dictionary<string, ValuesFromFile> dataToSort;
        
        public DataSorter(Dictionary<string, ValuesFromFile> dataToSort)
        {
            this.dataToSort = dataToSort;
            resultOfSorting = new Dictionary<string, Dictionary<string, int>>();
        }

        private Dictionary<string, Dictionary<string, int>> resultOfSorting;
        
        public Dictionary<string, Dictionary<string, int>> Sort()
        {
            try
            {
                foreach (var data in dataToSort)
                {
                    if (data.Value != null)
                    {
                        var sortedValueDictionary = SortValue(data.Value);
                        resultOfSorting.Add(data.Key, sortedValueDictionary);
                    }
                    else
                        resultOfSorting.Add(data.Key, null);
                }

                return resultOfSorting;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Dictionary<string, Dictionary<string, int>>();                
            }
            
        }

        private Dictionary<string, int> SortValue(ValuesFromFile valueForSort)
        {
            var dictionaryForSortValue = new Dictionary<string, int>();
            
            foreach(var value in valueForSort.Values)
            {
                if (dictionaryForSortValue.ContainsKey(value))
                    dictionaryForSortValue[value]++;
                else
                    dictionaryForSortValue.Add(value, 1);
            }

            return dictionaryForSortValue;
        }
    }
}
