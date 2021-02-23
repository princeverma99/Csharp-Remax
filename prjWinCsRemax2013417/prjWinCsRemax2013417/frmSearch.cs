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
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        DataTable tabAgent, tabHouse;

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(radioHouse.Checked)
            {
                if (comboBoxHouses.SelectedIndex == -1)
                {
                    gridResult.DataSource = clsGlobal.mySet.Tables["Houses"];
                }
                else
                {
                    clsGlobal.mySet.Tables.Remove("Houses");
                    SqlCommand myCmd = new SqlCommand("SELECT * FROM HOUSES WHERE ReferenceNumber = " + comboBoxHouses.SelectedItem, clsGlobal.myCon);
                    clsGlobal.adpHouse = new SqlDataAdapter(myCmd);
                    clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");
                    gridResult.DataSource = clsGlobal.mySet.Tables["Houses"];
                }
            }
            else if(radioAgent.Checked)
            {
                if (comboBoxAgents.SelectedIndex == -1)
                {
                    gridResult.DataSource = clsGlobal.mySet.Tables["Agents"];
                }
                else
                {
                    clsGlobal.mySet.Tables.Remove("Agents");
                    SqlCommand myCmd = new SqlCommand("SELECT * FROM Agents WHERE EmployeeNumber = " + comboBoxAgents.SelectedItem, clsGlobal.myCon);
                    clsGlobal.adpAgent = new SqlDataAdapter(myCmd);
                    clsGlobal.adpAgent.Fill(clsGlobal.mySet, "Agents");
                    gridResult.DataSource = clsGlobal.mySet.Tables["Agents"];
                }
            }
        }

        private void radioHouse_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioHouse.Checked)
            {
                comboBoxAgents.Enabled = false;
            }
            else
            {
                comboBoxAgents.Enabled = true;
            }
        }

        private void radioAgent_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioAgent.Checked)
            {
                comboBoxHouses.Enabled = false;
            }
            else
            {
                comboBoxHouses.Enabled = true;
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

            tabAgent = clsGlobal.mySet.Tables["Agents"];
            tabHouse = clsGlobal.mySet.Tables["Houses"];

            foreach (DataRow myrow in tabAgent.Rows)
            {
                comboBoxAgents.Items.Add(myrow["EmployeeNumber"].ToString());
            }
            foreach (DataRow myrow in tabHouse.Rows)
            {
                comboBoxHouses.Items.Add(myrow["ReferenceNumber"].ToString());
            }
            clsGlobal.myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            clsGlobal.myCon.Open();
        }
    }
}
