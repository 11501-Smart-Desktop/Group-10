using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDesktopApp.Features.Group10
{
    // 修改為 public，確保其他小組成員的檔案可以呼叫到這個類別
    public class QuizLogic
    {
        // 統一使用介面 IDataHandler，這樣未來就算更換資料來源也不用改這裡
        private IDataHandler _dataHandler;
        private List<VocabularyItem> _words;
        private Random _random;

        // 建構子
        public QuizLogic(IDataHandler dataHandler) // 在這裡「注入」介面
        {
            _dataHandler = dataHandler; // 直接使用傳進來的介面
            // 讀取資料
            _words = _dataHandler.LoadWords();
            _random = new Random();
        }

        public VocabularyItem GetNextWord()
        {
            if (_words == null || _words.Count == 0) return null;
            return _words[_random.Next(_words.Count)];
        }

        public void AnswerWord(VocabularyItem word, bool isEasy)
        {
            if (isEasy) word.ReviewLevel -= 1;
            else word.ReviewLevel += 3;

            // 呼叫介面定義的方法存檔
            _dataHandler.SaveWords(_words);
        }
    }
    //// 在 QuizLogic.cs 檔案的最下方，與 QuizLogic 類別同層級
    //public class DummyDataHandler : IDataHandler
    //{
    //    public List<VocabularyItem> LoadWords()
    //    {
    //        // 回傳空的清單，或者硬寫一些假資料讓你可以先測試邏輯
    //        return new List<VocabularyItem> {
    //        new VocabularyItem { English="Test", Chinese="測試", Type="n.", ReviewLevel=0 }
    //    };
    //    }
    //    public void SaveWords(List<VocabularyItem> words) { /* 什麼都不做 */ }
    //}
}