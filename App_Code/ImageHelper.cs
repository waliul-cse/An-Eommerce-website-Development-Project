using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ImageHelper
/// </summary>
public class ImageHelper
{
    public string Productname
    {
        get;
        set;
    }
    public int ProductID
    {
        get;
        set;
    }

    public string ImageUrl
    {
        get;
        set;
    }
    public int price
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;

    }
	public ImageHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public ImageHelper(string ProductName,string url, int price, string description )
    {
        this.Productname = ProductName;
        this.ImageUrl = url;
        this.price = price;
        this.Description = description;
    }
    public ImageHelper(string url)
    {
        this.ImageUrl = url;
    }
    public ImageHelper(string url,int productID)
    {
        this.ImageUrl = url;
        this.ProductID = productID;
    }
   
}
