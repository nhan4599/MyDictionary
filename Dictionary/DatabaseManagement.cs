using Dictionary.Data;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class DatabaseManagement
    {
        private readonly DictionaryEntities db;
        public DatabaseManagement()
        {
            db = new DictionaryEntities();
        }

        public List<string> GetDistinctWordsList()
        {
            return db.Words.Select(item => item.word_o).Distinct().ToList();
        }

        public List<WordView> GetWordsData()
        {
            var data = db.Words.Select(item => new { word = item.word_o, type = item.Type.type_description, mean = item.word_m }).ToList();
            var result = new List<WordView>();
            foreach (var item in data)
            {
                result.Add(new WordView() { word = item.word, type = item.type, mean = item.mean });
            }
            return result;
        }

        public string GetStringDescriptionOfTypeKey(int id)
        {
            return db.Types.Find(id).type_description;
        }

        public IQueryable<IGrouping<int, Word>> GetMeansOfWord(string word)
        {
            return db.Words.Where(item => item.word_o.ToLower().Equals(word.ToLower())).GroupBy(item => item.type_id);
        }

        public Word AddWord(string word, int typeID, string mean)
        {
            Word obj = new Word() { word_o = word, type_id = typeID, word_m = mean, Type = GetTypeOfId(typeID) };
            db.Words.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Word RemoveWord(string word, int typeID)
        {
            Word obj = db.Words.Find(word, typeID);
            db.Words.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public List<Word> GetWords(string word)
        {
            return db.Words.Where(item => item.word_o.ToLower().Equals(word)).ToList();
        }

        public List<Type> GetTypes()
        {
            return db.Types.ToList();
        }

        public Type GetTypeOfId(int id)
        {
            return db.Types.Find(id);
        }

        public Word EditWord(string word, int id, string mean)
        {
            Word obj = db.Words.Find(word, id);
            obj.word_m = mean;
            db.SaveChanges();
            return obj;
        }

        ~DatabaseManagement()
        {
            db.Dispose();
        }

        public int GetIDOfType(string type)
        {
            return db.Types.Where(item => item.type_description.Equals(type)).FirstOrDefault().Id;
        }
    }
}
