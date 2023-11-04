using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MauiFiszki.Models;

namespace MauiFiszki.DbConntection
{
	public class DbConnection
	{
        public IMongoCollection<BsonDocument> langCollection { set; get; }

        public List<BsonDocument> conn(string lang)
		{
            var client = new MongoClient("mongodb://localhost:27017");
			var database = client.GetDatabase("MauiFiszki");

            langCollection = database.GetCollection<BsonDocument>(lang);

            var allSections = langCollection.Find(_ => true);

			return allSections.ToList();
        }

		public async void sectionCompletion(LannguageSectionDeatails dzial)
		{
            var filter = Builders<BsonDocument>.Filter.Eq("Title", dzial.Title);
            var update = Builders<BsonDocument>.Update.Set("Completition", true);

            await langCollection.UpdateOneAsync(filter, update);
        }
	}
}

