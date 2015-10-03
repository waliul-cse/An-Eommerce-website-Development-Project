using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
/// Summary description for BuyerInfoData
/// </summary>
public class BuyerInfoData
{
	public BuyerInfoData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    internal static int Save(BuyerInfo buyer)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            try
            {

                string SaveString = "INSERT INTO Buyer ( Name, Email, Address, CreatedDate, IsonlinePayment, IsSuccessful) VALUES        (Name,@Email,@Address,@CreatedDate,@IsonlinePayment,@IsSuccessful)";
              //  string UpdateString = "UPDATE Catagory SET  CatagoryName =@CatagoryName, Description =@Description where CatagoryID=" + catagory.CatagoryID + ";";
                cmd.Parameters.Add(new OleDbParameter("@Name", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@Email", OleDbType.VarChar, 2500));
                cmd.Parameters.Add(new OleDbParameter("@Address", OleDbType.VarChar, 2500));
                cmd.Parameters.Add(new OleDbParameter("@CreatedDate", OleDbType.Date, 25000));
                cmd.Parameters.Add(new OleDbParameter("@IsonlinePayment", OleDbType.Boolean, 2500));
                cmd.Parameters.Add(new OleDbParameter("@IsSuccessful", OleDbType.Boolean, 25000));

                cmd.Parameters["@Name"].Value = buyer.Name;
                cmd.Parameters["@Email"].Value = buyer.Email;
                cmd.Parameters["@Address"].Value = buyer.Address;
                cmd.Parameters["@CreatedDate"].Value = buyer.CreatedDate;
                cmd.Parameters["@IsonlinePayment"].Value = buyer.IsonlinePayment;
                cmd.Parameters["@IsSuccessful"].Value = buyer.IsSuccessful;

                if (buyer.BuyerID == 0)
                {
                    cmd.CommandText = SaveString;
                }
               // else { cmd.CommandText = UpdateString; }
                int a = BaseDB.ExecuteNonQuery(cmd);
                return a;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
