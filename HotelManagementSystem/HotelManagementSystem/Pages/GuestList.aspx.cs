using System;
using System.Web.UI;

namespace HotelManagementSystem.Pages
{
    public partial class GuestList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("GuestEdit.aspx");
        }
        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

    }
}
