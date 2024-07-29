using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace HotelManagementSystem.Pages
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            var user = HttpContext.Current.User;
            if (user != null && user.Identity.IsAuthenticated)
            {
                FormsIdentity id = (FormsIdentity)User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;

                string[] roles = ticket.UserData.Split(',');
                if (roles.Length > 0)
                {
                    foreach (string role in roles)
                    {
                        if (role == "Manager")
                        {
                            ManagerPanel.Visible = true;
                            AdminPanel.Visible = true;
                            EmployeePanel.Visible = true;
                        }
                        else if (role == "TeamLeader")
                        {
                            AdminPanel.Visible = true;
                            EmployeePanel.Visible = true;
                        }
                        else if (role == "Employee")
                        {
                            EmployeePanel.Visible = true;
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('User does not have a valid role');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('User not authenticated');</script>");
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}
