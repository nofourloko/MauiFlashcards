using System;
using System.ComponentModel;

namespace MauiFiszki.Models
{
    public class FiszkaData : INotifyPropertyChanged
    {
        public List<string[]> wordBank { set; get; }
        public string Title { get; set; }
        public string Text { set; get; }
        private string currWord;
        public string completition {set;get;}

        public string currentWord
        {
            get { return currWord; }
            set
            {
                if (currWord != value)
                {
                    currWord = value;
                    NotifyPropertyChanged("currentWord");
                }
            }
        }

		public int currenntIndex { set; get; } = 0;

        public FiszkaData(LannguageSectionDeatails dzial) => populateWordBankList(dzial);

		public void populateWordBankList(LannguageSectionDeatails dzial)
		{
			wordBank = dzial.WordBank;
			Title = dzial.Title;
            currentWord = wordBank[currenntIndex][1];
            completition = dzial.Completition;
		}

		public string check(string inputWord)
		{
            Text = $"{wordBank[currenntIndex][1]} - {wordBank[currenntIndex][0]}";
            string result = "Źle";
            if (wordBank[currenntIndex][0] == inputWord)
            {
                wordBank.Remove(wordBank[currenntIndex]);
                if(wordBank.Count == 0)
                {
                    result = "Gratulacje";
                    return result;
                }
                else
                {
                    result = "Dobrze";
                }
            }

            if (wordBank.Count ==  1)
            {
                currenntIndex = 0;
            }
            else if(currenntIndex + 1 == wordBank.Count)
            {
                wordBank = ShuffleIntList(wordBank);
                currenntIndex = 0;
            }
            else
            {
                currenntIndex++;
            }


            currentWord = wordBank[currenntIndex][1];

            return result;
        }

        public void RigthAnswear(Label resultLabelBlad)
        {
            resultLabelBlad.IsVisible = true;
            resultLabelBlad.Text = Text;
        }

        public static List<string[]> ShuffleIntList(List<string[]> wordBank)
        {
            var random = new Random();
            var newShuffledList = new List<string[]>();
            var listcCount = wordBank.Count;
            for (int i = 0; i < listcCount; i++)
            {
                var randomElementInList = random.Next(0, wordBank.Count);
                newShuffledList.Add(wordBank[randomElementInList]);
                wordBank.Remove(wordBank[randomElementInList]);
            }
            return newShuffledList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

