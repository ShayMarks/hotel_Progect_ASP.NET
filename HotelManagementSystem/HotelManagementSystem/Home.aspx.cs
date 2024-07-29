using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace HotelManagementSystem
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string configPath = Server.MapPath("~/config.json");

            // במידה ורוצים לבצע בדיקות תקינות הקוד ללא איפיאי יש למחוק את כל הקטע הבא
            // בדוק אם הקובץ קיים לפני הקריאה
            if (File.Exists(configPath))
            {
                var config = JObject.Parse(File.ReadAllText(configPath));

                // בדוק אם מפתחות ה-API קיימים בקובץ
                if (config["weatherAPI"] != null && config["weatherAPI"]["apiKey"] != null)
                {
                    string weatherApiKey = config["weatherAPI"]["apiKey"].ToString();
                    ViewState["WeatherApiKey"] = weatherApiKey;
                }
                else
                {
                    ViewState["WeatherApiKey"] = "MISSING_API_KEY";
                }

                if (config["googleMapsAPI"] != null && config["googleMapsAPI"]["apiKey"] != null)
                {
                    string googleMapsApiKey = config["googleMapsAPI"]["apiKey"].ToString();
                    ViewState["GoogleMapsApiKey"] = googleMapsApiKey;
                }
                else
                {
                    ViewState["GoogleMapsApiKey"] = "MISSING_API_KEY";
                }

                if (config["emailService"] != null && config["emailService"]["publicKey"] != null)
                {
                    string emailServicePublicKey = config["emailService"]["publicKey"].ToString();
                    ViewState["EmailServicePublicKey"] = emailServicePublicKey;
                }
                else
                {
                    ViewState["EmailServicePublicKey"] = "MISSING_API_KEY";
                }
            }
            else

            {
                ViewState["WeatherApiKey"] = "MISSING_CONFIG_FILE";
                ViewState["GoogleMapsApiKey"] = "MISSING_CONFIG_FILE";
                ViewState["EmailServicePublicKey"] = "MISSING_CONFIG_FILE";
            }
        }

        protected void btnEmployeeLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/Login.aspx");
        }
    }
}
