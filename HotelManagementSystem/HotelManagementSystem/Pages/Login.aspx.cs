using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string query = "SELECT Role FROM Users WHERE Username=@Username AND Password=@Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    string role = cmd.ExecuteScalar() as string;
                    con.Close();

                    if (!string.IsNullOrEmpty(role))
                    {
                        FormsAuthentication.SetAuthCookie(username, true);

                        // Adding role to the cookie
                        var authTicket = new FormsAuthenticationTicket(
                            1,                  // version
                            username,           // user name
                            DateTime.Now,       // created
                            DateTime.Now.AddMinutes(30),  // expires
                            false,              // persistent?
                            role                // can be used to store roles
                        );

                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(authCookie);

                        Response.Redirect("~/Pages/Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid username or password');</script>");
                    }
                }
            }
        }
    }
}
