using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Paypal_information
/// </summary>
public class Paypal_information
{
    public int Paypal_processingID
    {
        get;
        set;
    }
    public int counttxn_id
    {
        get;
        set;
    }

    public string txn_id
    {
        get;
        set;
    }
    public DateTime payment_date
    {
        get;
        set;
    }
    public string payer_email
    {
        get;
        set;
    }
    public int item_number
    {
        get;
        set;
    }
    public string item_name
    {
        get;
        set;
    }
    public int mc_gross
    {
        get;
        set;
    }
    public string Address
    {
        get;
        set;
    }



    public Paypal_information(DataRow dataRow)
    {
        if (dataRow != null)
        {
            if (dataRow.Table.Columns.Contains("txn_id"))
                this.txn_id = (string)CommonUtility.FilterNull(dataRow["txn_id"], typeof(int));

           

        }
    }
    public Paypal_information()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static int Save(Paypal_information paypal_information)
    {
        return Paypal_informationData.Save(paypal_information);

    }

    //public static Paypal_information GetCountItem_id(string Item_id)
    //{
    //    DataTable paypal_informationData = Paypal_informationData.GetCountItem_id(Item_id);

    //    if (paypal_informationData == null)
    //    {
    //        return null;
    //    }
    //    else if (paypal_informationData.Rows.Count < 1)
    //    {
    //        return null;
    //    }
    //    else return LoadFromDataTable(paypal_informationData)[0];
    //}
    public static List<Paypal_information> GetCountItem_id(string Item_id)
    {
        DataTable paypal_informationData = Paypal_informationData.GetCountItem_id(Item_id);
        List<Paypal_information> paypal_information = LoadFromDataTable(paypal_informationData);
        return paypal_information;
    }
    private static List<Paypal_information> LoadFromDataTable(DataTable data)
    {
        List<Paypal_information> result = new List<Paypal_information>();

        if (data != null && data.Rows.Count > 0)
        {
            foreach (DataRow row in data.Rows)
            {
                result.Add(new Paypal_information(row));
            }
        }

        return result;
    }
}
