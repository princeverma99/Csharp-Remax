using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsRemax2013417
{
    public partial class frmAgent : Form
    {
        public frmAgent()
        {
            InitializeComponent();
        }

        //Global Variables
        int currentIndex;
        DataTable tabAgent;
        string mode;

        private void frmAgent_Load(object sender, EventArgs e)
        {
            tabAgent = clsGlobal.mySet.Tables["Agents"];
            
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
            txtFirstName.Text = tabAgent.Rows[currentIndex]["FirstName"].ToString();
            txtLastName.Text = tabAgent.Rows[currentIndex]["LastName"].ToString();
            dateTimeBday.Text = tabAgent.Rows[currentIndex]["BirthDate"].ToString();
            txtContactNo.Text = tabAgent.Rows[currentIndex]["ContactNumber"].ToString();
            txtUsername.Text = tabAgent.Rows[currentIndex]["Username"].ToString();
            txtPassword.Text = tabAgent.Rows[currentIndex]["Password"].ToString();
            lblInfo.Text = "Agent " + (currentIndex + 1) + " on a total of " + tabAgent.Rows.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            Display();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < (tabAgent.Rows.Count - 1))
            {
                currentIndex++;
                Display();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                Display();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentIndex = tabAgent.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtUsername.Text = txtFirstName.Text = txtLastName.Text = dateTimeBday.Text = txtContactNo.Text = txtPassword.Text = "";

            txtUsername.Focus();
            lblInfo.Text = "----------Add Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtUsername.Focus();
            lblInfo.Text = "----------Editing Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "add")
            {
                DataRow currentRow = tabAgent.NewRow();
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["BirthDate"] = Convert.ToDateTime(dateTimeBday.Text);
                currentRow["ContactNumber"] = txtContactNo.Text;
                currentRow["Username"] = txtUsername.Text;
                currentRow["Password"] = txtPassword.Text;
                tabAgent.Rows.Add(currentRow);
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpAgent);
                clsGlobal.adpAgent.Update(clsGlobal.mySet, "Agents");
                
                clsGlobal.mySet.Tables.Remove("Agents");
                
                clsGlobal.adpAgent.Fill(clsGlobal.mySet, "Agents");

                tabAgent = clsGlobal.mySet.Tables["Agents"];
                
                currentIndex = tabAgent.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                DataRow currentRow = tabAgent.Rows[currentIndex];
                
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["BirthDate"] = Convert.ToDateTime(dateTimeBday.Text);
                currentRow["ContactNumber"] = txtContactNo.Text;
                currentRow["Username"] = txtUsername.Text;
                currentRow["Password"] = txtPassword.Text;
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpAgent);
                clsGlobal.adpAgent.Update(clsGlobal.mySet, "Agents");
                
                clsGlobal.mySet.Tables.Remove("Agents");
                
                clsGlobal.adpAgent.Fill(clsGlobal.mySet, "Agents");

                tabAgent = clsGlobal.mySet.Tables["Agents"];
            }
            Display();
            mode = "";
            ActivateButtons(true, true, true, true, false, false, true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete this Agent", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabAgent.Rows[currentIndex].Delete();

                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpAgent);
                clsGlobal.adpAgent.Update(clsGlobal.mySet, "Agents");
                
                clsGlobal.mySet.Tables.Remove("Agents");
                clsGlobal.adpAgent.Fill(clsGlobal.mySet, "Agents");

                tabAgent = clsGlobal.mySet.Tables["Agents"];
                
                currentIndex = 0;
                Display();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateButtons(true, true, true, true, false, false, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Exit", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
