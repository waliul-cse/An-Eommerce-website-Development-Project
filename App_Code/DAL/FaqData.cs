using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for FaqData
/// </summary>
public class FaqData
{
	public FaqData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    internal static int Save(Faq faq)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            try
            {


                string SaveString = "INSERT INTO Faq(IsVisible, Question, Answer) VALUES        (@IsVisible,@Question,@Answer)";
                string UpdateString = "UPDATE Faq SET  IsVisible =@IsVisible, Question =@Question, Answer=@Answer where FaqID=" + faq.FaqID + ";";
                cmd.Parameters.Add(new OleDbParameter("@IsVisible", OleDbType.Boolean, 250));
                cmd.Parameters.Add(new OleDbParameter("@Question", OleDbType.VarChar, 25000));
                cmd.Parameters.Add(new OleDbParameter("@Answer", OleDbType.VarChar, 25000));

                cmd.Parameters["@IsVisible"].Value = faq.IsVisible;
                cmd.Parameters["@Question"].Value = faq.Question;
                cmd.Parameters["@Answer"].Value = faq.Answer;

                if (faq.FaqID == 0)
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
    internal static DataTable GetAllFaqforUser()
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
                cmd.Parameters.Add(new OleDbParameter("@IsVisible", OleDbType.Boolean, 250));
                

                cmd.Parameters["@IsVisible"].Value = true;
         
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Faq where IsVisible=@IsVisible";

                data = BaseDB.GetDataTable(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

    }
    internal static DataTable GetAllFaq()
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
               

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Faq";

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
                cmd.CommandText = "DELETE FROM Faq WHERE  (FaqID = " + ID + ")";

                ret = BaseDB.ExecuteNonQuery(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }
    }
    internal static DataTable GeFaqBYID(int ID)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {



                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Faq WHERE  (FaqID = " + ID + ") ";

                data = BaseDB.GetDataTable(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

    }
}
