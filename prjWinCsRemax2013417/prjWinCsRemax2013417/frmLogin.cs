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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //Global Variable
        int currentIndex;
        DataTable tabAdmin;

        private void frmLogin_Load(object sender, EventArgs e)
        {
             clsGlobal.mySet = new DataSet();

            //creating a connection string
            clsGlobal.myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            clsGlobal.myCon.Open();
            
            SqlCommand myCmd = new SqlCommand("SELECT * FROM Admins", clsGlobal.myCon);
            clsGlobal.adpAdmin = new SqlDataAdapter(myCmd);
            clsGlobal.adpAdmin.Fill(clsGlobal.mySet, "Admins");

            myCmd = new SqlCommand("SELECT * FROM Agents", clsGlobal.myCon);
            clsGlobal.adpAgent = new SqlDataAdapter(myCmd);
            clsGlobal.adpAgent.Fill(clsGlobal.mySet, "Agents");


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(radioAdmin.Checked)
            {
                if(txtUsername.Text == "")
                {
                    MessageBox.Show("Please Enter Username");
                    txtUsername.Focus();
                }
                else if(txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password");
                    txtPassword.Focus();
                }
                else
                {
                    int loginFlag = 0;
                    foreach(DataRow currentRow in clsGlobal.mySet.Tables["Admins"].Rows)
                    {
                        if(txtUsername.Text == currentRow["Username"].ToString() && txtPassword.Text == currentRow["Password"].ToString())
                        {
                            MessageBox.Show("Login Successful");
                            loginFlag = 1;
                            this.SetVisibleCore(false);
                            frmMain.mnuManage.Visible = true;
                            frmMain.mnuAdmin.Visible = true;
                            frmMain.mnuAgent.Visible = true;
                            frmMain.mnuClient.Visible = true;
                            frmMain.mnuHouse.Visible = true;
                            frmMain.mnuLogin.Visible = false;
                            frmMain.mnuLogout.Visible = true;
                            frmMain.mnuSearch.Visible = false;
                            
                            SqlCommand myCmd = new SqlCommand("SELECT * FROM Clients", clsGlobal.myCon);
                            clsGlobal.adpClient = new SqlDataAdapter(myCmd);
                            clsGlobal.adpClient.Fill(clsGlobal.mySet, "Clients");

                            myCmd = new SqlCommand("SELECT * FROM Houses", clsGlobal.myCon);
                            clsGlobal.adpHouse = new SqlDataAdapter(myCmd);
                            clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");

                            frmMain.search.Visible = false;
                           
                        }
                    }
                    if(loginFlag == 0)
                    {
                        MessageBox.Show("Username or Password Incorrect");
                        txtUsername.Focus();
                    }
                }
            }
            else if (radioAgent.Checked)
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Please Enter Username");
                    txtUsername.Focus();
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password");
                    txtPassword.Focus();
                }
                else
                {
                    int loginFlag = 0;
                    foreach (DataRow currentRow in clsGlobal.mySet.Tables["Agents"].Rows)
                    {
                        if (txtUsername.Text == currentRow["Username"].ToString() && txtPassword.Text == currentRow["Password"].ToString())
                        {
                            int employeeNumber = Convert.ToInt32(currentRow["EmployeeNumber"]);
                            MessageBox.Show("Login Successful");
                            loginFlag = 1;
                            this.SetVisibleCore(false);
                            frmMain.mnuManage.Visible = true;
                            frmMain.mnuAdmin.Visible = false;
                            frmMain.mnuAgent.Visible = false;
                            frmMain.mnuClient.Visible = true;
                            frmMain.mnuHouse.Visible = true;
                            frmMain.mnuLogin.Visible = false;
                            frmMain.mnuLogout.Visible = true;
                            frmMain.mnuSearch.Visible = false;
                            SqlCommand myCmd = new SqlCommand("SELECT * FROM Clients WHERE EmployeeNumber = " + employeeNumber, clsGlobal.myCon);
                            clsGlobal.adpClient = new SqlDataAdapter(myCmd);
                            clsGlobal.adpClient.Fill(clsGlobal.mySet, "Clients");

                            myCmd = new SqlCommand("SELECT * FROM Houses WHERE EmployeeNumber = " + employeeNumber, clsGlobal.myCon);
                            clsGlobal.adpHouse = new SqlDataAdapter(myCmd);
                            clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");
                            frmMain.search.Visible = false;
                        }
                    }
                    if (loginFlag == 0)
                    {
                        MessageBox.Show("Username or Password Incorrect");
                        txtUsername.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select User");
            }
        }
    }
}
