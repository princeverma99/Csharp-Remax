using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace prjWinCsRemax2013417
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        //Global Variables
        int currentIndex;
        DataTable tabAdmin;
        string mode;

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            tabAdmin = clsGlobal.mySet.Tables["Admins"];
            
            currentIndex = 0;
            Display();
            ActivateButtons(true, true, true, true, false, false, true);
        }

        private void ActivateButtons(bool NavButtons, bool Add, bool Edit, bool Delete, bool Save, bool Cancel, bool Close)
        {
            btnFirst.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnLast.Enabled = NavButtons;
            btnAdd.Enabled = Add;
            btnEdit.Enabled = Edit;
            btnDelete.Enabled = Delete;
            btnSave.Enabled = Save;
            btnCancel.Enabled = Cancel;
            btnClose.Enabled = Close;
        }

        private void Display()
        {
            txtFirstName.Text = tabAdmin.Rows[currentIndex]["FirstName"].ToString();
            txtLastName.Text = tabAdmin.Rows[currentIndex]["LastName"].ToString();
            txtContactNo.Text = tabAdmin.Rows[currentIndex]["ContactNumber"].ToString();
            txtUsername.Text = tabAdmin.Rows[currentIndex]["Username"].ToString();
            txtPassword.Text = tabAdmin.Rows[currentIndex]["Password"].ToString();
            lblInfo.Text = "Admin " + (currentIndex + 1) + " on a total of " + tabAdmin.Rows.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            Display();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(currentIndex < (tabAdmin.Rows.Count - 1))
            {
                currentIndex++;
                Display();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(currentIndex > 0)
            {
                currentIndex--;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentIndex = tabAdmin.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtUsername.Text = txtFirstName.Text = txtLastName.Text = txtContactNo.Text = txtPassword.Text = "";

            txtFirstName.Focus();
            lblInfo.Text = "----------Add Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtFirstName.Focus();
            lblInfo.Text = "----------Editing Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Delete this Admin", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                tabAdmin.Rows[currentIndex].Delete();
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpAdmin);
                clsGlobal.adpAdmin.Update(clsGlobal.mySet, "Admins");
                
                clsGlobal.mySet.Tables.Remove("Admins");
                clsGlobal.adpAdmin.Fill(clsGlobal.mySet, "Admins");

                tabAdmin = clsGlobal.mySet.Tables["Admins"];
                
                currentIndex = 0;
                Display();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "add")
            {
                DataRow currentRow = tabAdmin.NewRow();

                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["ContactNumber"] = txtContactNo.Text;
                currentRow["Username"] = txtUsername.Text;
                currentRow["Password"] = txtPassword.Text;
                tabAdmin.Rows.Add(currentRow);
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpAdmin);
                clsGlobal.adpAdmin.Update(clsGlobal.mySet, "Admins");
                
                clsGlobal.mySet.Tables.Remove("Admins");
                
                clsGlobal.adpAdmin.Fill(clsGlobal.mySet, "Admins");

                tabAdmin = clsGlobal.mySet.Tables["Admins"];
                
                currentIndex = tabAdmin.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                DataRow currentRow = tabAdmin.Rows[currentIndex];
                
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["ContactNumber"] = txtContactNo.Text;
                currentRow["Username"] = txtUsername.Text;
                currentRow["Password"] = txtPassword.Text;
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpAdmin);
                clsGlobal.adpAdmin.Update(clsGlobal.mySet, "Admins");
                
                clsGlobal.mySet.Tables.Remove("Admins");
                
                clsGlobal.adpAdmin.Fill(clsGlobal.mySet, "Admins");

                tabAdmin = clsGlobal.mySet.Tables["Admins"];
            }
            Display();
            mode = "";
            ActivateButtons(true, true, true, true, false, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Exit","Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateButtons(true, true, true, true, false, false, true);
        }
    }
}
