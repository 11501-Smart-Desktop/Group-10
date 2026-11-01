/// <summary>
/// Group 10 功能模組入口
/// 請各組於此處擴充組內專屬功能
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartDesktopApp.Features.Group10; // 務必確保引用正確的命名空間
using System.Diagnostics;


namespace SmartDesktopApp.Features.Group10
{
    public partial class UC_Group10 : UserControl
    {
        private QuizLogic _logic;
        private Label lblEnglish;
        private Label lblChinese;
        private VocabularyItem _currentWord;

        public UC_Group10()
        {
            InitializeComponent();

            // 1. 建立依賴關係
            // 根據介面設計，先建立 DataHandler，再注入給 QuizLogic
            // 整合長在這裡決定要注入誰
            // 階段 A (測試時)：IDataHandler data = new DummyDataHandler();
            // 階段 B (整合時)：IDataHandler data = new DataHandler(); 
            IDataHandler dataHandler = new DataHandler();
            _logic = new QuizLogic(dataHandler);
        }

        private void UC_Group10_Load(object sender, EventArgs e)
        {
            // 2. 畫面載入時自動抽題
            ShowNextWord();
        }

        private void ShowNextWord()
        {
            _currentWord = _logic.GetNextWord();

            if (_currentWord != null)
            {
                // 將資料層的資料塞進介面元件中
                // 假設您設計師拉出的元件名稱分別為 lblEnglish, lblChinese
                lblEnglish.Text = _currentWord.English;
                lblChinese.Text = $"({_currentWord.Type}) {_currentWord.Chinese}";
            }
            else
            {
                lblEnglish.Text = "無單字";
                lblChinese.Text = "";
            }
        }

        // 3. 處理使用者互動 (按鈕事件)
        private void btnEasy_Click(object sender, EventArgs e)
        {
            if (_currentWord != null)
            {
                _logic.AnswerWord(_currentWord, true); // 回報：簡單
                ShowNextWord(); // 顯示下一題
            }
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            if (_currentWord != null)
            {
                _logic.AnswerWord(_currentWord, false); // 回報：困難
                ShowNextWord(); // 顯示下一題
            }
        }

        private void InitializeComponent()
        {
            this.lblEnglish = new System.Windows.Forms.Label();
            this.lblChinese = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Location = new System.Drawing.Point(141, 97);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(65, 15);
            this.lblEnglish.TabIndex = 0;
            this.lblEnglish.Text = "lblEnglish";
            // 
            // lblChinese
            // 
            this.lblChinese.AutoSize = true;
            this.lblChinese.Location = new System.Drawing.Point(141, 166);
            this.lblChinese.Name = "lblChinese";
            this.lblChinese.Size = new System.Drawing.Size(66, 15);
            this.lblChinese.TabIndex = 1;
            this.lblChinese.Text = "lblChinese";
            // 
            // UC_Group10
            // 
            this.Controls.Add(this.lblChinese);
            this.Controls.Add(this.lblEnglish);
            this.Name = "UC_Group10";
            this.Size = new System.Drawing.Size(1032, 509);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void btnTestLogic_Click(object sender, EventArgs e)
        //{
        //    // 連續抽題測試演算法
        //    for (int i = 0; i < 5; i++)
        //    {
        //        var word = _logic.GetNextWord();
        //        // 檢查權重變化
        //        Debug.WriteLine($"第 {i + 1} 抽：{word.English}, 目前權重：{word.ReviewLevel}");

        //        // 模擬使用者回答「困難」
        //        _logic.AnswerWord(word, false);
        //        Debug.WriteLine($"回答困難後權重：{word.ReviewLevel}");
        //    }
        //}
    }
}
