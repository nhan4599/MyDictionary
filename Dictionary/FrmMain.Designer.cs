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
            this.rtbMeans = new RichTextBox();
            this.lbRecmWords = new ListBox();
            this.btnFind = new Button();

            // initialize controls for tab manage
            this.lblTitle = new Label();
            this.lblHelp = new LinkLabel();
            this.grdWords = new DataGridView();
            this.btnAdd = new Button();
            this.btnSwitch = new CheckBox();
            this.btnDelete = new Button();

            // initialize controls for tab im_ex
            this.boxExport = new GroupBox();
            this.btnDeSelect = new Button();
            this.btnSelect = new Button();
            this.btnExport = new Button();
            this.pnlWordsList = new FlowLayoutPanel();
            this.boxImport = new GroupBox();
            this.txtPath = new TextBox();
            this.lblPath = new Label();
            this.btnBrowse = new Button();
            this.btnImport = new Button();
            this.frmSave = new SaveFileDialog();
            this.frmOpen = new OpenFileDialog();

            // SuspendLayout
            this.tabSeparator.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.rtbMeans.SuspendLayout();
            this.tabManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWords)).BeginInit();
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
            this.tabSearch.Controls.Add(this.btnClear);
            this.tabSearch.Controls.Add(this.rtbMeans);
            this.tabSearch.Controls.Add(this.lbRecmWords);
            this.tabSearch.Controls.Add(this.txtSearch);
            this.tabSearch.Controls.Add(this.btnFind);
            this.tabSearch.Controls.Add(this.btnPronounce);
            this.tabSearch.Location = new System.Drawing.Point(4, 25);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(847, 422);
            this.tabSearch.Text = "Search";

            //
            // btnClear
            //
            this.btnClear.BackgroundImage = Properties.Resources._6;
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
            this.btnPronounce.Location = new Point(760, 107);
            this.btnPronounce.Name = "btnPronounce";
            this.btnPronounce.Size = new Size(47, 37);
            this.btnPronounce.UseVisualStyleBackColor = true;

            //
            // rtbMeans
            //
            this.rtbMeans.Location = new Point(404, 108);
            this.rtbMeans.Multiline = true;
            this.rtbMeans.Name = "txtMeans";
            this.rtbMeans.ReadOnly = true;
            this.rtbMeans.Size = new Size(335, 230);
            this.rtbMeans.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);

            //
            // lbRecmWords
            //
            this.lbRecmWords.Location = new Point(55, 108);
            this.lbRecmWords.Font = new Font("Arial", 10, FontStyle.Italic);
            this.lbRecmWords.Name = "recmWordsList";
            this.lbRecmWords.Size = new Size(308, 230);

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
            this.btnFind.BackgroundImage = Properties.Resources._6;
            this.btnFind.FlatStyle = FlatStyle.Popup;
            this.btnFind.Font = new Font("Microsoft PhagsPa", 9F, FontStyle.Bold);
            this.btnFind.Location = new Point(572, 50);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new Size(93, 33);
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;

            //
            // tabMange
            //
            this.tabManage.BackgroundImage = Properties.Resources._8;
            this.tabManage.Controls.Add(this.grdWords);
            this.tabManage.Controls.Add(this.lblTitle);
            this.tabManage.Controls.Add(this.lblHelp);
            this.tabManage.Controls.Add(this.btnDelete);
            this.tabManage.Controls.Add(this.btnAdd);
            this.tabManage.Controls.Add(this.btnSwitch);
            this.tabManage.Location = new System.Drawing.Point(4, 25);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabManage.Size = new System.Drawing.Size(847, 422);
            this.tabManage.Text = "Manage";

            //
            // grdWords
            //
            this.grdWords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.grdWords.BackgroundColor = Color.Honeydew;
            this.grdWords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWords.MultiSelect = false;
            this.grdWords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grdWords.Location = new Point(37, 70);
            this.grdWords.ReadOnly = true;
            this.grdWords.AllowUserToAddRows = false;
            this.grdWords.RowHeadersVisible = false;
            this.grdWords.Columns.Add("col1", "Word");
            this.grdWords.Columns.Add("col2", "Type");
            this.grdWords.Columns.Add("col3", "Mean");
            this.grdWords.Name = "wordsTable";
            this.grdWords.Size = new Size(774, 280);
            this.grdWords.TabIndex = 0;

            //
            // tabIm_Ex
            //
            this.tabIm_Ex.BackgroundImage = Properties.Resources._8;
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
            this.boxImport.Controls.Add(this.lblPath);
            this.boxImport.Controls.Add(this.txtPath);
            this.boxImport.Controls.Add(this.btnBrowse);
            this.boxImport.Controls.Add(this.btnImport);
            this.boxImport.TabStop = false;
            this.boxImport.BackColor = Color.Pink;
            this.boxImport.Text = "Import";

            //
            // boxExport
            //
            this.boxExport.Controls.Add(this.btnDeSelect);
            this.boxExport.Controls.Add(this.btnSelect);
            this.pnlWordsList.BorderStyle = BorderStyle.Fixed3D;
            this.boxExport.Controls.Add(this.pnlWordsList);
            this.boxExport.Controls.Add(this.btnExport);
            this.boxExport.Location = new Point(61, 132);
            this.boxExport.Name = "boxExport";
            this.boxExport.Size = new Size(682, 226);
            this.boxExport.TabStop = false;
            this.boxExport.BackColor = Color.Pink;
            this.boxExport.Text = "Export";

            //
            // pnlWordsList
            //
            this.pnlWordsList.Location = new Point(42, 32);
            this.pnlWordsList.Name = "wordListPanel";
            this.pnlWordsList.Size = new Size(386, 171);
            this.pnlWordsList.FlowDirection = FlowDirection.LeftToRight;
            this.pnlWordsList.AutoScroll = true;

            //
            // btnSelect
            //
            this.btnSelect.BackgroundImage = Properties.Resources._6;
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
            this.btnExport.BackgroundImage = Properties.Resources._6;
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
            this.btnImport.BackgroundImage = Properties.Resources._6;
            this.btnImport.FlatStyle = FlatStyle.Popup;
            this.btnImport.Location = new Point(620, 19);
            this.btnImport.Size = new Size(this.btnImport.Size.Width - 20, this.btnImport.Size.Height);
            this.btnImport.Text = "Import";
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;

            //
            // btnDeSelect
            //
            this.btnDeSelect.BackgroundImage = Properties.Resources._6;
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
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new Point(43, 24);
            this.lblPath.Name = "lbPath";
            this.lblPath.Size = new Size(37, 17);
            this.lblPath.Text = "Path";
            this.lblPath.TextAlign = ContentAlignment.MiddleRight;

            //
            // lbHelp
            //
            this.lblHelp.AutoSize = true;
            this.lblHelp.Location = new Point(673, 33);
            this.lblHelp.Name = "lbHelp";
            this.lblHelp.Size = new Size(156, 17);
            this.lblHelp.TabStop = true;
            this.lblHelp.Text = "Help me to use this tool";
            this.lblHelp.BackColor = Color.Transparent;

            //
            // btnDelete
            //
            this.btnDelete.BackgroundImage = Properties.Resources._6;
            this.btnDelete.FlatStyle = FlatStyle.Popup;
            this.btnDelete.Location = new Point(499, 369);
            this.btnDelete.Name = "btnSave";
            this.btnDelete.Size = new Size(116, 26);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;

            //
            // btnAdd
            //
            this.btnAdd.BackgroundImage = Properties.Resources._6;
            this.btnAdd.FlatStyle = FlatStyle.Popup;
            this.btnAdd.Location = new Point(250, 369);
            this.btnAdd.Name = "btnSave";
            this.btnAdd.Size = new Size(116, 26);
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;

            //
            // btnSwitch
            //
            this.btnSwitch.FlatStyle = FlatStyle.Flat;
            this.btnSwitch.TextAlign = ContentAlignment.MiddleCenter;
            this.btnSwitch.BackgroundImage = Properties.Resources._6;
            this.btnSwitch.Appearance = Appearance.Button;
            this.btnSwitch.Location = new Point(110, 25);
            this.btnSwitch.Size = new Size(50, 23);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;

            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Red;
            this.lblTitle.Location = new Point(247, 21);
            this.lblTitle.Name = "lbTitle";
            this.lblTitle.Size = new Size(350, 32);
            this.lblTitle.Text = "Dictionary Management Tool";
            this.lblTitle.BackColor = Color.Transparent;

            //
            // btnDirect
            //
            this.btnBrowse.BackgroundImage = Properties.Resources._6;
            this.btnBrowse.FlatStyle = FlatStyle.Popup;
            this.btnBrowse.Location = new Point(575, 19);
            this.btnBrowse.Name = "btnDirect";
            this.btnBrowse.Size = new Size(35, 23);
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;

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
            this.tabSearch.BackgroundImage = Properties.Resources._8;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.tabSeparator.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.rtbMeans.ResumeLayout(false);
            this.tabManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWords)).EndInit();
            this.tabIm_Ex.ResumeLayout(false);
            this.boxExport.ResumeLayout(false);
            this.boxImport.ResumeLayout(false);
            this.boxImport.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private TabControl tabSeparator;
        private TabPage tabSearch, tabManage, tabIm_Ex;
        private Button btnPronounce, btnFind, btnClear, btnSelect, btnDeSelect, btnBrowse, btnExport, btnDelete;
        private Button btnAdd, btnImport;
        private CheckBox btnSwitch;
        private TextBox txtSearch, txtPath;
        private RichTextBox rtbMeans;
        private ListBox lbRecmWords;
        private DataGridView grdWords;
        private GroupBox boxImport, boxExport;
        private FlowLayoutPanel pnlWordsList;
        private Label lblPath, lblTitle;
        private LinkLabel lblHelp;
        private SaveFileDialog frmSave;
        private OpenFileDialog frmOpen;
    }
}