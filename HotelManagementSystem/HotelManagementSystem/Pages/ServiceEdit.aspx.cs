using System;
using System.Web.UI;
using HotelManagementSystem.DAL;

namespace HotelManagementSystem.Pages
{
    public partial class ServiceEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["ServiceID"] != null)
                {
                    int serviceID = int.Parse(Request.QueryString["ServiceID"]);
                    Service service = ServiceDAL.GetServiceByID(serviceID);
                    if (service != null)
                    {
                        lblServiceIDValue.Text = service.ServiceID.ToString();
                        txtServiceName.Text = service.ServiceName;
                        txtDescription.Text = service.Description;
                        txtPrice.Text = service.Price.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Service service = new Service
            {
                ServiceID = string.IsNullOrEmpty(lblServiceIDValue.Text) ? 0 : int.Parse(lblServiceIDValue.Text),
                ServiceName = txtServiceName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text)
            };

            if (service.ServiceID == 0)
            {
                ServiceDAL.CreateService(service);
            }
            else
            {
                ServiceDAL.UpdateService(service);
            }

            Response.Redirect("ServiceList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceList.aspx");
        }
    }
}
