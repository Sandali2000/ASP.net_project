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
    public partial class police_accident : System.Web.UI.Page
    {
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

                SqlCommand cmd = new SqlCommand("INSERT INTO accident1(Image,Id,Location,Eyewittness,Reson,Accident_type,Date,user_id,Vehical_invol1,Name1,Vehical_num1,Vehical_invol2,Name2,Vehical_num2,Description) values(@Image,@Id,@Location,@Eyewittness,@Reson,@Accident_type,@Date,@user_id,@Vehical_invol1,@Name1,@Vehical_num1,@Vehical_invol2,@Name2,@Vehical_num2,@Description)", con);


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

        protected void Button3_Click(object sender, EventArgs e)
        {
            

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            getaccidentByID();
        }
        void getaccidentByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from accident1 WHERE Id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["Id"].ToString();
                    TextBox2.Text = dt.Rows[0]["Location"].ToString();
                    TextBox12.Text = dt.Rows[0]["Eyewittness"].ToString();
                    ListBox1.SelectedValue = dt.Rows[0]["Reson"].ToString();
                    DropDownList3.Text = dt.Rows[0]["Accident_type"].ToString();
                    TextBox3.Text = dt.Rows[0]["Date"].ToString();
                    TextBox8.Text = dt.Rows[0]["user_id"].ToString();
                    TextBox9.Text = dt.Rows[0]["Vehical_invol1"].ToString();
                    TextBox4.Text = dt.Rows[0]["Vehical_invol2"].ToString();
                    TextBox10.Text = dt.Rows[0]["Name1"].ToString();
                    TextBox5.Text = dt.Rows[0]["Name2"].ToString();
                    TextBox11.Text = dt.Rows[0]["Vehical_num1"].ToString();
                    TextBox7.Text = dt.Rows[0]["Vehical_num2"].ToString();
                    TextBox6.Text = dt.Rows[0]["Description"].ToString();
                    TextBox13.Text = dt.Rows[0]["acc_statuse"].ToString();
                    
                   


                   global_filepath = dt.Rows[0]["Image"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Accident ID');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        
        void updateaccidentByID()
        {

            if (checkIfBookExists())
            {
                try
                {
                    string filepath = "~/accident_pic/istockphoto-451333971-612x612.jpg";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("accident_pic/" + filename));
                        filepath = "~/accident_pic/" + filename;
                    }


                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update accident1 set Id=@Id, Location=@Location, Eyewittness=@Eyewittness, Accident_type=@Accident_type, Date=@Date, user_id=@user_id, Vehical_invol1=@Vehical_invol1, Vehical_invol2=@Vehical_invol2, Vehical_num2=@Vehical_num2, Vehical_num1=@Vehical_num1, Name2=@Name2, Name1=@Name1, Description=@Description, Image=@Image, Reson=@Reson  where Id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@Id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Eyewittness", TextBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@Reson", ListBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Accident_type", DropDownList3.Text.Trim());
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


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Accident Updated Successfully');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid ID');</script>");
            }
        }
       
        protected void Button2_Click(object sender, EventArgs e)
        {

            
            
                if (checkIfBookExists())
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand cmd = new SqlCommand("DELETE from accident1 WHERE Id='" + TextBox1.Text.Trim() + "'", con);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Accident Deleted Successfully');</script>");

                        GridView1.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid Accident ID');</script>");
                }
            }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("active");
        }


        void updateMemberStatusByID(string status)
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    SqlCommand cmd = new SqlCommand("UPDATE accident1 SET acc_statuse='" + status + "' WHERE Id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Accident Status Updated');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Accident ID');</script>");
            }

        }
        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from accident1 where Id='" + TextBox1.Text.Trim() + "';", con);
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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("pending");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("deactive");
        }
    }
    }