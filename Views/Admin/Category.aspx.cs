using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStore.Views.Admin
{
    public partial class Category : System.Web.UI.Page
    {


        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowCategories();
            }
        }

        private void ShowCategories()
        {
            string Query = "select Id as Number, Name as [Category Names] from Category";
            CategoriesList.DataSource = Con.GetData(Query);
            CategoriesList.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatName.Value != "")
                {
                    string Name = CatName.Value;
                    string Query = "Insert into Category values('{0}')";
                    Query = string.Format(Query, Name);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Added!!!";
                    CatName.Value = "";
                }
                else
                {
                    ErrMsg.InnerText = "No Category specified";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatName.Value = CategoriesList.SelectedRow.Cells[2].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatName.Value != "")
                {
                    string Name = CatName.Value;
                    string Query = "UPDATE Category set Name = '{0}' where Id = '{1}'";
                    Query = string.Format(Query, Name, CategoriesList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Edited!!!";
                    CatName.Value = "";
                }
                else
                {
                    ErrMsg.InnerText = "No Category specified";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatName.Value != "")
                {
                    string Name = CatName.Value;
                    string Query = "DELETE FROM Category where Id = '{0}'";
                    Query = string.Format(Query, CategoriesList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowCategories();
                    ErrMsg.InnerText = "Category Deleted!!!";
                    CatName.Value = "";
                }
                else
                {
                    ErrMsg.InnerText = "No Category specified";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }

        }
    }
}