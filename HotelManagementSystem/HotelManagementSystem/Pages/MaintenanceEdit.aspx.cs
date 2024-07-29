using System;
using System.Data.SqlClient;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class MaintenanceEdit : Page
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

                if (Request.QueryString["MaintenanceID"] != null)
                {
                    int maintenanceID = int.Parse(Request.QueryString["MaintenanceID"]);
                    Maintenance maintenance = MaintenanceDAL.GetMaintenanceByID(maintenanceID);
                    if (maintenance != null)
                    {
                        lblMaintenanceIDValue.Text = maintenance.MaintenanceID.ToString();
                        txtRoomID.Text = maintenance.RoomID.ToString();
                        txtDescription.Text = maintenance.Description;
                        txtMaintenanceDate.Text = maintenance.MaintenanceDate.ToString("yyyy-MM-dd");
                    }
                }
            }
        }

        private void CheckUserAuthorization()
        {
            string role = GetUserRole(User.Identity.Name); // שימוש בשם המשתמש המחובר

            if (role != "Manager" && role != "TeamLeader")
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
            Maintenance maintenance = new Maintenance
            {
                MaintenanceID = string.IsNullOrEmpty(lblMaintenanceIDValue.Text) ? 0 : int.Parse(lblMaintenanceIDValue.Text),
                RoomID = int.Parse(txtRoomID.Text),
                Description = txtDescription.Text,
                MaintenanceDate = DateTime.Parse(txtMaintenanceDate.Text)
            };

            if (maintenance.MaintenanceID == 0)
            {
                MaintenanceDAL.CreateMaintenance(maintenance);
            }
            else
            {
                MaintenanceDAL.UpdateMaintenance(maintenance);
            }

            Response.Redirect("MaintenanceList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaintenanceList.aspx");
        }
    }
}
