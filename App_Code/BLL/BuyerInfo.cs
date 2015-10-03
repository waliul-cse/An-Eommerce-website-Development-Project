using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BuyerInfo
/// </summary>
public class BuyerInfo
{
    public int BuyerID
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string Email
    {
        get;
        set;
    }
    public string Address
    {
        get;
        set;
    }
    public DateTime CreatedDate
    {
        get;
        set;

    }
    public bool IsonlinePayment
    {
        get;
        set;

    }
    public bool IsSuccessful
    {
        get;
        set;

    }
	public BuyerInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void Save(BuyerInfo buyer)
    {
        BuyerInfoData.Save(buyer);
    }
}
