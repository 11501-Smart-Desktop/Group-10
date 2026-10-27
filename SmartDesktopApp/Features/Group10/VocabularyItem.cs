using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 檔案：VocabularyItem.cs (大家共用的資料結構)
namespace SmartDesktopApp.Features.Group10
{
    public class VocabularyItem
    {
        public string English { get; set; }   // 英文
        public string Chinese { get; set; }   // 中文
        public string Type { get; set; }      // 詞性
        public int ReviewLevel { get; set; }  // 複習權重(分數越高越常出現)
    }
}
