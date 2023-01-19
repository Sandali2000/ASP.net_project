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
    public partial class addmin_viweaccident : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string global_filepath;
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

    }
}