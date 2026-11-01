using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDesktopApp.Features.Group10
{
    public interface IDataHandler
    {
        List<VocabularyItem> LoadWords();
        void SaveWords(List<VocabularyItem> words);
    }
}
