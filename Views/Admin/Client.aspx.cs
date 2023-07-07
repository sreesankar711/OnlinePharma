using MedicalStore.Views.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedicalStore
{
    public partial class Client : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Admin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Con = new Models.Functions();

        }



        protected void adminsearch(string id)
        {
            string query = "SELECT COUNT(*) FROM Cart WHERE ClientId = @ClientId";
            string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", id);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    query = "SELECT Id, ClientId, Med, Price, Quantity, TotalPrice FROM cart WHERE ClientId = " + id;
                    List.DataSource = Con.GetData(query);
                    List.DataBind();
                }
                else
                {
                    ErrMsg.Text = "No order from this ID";
                }
            }
        }


 
            protected void Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id.Value != "" )
                {
                    string id = Id.Value;
                    adminsearch(id);

                }
                else if(email.Value != "")
                {
                    string query = "SELECT Id FROM Client WHERE Email = @Email";
                    string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Email", email.Value);

                        connection.Open();

                        var result = command.ExecuteScalar();

                        Id.Value = result.ToString();

                        if (result != null)
                        {
                            adminsearch(result.ToString());
                        }
                        else
                        {
                            ErrMsg.Text = "email specified is wrong";
                        }
                    }
                }
                
            }
            catch (Exception Ex)
            {
                ErrMsg.Text = Ex.Message;
            }
        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            List.DataSource = null;
            List.DataBind();

            string query = "DELETE FROM Cart WHERE ClientId = @ClientId";
            string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", Id.Value);

            connection.Open();
            command.ExecuteNonQuery();
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            string script = "printGridView('" + Id.Value + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "PrintGridViewScript", script, true);

            string query = "DELETE FROM Cart WHERE ClientId = @ClientId";
            string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientId", Id.Value);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}