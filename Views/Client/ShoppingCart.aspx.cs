using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStore.Views.Client
{
    public partial class ShoppingCart : System.Web.UI.Page
    {

        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Con = new Models.Functions();
            string email = Session["LoggedInUserEmail"].ToString();
            int clientId = 0;

            string query = "SELECT Id FROM Client WHERE Email = @Email";
            string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    clientId = Convert.ToInt32(result);
                }
            }

            Session["clientId"] = clientId;

            ShowCart();
            decimal totalCost = 0;

            foreach (GridViewRow row in cartview.Rows)
            {
                decimal totalPrice = Convert.ToDecimal(row.Cells[4].Text); 

                totalCost += totalPrice;
            }


            Total_price.Text = totalCost.ToString();





        }

        private void ShowCart()
        {
            string query = "SELECT Id, Med, Price, Quantity, TotalPrice FROM Cart WHERE clientId = " + Session["clientId"];
            cartview.DataSource = Con.GetData(query);
            cartview.DataBind();
        }
    }
}