using System.Drawing;
using System.Windows.Forms;

namespace Dictionary
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        bool test = true;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSeparator = new TabControl();
            this.tabSearch = new TabPage();
            this.tabManage = new TabPage();
            this.tabIm_Ex = new TabPage();

            // initialize controls for tab search
            this.txtSearch = new TextBox();
            this.btnClear = new Button();
            this.btnPronounce = new Button();
            this.txtMeans = new RichTextBox();
            this.recmWordsList = new ListBox();
            this.btnFind = new Button();

            // initialize controls for tab manage
            this.lbTitle = new Label();
            this.lbHelp = new LinkLabel();
            this.wordsTable = new DataGridView();
            this.btnAdd = new Button();
            this.btnDelete = new Button();

            // initialize controls for tab im_ex
            this.boxExport = new GroupBox();
            this.btnDeSelect = new Button();
            this.btnSelect = new Button();
            this.btnExport = new Button();
            this.wordListPanel = new FlowLayoutPanel();
            this.boxImport = new GroupBox();
            this.txtPath = new TextBox();
            this.lbPath = new Label();
            this.btnDirect = new Button();
            this.btnImport = new Button();
            this.frmSave = new SaveFileDialog();
            this.frmOpen = new OpenFileDialog();

            // SuspendLayout
            this.tabSeparator.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.txtMeans.SuspendLayout();
            this.tabManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsTable)).BeginInit();
            this.tabIm_Ex.SuspendLayout();
            this.boxExport.SuspendLayout();
            this.boxImport.SuspendLayout();
            this.SuspendLayout();

            //
            // tabSeparator
            //
            this.tabSeparator.Controls.Add(this.tabSearch);
            this.tabSeparator.Controls.Add(this.tabManage);
            this.tabSeparator.Controls.Add(this.tabIm_Ex);
            this.tabSeparator.Location = new System.Drawing.Point(0, 0);
            this.tabSeparator.Name = "tabSeparator";
            this.tabSeparator.Size = new System.Drawing.Size(860, 451);

            //
            // tabSearch
            //
            this.tabSearch.BackColor = System.Drawing.Color.MintCream;
            this.tabSearch.Controls.Add(this.btnClear);
            this.tabSearch.Controls.Add(this.txtMeans);
            this.tabSearch.Controls.Add(this.recmWordsList);
            this.tabSearch.Controls.Add(this.txtSearch);
            this.tabSearch.Controls.Add(this.btnFind);
            this.tabSearch.Location = new System.Drawing.Point(4, 25);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(847, 422);
            this.tabSearch.Text = "Search";

            //
            // btnClear
            //
            this.btnClear.BackColor = Color.FromArgb(255, 106, 106);
            this.btnClear.FlatStyle = FlatStyle.Popup;
            this.btnClear.Font = new Font("Microsoft PhagsPa", 9F, FontStyle.Bold);
            this.btnClear.Location = new Point(699, 50);
            this.btnClear.Name = "button2";
            this.btnClear.Size = new Size(93, 33);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;

            //
            // btnPronounce
            //
            this.btnPronounce.Image = Properties.Resources.Speaker;
            this.btnPronounce.Location = new Point(280, 5);
            this.btnPronounce.Name = "btnPronounce";
            this.btnPronounce.Size = new Size(47, 37);
            this.btnPronounce.UseVisualStyleBackColor = true;

            //
            // txtMeans
            //
            this.txtMeans.Controls.Add(this.btnPronounce);
            this.txtMeans.Location = new Point(404, 108);
            this.txtMeans.Multiline = true;
            this.txtMeans.Name = "txtMeans";
            this.txtMeans.ReadOnly = true;
            this.txtMeans.Size = new Size(335, 230);
            this.txtMeans.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

            //
            // recmWordsList
            //
            this.recmWordsList.Location = new Point(55, 108);
            this.recmWordsList.Font = new Font("Arial", 10, FontStyle.Italic);
            this.recmWordsList.Name = "recmWordsList";
            this.recmWordsList.Size = new Size(308, 230);

            //
            // txtSearch
            //
            this.txtSearch.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold);
            this.txtSearch.Location = new Point(55, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(482, 28);

            //
            // btnFind
            //
            this.btnFind.BackColor = Color.FromArgb(255, 106, 106);
            this.btnFind.FlatStyle = FlatStyle.Popup;
            this.btnFind.Font = new Font("Microsoft PhagsPa", 9F, FontStyle.Bold);
            this.btnFind.Location = new Point(572, 50);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new Size(93, 33);
            this.btnFind.Text = "Search";
            this.btnFind.UseVisualStyleBackColor = false;

            //
            // tabMange
            //
            this.tabManage.BackColor = System.Drawing.Color.MintCream;
            this.tabManage.Controls.Add(this.wordsTable);
            this.tabManage.Controls.Add(this.lbTitle);
            this.tabManage.Controls.Add(this.lbHelp);
            this.tabManage.Controls.Add(this.btnDelete);
            this.tabManage.Controls.Add(this.btnAdd);
            this.tabManage.Location = new System.Drawing.Point(4, 25);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabManage.Size = new System.Drawing.Size(847, 422);
            this.tabManage.Text = "Manage";

            //
            // wordsTable
            //
            this.wordsTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.wordsTable.BackgroundColor = Color.Honeydew;
            this.wordsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsTable.MultiSelect = false;
            this.wordsTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.wordsTable.Location = new Point(37, 70);
            this.wordsTable.ReadOnly = true;
            this.wordsTable.AllowUserToAddRows = false;
            this.wordsTable.RowHeadersVisible = false;
            this.wordsTable.Columns.Add("col1", "Word");
            this.wordsTable.Columns.Add("col2", "Type");
            this.wordsTable.Columns.Add("col3", "Mean");
            this.wordsTable.Name = "wordsTable";
            this.wordsTable.Size = new Size(774, 280);
            this.wordsTable.TabIndex = 0;

            //
            // tabIm_Ex
            //
            this.tabIm_Ex.BackColor = System.Drawing.Color.MintCream;
            this.tabIm_Ex.Controls.Add(this.boxExport);
            this.tabIm_Ex.Controls.Add(this.boxImport);
            this.tabIm_Ex.Location = new System.Drawing.Point(4, 25);
            this.tabIm_Ex.Name = "tabIm_Ex";
            this.tabIm_Ex.Padding = new System.Windows.Forms.Padding(3);
            this.tabIm_Ex.Size = new System.Drawing.Size(847, 422);
            this.tabIm_Ex.Text = "Import / Export";

            //
            // boxImport
            //
            this.boxImport.Location = new Point(61, 42);
            this.boxImport.Name = "boxImport";
            this.boxImport.Size = new Size(682, 59);
            this.boxImport.Controls.Add(this.lbPath);
            this.boxImport.Controls.Add(this.txtPath);
            this.boxImport.Controls.Add(this.btnDirect);
            this.boxImport.Controls.Add(this.btnImport);
            this.boxImport.TabStop = false;
            this.boxImport.Text = "Import";

            //
            // boxExport
            //
            this.boxExport.Controls.Add(this.btnDeSelect);
            this.boxExport.Controls.Add(this.btnSelect);
            this.wordListPanel.BorderStyle = BorderStyle.Fixed3D;
            this.boxExport.Controls.Add(this.wordListPanel);
            this.boxExport.Controls.Add(this.btnExport);
            this.boxExport.Location = new Point(61, 132);
            this.boxExport.Name = "boxExport";
            this.boxExport.Size = new Size(682, 226);
            this.boxExport.TabStop = false;
            this.boxExport.Text = "Export";

            //
            // wordsListPanel
            //
            this.wordListPanel.Location = new Point(42, 32);
            this.wordListPanel.Name = "wordListPanel";
            this.wordListPanel.Size = new Size(386, 171);
            this.wordListPanel.FlowDirection = FlowDirection.LeftToRight;
            this.wordListPanel.AutoScroll = true;

            //
            // btnSelect
            //
            this.btnSelect.BackColor = Color.FromArgb(255, 106, 106);
            this.btnSelect.FlatStyle = FlatStyle.Popup;
            this.btnSelect.Font = new Font("Microsoft PhagsPa", 9F, FontStyle.Bold);
            this.btnSelect.Location = new Point(434, 32);
            this.btnSelect.Name = "button4";
            this.btnSelect.Size = new Size(115, 33);
            this.btnSelect.Text = "Select all";
            this.btnSelect.UseVisualStyleBackColor = false;

            //
            // btnExport
            //
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(255, 106, 106);
            this.btnExport.FlatStyle = FlatStyle.Popup;
            this.btnExport.Font = new Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new Point(492, 99);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new Size(115, 33);
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;

            //
            // btnImport
            //
            this.btnImport.BackColor = Color.FromArgb(255, 106, 106);
            this.btnImport.FlatStyle = FlatStyle.Popup;
            this.btnImport.Location = new Point(620, 19);
            this.btnImport.Size = new Size(this.btnImport.Size.Width - 20, this.btnImport.Size.Height);
            this.btnImport.Text = "Import";
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;

            //
            // btnDeSelect
            //
            this.btnDeSelect.BackColor = Color.FromArgb(255, 106, 106);
            this.btnDeSelect.FlatStyle = FlatStyle.Popup;
            this.btnDeSelect.Font = new Font("Microsoft PhagsPa", 9F, FontStyle.Bold);
            this.btnDeSelect.Location = new Point(555, 32);
            this.btnDeSelect.Name = "btnDeSelect";
            this.btnDeSelect.Size = new Size(111, 33);
            this.btnDeSelect.Text = "Deselect all";
            this.btnDeSelect.UseVisualStyleBackColor = false;

            //
            // txtPath
            //
            this.txtPath.Location = new Point(95, 21);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new Size(467, 22);
            this.txtPath.ReadOnly = true;
            this.txtPath.TabIndex = 0;

            //
            // lbPath
            //
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new Point(43, 24);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new Size(37, 17);
            this.lbPath.Text = "Path";
            this.lbPath.TextAlign = ContentAlignment.MiddleRight;

            //
            // lbHelp
            //
            this.lbHelp.AutoSize = true;
            this.lbHelp.Location = new Point(673, 33);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new Size(156, 17);
            this.lbHelp.TabStop = true;
            this.lbHelp.Text = "Help me to use this tool";

            //
            // btnDelete
            //
            this.btnDelete.BackColor = Color.FromArgb(255, 106, 106);
            this.btnDelete.FlatStyle = FlatStyle.Popup;
            this.btnDelete.Location = new Point(499, 369);
            this.btnDelete.Name = "btnSave";
            this.btnDelete.Size = new Size(116, 26);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;

            //
            // btnAdd
            //
            this.btnAdd.BackColor = Color.FromArgb(255, 106, 106);
            this.btnAdd.FlatStyle = FlatStyle.Popup;
            this.btnAdd.Location = new Point(250, 369);
            this.btnAdd.Name = "btnSave";
            this.btnAdd.Size = new Size(116, 26);
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;

            //
            // lbTitle
            //
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = Color.Red;
            this.lbTitle.Location = new Point(247, 21);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new Size(350, 32);
            this.lbTitle.Text = "Dictionary Management Tool";

            //
            // btnDirect
            //
            this.btnDirect.BackColor = Color.FromArgb(255, 106, 106);
            this.btnDirect.FlatStyle = FlatStyle.Popup;
            this.btnDirect.Location = new Point(575, 19);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new Size(35, 23);
            this.btnDirect.Text = "...";
            this.btnDirect.UseVisualStyleBackColor = true;

            //
            // frmSave
            //
            this.frmSave.InitialDirectory = @"C:\";
            this.frmSave.Filter = "Excel (*.xlsx)|*.xlsx|Comma separated values (*.csv)|*.csv";
            this.frmSave.RestoreDirectory = true;

            //
            // frmOpen
            //
            this.frmOpen.InitialDirectory = @"C:\";
            this.frmOpen.Filter = frmSave.Filter;
            this.frmOpen.RestoreDirectory = false;

            //
            // GUI
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ClientSize = new Size(858, 440);
            this.Controls.Add(this.tabSeparator);
            this.Name = "GUI";
            this.Text = "Your dictionary";
            this.Icon = Properties.Resources.AppIcon;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.tabSeparator.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.txtMeans.ResumeLayout(false);
            this.tabManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wordsTable)).EndInit();
            this.tabIm_Ex.ResumeLayout(false);
            this.boxExport.ResumeLayout(false);
            this.boxImport.ResumeLayout(false);
            this.boxImport.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private TabControl tabSeparator;
        private TabPage tabSearch, tabManage, tabIm_Ex;
        private Button btnPronounce, btnFind, btnClear, btnSelect, btnDeSelect, btnDirect, btnExport, btnDelete;
        private Button btnAdd, btnImport;
        private TextBox txtSearch, txtPath;
        private RichTextBox txtMeans;
        private ListBox recmWordsList;
        private DataGridView wordsTable;
        private GroupBox boxImport, boxExport;
        private FlowLayoutPanel wordListPanel;
        private Label lbPath, lbTitle;
        private LinkLabel lbHelp;
        private SaveFileDialog frmSave;
        private OpenFileDialog frmOpen;
    }
}