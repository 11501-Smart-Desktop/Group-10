using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json;

namespace SmartDesktopApp.Features.Group10
{
    public class DataHandler
    {
        private string filePath = "vocabulary.json";

        public List<VocabularyItem> LoadWords()
        {
            if (!File.Exists(filePath)) return new List<VocabularyItem>();
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<VocabularyItem>>(json);
        }

        public void SaveWords(List<VocabularyItem> words)
        {
            string json = JsonConvert.SerializeObject(words, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
