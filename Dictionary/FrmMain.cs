using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.IO;
using Dictionary.Data;
using System.Drawing;

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
            this.lbRecmWords.MouseClick += RecmWordsList_MouseClick;
            this.btnFind.Click += BtnFind_Click;
            this.btnClear.Click += btnClear_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.grdWords.CellDoubleClick += WordsTable_CellDoubleClick;
            this.btnSelect.Click += (sender, e) => SelectAllCheckBox(true);
            this.btnDeSelect.Click += (sender, e) => SelectAllCheckBox(false);
            this.btnExport.Click += BtnExport_Click;
            this.btnBrowse.Click += BtnDirect_Click;
            this.btnImport.Click += BtnImport_Click;
            this.btnPronounce.Click += BtnPronounce_Click;
            this.btnSwitch.CheckedChanged += btnSwitch_CheckedChanged;
        }

        void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSearch.Clear();
            LoadWordsToHintList();
        }

        void btnSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.btnSwitch.Checked == true)
            {
                this.grdWords.Columns.Clear();
                this.grdWords.Columns.Add("col1", "Type's ID");
                this.grdWords.Columns.Add("col2", "Type");
                LoadTypesToManageList();
            }
            else
            {
                this.grdWords.Columns.Clear();
                this.grdWords.Columns.Add("col1", "Word");
                this.grdWords.Columns.Add("col2", "Type");
                this.grdWords.Columns.Add("col3", "Mean");
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
                    Word obj = frm.PerformAction();
                    grdWords.Rows.Add(obj.word_o, obj.Type.type_description, obj.word_m);
                    grdWords.Sort(grdWords.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    LoadWordsToHintList();
                    LoadWordsToImExTab();
                    MessageBox.Show("Added successfully");
                }
            }
            else
            {
                FrmAdd_EditType frm = new FrmAdd_EditType(true);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Data.Type obj = frm.PerformAction();
                    grdWords.Rows.Add(obj.Id, obj.type_description);
                    grdWords.Sort(grdWords.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                    LoadWordsToHintList();
                    LoadWordsToImExTab();
                    MessageBox.Show("Added successfully");
                }
            }
        }

        private void BtnPronounce_Click(object sender, EventArgs e)
        {
            if (this.rtbMeans.TextLength > 0)
            {
                string word = this.rtbMeans.Lines[0];
                SpeechManagement speech = new SpeechManagement();
                speech.Speak(word);
                speech.Dispose();
            }
            else
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
                this.grdWords.Rows.Add(objs[i].word_o, manager.GetTypeOfId(objs[i].type_id).type_description, objs[i].word_m);
            }
            this.Enabled = true;
            this.grdWords.Sort(this.grdWords.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            LoadWordsToHintList();
            LoadWordsToImExTab();
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
            foreach (CheckBox ctrl in pnlWordsList.Controls)
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
            foreach (Control ctrl in pnlWordsList.Controls)
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
                    string word = grdWords.SelectedRows[0].Cells[0].Value.ToString();
                    string type = grdWords.SelectedRows[0].Cells[1].Value.ToString();
                    int id = manager.GetIdOfType(type);
                    manager.RemoveWord(word, id);
                }
                else
                {
                    int typeID = int.Parse(grdWords.SelectedRows[0].Cells[0].Value.ToString());
                    manager.RemoveType(typeID);
                }
                grdWords.Rows.RemoveAt(grdWords.SelectedRows[0].Index);
                LoadWordsToHintList();
                LoadWordsToImExTab();
                MessageBox.Show("removed successfully");
            }
        }

        private void WordsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnSwitch.Checked)
            {
                string word = grdWords.Rows[e.RowIndex].Cells[0].Value.ToString();
                string type = grdWords.Rows[e.RowIndex].Cells[1].Value.ToString();
                string mean = grdWords.Rows[e.RowIndex].Cells[2].Value.ToString();
                FrmEdit_Add frm = new FrmEdit_Add(false, word, manager.GetIdOfType(type), mean);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Word obj = frm.PerformAction();
                    grdWords.Rows[e.RowIndex].Cells[2].Value = obj.word_m;
                    MessageBox.Show("Edited successfully");
                }
                frm.Dispose();
            }
            else
            {
                int id = int.Parse(this.grdWords.SelectedRows[0].Cells[0].Value.ToString());
                string type = this.grdWords.SelectedRows[0].Cells[1].Value.ToString();
                FrmAdd_EditType frm = new FrmAdd_EditType(false, id, type);
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Data.Type obj = frm.PerformAction();
                    grdWords.Rows[e.RowIndex].Cells[1].Value = obj.type_description;
                    MessageBox.Show("Edited successfully");
                }
                frm.Dispose();
            }
        }

        private void RecmWordsList_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtSearch.TextChanged -= TxtSearch_TextChanged;
            this.txtSearch.Text = this.lbRecmWords.Items[this.lbRecmWords.IndexFromPoint(e.Location)].ToString();
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (lbRecmWords.Items.Count == 0)
            {
                this.Enabled = false;
                try
                {
                    WebSearcher searcher = new WebSearcher();
                    List<Word> searchResult = searcher.Search(txtSearch.Text);
                    ShowWordInfs(searchResult);
                }catch (Exception ex)
                {
                    if (ex is System.Net.WebException)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Unexpected error has been occured. Please try again",
                            "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                this.Enabled = true;
                return;
            }
            ShowWordInfs(manager.GetWords(txtSearch.Text));
        }

        private void ShowWordInfs(List<Word> data)
        {
            this.rtbMeans.Clear();
            this.AppendText(data[0].word_o + Environment.NewLine, Color.Purple);
            for (int i = 0; i < data.Count; i++)
            {
                this.AppendText("    - " + data[i].Type.type_description + Environment.NewLine, Color.Blue);
                this.AppendText("\t+ " + data[i].word_m + Environment.NewLine, Color.Black);
            }
        }

        private void AppendText(string text, Color color)
        {
            rtbMeans.SelectionStart = rtbMeans.TextLength;
            rtbMeans.SelectionLength = 0;
            rtbMeans.SelectionColor = color;
            rtbMeans.AppendText(text);
            rtbMeans.SelectionColor = rtbMeans.ForeColor;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ShowRecommendWords(this.txtSearch.Text);
        }
       
        private void ShowRecommendWords(string text)
        {
            this.lbRecmWords.DataSource = manager.GetWordsStartWith(text);
            this.lbRecmWords.ClearSelected();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            LoadWordsToHintList();
            LoadWordsToManageList();
            LoadWordsToImExTab();
        }

        private void LoadWordsToImExTab()
        {
            pnlWordsList.Controls.Clear();
            var data = manager.GetDistinctWordsList();
            foreach (string item in data)
            {
                this.pnlWordsList.Controls.Add(new CheckBox() { Checked = false, Text = item, Cursor = Cursors.Hand });
            }
        }

        private void LoadWordsToManageList()
        {
            var data = manager.GetWordsData();
            foreach (var item in data)
            {
                grdWords.Rows.Add(item.word, item.type, item.mean);
            }
        }

        private void LoadTypesToManageList()
        {
            var data = manager.GetTypes();
            foreach (var item in data)
            {
                grdWords.Rows.Add(item.Id, item.type_description);
            }
        }

        private void LoadWordsToHintList()
        {
            this.lbRecmWords.DataSource = manager.GetDistinctWordsList();
            this.lbRecmWords.ClearSelected();
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
