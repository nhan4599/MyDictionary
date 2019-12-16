
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
            this.lblWord = new Label();
            this.txtWord = new TextBox();
            this.lblType = new Label();
            this.lblMean = new Label();
            this.txtMean = new TextBox();
            this.cboType = new ComboBox();
            this.btnPerform = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            //
            // lbWord
            //
            this.lblWord.AutoSize = true;
            this.lblWord.Location = new Point(59, 30);
            this.lblWord.Name = "lbWord";
            this.lblWord.Size = new Size(42, 17);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "Word";

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
            this.lblType.AutoSize = true;
            this.lblType.Location = new Point(61, 87);
            this.lblType.Name = "lbType";
            this.lblType.Size = new Size(40, 17);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = ContentAlignment.MiddleRight;

            //
            // lbMean
            //
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new Point(59, 141);
            this.lblMean.Name = "lbMean";
            this.lblMean.Size = new Size(43, 17);
            this.lblMean.TabIndex = 4;
            this.lblMean.Text = "Mean";

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
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.lblWord);
            this.Name = "FrmEdit_Add";
            this.Text = "FrmEdit_Add";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblWord, lblType, lblMean;
        private TextBox txtWord, txtMean;
        private Button btnPerform, btnCancel;
        private ComboBox cboType;
    }
}