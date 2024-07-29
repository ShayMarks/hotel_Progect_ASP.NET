using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class EmployeeManagement : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            CheckUserAuthorization();

            if (!IsPostBack)
            {
                BindEmployeeGrid();
            }
        }

        private void CheckUserAuthorization()
        {
            string role = GetUserRole(User.Identity.Name);

            if (role != "Manager") // רק מנהל יכול לגשת לדף זה
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

        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

        private void BindEmployeeGrid()
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserID, Username, Role FROM Users", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvEmployees.DataSource = dt;
                        gvEmployees.DataBind();
                    }
                }
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            pnlAddEditEmployee.Visible = true;
            lblAddEditEmployee.Text = "Add Employee";
            ClearForm();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd;
                if (lblAddEditEmployee.Text == "Add Employee")
                {
                    cmd = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", con);
                }
                else
                {
                    int userID = Convert.ToInt32(gvEmployees.SelectedDataKey.Value);
                    cmd = new SqlCommand("UPDATE Users SET Username=@Username, Password=@Password, Role=@Role WHERE UserID=@UserID", con);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                }

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            pnlAddEditEmployee.Visible = false;
            BindEmployeeGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAddEditEmployee.Visible = false;
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvEmployees.Rows[e.RowIndex];
            if (row == null || e.RowIndex < 0 || e.RowIndex >= gvEmployees.DataKeys.Count)
            {
                // Handle the case where the row is not valid
                return;
            }

            int userID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);
            TextBox txtUsernameEdit = row.FindControl("txtUsernameEdit") as TextBox;
            TextBox txtPasswordEdit = row.FindControl("txtPasswordEdit") as TextBox;
            DropDownList ddlRoleEdit = row.FindControl("ddlRoleEdit") as DropDownList;

            if (txtUsernameEdit == null || txtPasswordEdit == null || ddlRoleEdit == null)
            {
                // Handle the case where the controls are not found
                return;
            }

            string username = txtUsernameEdit.Text;
            string password = txtPasswordEdit.Text;
            string role = ddlRoleEdit.SelectedValue;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Username=@Username, Password=@Password, Role=@Role WHERE UserID=@UserID", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            gvEmployees.EditIndex = -1;
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            BindEmployeeGrid();
        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= gvEmployees.DataKeys.Count)
            {
                // Handle the case where the row is not valid
                return;
            }

            int userID = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID=@UserID", con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            BindEmployeeGrid();
        }

        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            ddlRole.SelectedIndex = 0;
        }
    }
}
