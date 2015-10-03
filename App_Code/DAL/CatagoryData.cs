using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for CatagoryData
/// </summary>
public class CatagoryData
{
    internal static int Save(Catagory catagory)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            try
            {


                string SaveString = "INSERT INTO Catagory (CatagoryName, Description)VALUES(@CatagoryName,@Description)";
                string UpdateString = "UPDATE Catagory SET  CatagoryName =@CatagoryName, Description =@Description where CatagoryID=" + catagory.CatagoryID + ";";
                cmd.Parameters.Add(new OleDbParameter("@CatagoryName", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@Description", OleDbType.VarChar, 25000));

                cmd.Parameters["@CatagoryName"].Value = catagory.CatagoryName;
                cmd.Parameters["@Description"].Value = catagory.Description;

                if (catagory.CatagoryID == 0)
                {
                    cmd.CommandText = SaveString;
                }
                else { cmd.CommandText = UpdateString; }
                int a = BaseDB.ExecuteNonQuery(cmd);
                return a;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    internal static DataTable GetCatagoryBYSearch(string Search)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
                if (string.IsNullOrEmpty(Search))
                { Search = null; }

                else
                {
                    Search = " and CatagoryName LIKE '%"+Search+"%'";
                }

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Catagory WHERE 1=1" + Search + " ";

                data = BaseDB.GetDataTable(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

    }

    internal static DataTable GetCatagoryBYName(string Name)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
                

                
                cmd.CommandText = "Select * from Catagory WHERE CatagoryName=@Name";
                cmd.Parameters.Add(new OleDbParameter("@Name", OleDbType.VarChar, 250));
                cmd.Parameters["@Name"].Value = Name;
                cmd.CommandType = CommandType.Text;
                data = BaseDB.GetDataTable(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

    }

    internal static DataTable GetCatagoryBYID(int ID)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {



                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Catagory WHERE  (CatagoryID = " + ID + ") ";

                data = BaseDB.GetDataTable(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

    }
    internal static int DeletebyID(int ID)
    {
        int ret = 0;
        using (OleDbCommand cmd = new OleDbCommand())
        {

            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Catagory WHERE  (CatagoryID = " + ID + ")";

                ret= BaseDB.ExecuteNonQuery(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }


    }
}

