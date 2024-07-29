using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/*
מחלקת Guest: מייצגת את ישות האורח עם כל השדות הרלוונטיים.

מחלקת GuestDAL:
GetAllGuests: מחזירה רשימה של כל האורחים.
GetGuestByID: מחזירה אורח לפי מזהה (ID).
CreateGuest: יוצרת אורח חדש.
UpdateGuest: מעדכנת אורח קיים.
DeleteGuest: מוחקת אורח לפי מזהה (ID).
 */

namespace HotelManagementSystem.DAL
{
    // Guest entity class
    public class Guest
    {
        public int GuestID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class GuestDAL
    {
        // Method to get all guests
        public static List<Guest> GetAllGuests()
        {
            List<Guest> guests = new List<Guest>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Guests";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Guest guest = new Guest
                    {
                        GuestID = (int)reader["GuestID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                    guests.Add(guest);
                }
                reader.Close();
            }

            return guests;
        }

        // Method to get a guest by ID
        public static Guest GetGuestByID(int guestID)
        {
            Guest guest = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Guests WHERE GuestID = @GuestID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GuestID", guestID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    guest = new Guest
                    {
                        GuestID = (int)reader["GuestID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };
                }
                reader.Close();
            }

            return guest;
        }

        // Method to create a new guest
        public static void CreateGuest(Guest guest)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Guests (FirstName, LastName, Email, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Phone, @Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", guest.FirstName);
                command.Parameters.AddWithValue("@LastName", guest.LastName);
                command.Parameters.AddWithValue("@Email", guest.Email);
                command.Parameters.AddWithValue("@Phone", guest.Phone);
                command.Parameters.AddWithValue("@Address", guest.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing guest
        public static void UpdateGuest(Guest guest)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Guests SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address WHERE GuestID = @GuestID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", guest.FirstName);
                command.Parameters.AddWithValue("@LastName", guest.LastName);
                command.Parameters.AddWithValue("@Email", guest.Email);
                command.Parameters.AddWithValue("@Phone", guest.Phone);
                command.Parameters.AddWithValue("@Address", guest.Address);
                command.Parameters.AddWithValue("@GuestID", guest.GuestID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a guest
        public static void DeleteGuest(int guestID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Guests WHERE GuestID = @GuestID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GuestID", guestID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
