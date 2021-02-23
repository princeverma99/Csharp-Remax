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
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        //Global Variables
        int currentIndex;
        DataTable tabClient, tabAgent;
        string mode;

        private void frmClient_Load(object sender, EventArgs e)
        {
            tabClient = clsGlobal.mySet.Tables["Clients"];
            tabAgent = clsGlobal.mySet.Tables["Agents"];

            DataColumn[] keys = new DataColumn[1];
            keys[0] = tabAgent.Columns["EmployeeNumber"];
            tabAgent.PrimaryKey = keys;

            foreach(DataRow myrow in tabAgent.Rows)
            {
                comboBoxAgent.Items.Add(myrow["FirstName"].ToString() + " " + myrow["LastName"].ToString());
            }
            
            currentIndex = 0;
            Display();
            ActivateButtons(true, true, true, true, false, false, true);
            comboBoxAgent.Enabled = false;
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
            txtFirstName.Text = tabClient.Rows[currentIndex]["FirstName"].ToString();
            txtLastName.Text = tabClient.Rows[currentIndex]["LastName"].ToString();
            dateTimeBday.Text = tabClient.Rows[currentIndex]["BirthDate"].ToString();
            txtType.Text = tabClient.Rows[currentIndex]["Type"].ToString();
            txtContactNo.Text = tabClient.Rows[currentIndex]["ContactNumber"].ToString();
            foreach (DataRow myrow in tabAgent.Rows)
            {
                if (tabClient.Rows[currentIndex]["EmployeeNumber"].ToString() == myrow["EmployeeNumber"].ToString())
                {
                    comboBoxAgent.Text = myrow["FirstName"].ToString() + " " + myrow["LastName"].ToString();
                }
            }
            lblInfo.Text = "Client " + (currentIndex + 1) + " on a total of " + tabClient.Rows.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            Display();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < (tabClient.Rows.Count - 1))
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
            currentIndex = tabClient.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtFirstName.Text = txtLastName.Text = dateTimeBday.Text = txtType.Text = txtContactNo.Text = "";

            txtFirstName.Focus();
            lblInfo.Text = "----------Add Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
            comboBoxAgent.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtFirstName.Focus();
            lblInfo.Text = "----------Editing Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
            comboBoxAgent.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "add")
            {
                DataRow currentRow = tabClient.NewRow();
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["BirthDate"] = Convert.ToDateTime(dateTimeBday.Text);
                currentRow["Type"] = txtType.Text;
                currentRow["ContactNumber"] = txtContactNo.Text;
                foreach (DataRow myRow in tabAgent.Rows)
                {
                    if (myRow["FirstName"].ToString() + " " + myRow["LastName"].ToString() == comboBoxAgent.SelectedItem.ToString())
                    {
                        currentRow["EmployeeNumber"] = myRow["EmployeeNumber"];
                    }
                }
                tabClient.Rows.Add(currentRow);
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClient);
                clsGlobal.adpClient.Update(clsGlobal.mySet, "Clients");
                
                clsGlobal.mySet.Tables.Remove("Clients");
                
                clsGlobal.adpClient.Fill(clsGlobal.mySet, "Clients");

                tabClient = clsGlobal.mySet.Tables["Clients"];
                
                currentIndex = tabClient.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                DataRow currentRow = tabClient.Rows[currentIndex];
                
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["BirthDate"] = Convert.ToDateTime(dateTimeBday.Text);
                currentRow["Type"] = txtType.Text;
                currentRow["ContactNumber"] = txtContactNo.Text;
                foreach (DataRow myRow in tabAgent.Rows)
                {
                    if (myRow["FirstName"].ToString() + " " + myRow["LastName"].ToString() == comboBoxAgent.SelectedItem.ToString())
                    {
                        currentRow["EmployeeNumber"] = myRow["EmployeeNumber"];
                    }
                }
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClient);
                clsGlobal.adpClient.Update(clsGlobal.mySet, "Clients");
                
                clsGlobal.mySet.Tables.Remove("Clients");
                
                clsGlobal.adpClient.Fill(clsGlobal.mySet, "Clients");

                tabClient = clsGlobal.mySet.Tables["Clients"];
            }
            Display();
            mode = "";
            ActivateButtons(true, true, true, true, false, false, true);
            comboBoxAgent.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete this Client", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabClient.Rows[currentIndex].Delete();
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClient);
                clsGlobal.adpClient.Update(clsGlobal.mySet, "Clients");
                
                clsGlobal.mySet.Tables.Remove("Clients");
                clsGlobal.adpClient.Fill(clsGlobal.mySet, "Clients");

                tabClient = clsGlobal.mySet.Tables["Clients"];
                
                currentIndex = 0;
                Display();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateButtons(true, true, true, true, false, false, true);
            comboBoxAgent.Enabled = false;
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
