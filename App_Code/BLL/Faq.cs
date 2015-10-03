using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Faq
/// </summary>
public class Faq
{
    public int FaqID
    {
        get;
        set;
    }
    public bool IsVisible
    {
        get;
        set;
    }
    public string Question
    {
        get;
        set;
    }
    public string Answer
    {
        get;
        set;
    }

    public Faq()
    { }
	public Faq(DataRow dataRow)
	{
        if (dataRow != null)
        {
            if (dataRow.Table.Columns.Contains("FaqID"))
                this.FaqID = (int)CommonUtility.FilterNull(dataRow["FaqID"], typeof(int));
            if (dataRow.Table.Columns.Contains("IsVisible"))
                this.IsVisible = (bool)CommonUtility.FilterNull(dataRow["IsVisible"], typeof(string));

            if (dataRow.Table.Columns.Contains("Question"))
                this.Question = (string)CommonUtility.FilterNull(dataRow["Question"], typeof(string));


            if (dataRow.Table.Columns.Contains("Answer"))
                this.Answer = (string)CommonUtility.FilterNull(dataRow["Answer"], typeof(string));
        }
	}
    public static List<Faq> GetAllFaq()
    {
        DataTable faqData = FaqData.GetAllFaq();
        List<Faq> faq = LoadFromDataTable(faqData);
        return faq;
    }
    public static List<Faq> GetAllFaqforUser()
    {
        DataTable faqData = FaqData.GetAllFaqforUser();
        List<Faq> faq = LoadFromDataTable(faqData);
        return faq;
    }
    public static int Save(Faq faq)
    {
        return FaqData.Save(faq);

    }
    public static int DeletebyID(int id)
    {
        return FaqData.DeletebyID(id);

    }
   
    public static Faq GetFaqBYID(int ID)
    {
        DataTable faqData = FaqData.GeFaqBYID(ID);

        if (faqData == null)
        {
            return null;
        }
        else if (faqData.Rows.Count < 1)
        {
            return null;
        }
        else return LoadFromDataTable(faqData)[0];
    }
    private static List<Faq> LoadFromDataTable(DataTable data)
    {
        List<Faq> result = new List<Faq>();

        if (data != null && data.Rows.Count > 0)
        {
            foreach (DataRow row in data.Rows)
            {
                result.Add(new Faq(row));
            }
        }

        return result;
    }
}
