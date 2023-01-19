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
    public partial class po_register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            {
                if (checkMemberExists())
                {

                    Response.Write("<script>alert('Member Already Exist with this User ID, try other ID');</script>");
                }
                else
                {
                    signUpNewMember();
                }

            }

            // user defined method
            bool checkMemberExists()
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from login2 where USER_ID='" + TextBox2.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    return false;
                }
            }
            void signUpNewMember()
            {

                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO login2(FULL_NAME,USER_ID,CONTACT_NUM,EAMIL,STATE,CITY,PINCODE,PASSWORD,CONFIRM_PASSWORD) values(@FULL_NAME,@USER_ID,@CONTACT_NUM,@EAMIL,@STATE,@CITY,@PINCODE,@PASSWORD,@CONFIRM_PASSWORD)", con);
                    cmd.Parameters.AddWithValue("@FULL_NAME", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@USER_ID", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@CONTACT_NUM", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@EAMIL", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@STATE", DropDownList1.Text.Trim());
                    cmd.Parameters.AddWithValue("@CITY", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@PINCODE", TextBox7.Text.Trim());


                    cmd.Parameters.AddWithValue("@PASSWORD", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@CONFIRM_PASSWORD", TextBox10.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }

        }
    }

}

