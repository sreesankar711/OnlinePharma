using System;
using System.Data.SqlClient;

namespace MedicalStore.Views.Admin
{
    public partial class Medicines : System.Web.UI.Page
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
                ShowMedicines();
            }
        }

        private void ShowMedicines()
        {
            string Query = "select * from MedicalTbl";
            MedicineList.DataSource = Con.GetData(Query);
            MedicineList.DataBind();
        }

        protected bool IsCategoryExists(int categoryId)
        {
            string query = "SELECT COUNT(*) FROM Category WHERE Id = @CategoryId";
            string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            connection.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }


        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(MedId.Value != "" && MedName.Value != "" && MedStock.Value != "" && ExpDate.Value != "" && MedPrice.Value !="" && Categ.Value !="")
                {
                    if(IsCategoryExists(Convert.ToInt32(Categ.Value)))
                    {
                        string Id = MedId.Value;
                        string Name = MedName.Value;
                        string Stock = MedStock.Value;
                        string expdate = ExpDate.Value;
                        string price = MedPrice.Value;
                        string category = Categ.Value;



                        string Query = "Insert into MedicalTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                        Query = string.Format(Query, Id, Name, price, Stock, expdate, category);
                        Con.SetData(Query);
                        ShowMedicines();
                        ErrMsg.InnerText = "Medicine Added!!!";
                        MedId.Value = "";
                        MedName.Value = "";
                        MedStock.Value = "";
                        ExpDate.Value = "";
                        MedPrice.Value = "";
                        Categ.Value = "";
                    }
                    else
                    {
                        Categ.Value = "";
                        ErrMsg.InnerText = "This Category does not exists";
                    }

                    

                }
                else
                {
                    ErrMsg.InnerText = "No Med specified";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void MedicineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedId.Value = MedicineList.SelectedRow.Cells[1].Text;
            MedName.Value = MedicineList.SelectedRow.Cells[2].Text;
            MedStock.Value = MedicineList.SelectedRow.Cells[4].Text;
            DateTime expDate;
            if (DateTime.TryParse(MedicineList.SelectedRow.Cells[5].Text, out expDate))
            {
                ExpDate.Value = expDate.ToString("yyyy-MM-dd");
            }
            MedPrice.Value = MedicineList.SelectedRow.Cells[3].Text;
            Categ.Value = MedicineList.SelectedRow.Cells[6].Text;

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MedName.Value != "")
                {
                    if (IsCategoryExists(Convert.ToInt32(Categ.Value)))
                    {

                        string Query = "UPDATE MedicalTbl SET Name = '{0}', Price = '{1}', Stock = '{2}', ExpDate = '{3}', Category = '{4}' WHERE Id = '{5}'";
                        Query = string.Format(Query, MedName.Value, MedPrice.Value, MedStock.Value, ExpDate.Value, Categ.Value, MedId.Value);
                        Con.SetData(Query);
                        ShowMedicines();
                        ErrMsg.InnerText = "Medicine Edited!!!";
                        MedId.Value = "";
                        MedName.Value = "";
                        MedStock.Value = "";
                        ExpDate.Value = "";
                        MedPrice.Value = "";
                        Categ.Value = "";
                    }
                    else
                    {
                        Categ.Value = "";
                        ErrMsg.InnerText = "This Category does not exists";
                    }
                   
                }
                else
                {
                    ErrMsg.InnerText = "No MED specified";
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
                if (MedId.Value != "")
                {
 
                    string Query = "DELETE FROM MedicalTbl where Id = '{0}'";
                    Query = string.Format(Query, MedicineList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowMedicines();
                    ErrMsg.InnerText = "Medicine Deleted!!!";
                    MedId.Value = "";
                    MedName.Value = "";
                    MedStock.Value = "";
                    ExpDate.Value = "";
                    MedPrice.Value = "";
                    Categ.Value = "";
                }
                else
                {
                    ErrMsg.InnerText = "No MED specified";
                }
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

    }
}