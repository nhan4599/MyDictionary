using Excel = Microsoft.Office.Interop.Excel; // use alias named Excel for Microsoft.Office.Interop.Excel
using System.Collections.Generic;
using Dictionary.Data;
using System.IO;
using System;

namespace Dictionary
{
    class ExcelManagement
    {
        private readonly string path;
        private readonly Excel._Application xlsApp; // Application is the top-level interface of Excel file
        private Excel.Workbook xlsFile; // represented a excel file
        private Excel.Worksheet sheet; // represented a sheet in xlsFile

        public ExcelManagement(string path)
        {
            this.path = path;
            xlsApp = new Excel.Application();
            if (!File.Exists(path))
            {
                this.CreateNewFile(path);
            }
            else
            {
                xlsFile = xlsApp.Workbooks.Open(path);
            }

            // the index of excel file is based 1, not based 0 like arrays
            sheet = xlsFile.Sheets[1];
        }

        public List<Word> ReadFile()
        {
            List<Word> list = new List<Word>();
            if (sheet.UsedRange.Columns.Count != 3)
            {
                throw new Exception("This file does not match");
            }
            else
            {
                for (int i = 1; i <= sheet.UsedRange.Rows.Count; i++)
                {
                    Word obj = new Word();
                    obj.word_o = sheet.Cells[i, 1].Value2.ToString();
                    obj.type_id = int.Parse(sheet.Cells[i, 2].Value2.ToString());
                    obj.word_m = sheet.Cells[i, 3].Value2.ToString();
                    list.Add(obj);
                }
            }
            return list;
        }

        public void WriteFile(List<Word> t)
        {
            // index in excel file is based on 1. But index in arrays or list is based on 0
            for (int i = 1; i <= t.Count; i++)
            {
                Word temp = t[i - 1];
                sheet.Cells[i, 1].Value2 = temp.word_o;
                sheet.Cells[i, 2].Value2 = temp.type_id;
                sheet.Cells[i, 3].Value2 = temp.word_m;
            }
        }

        public void Save()
        {
            xlsFile.Save();
        }

        public void SaveAs(string path)
        {
            xlsFile.SaveAs(path);
        }

        public void CreateNewFile(string path)
        {
            xlsFile = xlsApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            sheet = xlsFile.ActiveSheet;
            this.SaveAs(path);
        }

        public void Close()
        {
            xlsFile.Close();
        }

        public void ClearData()
        {
            sheet.Cells.ClearContents();
        }
    }
}
