using System;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.IO;
using Dictionary.Data;

namespace Dictionary
{
    public partial class FrmMain : Form
    {
        private readonly DatabaseManagement manager;
        public FrmMain()
        {
            InitializeComponent();
            manager = new DatabaseManagement();
            SetHandCursor(tabSearch);
            SetHandCursor(tabManage);
            SetHandCursor(tabIm_Ex);
            SetHandCursor(boxImport);
            SetHandCursor(boxExport);
            btnPronounce.Cursor = Cursors.Hand;
            this.txtSearch.Focus();
            this.Load += GUI_Load;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.recmWordsList.MouseClick += RecmWordsList_MouseClick;
            this.btnFind.Click += BtnFind_Click;
            this.btnClear.Click += (sender, e) => this.txtSearch.Clear();
            this.btnAdd.Click += btnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.wordsTable.CellDoubleClick += WordsTable_CellDoubleClick;
            this.btnSelect.Click += (sender, e) => SelectAllCheckBox(true);
            this.btnDeSelect.Click += (sender, e) => SelectAllCheckBox(false);
            this.btnExport.Click += BtnExport_Click;
            this.btnDirect.Click += BtnDirect_Click;
            this.btnImport.Click += BtnImport_Click;
            this.btnPronounce.Click += BtnPronounce_Click;
            this.btnSwitch.CheckedChanged += btnSwitch_CheckedChanged;
        }

        void btnSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnSwitch.Checked == true)
            {
                this.wordsTable.Columns.Clear();
                this.wordsTable.Columns.Add("col1", "Type's ID");
                this.wordsTable.Columns.Add("col2", "Type");
                LoadTypesToManageList();
            }
            else
            {
                this.wordsTable.Columns.Clear();
                this.wordsTable.Columns.Add("col1", "Word");
                this.wordsTable.Columns.Add("col2", "Type");
                this.wordsTable.Columns.Add("col3", "Mean");
                LoadWordsToManageList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!this.btnSwitch.Checked)
            {
                FrmEdit_Add frm = new FrmEdit_Add(true);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Word obj;
                    frm.PerformAction(out obj);
                    wordsTable.Rows.Add(obj.word_o, obj.Type.type_description, obj.word_m);
                }
            }
            else
            {
                FrmAdd_EditType frm = new FrmAdd_EditType(true);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Data.Type obj;
                    frm.PerformAction(out obj);
                    wordsTable.Rows.Add(obj.Id, obj.type_description);
                }
            }
            wordsTable.Sort(wordsTable.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            MessageBox.Show("Added successfully");
        }

        private void BtnPronounce_Click(object sender, EventArgs e)
        {
            if (this.txtMeans.TextLength > 0)
            {
                string word = this.txtMeans.Lines[0];
                SpeechManagement speech = new SpeechManagement();
                speech.Speak(word);
                speech.Dispose();
            }else
            {
                MessageBox.Show("Don't have anything to speak out, first you must choose a word");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length == 0)
            {
                MessageBox.Show("You haven't ever choose a file, please choose a file");
                return;
            }
            this.Enabled = false;
            string path = txtPath.Text;
            ImportManagement importer = new ImportManagement(path);
            List<Word> objs = importer.ImportTo(manager);
            for (int i = 0; i < objs.Count; i++)
            {
                this.wordsTable.Rows.Add(objs[i].word_o, manager.GetTypeOfId(objs[i].type_id).type_description, objs[i].word_m);
            }
            this.Enabled = true;
            this.wordsTable.Sort(this.wordsTable.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            MessageBox.Show("Imported successfully");
        }

        private void BtnDirect_Click(object sender, EventArgs e)
        {
            if (frmOpen.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = frmOpen.FileName;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (frmSave.ShowDialog() == DialogResult.OK)
            {
                string path = frmSave.FileName;
                List<Word> list = GetSelectedWordsList();
                if (File.Exists(path))
                {
                    MessageBox.Show("file has been existed, please choose another name",
                                    "Error",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error);
                    return;
                }
                this.Enabled = false;
                if (frmSave.FilterIndex == 1)
                {
                    WriteToExcel(path, list);
                }
                else
                {
                    WriteToCsvFile(path, list);
                }
                this.Enabled = true;
            }
        }

        private void WriteToCsvFile(string path, List<Word> list)
        {
            CsvFileManagement csv = new CsvFileManagement(path);
            csv.WriteFile(list);
        }

        private void WriteToExcel(string path, List<Word> list)
        {
            ExcelManagement exl = new ExcelManagement(path);
            exl.ClearData();
            exl.WriteFile(list);
            exl.Save();
            exl.Close();
            MessageBox.Show("Completed to export selected data to " + path);
        }

        private List<Word> GetSelectedWordsList()
        {
            List<Word> list = new List<Word>();
            foreach (CheckBox ctrl in wordListPanel.Controls)
            {
                if (ctrl.Checked)
                {
                    var temp = manager.GetWords(ctrl.Text);
                    for (int i = 0; i < temp.Count; i++)
                    {
                        list.Add(temp[i]);
                    }
                }
            }
            return list;
        }

        private void SelectAllCheckBox(bool @checked)
        {
            foreach (Control ctrl in wordListPanel.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = @checked;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected item?",
                                                "Confirm",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (this.btnSwitch.Checked == false)
                {
                    string word = wordsTable.SelectedRows[0].Cells[0].Value.ToString();
                    string type = wordsTable.SelectedRows[0].Cells[1].Value.ToString();
                    int id = manager.GetIDOfType(type);
                    manager.RemoveWord(word, id);
                }
                else
                {
                    int typeID = int.Parse(wordsTable.SelectedRows[0].Cells[0].Value.ToString());
                    manager.RemoveType(typeID);
                }
                wordsTable.Rows.RemoveAt(wordsTable.SelectedRows[0].Index);
                MessageBox.Show("removed successfully");
            }
        }

        private void WordsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnSwitch.Checked)
            {
                string word = wordsTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                string type = wordsTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                string mean = wordsTable.Rows[e.RowIndex].Cells[2].Value.ToString();
                FrmEdit_Add frm = new FrmEdit_Add(false, word, manager.GetIDOfType(type), mean);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Word obj;
                    frm.PerformAction(out obj);
                    wordsTable.Rows[e.RowIndex].Cells[2].Value = obj.word_m;
                }
                frm.Dispose();
            }
            else
            {
                int id = int.Parse(this.wordsTable.SelectedRows[0].Cells[0].Value.ToString());
                string type = this.wordsTable.SelectedRows[0].Cells[1].Value.ToString();
                FrmAdd_EditType frm = new FrmAdd_EditType(false, id, type);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Data.Type obj;
                    frm.PerformAction(out obj);
                    wordsTable.Rows[e.RowIndex].Cells[1].Value = obj.type_description;
                }
                frm.Dispose();
            }
            MessageBox.Show("Edited successfully");
        }

        private void RecmWordsList_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtSearch.TextChanged -= TxtSearch_TextChanged;
            this.txtSearch.Text = this.recmWordsList.Items[this.recmWordsList.IndexFromPoint(e.Location)].ToString();
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (recmWordsList.Items.Count == 0)
            {
                WebSearcher searcher = new WebSearcher();
                MessageBox.Show(searcher.Search("culture"));
                return;
            }
            ShowWordInfs(txtSearch.Text);
        }

        private void ShowWordInfs(string word)
        {
            this.txtMeans.Clear();
            this.txtMeans.AppendText(word + Environment.NewLine);
            this.txtMeans.SelectionStart = 0;
            this.txtMeans.SelectionLength = this.txtMeans.Lines[0].Length;
            this.txtMeans.SelectionColor = System.Drawing.Color.Purple;
            var data = manager.GetMeansOfWord(word);
            foreach (var type in data)
            {
                this.txtMeans.AppendText("    - " + manager.GetStringDescriptionOfTypeKey(type.Key));
                this.txtMeans.SelectionStart = this.txtMeans.GetFirstCharIndexOfCurrentLine();
                this.txtMeans.SelectionLength = this.txtMeans.Lines[this.txtMeans.GetLineFromCharIndex(this.txtMeans.SelectionStart)].Length;
                this.txtMeans.SelectionColor = System.Drawing.Color.Blue;
                this.txtMeans.AppendText(Environment.NewLine);
                foreach (var means in type)
                {
                    this.txtMeans.AppendText("        + " + means.word_m + Environment.NewLine);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowRecommendWords(this.txtSearch.Text);
        }

        private void ShowRecommendWords(string text)
        {
            var dataSource = manager.GetDistinctWordsList();
            var data = dataSource.Where(item => item.ToLower().StartsWith(text.ToLower())).Select(item => item);
            this.recmWordsList.DataSource = data.ToList();
            this.recmWordsList.ClearSelected();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            LoadWordsToHintList();
            LoadWordsToManageList();
            LoadWordsToImExTab();
        }

        private void LoadWordsToImExTab()
        {
            var data = manager.GetDistinctWordsList();
            foreach (string item in data)
            {
                this.wordListPanel.Controls.Add(new CheckBox() { Checked = false, Text = item, Cursor = Cursors.Hand });
            }
        }

        private void LoadWordsToManageList()
        {
            var data = manager.GetWordsData();
            foreach (var item in data)
            {
                wordsTable.Rows.Add(item.word, item.type, item.mean);
            }
        }

        private void LoadTypesToManageList()
        {
            var data = manager.GetTypes();
            foreach (var item in data)
            {
                wordsTable.Rows.Add(item.Id, item.type_description);
            }
        }

        private void LoadWordsToHintList()
        {
            this.recmWordsList.DataSource = manager.GetDistinctWordsList();
            this.recmWordsList.ClearSelected();
        }

        private void SetHandCursor(Control page)
        {
            foreach (Control comp in page.Controls)
            {
                if (comp is ButtonBase)
                {
                    comp.Cursor = Cursors.Hand;
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            txtSearch.Select();
            base.OnShown(e);
        }
    }
}
