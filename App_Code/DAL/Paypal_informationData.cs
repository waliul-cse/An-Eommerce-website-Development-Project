using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for Paypal_informationData
/// </summary>
public class Paypal_informationData
{
	public Paypal_informationData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    internal static int Save(Paypal_information paypal_informationData)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            try
            {


                string SaveString = " INSERT INTO Paypal_information    (txn_id, payment_date, payer_email, item_number, item_name, mc_gross, Address) VALUES(@txn_id,@payment_date,@payer_email,@item_number,@item_name,@mc_gross,@Address)";
                cmd.Parameters.Add(new OleDbParameter("@txn_id", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@payment_date", OleDbType.Date, 25000));
                cmd.Parameters.Add(new OleDbParameter("@payer_email", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@item_number", OleDbType.Integer, 25000));
                cmd.Parameters.Add(new OleDbParameter("@item_name", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@mc_gross", OleDbType.Integer, 25000));
                cmd.Parameters.Add(new OleDbParameter("@Address", OleDbType.VarChar, 25000));

                cmd.Parameters["@txn_id"].Value = paypal_informationData.txn_id;
                cmd.Parameters["@payment_date"].Value = paypal_informationData.payment_date;
                cmd.Parameters["@payer_email"].Value = paypal_informationData.payer_email;
                cmd.Parameters["@item_number"].Value = paypal_informationData.item_number;
                cmd.Parameters["@item_name"].Value = paypal_informationData.item_name;
                cmd.Parameters["@mc_gross"].Value = paypal_informationData.mc_gross;
                cmd.Parameters["@Address"].Value = paypal_informationData.Address;
              
                    cmd.CommandText = SaveString;
            
                int a = BaseDB.ExecuteNonQuery(cmd);
                return a;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
     internal static DataTable GetCountItem_id(string txn_id)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {

         


                
                cmd.CommandText = "Select *   from Paypal_information WHERE txn_id=@txn_id";
                cmd.Parameters.Add(new OleDbParameter("@txn_id", OleDbType.VarChar, 250));
                cmd.Parameters["@txn_id"].Value = txn_id;

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
}
