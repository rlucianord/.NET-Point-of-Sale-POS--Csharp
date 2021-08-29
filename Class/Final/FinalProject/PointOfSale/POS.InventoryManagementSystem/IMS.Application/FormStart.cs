﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalPoject.UserInterface.Dashboard;
using Guna.UI2.WinForms;

namespace FinalPoject
{
    public partial class FormStart : Form
    {
        private string role;
        public FormStart(string role)
        {
            InitializeComponent();
            this.role = role;

            if (role == "Admin")
            {
                SetupForAdmin();
            }
            else if(role=="Cashier")
            {
                SetupForCashier();
            }

            this.lblShowUserInfo.Text = this.role;
        }

        void SetupForAdmin()
        {
            btnDashboard.Enabled = true;
            btnMakeSell.Enabled = true;
            btnMasterCustomers.Enabled = true;
            btnMasterProducts.Enabled = true;
            btnMasterStock.Enabled = true;
        }

        void SetupForCashier()
        {
            btnDashboard.Enabled = true;
            btnMakeSell.Enabled = true;
            btnMasterCustomers.Enabled = false;
            btnMasterProducts.Enabled = true;
            btnMasterStock.Enabled = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ViewForm(new FormDashboard());
        }

        private void btnMakeSell_Click(object sender, EventArgs e)
        {
            FormMakeSale makeSale = new FormMakeSale();
            makeSale.ShowDialog();
        }

        private void btnMasterStock_Click(object sender, EventArgs e)
        {
            FormAddProduct addProduct = new FormAddProduct();
            addProduct.ShowDialog();
        }

        private void btnMasterProducts_Click(object sender, EventArgs e)
        {
            ViewForm(new FormProductsMaster());
        }

        private void btnMasterUser_Click(object sender, EventArgs e)
        {
            ViewForm(new FormUser());
        }

        private void btnMasterCustomer_Click(object sender, EventArgs e)
        {

        }

        private void btnSellingHistory_Click(object sender, EventArgs e)
        {
            ViewForm( new FormSellsHistory());
        }

        public void ViewForm(object _form)
        {
            if (pnlFormViwer.Controls.Count > 0) pnlFormViwer.Controls.Clear();
            {
                Form form = _form as Form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pnlFormViwer.Controls.Add(form);
                pnlFormViwer.Tag = form;
                form.Show();
            }
        }
    }
}
