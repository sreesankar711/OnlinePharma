using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace MedicalStore.Views.Client
{
    public partial class Shop : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Loggedin"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowMedicines();
                ShowSelectedMedicines();
            }

            if (Session["CartTable"] != null)
            {
                SelectedMedicine.DataSource = Session["CartTable"];
                SelectedMedicine.DataBind();
                DataTable cartTable = (DataTable)Session["CartTable"];
                int totalPrice = cartTable.AsEnumerable().Sum(row => Convert.ToInt32(row["TotalPrice"]));
                Total_price.Text = totalPrice.ToString();

            }

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

        }
        private void ShowSelectedMedicines()
        {
            DataTable cartTable = new DataTable();
            cartTable.Columns.Add("MedicineId", typeof(string));
            cartTable.Columns.Add("ClientId", typeof(int));
            cartTable.Columns.Add("MedicineName", typeof(string));
            cartTable.Columns.Add("Price", typeof(int));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("TotalPrice", typeof(int));

            SelectedMedicine.DataSource = cartTable;
            SelectedMedicine.DataBind();

        }




            private void ShowMedicines()
        {
            string Query = "select * from MedicalTbl";
            MedicineList.DataSource = Con.GetData(Query);
            MedicineList.DataBind();
        }


        protected void MedicineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = MedicineList.SelectedRow.Cells[1].Text;
            string stock = MedicineList.SelectedRow.Cells[4].Text;
            string medicineName = MedicineList.SelectedRow.Cells[2].Text;
            int medicinePrice = Convert.ToInt32(MedicineList.SelectedRow.Cells[3].Text);

            // Update the stock in the database
            string query = "UPDATE MedicalTbl SET Stock = Stock - 1 WHERE Id = @Id";
            string deleteQuery = "DELETE FROM MedicalTbl WHERE Id = @Id";
            string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                int newStock = Convert.ToInt32(stock) - 1;

                if (newStock == 0)
                {
                    command = new SqlCommand(deleteQuery, connection);
                }
                else
                {
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NewStock", newStock);
                }

                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
            ShowMedicines();

            DataTable cartTable;
            if (Session["CartTable"] == null)
            {
                cartTable = new DataTable();
                cartTable.Columns.Add("MedicineId", typeof(string));
                cartTable.Columns.Add("ClientId", typeof(int));
                cartTable.Columns.Add("MedicineName", typeof(string));
                cartTable.Columns.Add("Price", typeof(int));
                cartTable.Columns.Add("Quantity", typeof(int));
                cartTable.Columns.Add("TotalPrice", typeof(int));
                Session["CartTable"] = cartTable;
            }
            else
            {
                cartTable = (DataTable)Session["CartTable"];
            }

            DataRow[] rows = cartTable.Select("MedicineId = " + id);
            if (rows.Length > 0)
            {
                DataRow existingRow = rows[0];
                existingRow["Quantity"] = Convert.ToInt32(existingRow["Quantity"]) + 1;
                existingRow["TotalPrice"] = Convert.ToInt32(existingRow["Quantity"]) * medicinePrice;
            }
            else
            {
                DataRow newRow = cartTable.NewRow();
                newRow["MedicineId"] = id;
                newRow["ClientId"] = Convert.ToInt32(Session["clientId"]);
                newRow["MedicineName"] = medicineName;
                newRow["Price"] = medicinePrice;
                newRow["Quantity"] = 1;
                newRow["TotalPrice"] = medicinePrice;
                cartTable.Rows.Add(newRow);

            }

            int totalPrice = cartTable.AsEnumerable().Sum(row => Convert.ToInt32(row["TotalPrice"]));
            Total_price.Text = totalPrice.ToString();



            SelectedMedicine.DataSource = cartTable;
            Session["CartTable"] = cartTable;
            SelectedMedicine.DataBind();


        }

         protected void Cart_Click(object sender, EventArgs e)
            {
                DataTable cartTable = (DataTable)Session["CartTable"];
                if (cartTable != null && cartTable.Rows.Count > 0)
                {
                    string connectionString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (GridViewRow row in SelectedMedicine.Rows)
                        {
                        string clientId = row.Cells[1].Text;
                        string medicineId = row.Cells[0].Text;
                        string medicineName = row.Cells[2].Text;
                        string price = row.Cells[3].Text;
                        string quantity = row.Cells[4].Text;
                        string totalPrice = row.Cells[5].Text;

                        string insertQuery = "INSERT INTO Cart (Id,ClientId, Med, Price, Quantity, TotalPrice) " +
                                                 "VALUES ( @MedicineId,@ClientId, @MedicineName, @Price, @Quantity, @TotalPrice)";
                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@ClientId", clientId);
                            insertCommand.Parameters.AddWithValue("@MedicineId", medicineId);
                            insertCommand.Parameters.AddWithValue("@MedicineName", medicineName);
                            insertCommand.Parameters.AddWithValue("@Price", price);
                            insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                            insertCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                SelectedMedicine.DataSource = null;
                SelectedMedicine.DataBind();
                cartTable.Clear();
                Session["CartTable"] = null;
                Total_price.Text = "0";
            }
            }

        }



    }
