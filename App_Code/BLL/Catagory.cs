using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Catagory
/// </summary>
public class Catagory
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

    public string MiniMizeDescription
    {
        get
        {
            string ReduceDescription = null;
            if (Description.Length > 30)
            {
                ReduceDescription = Description.Substring(0, 29) + ".......";
            }
            else
            {
                ReduceDescription = Description;
            }
            return ReduceDescription;
        }
       
    }

    public Catagory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Catagory(DataRow dataRow)
    {
        if (dataRow != null)
        {
            if (dataRow.Table.Columns.Contains("CatagoryID"))
                this.CatagoryID = (int)CommonUtility.FilterNull(dataRow["CatagoryID"], typeof(int));
            if (dataRow.Table.Columns.Contains("CatagoryName"))
                this.CatagoryName = (string)CommonUtility.FilterNull(dataRow["CatagoryName"], typeof(string));

            if (dataRow.Table.Columns.Contains("Description"))
                this.Description = (string)CommonUtility.FilterNull(dataRow["Description"], typeof(string));
           

        }
    }
    public static List<Catagory> GetCatagoryBySearch(string search)
    {
        DataTable catagoryData = CatagoryData.GetCatagoryBYSearch(search);
        List<Catagory> catagory = LoadFromDataTable(catagoryData);
        return catagory;
    }
    public static List<Catagory> GetCatagoryByName(string name)
    {
        DataTable catagoryData = CatagoryData.GetCatagoryBYName(name);
        List<Catagory> catagory = LoadFromDataTable(catagoryData);
        return catagory;
    }
    public static int Save(Catagory catagory)
    {
        return CatagoryData.Save(catagory);
       
    }
    public static int DeletebyID(int ID)
    {
      return  CatagoryData.DeletebyID(ID);
    }
    public static Catagory GetCatagoryBYID(int ID)
    {
        DataTable catagoryData = CatagoryData.GetCatagoryBYID(ID);

        if (catagoryData == null)
        {
            return null;
        }
        else if (catagoryData.Rows.Count < 1)
        {
            return null;
        }
        else return LoadFromDataTable(catagoryData)[0];
    }
    private static List<Catagory> LoadFromDataTable(DataTable data)
    {
        List<Catagory> result = new List<Catagory>();

        if (data != null && data.Rows.Count > 0)
        {
            foreach (DataRow row in data.Rows)
            {
                result.Add(new Catagory(row));
            }
        }

        return result;
    }
}
