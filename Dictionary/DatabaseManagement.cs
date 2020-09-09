using Dictionary.Data;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class DatabaseManagement
    {
        DictionaryEntities db = new DictionaryEntities();

        public List<string> GetDistinctWordsList()
        {
            return db.Words.Select(item => item.word_o).Distinct().ToList();
        }

        public List<string> GetTypesString()
        {
            return db.Types.Select(item => item.type_description).ToList();
        }

        public List<string> GetWordsStartWith(string text)
        {
            var data = GetDistinctWordsList();
            return data.Where(item => item.ToLower().StartsWith(text.ToLower())).ToList();
        }

        public List<WordView> GetWordsData()
        {
            var data = db.Words.ToList();
            var result = new List<WordView>();
            foreach (var item in data)
            {
                result.Add(new WordView() { word = item.word_o, type = GetStringDescriptionOfTypeKey(item.type_id), mean = item.word_m });
            }
            return result;
        }

        private string GetStringDescriptionOfTypeKey(int id)
        {
            return db.Types.AsNoTracking().Where(i => i.Id == id).FirstOrDefault().type_description;
        }

        public Word AddWord(string word, int typeID, string mean)
        {
            Word obj = new Word() { word_o = word, type_id = typeID, word_m = mean};
            db.Words.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Type AddType(string type)
        {
            Type obj = new Type() { type_description = type };
            db.Types.Add(obj);
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

        public Type RemoveType(int id)
        {
            Type obj = db.Types.Find(id);
            db.Types.Remove(obj);
            db.SaveChanges();
            return obj;
        }

        public List<Word> GetWords(string word)
        {
            return db.Words.AsNoTracking().Where(item => item.word_o.ToLower().Equals(word)).ToList();
        }

        public List<Type> GetTypes()
        {
            return db.Types.AsNoTracking().ToList();
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

        public Type EditType(int id, string type)
        {
            Type obj = db.Types.Find(id);
            obj.type_description = type;
            db.SaveChanges();
            return obj;
        }

        public int GetIdOfType(string type)
        {
            return db.Types.Where(item => item.type_description.Equals(type)).FirstOrDefault().Id;
        }
    }
}
