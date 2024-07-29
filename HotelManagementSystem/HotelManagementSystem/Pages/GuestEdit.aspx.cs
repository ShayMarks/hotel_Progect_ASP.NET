using System;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class GuestEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["GuestID"] != null)
                {
                    int guestID = int.Parse(Request.QueryString["GuestID"]);
                    Guest guest = GuestDAL.GetGuestByID(guestID);
                    if (guest != null)
                    {
                        lblGuestIDValue.Text = guest.GuestID.ToString();
                        txtFirstName.Text = guest.FirstName;
                        txtLastName.Text = guest.LastName;
                        txtEmail.Text = guest.Email;
                        txtPhone.Text = guest.Phone;
                        txtAddress.Text = guest.Address;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guest guest = new Guest
            {
                GuestID = string.IsNullOrEmpty(lblGuestIDValue.Text) ? 0 : int.Parse(lblGuestIDValue.Text),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            if (guest.GuestID == 0)
            {
                GuestDAL.CreateGuest(guest);
            }
            else
            {
                GuestDAL.UpdateGuest(guest);
            }

            Response.Redirect("GuestList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("GuestList.aspx");
        }
    }
}
