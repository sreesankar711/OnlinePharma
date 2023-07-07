using System;
using System.Data.SqlClient;

namespace MedicalStore.Views.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if(email_field.Value != "" && pwd_field.Value != "")
            {
                string email = email_field.Value;
                string pwd = pwd_field.Value;

                string query = "SELECT COUNT(*) FROM Admins WHERE email = @Email AND pwd = @Password";
                string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", pwd);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        Session["LoggedInUserEmail"] = email;
                        Session["Admin"] = "true";
                        Response.Redirect("Admin/Medicines.aspx");
                    }
                    else
                    {
                        string queryCheckEmail = "SELECT COUNT(*) FROM Admins WHERE email = @Email";
                        using (SqlCommand commandCheckEmail = new SqlCommand(queryCheckEmail, connection))
                        {
                            commandCheckEmail.Parameters.AddWithValue("@Email", email);
                            int countEmail = (int)commandCheckEmail.ExecuteScalar();
                            if (countEmail > 0)
                            {
                                errlabel.Text = "Invalid email or password";
                            }
                            else
                            {
                                string qu = "SELECT COUNT(*) FROM Client WHERE Email = @Email AND Password = @Password";
                                using (SqlCommand clientcommand = new SqlCommand(qu, connection))
                                {

                                    clientcommand.Parameters.AddWithValue("@Email", email);
                                    clientcommand.Parameters.AddWithValue("@Password", pwd);

                                    int c = (int)clientcommand.ExecuteScalar();
                                    if (c > 0)
                                    {
                                        Session["Loggedin"] = "true";
                                        Session["LoggedInUserEmail"] = email;
                                        Response.Redirect("Client/shop.aspx");
                                    }
                                    else
                                    {
                                        string que = "SELECT COUNT(*) FROM Client WHERE Email = @Email ";
                                        using (SqlCommand clcommand = new SqlCommand(que, connection))
                                        {
                                            clcommand.Parameters.AddWithValue("@Email", email);
                                            int cu = (int)clcommand.ExecuteScalar();
                                            if (cu > 0)
                                            {
                                                errlabel.Text = "Invalid email or password";
                                            }
                                            else
                                            {
                                                string insertQuery = "INSERT INTO Client (Email, Password) VALUES (@Email, @Password)";
                                                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                                {
                                                    insertCommand.Parameters.AddWithValue("@Email", email);
                                                    insertCommand.Parameters.AddWithValue("@Password", pwd);
                                                    insertCommand.ExecuteNonQuery();
                                                    Session["LoggedInUserEmail"] = email;
                                                    Session["Loggedin"] = "true";
                                                    Response.Redirect("Client/shop.aspx");
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                }
            }
          }
        }
    }
}