using System.Windows.Forms;
using Dictionary.Data;

namespace Dictionary
{
    public partial class FrmEdit_Add : Form
    {
        private readonly bool shouldAdd = false;

        private readonly string[] key = new string[2];

        private readonly DatabaseManagement manager;

        public FrmEdit_Add(bool shouldAdd, string word = "", int type = -1, string mean = "")
        {
            InitializeComponent();
            manager = new DatabaseManagement();
            this.shouldAdd = shouldAdd;

            this.Load += (sender, e) =>
            {
                LoadTypeList();
                if (this.shouldAdd)
                {
                    this.btnPerform.Text = "Add";
                }
                else
                {
                    key[0] = word;
                    key[1] = type.ToString();
                    this.txtWord.Text = word;
                    this.txtWord.ReadOnly = true;
                    this.cboType.SelectedItem = manager.GetTypeOfId(type);
                    this.cboType.Enabled = false;
                    this.txtMean.Text = mean;
                    this.btnPerform.Text = "Save";
                }
            };
            this.btnPerform.DialogResult = DialogResult.Yes;
            this.btnCancel.Click += (sender, e) => this.Close();
        }

        public void PerformAction(out Word obj)
        {
            if (shouldAdd)
            {
                obj = manager.AddWord(txtWord.Text, int.Parse(cboType.SelectedValue.ToString()), txtMean.Text);
            }
            else
            {
                obj = manager.EditWord(txtWord.Text, int.Parse(cboType.SelectedValue.ToString()), txtMean.Text);
            }
            this.btnCancel.PerformClick();
        }

        private void LoadTypeList()
        {
            this.cboType.DataSource = manager.GetTypes();
            this.cboType.DisplayMember = "type_description";
            this.cboType.ValueMember = "Id";
        }
    }
}
