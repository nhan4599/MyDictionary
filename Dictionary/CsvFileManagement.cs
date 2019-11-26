using System.IO;
using System.Collections.Generic;
using Dictionary.Data;

namespace Dictionary
{
    class CsvFileManagement
    {
        private readonly string path;

        public CsvFileManagement(string path)
        {
            if (!File.Exists(path))
            {
                CreateNewFile(path).Close();
            }
            this.path = path;
        }

        public void WriteFile(List<Word> list)
        {
            StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            for (int i = 0; i < list.Count; i++)
            {
                writer.WriteLine(string.Join(";", list[i].word_o, list[i].type_id, list[i].word_m));
            }
            writer.Close();
        }

        public List<Word> ReadFile()
        {
            FileStream stream = File.Open(path, FileMode.Open);
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
            List<Word> list = new List<Word>();
            string data = reader.ReadLine();
            while (data != null)
            {
                string[] currObj = data.Split(';');
                list.Add(new Word() { word_o = currObj[0], type_id = int.Parse(currObj[1]), word_m = currObj[2] });
                data = reader.ReadLine();
            }
            stream.Close();
            reader.Close();
            return list;
        }

        private FileStream CreateNewFile(string path)
        {
            return File.Create(path);
        }
    }
}
