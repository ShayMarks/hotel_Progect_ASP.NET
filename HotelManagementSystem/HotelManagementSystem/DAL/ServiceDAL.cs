using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/*
מחלקת Service: מייצגת את ישות השירות עם כל השדות הרלוונטיים.

מחלקת ServiceDAL:
GetAllServices: מחזירה רשימה של כל השירותים.
GetServiceByID: מחזירה שירות לפי מזהה (ID).
CreateService: יוצרת שירות חדש.
UpdateService: מעדכנת שירות קיים.
DeleteService: מוחקת שירות לפי מזהה (ID).
 */
namespace HotelManagementSystem.DAL
{
    // Service entity class
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ServiceDAL
    {
        // Method to get all services
        public static List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Services";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Service service = new Service
                    {
                        ServiceID = (int)reader["ServiceID"],
                        ServiceName = reader["ServiceName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"]
                    };
                    services.Add(service);
                }
                reader.Close();
            }

            return services;
        }

        // Method to get a service by ID
        public static Service GetServiceByID(int serviceID)
        {
            Service service = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Services WHERE ServiceID = @ServiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceID", serviceID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    service = new Service
                    {
                        ServiceID = (int)reader["ServiceID"],
                        ServiceName = reader["ServiceName"].ToString(),
                        Description = reader["Description"].ToString(),
                        Price = (decimal)reader["Price"]
                    };
                }
                reader.Close();
            }

            return service;
        }

        // Method to create a new service
        public static void CreateService(Service service)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Services (ServiceName, Description, Price) VALUES (@ServiceName, @Description, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                command.Parameters.AddWithValue("@Description", service.Description);
                command.Parameters.AddWithValue("@Price", service.Price);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing service
        public static void UpdateService(Service service)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Services SET ServiceName = @ServiceName, Description = @Description, Price = @Price WHERE ServiceID = @ServiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                command.Parameters.AddWithValue("@Description", service.Description);
                command.Parameters.AddWithValue("@Price", service.Price);
                command.Parameters.AddWithValue("@ServiceID", service.ServiceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a service
        public static void DeleteService(int serviceID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Services WHERE ServiceID = @ServiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceID", serviceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
