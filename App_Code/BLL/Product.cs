using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{

    public int CatagoryID
    {
        get;
        set;
    }
    public string CatagoryName
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;
    }
    public int ProductID
    {
        get;
        set;
    }
    public string ProductName
    {
        get;
        set;
    }
    public int UnitPrice
    {
        get;
        set;
    }
    public bool IsVisible
    {
        get;
        set;
    }
    public bool Isnewproduct
    {
        get;
        set;
    }
    public bool Isfeatured
    {
        get;
        set;
    }
    public bool IsOnsell
    {
        get;
        set;
    }
    public int Saleprice
    {
        get;
        set;
    }
    public string ImageUrl
    {
        get;
        set;
    }
    public string ProductDescription
    {
        get;
        set;
    }
    public int Actualprice
    {
        get
        {
            int newPrice = 0;
            if (IsOnsell)
            {
                newPrice =Saleprice;
            }
            else
            {
                newPrice =UnitPrice;
            }
            return newPrice;
        }
    }
    public string price
    {
        get
        {
            string newPrice = null;
            if (IsOnsell)
            {
                newPrice =  "<strike>$"+UnitPrice.ToString()+"</strike>"+"  $"+Saleprice.ToString();
            }
            else
            {
                newPrice = "$"+UnitPrice.ToString();
            }
            return newPrice;
        }
    }

    public string firstImage
    {
        get
        {
            string[] urls = ImageUrl.Split(',');

            return urls.First();
        }
    }
    public List<ImageHelper> TotalUrl
    {
        get
        {
            string[] urls = ImageUrl.Split(',');
            List<ImageHelper> imageHelpers = new List<ImageHelper>();
            foreach (string url in urls)
            {
                imageHelpers.Add(new ImageHelper(url));
            }
            return imageHelpers;
        }
    }

    public int Quantity
    {
        get;
        set;
    }
    public string MiniMizeDescription
    {
        get
        {
            string ReduceDescription = null;
            if (ProductDescription.Length > 150)
            {
                ReduceDescription = ProductDescription.Substring(0, 149) + ".......";
            }
            else
            {
                ReduceDescription = ProductDescription;
            }
            return ReduceDescription;
        }

    }

    public Product()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Product(int id)
    { }
    public Product(DataRow dataRow)
    {
        if (dataRow != null)
        {
            if (dataRow.Table.Columns.Contains("CatagoryID"))
                this.CatagoryID = (int)CommonUtility.FilterNull(dataRow["CatagoryID"], typeof(int));
            if (dataRow.Table.Columns.Contains("CatagoryName"))
                this.CatagoryName = (string)CommonUtility.FilterNull(dataRow["CatagoryName"], typeof(string));

            if (dataRow.Table.Columns.Contains("Description"))
                this.Description = (string)CommonUtility.FilterNull(dataRow["Description"], typeof(string));

            if (dataRow.Table.Columns.Contains("ProductID"))
                this.ProductID = (int)CommonUtility.FilterNull(dataRow["ProductID"], typeof(int));
            if (dataRow.Table.Columns.Contains("ProductName"))
                this.ProductName = (string)CommonUtility.FilterNull(dataRow["ProductName"], typeof(string));

            if (dataRow.Table.Columns.Contains("UnitPrice"))
                this.UnitPrice = (int)CommonUtility.FilterNull(dataRow["UnitPrice"], typeof(int));

            if (dataRow.Table.Columns.Contains("IsVisible"))
                this.IsVisible = (bool)CommonUtility.FilterNull(dataRow["IsVisible"], typeof(bool));


            if (dataRow.Table.Columns.Contains("Saleprice"))
                this.Saleprice = (int)CommonUtility.FilterNull(dataRow["Saleprice"], typeof(int));
            if (dataRow.Table.Columns.Contains("Isnewproduct"))
                this.Isnewproduct = (bool)CommonUtility.FilterNull(dataRow["Isnewproduct"], typeof(bool));
            if (dataRow.Table.Columns.Contains("Isfeatured"))
                this.Isfeatured = (bool)CommonUtility.FilterNull(dataRow["Isfeatured"], typeof(bool));
            if (dataRow.Table.Columns.Contains("IsOnsell"))
                this.IsOnsell = (bool)CommonUtility.FilterNull(dataRow["IsOnsell"], typeof(bool));

            if (dataRow.Table.Columns.Contains("ImageUrl"))
                this.ImageUrl = (string)CommonUtility.FilterNull(dataRow["ImageUrl"], typeof(string));


            if (dataRow.Table.Columns.Contains("Quantity"))
                this.Quantity = (int)CommonUtility.FilterNull(dataRow["Quantity"], typeof(int));

            if (dataRow.Table.Columns.Contains("ProductDescription"))
                this.ProductDescription = (string)CommonUtility.FilterNull(dataRow["ProductDescription"], typeof(string));

        }
    }
    public static List<Product> GetProductBySearch(string Name, int CatagoryID)
    {
        DataTable productData = ProductData.GetProductyBYSearch(CatagoryID, Name);
        List<Product> product = LoadFromDataTable(productData);
        return product;
    }
    public static List<Product> GetProductByCatagoryID(int CatagoryID)
    {
        DataTable productData = ProductData.GetProductyBYCatagoryID(CatagoryID);
        List<Product> product = LoadFromDataTable(productData);
        return product;
    }
    public static List<Product> GetProductByfeature()
    {
        DataTable productData = ProductData.GetProductBYFeature();
        List<Product> product = LoadFromDataTable(productData);
        return product;
    }

    public static List<Product> GetProductBYCatagoryIDAndProductName(string Name, int CatagoryID)
    {
        DataTable productData = ProductData.GetProductBYCatagoryIDAndProductName(CatagoryID, Name);
        List<Product> product = LoadFromDataTable(productData);
        return product;
    }
    public static Product GetProductBYCatagoryIDAndProductID(int CatagoryID, int ProductID)
    {
        DataTable productData = ProductData.GetProductBYCatagoryIDAndProductID(CatagoryID, ProductID);
        if (productData == null)
        {
            return null;
        }
        else if (productData.Rows.Count < 1)
        {
            return null;
        }
        else return LoadFromDataTable(productData)[0];

    }

    public static int Save(Product product)
    {
        return ProductData.Save(product);

    }
    public static int DeletebyID(int ID)
    {
        return ProductData.DeletebyID(ID);
    }
    public static Product GetProductBYID(int ID)
    {
        DataTable productData = ProductData.GetProductBYID(ID);

        if (productData == null)
        {
            return null;
        }
        else if (productData.Rows.Count < 1)
        {
            return null;
        }
        else return LoadFromDataTable(productData)[0];
    }
    private static List<Product> LoadFromDataTable(DataTable data)
    {
        List<Product> result = new List<Product>();

        if (data != null && data.Rows.Count > 0)
        {
            foreach (DataRow row in data.Rows)
            {
                result.Add(new Product(row));
            }
        }

        return result;
    }
}
