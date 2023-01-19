using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Accident
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True"))
            {
                sqlcon.Open();
                string query = "SELECT COUNT(*) FROM login Where USER_ID=@username AND PASSWORD=@password";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["User_name"] = TextBox1.Text.Trim();
                    Response.Redirect("userhome.aspx");

                }
                else { Label2.Visible = true; }
            }
        }
    }
}