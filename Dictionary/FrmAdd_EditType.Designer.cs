using System.Drawing;
using System.Windows.Forms;

namespace Dictionary
{
    partial class FrmAdd_EditType
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
            this.lbType = new Label();
            this.txtType = new TextBox();
            this.btnTypeCancel = new Button();
            this.btnTypeSave = new Button();
            this.SuspendLayout();

            // 
            // lblType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = Color.Red;
            this.lbType.Location = new Point(100, 10);
            this.lbType.Name = "lblType";
            this.lbType.Size = new Size(61, 27);
            this.lbType.TabIndex = 3;
            this.lbType.Text = "Type";

            // 
            // txtType
            // 
            this.txtType.Location = new Point(41, 53);
            this.txtType.Name = "txtType";
            this.txtType.Size = new Size(189, 24);
            this.txtType.TabIndex = 0;

            // 
            // btnTypeCancel
            // 
            this.btnTypeCancel.Font = new Font("Microsoft PhagsPa", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeCancel.Location = new Point(41, 94);
            this.btnTypeCancel.Name = "btnTypeCancel";
            this.btnTypeCancel.Size = new Size(75, 40);
            this.btnTypeCancel.TabIndex = 2;
            this.btnTypeCancel.Text = "Cancel";
            this.btnTypeCancel.UseVisualStyleBackColor = true;
            // 
            // btnTypeSave
            // 
            this.btnTypeSave.Font = new Font("Microsoft PhagsPa", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnTypeSave.Location = new Point(155, 94);
            this.btnTypeSave.Name = "btnTypeSave";
            this.btnTypeSave.Size = new Size(75, 40);
            this.btnTypeSave.TabIndex = 1;
            this.btnTypeSave.Text = "Save";
            this.btnTypeSave.UseVisualStyleBackColor = true;

            // 
            // FrmAddType
            // 
            this.AutoScaleDimensions = new SizeF(8F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.MintCream;
            this.ClientSize = new Size(268, 146);
            this.StartPosition = FormStartPosition.CenterParent;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Controls.Add(this.btnTypeSave);
            this.Controls.Add(this.btnTypeCancel);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lbType);
            this.Font = new System.Drawing.Font("Microsoft PhagsPa", 7.8F, FontStyle.Bold,GraphicsUnit.Point);
            this.Name = "FrmAddType";
            this.Text = "FrmAddType";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnTypeCancel;
        private System.Windows.Forms.Button btnTypeSave;
    }
}