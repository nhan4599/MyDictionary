using Dictionary.Data;
using System;
using System.Collections.Generic;

namespace Dictionary
{
    class ImportManagement
    {
        // path of file which you want to import to
        readonly string path;

        // create a instance with the specific path
        public ImportManagement(string path)
        {
            this.path = path;
        }

        public List<Word> ImportTo(DatabaseManagement manager)
        {
            string fileType = GetFileType();
            // create a list to contain words that not existed in database 
            // used to add its to datagridview but not reload all words from database
            List<Word> addedList = new List<Word>();
            List<Word> dataList = new List<Word>();
            if (fileType.Equals(".xlsx"))
            {
                ExcelManagement exl = new ExcelManagement(path);
                // the dataList is the list which contains words readed from file
                dataList = exl.ReadFile();
                exl.Close();
            }
            else if (fileType.Equals(".csv"))
            {
                CsvFileManagement csv = new CsvFileManagement(path);
                dataList = csv.ReadFile();
            }
            for (int i = 0; i < dataList.Count; i++)
            {
                try
                {
                    // if the words has already existed in database, it will throw a exception
                    manager.AddWord(dataList[i].word_o, dataList[i].type_id, dataList[i].word_m);
                    addedList.Add(dataList[i]);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return addedList;
        }

        // get the file type of file
        private string GetFileType()
        {
            return path.Substring(path.LastIndexOf('.'));
        }
    }
}
