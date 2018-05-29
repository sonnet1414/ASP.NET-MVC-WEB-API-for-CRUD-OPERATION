using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// Summary description for EmailOption
/// </summary>
/// 

    namespace WebApi.EmailOption
{

    public class EmailOption
    {

        public static SqlDataReader PopDr4(string _SP, string _Type, string _PID1, string _PID2, string _PID3, string _PID4, string _CID, string _UID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(_SP, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@rptType", SqlDbType.NVarChar, 50).Value = _Type;
            cmd.Parameters.Add("@fillParam1", SqlDbType.NVarChar, 50).Value = _PID1;
            cmd.Parameters.Add("@fillParam2", SqlDbType.NVarChar, 50).Value = _PID2;
            cmd.Parameters.Add("@fillParam3", SqlDbType.NVarChar, 50).Value = _PID3;
            cmd.Parameters.Add("@fillParam4", SqlDbType.NVarChar, 50).Value = _PID4;
            cmd.Parameters.Add("@CompanyID", SqlDbType.NVarChar, 50).Value = _CID;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar, 50).Value = _UID;
            SqlDataReader datReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.CommandTimeout = 0;
            return datReader;
            datReader.Close();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }


    }

}

