using System.Windows.Forms;
using Dictionary.Data;

namespace Dictionary
{
    public partial class FrmEdit_Add : Form
    {
        private readonly bool shouldAdd = false;

        private readonly string[] key = new string[3];

        private readonly DatabaseManagement manager;

        public FrmEdit_Add(bool shouldAdd, string word = "", int type = -1, string mean = "")
        {
            InitializeComponent();
            manager = new DatabaseManagement();
            this.shouldAdd = shouldAdd;
            key[0] = word;
            key[1] = type.ToString();
            key[2] = mean;
            this.Load += FrmEdit_Add_Load;
            this.btnPerform.DialogResult = DialogResult.Yes;
            this.btnCancel.Click += (sender, e) => this.Close();
        }

        void FrmEdit_Add_Load(object sender, System.EventArgs e)
        {
            LoadTypeList();
            if (this.shouldAdd)
            {
                this.btnPerform.Text = "Add";
            }
            else
            {
                this.txtWord.Text = key[0];
                this.txtWord.ReadOnly = true;
                this.cboType.SelectedItem = manager.GetTypeOfId(int.Parse(key[1]));
                this.cboType.Enabled = false;
                this.txtMean.Text = key[2];
                this.btnPerform.Text = "Save";
            }
        }

        public Word PerformAction()
        {
            Word result;
            if (shouldAdd)
            {
                result = manager.AddWord(txtWord.Text, int.Parse(cboType.SelectedValue.ToString()), txtMean.Text);
            }
            else
            {
                result = manager.EditWord(txtWord.Text, int.Parse(cboType.SelectedValue.ToString()), txtMean.Text);
            }
            this.btnCancel.PerformClick();
            return result;
        }

        private void LoadTypeList()
        {
            this.cboType.DataSource = manager.GetTypes();
            this.cboType.DisplayMember = "type_description";
            this.cboType.ValueMember = "Id";
        }
    }
}
