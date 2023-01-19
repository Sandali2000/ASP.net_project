﻿using System;
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
    public partial class viweusers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["user_name"].ToString() == "" || Session["user_name"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("login.aspx");
            }
            else
            {
                updateUserPersonalDetails();

            }
        }
        void updateUserPersonalDetails()
        {
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rode_Cover;Integrated Security=True");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update login set FULL_NAME=@FULL_NAME, USER_ID=@USER_ID, CONTACT_NUM=@CONTACT_NUM, EAMIL=@EAMIL, STATE=@STATE, CITY=@CITY, PINCODE=@PINCODE, PASSWORD=PASSWORD, CONFIRM_PASSWORD=@CONFIRM_PASSWORD  WHERE USER_ID='" + Session["user_name"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@FULL_NAME", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@USER_ID", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@CONTACT_NUM", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@EAMIL", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@STATE", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@CITY", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@PINCODE", TextBox7.Text.Trim());


                cmd.Parameters.AddWithValue("@PASSWORD", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@CONFIRM_PASSWORD", TextBox10.Text.Trim());


                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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

                TextBox1.Text = dt.Rows[0]["FULL_NAME"].ToString();
                TextBox2.Text = dt.Rows[0]["USER_ID"].ToString();
                TextBox3.Text = dt.Rows[0]["CONTACT_NUM"].ToString();
                TextBox4.Text = dt.Rows[0]["EAMIL"].ToString();
               DropDownList1.Text = dt.Rows[0]["STATE"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["CITY"].ToString();
                TextBox7.Text = dt.Rows[0]["PINCODE"].ToString();
                
               TextBox10.Text = dt.Rows[0]["PASSWORD"].ToString();
                TextBox9.Text = dt.Rows[0]["CONFIRM_PASSWORD"].ToString();
                Label1.Text = dt.Rows[0]["ACC_STATUS"].ToString().Trim();

                if (dt.Rows[0]["ACC_STATUS"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("cssclass", " bg-success");
                }
                else if (dt.Rows[0]["ACC_STATUS"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("cssclass", " bg-warning");
                }
                else if (dt.Rows[0]["ACC_STATUS"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("cssclass", " bg-danger");
                }
                else
                {
                    Label1.Attributes.Add("cssclass", " badge-info");
                }








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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}