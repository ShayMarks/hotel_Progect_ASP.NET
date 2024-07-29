using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
/*
מחלקת Invoice: מייצגת את ישות החשבונית עם כל השדות הרלוונטיים.

מחלקת InvoiceDAL:
GetAllInvoices: מחזירה רשימה של כל החשבוניות.
GetInvoiceByID: מחזירה חשבונית לפי מזהה (ID).
CreateInvoice: יוצרת חשבונית חדשה.
UpdateInvoice: מעדכנת חשבונית קיימת.
DeleteInvoice: מוחקת חשבונית לפי מזהה (ID).
 */
namespace HotelManagementSystem.DAL
{
    // Invoice entity class
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public int ReservationID { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class InvoiceDAL
    {
        // Method to get all invoices
        public static List<Invoice> GetAllInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Invoices";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Invoice invoice = new Invoice
                    {
                        InvoiceID = (int)reader["InvoiceID"],
                        ReservationID = (int)reader["ReservationID"],
                        IssueDate = (DateTime)reader["IssueDate"],
                        TotalAmount = (decimal)reader["TotalAmount"]
                    };
                    invoices.Add(invoice);
                }
                reader.Close();
            }

            return invoices;
        }

        // Method to get an invoice by ID
        public static Invoice GetInvoiceByID(int invoiceID)
        {
            Invoice invoice = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InvoiceID", invoiceID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    invoice = new Invoice
                    {
                        InvoiceID = (int)reader["InvoiceID"],
                        ReservationID = (int)reader["ReservationID"],
                        IssueDate = (DateTime)reader["IssueDate"],
                        TotalAmount = (decimal)reader["TotalAmount"]
                    };
                }
                reader.Close();
            }

            return invoice;
        }

        // Method to create a new invoice
        public static void CreateInvoice(Invoice invoice)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Invoices (ReservationID, IssueDate, TotalAmount) VALUES (@ReservationID, @IssueDate, @TotalAmount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", invoice.ReservationID);
                command.Parameters.AddWithValue("@IssueDate", invoice.IssueDate);
                command.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing invoice
        public static void UpdateInvoice(Invoice invoice)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Invoices SET ReservationID = @ReservationID, IssueDate = @IssueDate, TotalAmount = @TotalAmount WHERE InvoiceID = @InvoiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", invoice.ReservationID);
                command.Parameters.AddWithValue("@IssueDate", invoice.IssueDate);
                command.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                command.Parameters.AddWithValue("@InvoiceID", invoice.InvoiceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete an invoice
        public static void DeleteInvoice(int invoiceID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InvoiceID", invoiceID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
