using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/*
מחלקת Maintenance: מייצגת את ישות התחזוקה עם כל השדות הרלוונטיים.

מחלקת MaintenanceDAL:
GetAllMaintenances: מחזירה רשימה של כל רשומות התחזוקה.
GetMaintenanceByID: מחזירה רשומת תחזוקה לפי מזהה (ID).
CreateMaintenance: יוצרת רשומת תחזוקה חדשה.
UpdateMaintenance: מעדכנת רשומת תחזוקה קיימת.
DeleteMaintenance: מוחקת רשומת תחזוקה לפי מזהה (ID).
*/
namespace HotelManagementSystem.DAL
{
    // Maintenance entity class
    public class Maintenance
    {
        public int MaintenanceID { get; set; }
        public int RoomID { get; set; }
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
    }

    public class MaintenanceDAL
    {
        // Method to get all maintenance records
        public static List<Maintenance> GetAllMaintenances()
        {
            List<Maintenance> maintenances = new List<Maintenance>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Maintenance";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Maintenance maintenance = new Maintenance
                    {
                        MaintenanceID = (int)reader["MaintenanceID"],
                        RoomID = (int)reader["RoomID"],
                        Description = reader["Description"].ToString(),
                        MaintenanceDate = (DateTime)reader["MaintenanceDate"]
                    };
                    maintenances.Add(maintenance);
                }
                reader.Close();
            }

            return maintenances;
        }

        // Method to get a maintenance record by ID
        public static Maintenance GetMaintenanceByID(int maintenanceID)
        {
            Maintenance maintenance = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Maintenance WHERE MaintenanceID = @MaintenanceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaintenanceID", maintenanceID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    maintenance = new Maintenance
                    {
                        MaintenanceID = (int)reader["MaintenanceID"],
                        RoomID = (int)reader["RoomID"],
                        Description = reader["Description"].ToString(),
                        MaintenanceDate = (DateTime)reader["MaintenanceDate"]
                    };
                }
                reader.Close();
            }

            return maintenance;
        }

        // Method to create a new maintenance record
        public static void CreateMaintenance(Maintenance maintenance)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Maintenance (RoomID, Description, MaintenanceDate) VALUES (@RoomID, @Description, @MaintenanceDate)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", maintenance.RoomID);
                command.Parameters.AddWithValue("@Description", maintenance.Description);
                command.Parameters.AddWithValue("@MaintenanceDate", maintenance.MaintenanceDate);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing maintenance record
        public static void UpdateMaintenance(Maintenance maintenance)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Maintenance SET RoomID = @RoomID, Description = @Description, MaintenanceDate = @MaintenanceDate WHERE MaintenanceID = @MaintenanceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", maintenance.RoomID);
                command.Parameters.AddWithValue("@Description", maintenance.Description);
                command.Parameters.AddWithValue("@MaintenanceDate", maintenance.MaintenanceDate);
                command.Parameters.AddWithValue("@MaintenanceID", maintenance.MaintenanceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a maintenance record
        public static void DeleteMaintenance(int maintenanceID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Maintenance WHERE MaintenanceID = @MaintenanceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaintenanceID", maintenanceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
