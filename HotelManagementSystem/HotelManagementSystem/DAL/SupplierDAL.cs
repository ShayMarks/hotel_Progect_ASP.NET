using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/*
מחלקת Supplier: מייצגת את ישות הספק עם כל השדות הרלוונטיים.

מחלקת SupplierDAL:
GetAllSuppliers: מחזירה רשימה של כל הספקים.
GetSupplierByID: מחזירה ספק לפי מזהה (ID).
CreateSupplier: יוצרת ספק חדש.
UpdateSupplier: מעדכנת ספק קיים.
DeleteSupplier: מוחקת ספק לפי מזהה (ID).
 */
namespace HotelManagementSystem.DAL
{
    // Supplier entity class
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class SupplierDAL
    {
        // Method to get all suppliers
        public static List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Suppliers";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Supplier supplier = new Supplier
                    {
                        SupplierID = (int)reader["SupplierID"],
                        SupplierName = reader["SupplierName"].ToString(),
                        ContactName = reader["ContactName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString()
                    };
                    suppliers.Add(supplier);
                }
                reader.Close();
            }

            return suppliers;
        }

        // Method to get a supplier by ID
        public static Supplier GetSupplierByID(int supplierID)
        {
            Supplier supplier = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Suppliers WHERE SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    supplier = new Supplier
                    {
                        SupplierID = (int)reader["SupplierID"],
                        SupplierName = reader["SupplierName"].ToString(),
                        ContactName = reader["ContactName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString()
                    };
                }
                reader.Close();
            }

            return supplier;
        }

        // Method to create a new supplier
        public static void CreateSupplier(Supplier supplier)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Suppliers (SupplierName, ContactName, Email, Phone) VALUES (@SupplierName, @ContactName, @Email, @Phone)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                command.Parameters.AddWithValue("@Email", supplier.Email);
                command.Parameters.AddWithValue("@Phone", supplier.Phone);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing supplier
        public static void UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Suppliers SET SupplierName = @SupplierName, ContactName = @ContactName, Email = @Email, Phone = @Phone WHERE SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                command.Parameters.AddWithValue("@Email", supplier.Email);
                command.Parameters.AddWithValue("@Phone", supplier.Phone);
                command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a supplier
        public static void DeleteSupplier(int supplierID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
