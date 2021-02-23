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
    public partial class frmHouse : Form
    {
        public frmHouse()
        {
            InitializeComponent();
        }

        //Global Variable
        int currentIndex;
        DataTable tabHouse, tabAgent;
        string mode;

        private void frmHouse_Load(object sender, EventArgs e)
        {
            //the variable tabHouse will replace clsGloabl.mySet.Tables["Admin"]
            tabHouse = clsGlobal.mySet.Tables["Houses"];
            tabAgent = clsGlobal.mySet.Tables["Agents"];

            DataColumn[] keys = new DataColumn[1];
            keys[0] = tabAgent.Columns["EmployeeNumber"];
            tabAgent.PrimaryKey = keys;

            foreach (DataRow myrow in tabAgent.Rows)
            {
                comboBoxAgent.Items.Add(myrow["FirstName"].ToString() + " " + myrow["LastName"].ToString());
            }

            //displaying the first datarow (index 0) of the table Admin in the textboxes
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
            txtAddress.Text = tabHouse.Rows[currentIndex]["Address"].ToString();
            txtCity.Text = tabHouse.Rows[currentIndex]["City"].ToString();
            txtType.Text = tabHouse.Rows[currentIndex]["type"].ToString();
            txtRooms.Text = tabHouse.Rows[currentIndex]["NumberofRooms"].ToString();
            txtWashrooms.Text = tabHouse.Rows[currentIndex]["NumberofWashrooms"].ToString();
            txtPrice.Text = tabHouse.Rows[currentIndex]["Price"].ToString();
            foreach (DataRow myrow in tabAgent.Rows)
            {
                if (tabHouse.Rows[currentIndex]["EmployeeNumber"].ToString() == myrow["EmployeeNumber"].ToString())
                {
                    comboBoxAgent.Text = myrow["FirstName"].ToString() + " " + myrow["LastName"].ToString();
                }
            }
            lblInfo.Text = "House " + (currentIndex + 1) + " on a total of " + tabHouse.Rows.Count;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Exit", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            Display();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < (tabHouse.Rows.Count - 1))
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
            currentIndex = tabHouse.Rows.Count - 1;
            Display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtAddress.Text = txtCity.Text = txtType.Text = txtRooms.Text = txtWashrooms.Text = txtPrice.Text = "";

            txtAddress.Focus();
            lblInfo.Text = "----------Add Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
            comboBoxAgent.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtAddress.Focus();
            lblInfo.Text = "----------Editing Mode----------";
            ActivateButtons(false, false, false, false, true, true, false);
            comboBoxAgent.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Delete this House", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabHouse.Rows[currentIndex].Delete();
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpHouse);
                clsGlobal.adpHouse.Update(clsGlobal.mySet, "Houses");
                
                clsGlobal.mySet.Tables.Remove("Houses");
                clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");

                tabHouse = clsGlobal.mySet.Tables["Houses"];
                
                currentIndex = 0;
                Display();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "add")
            {
                DataRow currentRow = tabHouse.NewRow();

                currentRow["Address"] = txtAddress.Text;
                currentRow["City"] = txtCity.Text;
                currentRow["Type"] = txtType.Text;
                currentRow["NumberofRooms"] = txtRooms.Text;
                currentRow["NumberofWashrooms"] = txtWashrooms.Text;
                currentRow["Price"] = txtPrice.Text;
                foreach (DataRow myRow in tabAgent.Rows)
                {
                    if (myRow["FirstName"].ToString() + " " + myRow["LastName"].ToString() == comboBoxAgent.SelectedItem.ToString())
                    {
                        currentRow["EmployeeNumber"] = myRow["EmployeeNumber"];
                    }
                }
                tabHouse.Rows.Add(currentRow);
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpHouse);
                clsGlobal.adpHouse.Update(clsGlobal.mySet, "Houses");
                
                clsGlobal.mySet.Tables.Remove("Houses");
                
                clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");

                tabHouse = clsGlobal.mySet.Tables["Houses"];
                
                currentIndex = tabHouse.Rows.Count - 1;

            }
            else if (mode == "edit")
            {
                DataRow currentRow = tabHouse.Rows[currentIndex];
                
                currentRow["Address"] = txtAddress.Text;
                currentRow["City"] = txtCity.Text;
                currentRow["Type"] = txtType.Text;
                currentRow["NumberofRooms"] = txtRooms.Text;
                currentRow["NumberofWashrooms"] = txtWashrooms.Text;
                currentRow["Price"] = txtPrice.Text;
                foreach (DataRow myRow in tabAgent.Rows)
                {
                    if (myRow["FirstName"].ToString() + " " + myRow["LastName"].ToString() == comboBoxAgent.SelectedItem.ToString())
                    {
                        currentRow["EmployeeNumber"] = myRow["EmployeeNumber"];
                    }
                }
                
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpHouse);
                clsGlobal.adpHouse.Update(clsGlobal.mySet, "Houses");
                
                clsGlobal.mySet.Tables.Remove("Houses");
                
                clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");

                tabHouse = clsGlobal.mySet.Tables["Houses"];
            }
            Display();
            mode = "";
            ActivateButtons(true, true, true, true, false, false, true);
            comboBoxAgent.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Display();
            ActivateButtons(true, true, true, true, false, false, true);
            comboBoxAgent.Enabled = false;
        }
    }
}
