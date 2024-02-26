using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crudnew
{
    public partial class crud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4GKIR43;Initial Catalog=eLibraryDB;Integrated Security=True");
        protected void Button1_Click(object sender, EventArgs e)
        {
            int productid = int.Parse(TextBox1.Text);
            string iname = TextBox2.Text, specification = TextBox3.Text, unit = DropDownList1.SelectedValue, status = RadioButtonList1.SelectedValue;
          //  DateTime cdate = DateTime.Parse(TextBox4.Text);
            con.Open();
            SqlCommand co = new SqlCommand("exec ProductSetup_SP '" + productid + "','" + iname + "','" + specification + "','" + unit + "','" + status + "', ", con);
            co.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted.');", true);
            GetProductList();
        }

        void GetProductList()
        {
            SqlCommand co = new SqlCommand("exec ProductList_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(co);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
       
    }
}