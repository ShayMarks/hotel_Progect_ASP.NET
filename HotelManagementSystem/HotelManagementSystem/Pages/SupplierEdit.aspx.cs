using System;
using System.Data.SqlClient;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class SupplierEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CheckUserAuthorization();

                if (Request.QueryString["SupplierID"] != null)
                {
                    int supplierID = int.Parse(Request.QueryString["SupplierID"]);
                    Supplier supplier = SupplierDAL.GetSupplierByID(supplierID);
                    if (supplier != null)
                    {
                        lblSupplierIDValue.Text = supplier.SupplierID.ToString();
                        txtSupplierName.Text = supplier.SupplierName;
                        txtContactName.Text = supplier.ContactName;
                        txtEmail.Text = supplier.Email;
                        txtPhone.Text = supplier.Phone;
                    }
                }
            }
        }

        private void CheckUserAuthorization()
        {
            string role = GetUserRole(User.Identity.Name);

            if (role != "Manager" && role != "TeamLeader") // רק מנהל ומנהל צוות יכולים לגשת לדף זה
            {
                Response.Redirect("Unauthorized.aspx");
            }
        }

        private string GetUserRole(string username)
        {
            string role = string.Empty;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["HotelManagementDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Role FROM Users WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    role = reader["Role"].ToString();
                }

                reader.Close();
            }

            return role;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                SupplierID = string.IsNullOrEmpty(lblSupplierIDValue.Text) ? 0 : int.Parse(lblSupplierIDValue.Text),
                SupplierName = txtSupplierName.Text,
                ContactName = txtContactName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            if (supplier.SupplierID == 0)
            {
                SupplierDAL.CreateSupplier(supplier);
            }
            else
            {
                SupplierDAL.UpdateSupplier(supplier);
            }

            Response.Redirect("SupplierList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierList.aspx");
        }
    }
}
