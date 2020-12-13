using Newtonsoft.Json;
using System.IO;


namespace TestApplicationElcomPlus.Model
{
    public class JsonHandler
    {
        private string filePath;
        private ValuesFromFile valueJson;
        

        public JsonHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public ValuesFromFile Handle()
        {
            JsonFileRead();
            return valueJson;
        }

        private void JsonFileRead()
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                valueJson = JsonConvert.DeserializeObject<ValuesFromFile>(json);
            }
        }
    }
}
