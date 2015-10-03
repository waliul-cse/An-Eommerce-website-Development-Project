using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        OleDbConnection oledbConnection = BaseDB.GetConnection();

        OleDbCommand sqlCommand = new OleDbCommand("select * from Paypal_information", oledbConnection);

        oledbConnection.Open();



        OleDbDataReader reader = sqlCommand.ExecuteReader();




        GridView1.DataSource = reader;

        GridView1.DataBind();
        oledbConnection.Close();

    }
}
