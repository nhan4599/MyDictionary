﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dictionary.Data;

namespace Dictionary
{
    public partial class FrmAdd_EditType : Form
    {
        bool shouldAdd = false;
        DatabaseManagement manager;
        string[] key = new string[2];
        public FrmAdd_EditType(bool shouldAdd, int id = -1, string type = "")
        {
            InitializeComponent();
            manager = new DatabaseManagement();
            this.shouldAdd = shouldAdd;
            key[0] = id.ToString();
            key[1] = type;
            this.Load += FrmEdit_AddTypeLoad;
            this.btnTypeSave.DialogResult = DialogResult.Yes;
            this.btnTypeCancel.Click += (sender, e) => this.Close();
        }

        private void FrmEdit_AddTypeLoad(object sender, EventArgs e)
        {
            if (shouldAdd)
            {
                this.Text = "Add new type";
                this.btnTypeSave.Text = "Add";
            }
            else
            {
                this.Text = string.Format("Edit type \"{0}\"", key[1]);
                this.btnTypeSave.Text = "Save";
            }
        }

        public void PerformAction(out Data.Type obj)
        {
            if (shouldAdd)
            {
                obj = manager.AddType(txtType.Text);
            }
            else
            {
                obj = manager.EditType(int.Parse(key[0]), txtType.Text);
            }
            this.btnTypeCancel.PerformClick();
        }
    }
}