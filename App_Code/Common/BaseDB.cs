using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for BaseDB
/// </summary>
public class BaseDB
{

    public static OleDbConnection GetConnection()
    {
        OleDbConnection conn;
        string path = HttpContext.Current.Server.MapPath("~/DB/EcommerceDatabase.mdb");
        conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + path + "");
        return conn;
    }

    public static DataSet GetDataSet(OleDbCommand com)
    {
        using (OleDbConnection con = GetConnection())
        {
            using (DataSet ds = new DataSet())
            {
                using (OleDbDataAdapter adp = new OleDbDataAdapter(com))
                {
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adp.Fill(ds);

                }
                return ds;
            }
        }
    }

    public static object ExecuteScalar(OleDbCommand com)
    {
        using (OleDbConnection con = GetConnection())
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (OleDbDataAdapter adp = new OleDbDataAdapter(com))
            {
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                return adp.SelectCommand.ExecuteScalar();

            }
        }
    }
    public static DataTable GetDataTable(OleDbCommand com)
    {
        using (OleDbConnection con = GetConnection())
        {
            using (DataSet ds = new DataSet())
            {
                using (OleDbDataAdapter adp = new OleDbDataAdapter(com))
                {
                    adp.SelectCommand.Connection = con;
                    adp.SelectCommand.CommandType = CommandType.Text;

                    adp.Fill(ds);

                }
                return ds.Tables[0];
            }
        }
    }


    public static int ExecuteNonQuery(OleDbCommand com)
    {
        int a = 0;
        using (OleDbConnection con = GetConnection())
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (OleDbDataAdapter adp = new OleDbDataAdapter(com))
            {
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandType = CommandType.Text;
                a = adp.SelectCommand.ExecuteNonQuery();

            }

        }
        return a;
    }

    public static OleDbDataReader ExecuteReader(OleDbCommand com)
    {
        OleDbDataReader dr;
        using (OleDbConnection con = GetConnection())
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            using (OleDbDataAdapter adp = new OleDbDataAdapter(com))
            {
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                dr = adp.SelectCommand.ExecuteReader();

            }

        }
        return dr;
    }
    public static void Insert_Data(OleDbCommand Cmd, String SqlObject, bool Storeprocess)
    {
        OleDbConnection Con = GetConnection();
        if (Cmd == null) Cmd = new OleDbCommand();
        //SqlCommand Cmd = new SqlCommand();
        if (Storeprocess) Cmd.CommandType = CommandType.StoredProcedure;
        else Cmd.CommandType = CommandType.Text;
        Cmd.CommandText = SqlObject;
        Cmd.Connection = Con;
        if (Con.State == ConnectionState.Closed) Con.Open();
        Cmd.ExecuteNonQuery();
        if (Con.State == ConnectionState.Open) Con.Close();
        Con.Dispose();
    }
}
