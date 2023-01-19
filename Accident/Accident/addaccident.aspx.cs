using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Accident
{
    public partial class addaccident : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                GridView1.DataBind();
                {

                    try
                    {
                        if (Session["user_name"].ToString() == "" || Session["user_name"] == null)
                        {
                            Response.Write("<script>alert('Session Expired Login Again');</script>");
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            getUserBookData();


                            if (!Page.IsPostBack)
                            {
                                getUserPersonalDetails();

                            }

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("<script>alert('Session Expired Login Again');</script>");
                        Response.Redirect("login.aspx");
                    }

                }
            }

        }
        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from login where USER_ID='" + Session["user_name"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                TextBox12.Text = dt.Rows[0]["FULL_NAME"].ToString();

                TextBox8.Text = dt.Rows[0]["USER_ID"].ToString();
                





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from accident1 where Id='" + TextBox1.Text.Trim() + "' ;", con);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else

            {
                if ("Id" == null)
                {
                    Response.Write("<script>alert('Ente Accident ID');</script>");
                }
                    addNewAccident();
            }
        }
        void addNewAccident()
        {
            try
            {

                string filepath = "~/accident_pic/istockphoto-451333971-612x612.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("accident_pic/" + filename));
                filepath = "~/accident_pic/" + filename;


                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO accident1(Image,Id,Location,Eyewittness,Reson,Accident_type,Date,user_id,Vehical_invol1,Name1,Vehical_num1,Vehical_invol2,Name2,Vehical_num2,Description,acc_statuse) values(@Image,@Id,@Location,@Eyewittness,@Reson,@Accident_type,@Date,@user_id,@Vehical_invol1,@Name1,@Vehical_num1,@Vehical_invol2,@Name2,@Vehical_num2,@Description,@acc_statuse)", con);


                cmd.Parameters.AddWithValue("@Id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Location", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Eyewittness", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@Reson", ListBox1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Accident_type", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@user_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@Vehical_invol1", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Name1", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@Vehical_num1", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@Vehical_invol2", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Name2", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Vehical_num2", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Image", filepath);
                cmd.Parameters.AddWithValue("@acc_statuse", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
              
                Response.Write("<script>alert('Accident added successfully.');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from accident1 where user_id ='" + Session["user_name"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
       
       
    }
    
}