using System;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class ReservationEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["ReservationID"] != null)
                {
                    int reservationID = int.Parse(Request.QueryString["ReservationID"]);
                    Reservation reservation = ReservationDAL.GetReservationByID(reservationID);
                    if (reservation != null)
                    {
                        lblReservationIDValue.Text = reservation.ReservationID.ToString();
                        txtGuestID.Text = reservation.GuestID.ToString();
                        txtRoomID.Text = reservation.RoomID.ToString();
                        txtCheckInDate.Text = reservation.CheckInDate.ToString("yyyy-MM-dd");
                        txtCheckOutDate.Text = reservation.CheckOutDate.ToString("yyyy-MM-dd");
                        txtTotalAmount.Text = reservation.TotalAmount.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation
            {
                ReservationID = string.IsNullOrEmpty(lblReservationIDValue.Text) ? 0 : int.Parse(lblReservationIDValue.Text),
                GuestID = int.Parse(txtGuestID.Text),
                RoomID = int.Parse(txtRoomID.Text),
                CheckInDate = DateTime.Parse(txtCheckInDate.Text),
                CheckOutDate = DateTime.Parse(txtCheckOutDate.Text),
                TotalAmount = decimal.Parse(txtTotalAmount.Text)
            };

            if (reservation.ReservationID == 0)
            {
                ReservationDAL.CreateReservation(reservation);
            }
            else
            {
                ReservationDAL.UpdateReservation(reservation);
            }

            Response.Redirect("ReservationList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReservationList.aspx");
        }
    }
}
