using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/*
מחלקת Room: מייצגת את ישות החדר עם כל השדות הרלוונטיים.

מחלקת RoomDAL:
GetAllRooms: מחזירה רשימה של כל החדרים.
GetRoomByID: מחזירה חדר לפי מזהה (ID).
CreateRoom: יוצרת חדר חדש.
UpdateRoom: מעדכנת חדר קיים.
DeleteRoom: מוחקת חדר לפי מזהה (ID).
 */

namespace HotelManagementSystem.DAL
{
    // Room entity class
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }

    public class RoomDAL
    {
        // Method to get all rooms
        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Rooms";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Room room = new Room
                    {
                        RoomID = (int)reader["RoomID"],
                        RoomNumber = reader["RoomNumber"].ToString(),
                        Type = reader["Type"].ToString(),
                        Price = (decimal)reader["Price"],
                        Status = reader["Status"].ToString()
                    };
                    rooms.Add(room);
                }
                reader.Close();
            }

            return rooms;
        }

        // Method to get a room by ID
        public static Room GetRoomByID(int roomID)
        {
            Room room = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    room = new Room
                    {
                        RoomID = (int)reader["RoomID"],
                        RoomNumber = reader["RoomNumber"].ToString(),
                        Type = reader["Type"].ToString(),
                        Price = (decimal)reader["Price"],
                        Status = reader["Status"].ToString()
                    };
                }
                reader.Close();
            }

            return room;
        }

        // Method to create a new room
        public static void CreateRoom(Room room)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Rooms (RoomNumber, Type, Price, Status) VALUES (@RoomNumber, @Type, @Price, @Status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@Type", room.Type);
                command.Parameters.AddWithValue("@Price", room.Price);
                command.Parameters.AddWithValue("@Status", room.Status);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing room
        public static void UpdateRoom(Room room)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Rooms SET RoomNumber = @RoomNumber, Type = @Type, Price = @Price, Status = @Status WHERE RoomID = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@Type", room.Type);
                command.Parameters.AddWithValue("@Price", room.Price);
                command.Parameters.AddWithValue("@Status", room.Status);
                command.Parameters.AddWithValue("@RoomID", room.RoomID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a room
        public static void DeleteRoom(int roomID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
