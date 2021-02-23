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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //Global Menu Items
        public static ToolStripMenuItem mnuManage;
        public static ToolStripMenuItem mnuAdmin;
        public static ToolStripMenuItem mnuAgent;
        public static ToolStripMenuItem mnuClient;
        public static ToolStripMenuItem mnuHouse;
        public static ToolStripMenuItem mnuLogin;
        public static ToolStripMenuItem mnuLogout;
        public static ToolStripMenuItem mnuSearch;
        public static frmSearch search;

        private void frmMain_Load(object sender, EventArgs e)
        {
            mnuManage = menuManage;
            mnuAdmin = menuAdmin;
            mnuAgent = menuAgent;
            mnuClient = menuClient;
            mnuHouse = menuHouse;
            mnuLogin = menuLogin;
            mnuLogout = menuLogout;
            mnuSearch = menuSearch;

            mnuManage.Visible = false;
            mnuLogout.Visible = false;

            clsGlobal.mySet = new DataSet();

            //creating a connection string
            clsGlobal.myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBRemax;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            clsGlobal.myCon.Open();
            /*
            //Inserting the data from table Admins to the global dataset
            //creating a command to the connection to request the table Admins
            SqlCommand myCmd = new SqlCommand("SELECT * FROM Admins", clsGlobal.myCon);
            //creating a dataAdapter with the command, and filling the dataset with the result of the command as new datatable
            clsGlobal.adpAdmin = new SqlDataAdapter(myCmd);
            clsGlobal.adpAdmin.Fill(clsGlobal.mySet, "Admins");  

            */
            //Inserting the data from table Agents to the global dataset
            //creating a command to the connection to request the table Agents
            SqlCommand myCmd = new SqlCommand("SELECT * FROM Agents", clsGlobal.myCon);
            //creating a dataAdapter with the command, and filling the dataset with the result of the command as new datatable
            clsGlobal.adpAgent = new SqlDataAdapter(myCmd);
            clsGlobal.adpAgent.Fill(clsGlobal.mySet, "Agents");
            
            //Inserting the data from table Agents to the global dataset
            //creating a command to the connection to request the table Agents
            myCmd = new SqlCommand("SELECT * FROM Clients", clsGlobal.myCon);
            //creating a dataAdapter with the command, and filling the dataset with the result of the command as new datatable
            clsGlobal.adpClient = new SqlDataAdapter(myCmd);
            clsGlobal.adpClient.Fill(clsGlobal.mySet, "Clients");

            //Inserting the data from table Agents to the global dataset
            //creating a command to the connection to request the table Agents
           
            myCmd = new SqlCommand("SELECT * FROM Houses", clsGlobal.myCon);
            //creating a dataAdapter with the command, and filling the dataset with the result of the command as new datatable
            clsGlobal.adpHouse = new SqlDataAdapter(myCmd);
            clsGlobal.adpHouse.Fill(clsGlobal.mySet, "Houses");

            search = new frmSearch();
            search.MdiParent = this;
            search.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.MdiParent = this;
            login.Show();
        }

        private void menuAdmin_Click(object sender, EventArgs e)
        {
            frmAdmin admin = new frmAdmin();
            admin.MdiParent = this;
            admin.Show();
        }

        private void menuAgent_Click(object sender, EventArgs e)
        {
            frmAgent agent = new frmAgent();
            agent.MdiParent = this;
            agent.Show();
        }

        private void menuClient_Click(object sender, EventArgs e)
        {
            frmClient client = new frmClient();
            client.MdiParent = this;
            client.Show();
        }

        private void menuHouse_Click(object sender, EventArgs e)
        {
            frmHouse house = new frmHouse();
            house.MdiParent = this;
            house.Show();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            mnuManage.Visible = false;
            mnuLogout.Visible = false;
            mnuLogin.Visible = true;
            mnuSearch.Visible = true;
            search = new frmSearch();
            search.MdiParent = this;
            search.Visible = true;
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search = new frmSearch();
            search.MdiParent = this;
            search.Show();
        }
    }
}
