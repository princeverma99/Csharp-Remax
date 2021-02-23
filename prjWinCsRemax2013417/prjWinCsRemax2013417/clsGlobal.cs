using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace prjWinCsRemax2013417
{
    public class clsGlobal
    {
        //Gloabl Variables of Remax Project
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static SqlDataAdapter adpAdmin, adpAgent, adpClient, adpHouse;
    }
}
