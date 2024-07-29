using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HotelManagementSystem.Pages
{
    public partial class EmployeeList : Page
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
                // Add any additional logic here
            }
        }

        private void CheckUserAuthorization()
        {
            string role = GetUserRole(User.Identity.Name); // שימוש בשם המשתמש המחובר

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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeEdit.aspx");
        }

        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }
    }
}
