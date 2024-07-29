using System;
using System.Web.UI;

namespace HotelManagementSystem.Pages
{
    public partial class ServiceList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceEdit.aspx");
        }
        protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Default.aspx");
        }

    }
}
