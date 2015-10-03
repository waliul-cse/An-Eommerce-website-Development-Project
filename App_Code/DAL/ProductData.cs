using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for ProductData
/// </summary>
public class ProductData
{


    internal static int Save(Product product)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            try
            {


                string SaveString = "INSERT INTO Product(ProductName, CatagoryID, UnitPrice, IsVisible, ImageUrl, Quantity,ProductDescription,Saleprice,Isnewproduct,Isfeatured,IsOnsell)VALUES(@ProductName,@CatagoryID,@UnitPrice,@IsVisible,@ImageUrl,@Quantity,@ProductDescription,@Saleprice,@Isnewproduct,@Isfeatured,@IsOnsell)";
                string UpdateString = "UPDATE       Product SET                ProductName =@ProductName, CatagoryID =@CatagoryID, UnitPrice =@UnitPrice, IsVisible =@IsVisible, ImageUrl =@ImageUrl, Quantity =@Quantity,ProductDescription=@ProductDescription,Saleprice=@Saleprice,Isnewproduct=@Isnewproduct, Isfeatured=@Isfeatured,IsOnsell=@IsOnsell where ProductID=" + product.ProductID + ";";
                cmd.Parameters.Add(new OleDbParameter("@ProductName", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@CatagoryID", OleDbType.Integer, 25000));
                cmd.Parameters.Add(new OleDbParameter("@UnitPrice", OleDbType.Integer, 250));
                cmd.Parameters.Add(new OleDbParameter("@IsVisible", OleDbType.Boolean, 25000));
                cmd.Parameters.Add(new OleDbParameter("@ImageUrl", OleDbType.VarChar, 250));
                cmd.Parameters.Add(new OleDbParameter("@Quantity", OleDbType.Integer, 25000));
                cmd.Parameters.Add(new OleDbParameter("@ProductDescription", OleDbType.VarChar, 25000));

                cmd.Parameters.Add(new OleDbParameter("@Saleprice", OleDbType.Integer, 25000));

                cmd.Parameters.Add(new OleDbParameter("@Isnewproduct", OleDbType.Boolean, 25000));
                cmd.Parameters.Add(new OleDbParameter("@Isfeatured", OleDbType.Boolean, 25000));
                cmd.Parameters.Add(new OleDbParameter("@IsOnsell", OleDbType.Boolean, 25000));


                cmd.Parameters["@Saleprice"].Value = product.Saleprice;
                cmd.Parameters["@Isnewproduct"].Value = product.Isnewproduct;

                cmd.Parameters["@Isfeatured"].Value = product.Isfeatured;
                cmd.Parameters["@IsOnsell"].Value = product.IsOnsell;

                cmd.Parameters["@ProductName"].Value = product.ProductName;
                cmd.Parameters["@CatagoryID"].Value = product.CatagoryID;
                cmd.Parameters["@UnitPrice"].Value = product.UnitPrice;
                cmd.Parameters["@IsVisible"].Value = product.IsVisible;
                cmd.Parameters["@ImageUrl"].Value = product.ImageUrl;
                cmd.Parameters["@Quantity"].Value = product.Quantity;
                cmd.Parameters["@ProductDescription"].Value = product.ProductDescription;
                if (product.ProductID == 0)
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
    internal static DataTable GetProductyBYSearch(int CatagoryID, string Name)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
                if (string.IsNullOrEmpty(Name))
                { Name = null; }

                else
                {
                    Name = " and ProductName LIKE '%" + Name + "%'";
                }
                string catagorySearch = null;
                if (CatagoryID == 0)
                {
                     catagorySearch = null;
                }
                else
                {
                    catagorySearch = " and  c.CatagoryID=" + CatagoryID + "";
                }
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  Saleprice,Isnewproduct,Isfeatured,IsOnsell,c.CatagoryID AS CatagoryID, CatagoryName,Description,ProductID, ProductName,  UnitPrice,  IsVisible,ImageUrl,ProductDescription, Quantity FROM (Catagory c INNER JOIN Product p ON c.CatagoryID = p.CatagoryID)  WHERE 1=1 " + Name + "" + catagorySearch + "";

                data = BaseDB.GetDataTable(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return data;
        }

    }
    internal static DataTable GetProductyBYCatagoryID(int CatagoryID)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
                bool IsVisible = true;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Saleprice,Isnewproduct,Isfeatured,IsOnsell, c.CatagoryID AS CatagoryID,ProductDescription, CatagoryName,Description,ProductID, ProductName,  UnitPrice,  IsVisible,ImageUrl, Quantity FROM (Catagory c INNER JOIN Product p ON c.CatagoryID = p.CatagoryID)  WHERE  c.CatagoryID=@CatagoryID and IsVisible=@IsVisible";
                cmd.Parameters.Add(new OleDbParameter("@CatagoryID", OleDbType.Integer, 250));
                cmd.Parameters["@CatagoryID"].Value = CatagoryID;
                cmd.Parameters.Add(new OleDbParameter("@IsVisible", OleDbType.Boolean, 250));
                cmd.Parameters["@IsVisible"].Value = IsVisible;
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
    internal static DataTable GetProductBYFeature()
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {
                cmd.CommandText = "SELECT Saleprice,Isnewproduct,Isfeatured,IsOnsell,ProductDescription, c.CatagoryID AS CatagoryID, CatagoryName,Description,ProductID, ProductName,  UnitPrice,  IsVisible,ImageUrl, Quantity FROM (Catagory c INNER JOIN Product p ON c.CatagoryID = p.CatagoryID)  WHERE  Isfeatured=@Isfeatured ";
                cmd.Parameters.Add(new OleDbParameter("@Isfeatured", OleDbType.Boolean, 250));
                cmd.Parameters["@Isfeatured"].Value = true;
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
  
    internal static DataTable GetProductBYCatagoryIDAndProductName(int ID, string Name)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {

                cmd.CommandText = "SELECT Saleprice,Isnewproduct,Isfeatured,IsOnsell,ProductDescription, c.CatagoryID AS CatagoryID, CatagoryName,Description,ProductID, ProductName,  UnitPrice,  IsVisible,ImageUrl, Quantity FROM (Catagory c INNER JOIN Product p ON c.CatagoryID = p.CatagoryID)  WHERE  (c.CatagoryID = " + ID + ") and ProductName=@Name ";
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

    internal static DataTable GetProductBYCatagoryIDAndProductID(int CatagoryID, int  productID)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {

                cmd.CommandText = "SELECT  Saleprice,Isnewproduct,Isfeatured,IsOnsell,ProductDescription,c.CatagoryID AS CatagoryID, CatagoryName,Description,ProductID, ProductName,  UnitPrice,  IsVisible,ImageUrl, Quantity FROM (Catagory c INNER JOIN Product p ON c.CatagoryID = p.CatagoryID)  WHERE  (c.CatagoryID = " + CatagoryID + ") and ProductID=" + productID + " ";
               
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

    internal static DataTable GetProductBYID(int ID)
    {
        using (OleDbCommand cmd = new OleDbCommand())
        {
            DataTable data = null;
            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Saleprice,Isnewproduct,Isfeatured,IsOnsell,ProductDescription, c.CatagoryID AS CatagoryID, CatagoryName,Description,ProductID, ProductName,  UnitPrice,  IsVisible,ImageUrl, Quantity FROM (Catagory c INNER JOIN Product p ON c.CatagoryID = p.CatagoryID)  WHERE  (ProductID = " + ID + ") ";

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
                cmd.CommandText = "DELETE FROM Product WHERE  (ProductID = " + ID + ")";

                ret = BaseDB.ExecuteNonQuery(cmd);

            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }
    }
}
