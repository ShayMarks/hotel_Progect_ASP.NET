using System;
using System.Data.SqlClient;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class EmployeeEdit : Page
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

                if (Request.QueryString["EmployeeID"] != null)
                {
                    int employeeID = int.Parse(Request.QueryString["EmployeeID"]);
                    Employee employee = EmployeeDAL.GetEmployeeByID(employeeID);
                    if (employee != null)
                    {
                        lblEmployeeIDValue.Text = employee.EmployeeID.ToString();
                        txtFirstName.Text = employee.FirstName;
                        txtLastName.Text = employee.LastName;
                        txtEmail.Text = employee.Email;
                        txtPhone.Text = employee.Phone;
                        txtPosition.Text = employee.Position;
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
            Employee employee = new Employee
            {
                EmployeeID = string.IsNullOrEmpty(lblEmployeeIDValue.Text) ? 0 : int.Parse(lblEmployeeIDValue.Text),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Position = txtPosition.Text
            };

            if (employee.EmployeeID == 0)
            {
                EmployeeDAL.CreateEmployee(employee);
            }
            else
            {
                EmployeeDAL.UpdateEmployee(employee);
            }

            Response.Redirect("EmployeeList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeList.aspx");
        }
    }
}
