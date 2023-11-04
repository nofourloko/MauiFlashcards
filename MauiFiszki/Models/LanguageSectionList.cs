using System;
using System.Collections.ObjectModel;
using MauiFiszki.DbConntection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MauiFiszki.Models
{
	public class LanguageSectionList
	{
		public ObservableCollection<LannguageSectionDeatails> allSectionsList { set; get; } = new ObservableCollection<LannguageSectionDeatails>();
        public DbConnection Db { get; set; } = new DbConnection();
        public LanguageSectionList(string lang) => AllSectionsList(Db.conn(lang));

		public void AllSectionsList(List<BsonDocument> allSections)
		{
            foreach (var section in allSections)
            {
                string title = Convert.ToString(section["Title"]);
                string langauge = Convert.ToString(section["Lang"]);
                List<string[]> wordBank = new List<string[]>(section["WordBank"].AsBsonArray.Select(arr => arr.AsBsonArray.Select(element => element.AsString).ToArray()));
                string completition = "Nie ukończone ;((";

                if (Convert.ToBoolean(section["Completition"]) == true)
                {
                    completition = "Ukończone!!!";
                }

                allSectionsList.Add(new LannguageSectionDeatails { Title = title, Completition = completition, WordBank = wordBank, Lang = langauge });
            }
        }

        public async void SectionUpdate(LannguageSectionDeatails dzial)
        {
       
            int indexToChange = allSectionsList.IndexOf(dzial);

            if (indexToChange != -1)
            {
                allSectionsList[indexToChange] = dzial;
            }

            Db.sectionCompletion(dzial);

        }

    }
}

