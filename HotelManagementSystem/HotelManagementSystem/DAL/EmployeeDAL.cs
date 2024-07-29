using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/*
מחלקת Employee: מייצגת את ישות העובד עם כל השדות הרלוונטיים.

מחלקת EmployeeDAL:
GetAllEmployees: מחזירה רשימה של כל העובדים.
GetEmployeeByID: מחזירה עובד לפי מזהה (ID).
CreateEmployee: יוצרת עובד חדש.
UpdateEmployee: מעדכנת עובד קיים.
DeleteEmployee: מוחקת עובד לפי מזהה (ID).
 */
namespace HotelManagementSystem.DAL
{
    // Employee entity class
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
    }

    public class EmployeeDAL
    {
        // Method to get all employees
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Position = reader["Position"].ToString()
                    };
                    employees.Add(employee);
                }
                reader.Close();
            }

            return employees;
        }

        // Method to get an employee by ID
        public static Employee GetEmployeeByID(int employeeID)
        {
            Employee employee = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeID = (int)reader["EmployeeID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Position = reader["Position"].ToString()
                    };
                }
                reader.Close();
            }

            return employee;
        }

        // Method to create a new employee
        public static void CreateEmployee(Employee employee)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Employees (FirstName, LastName, Email, Phone, Position) VALUES (@FirstName, @LastName, @Email, @Phone, @Position)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Phone", employee.Phone);
                command.Parameters.AddWithValue("@Position", employee.Position);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing employee
        public static void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Position = @Position WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Phone", employee.Phone);
                command.Parameters.AddWithValue("@Position", employee.Position);
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete an employee
        public static void DeleteEmployee(int employeeID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
