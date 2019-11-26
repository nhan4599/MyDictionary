
using System.Drawing;
using System.Windows.Forms;

namespace Dictionary
{
    partial class FrmEdit_Add
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
            this.lbWord = new Label();
            this.txtWord = new TextBox();
            this.lbType = new Label();
            this.lbMean = new Label();
            this.txtMean = new TextBox();
            this.cboType = new ComboBox();
            this.btnPerform = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            //
            // lbWord
            //
            this.lbWord.AutoSize = true;
            this.lbWord.Location = new Point(59, 30);
            this.lbWord.Name = "lbWord";
            this.lbWord.Size = new Size(42, 17);
            this.lbWord.TabIndex = 0;
            this.lbWord.Text = "Word";

            //
            // txtWord
            //
            this.txtWord.Location = new Point(149, 25);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new Size(149, 22);
            this.txtWord.TabIndex = 1;

            //
            // lbType
            //
            this.lbType.AutoSize = true;
            this.lbType.Location = new Point(61, 87);
            this.lbType.Name = "lbType";
            this.lbType.Size = new Size(40, 17);
            this.lbType.TabIndex = 2;
            this.lbType.Text = "Type";
            this.lbType.TextAlign = ContentAlignment.MiddleRight;

            //
            // lbMean
            //
            this.lbMean.AutoSize = true;
            this.lbMean.Location = new Point(59, 141);
            this.lbMean.Name = "lbMean";
            this.lbMean.Size = new Size(43, 17);
            this.lbMean.TabIndex = 4;
            this.lbMean.Text = "Mean";

            //
            // txtMean
            //
            this.txtMean.Location = new Point(149, 141);
            this.txtMean.Name = "txtMean";
            this.txtMean.Size = new Size(149, 22);
            this.txtMean.TabIndex = 5;

            //
            // cboType
            //
            this.cboType.Location = new Point(149, 87);
            this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboType.Name = "cboType";
            this.cboType.Size = new Size(121, 24);
            this.cboType.TabIndex = 6;

            //
            // btnPerform
            //
            this.btnPerform.Location = new Point(84, 189);
            this.btnPerform.FlatStyle = FlatStyle.Popup;
            this.btnPerform.Cursor = Cursors.Hand;
            this.btnPerform.BackColor = Color.FromArgb(255, 106, 106);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.Size = new Size(75, 32);
            this.btnPerform.TabIndex = 7;
            this.btnPerform.Text = "Temp";
            this.btnPerform.UseVisualStyleBackColor = true;

            //
            // btnCancel
            //
            this.btnCancel.Location = new Point(240, 189);
            this.btnCancel.FlatStyle = FlatStyle.Popup;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.BackColor = Color.FromArgb(255, 106, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;

            //
            // FrmEdit_Add
            //
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(412, 243);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPerform);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.txtMean);
            this.Controls.Add(this.lbMean);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.lbWord);
            this.Name = "FrmEdit_Add";
            this.Text = "FrmEdit_Add";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lbWord, lbType, lbMean;
        private TextBox txtWord, txtMean;
        private Button btnPerform, btnCancel;
        private ComboBox cboType;
    }
}