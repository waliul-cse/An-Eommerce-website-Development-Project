using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ECommerce.Control
{

    [SupportsEventValidation, ValidationProperty("SelectedValue")]
    [ToolboxData("<{0}:CatgoryDropdown runat=server></{0}:CatgoryDropdown>")]
    public class CatgoryDropdown : DropDownList
    {
        public override void DataBind()
        {
            List<Catagory> Catagories = Catagory.GetCatagoryBySearch("");

            foreach (Catagory catagory in Catagories)
            {
                this.Items.Add(new ListItem(catagory.CatagoryName, catagory.CatagoryID.ToString()));
            }

            if (UseFirstItem)
            {
                this.Items.Insert(0, new ListItem(FirstItemText, FirstItemValue));
            }

            base.DataBind();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
                this.DataBind();
            base.OnLoad(e);
        }

        private string _firstItemText = "Select Catagory";
        public string FirstItemText
        {
            get { return _firstItemText; }
            set { _firstItemText = value; }
        }

        private string _firstItemValue = "-1";
        public string FirstItemValue
        {
            get { return this._firstItemValue; }
            set { this._firstItemValue = value; }
        }

        private bool _useFirtItem = false;
        public bool UseFirstItem
        {
            get { return this._useFirtItem; }
            set { this._useFirtItem = value; }
        }
    }
}


