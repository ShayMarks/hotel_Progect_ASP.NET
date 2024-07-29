using System;
using System.Data.SqlClient;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class RoomEdit : Page
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

                if (Request.QueryString["RoomID"] != null)
                {
                    int roomID;
                    if (int.TryParse(Request.QueryString["RoomID"], out roomID))
                    {
                        Room room = RoomDAL.GetRoomByID(roomID);
                        if (room != null)
                        {
                            lblRoomIDValue.Text = room.RoomID.ToString();
                            txtRoomNumber.Text = room.RoomNumber;
                            txtType.Text = room.Type;
                            txtPrice.Text = room.Price.ToString();
                            txtStatus.Text = room.Status;
                        }
                    }
                    else
                    {
                        // Handle error if the RoomID query string is not a valid integer
                        lblRoomIDValue.Text = "Invalid Room ID";
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
            int roomID = 0;
            if (!string.IsNullOrEmpty(lblRoomIDValue.Text))
            {
                int.TryParse(lblRoomIDValue.Text, out roomID);
            }

            decimal price = 0;
            if (!string.IsNullOrEmpty(txtPrice.Text))
            {
                decimal.TryParse(txtPrice.Text, out price);
            }

            Room room = new Room
            {
                RoomID = roomID,
                RoomNumber = txtRoomNumber.Text,
                Type = txtType.Text,
                Price = price,
                Status = txtStatus.Text
            };

            if (room.RoomID == 0)
            {
                RoomDAL.CreateRoom(room);
            }
            else
            {
                RoomDAL.UpdateRoom(room);
            }

            Response.Redirect("RoomList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoomList.aspx");
        }
    }
}
