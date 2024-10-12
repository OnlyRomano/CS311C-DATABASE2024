﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311C_DATABASE2024
{
    public partial class frmMain : Form
    {
        private string username, usertype;
        public frmMain(string username, string usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }

        bool sidebarexpand = true;
        private void sidebartimer_Tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 66)
                {
                    sidebarexpand = false;
                    sidebartimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 214)
                {
                    sidebarexpand = true;
                    sidebartimer.Stop();
                }
            }
        }

        bool menuExpand = false;
        private void menutransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menucontainer.Height += 10;
                if (menucontainer.Height >= 361)
                {
                    menutransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menucontainer.Height -= 10;
                if (menucontainer.Height <= 51)
                {
                    menutransition.Stop();
                    menuExpand = false;
                }
            }
        }
        private void menu_Click(object sender, EventArgs e)
        {
            sidebartimer.Start();
        }

        private void btnMaintenance_Click_1(object sender, EventArgs e)
        {
            menutransition.Start();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmlogin loginform = new frmlogin();
            loginform.Show();
        }

        private void btnaccount_Click_1(object sender, EventArgs e)
        {
            frmAccounts accountsform = new frmAccounts(username);
            accountsform.MdiParent = this;
            accountsform.Show();
        }

        private void btnstudents_Click_1(object sender, EventArgs e)
        {
            frmStudents studentform = new frmStudents(username);
            studentform.MdiParent = this;
            studentform.Show();
        }

        private void btncourse_Click_1(object sender, EventArgs e)
        {
            frmCourses coursefrm = new frmCourses(username);
            coursefrm.MdiParent = this;
            coursefrm.Show();
        }

        private void btnstrand_Click_1(object sender, EventArgs e)
        {
            frmStrands strandfrm = new frmStrands(username);
            strandfrm.MdiParent = this;
            strandfrm.Show();
        }

        private void btnviolation_Click_1(object sender, EventArgs e)
        {
            frmViolation violationfrm = new frmViolation(username);
            violationfrm.MdiParent = this;
            violationfrm.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Username: " + username;
            toolStripStatusLabel2.Text = "User Type: " + usertype;

            if (usertype == "BRANCH ADMINISTRATOR")
            {
                btnaccount.Hide();
            }
            if (usertype == "STAFF")
            {
                btnaccount.Hide();
                btnstudents.Hide();
            }
        }
    }
}