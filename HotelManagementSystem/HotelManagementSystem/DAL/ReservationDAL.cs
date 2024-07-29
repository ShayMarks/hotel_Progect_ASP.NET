using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

/*
מחלקת Reservation: מייצגת את ישות ההזמנה עם כל השדות הרלוונטיים.

מחלקת ReservationDAL:
GetAllReservations: מחזירה רשימה של כל ההזמנות.
GetReservationByID: מחזירה הזמנה לפי מזהה (ID).
CreateReservation: יוצרת הזמנה חדשה.
UpdateReservation: מעדכנת הזמנה קיימת.
DeleteReservation: מוחקת הזמנה לפי מזהה (ID).
 */

namespace HotelManagementSystem.DAL
{
    // Reservation entity class
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int GuestID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class ReservationDAL
    {
        // Method to get all reservations
        public static List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Reservations";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Reservation reservation = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        GuestID = (int)reader["GuestID"],
                        RoomID = (int)reader["RoomID"],
                        CheckInDate = (DateTime)reader["CheckInDate"],
                        CheckOutDate = (DateTime)reader["CheckOutDate"],
                        TotalAmount = (decimal)reader["TotalAmount"]
                    };
                    reservations.Add(reservation);
                }
                reader.Close();
            }

            return reservations;
        }

        // Method to get a reservation by ID
        public static Reservation GetReservationByID(int reservationID)
        {
            Reservation reservation = null;

            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Reservations WHERE ReservationID = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservationID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    reservation = new Reservation
                    {
                        ReservationID = (int)reader["ReservationID"],
                        GuestID = (int)reader["GuestID"],
                        RoomID = (int)reader["RoomID"],
                        CheckInDate = (DateTime)reader["CheckInDate"],
                        CheckOutDate = (DateTime)reader["CheckOutDate"],
                        TotalAmount = (decimal)reader["TotalAmount"]
                    };
                }
                reader.Close();
            }

            return reservation;
        }

        // Method to create a new reservation
        public static void CreateReservation(Reservation reservation)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "INSERT INTO Reservations (GuestID, RoomID, CheckInDate, CheckOutDate, TotalAmount) VALUES (@GuestID, @RoomID, @CheckInDate, @CheckOutDate, @TotalAmount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GuestID", reservation.GuestID);
                command.Parameters.AddWithValue("@RoomID", reservation.RoomID);
                command.Parameters.AddWithValue("@CheckInDate", reservation.CheckInDate);
                command.Parameters.AddWithValue("@CheckOutDate", reservation.CheckOutDate);
                command.Parameters.AddWithValue("@TotalAmount", reservation.TotalAmount);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to update an existing reservation
        public static void UpdateReservation(Reservation reservation)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE Reservations SET GuestID = @GuestID, RoomID = @RoomID, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate, TotalAmount = @TotalAmount WHERE ReservationID = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GuestID", reservation.GuestID);
                command.Parameters.AddWithValue("@RoomID", reservation.RoomID);
                command.Parameters.AddWithValue("@CheckInDate", reservation.CheckInDate);
                command.Parameters.AddWithValue("@CheckOutDate", reservation.CheckOutDate);
                command.Parameters.AddWithValue("@TotalAmount", reservation.TotalAmount);
                command.Parameters.AddWithValue("@ReservationID", reservation.ReservationID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a reservation
        public static void DeleteReservation(int reservationID)
        {
            using (SqlConnection connection = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservationID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
