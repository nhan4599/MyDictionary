using Dictionary.Data;
using System;
using System.Collections.Generic;

namespace Dictionary
{
    class ImportManagement
    {
        readonly string path;

        public ImportManagement(string path)
        {
            this.path = path;
        }

        public List<Word> ImportTo(DatabaseManagement manager)
        {
            string fileType = GetFileType();
            List<Word> addedList = new List<Word>();
            if (fileType.Equals(".xls") || fileType.Equals(".xlsx"))
            {
                ExcelManagement exl = new ExcelManagement(path);
                List<Word> dataList = exl.ReadFile();
                for (int i = 0; i < dataList.Count; i++)
                {
                    try
                    {
                        manager.AddWord(dataList[i].word_o, dataList[i].type_id, dataList[i].word_m);
                        addedList.Add(dataList[i]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                exl.Close();
            }
            else if (fileType.Equals(".csv"))
            {
                CsvFileManagement csv = new CsvFileManagement(path);
                List<Word> dataList = csv.ReadFile();
                for (int i = 0; i < dataList.Count; i++)
                {
                    try
                    {
                        manager.AddWord(dataList[i].word_o, dataList[i].type_id, dataList[i].word_m);
                        addedList.Add(dataList[i]);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            return addedList;
        }

        private string GetFileType()
        {
            return path.Substring(path.LastIndexOf('.'));
        }
    }
}
