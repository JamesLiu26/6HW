using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace _6HW
{
    public partial class _6HW : System.Web.UI.Page
    {
        //Global Variable
        string sbcon = "Data Source=(localdb)\\ProjectsV13;" + "" +
                "Initial Catalog=Test;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False;" +
                "User ID=sa; Password=12345";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(sbcon);
            SqlCommand sel = new SqlCommand("SELECT * FROM Users",dbcon);
            try
            {
                dbcon.Open();
                //重新導向時，初始化資料
                lb_Data.Text = "";
                SqlDataReader reader = sel.ExecuteReader();
                //Infinite loop
                for (;reader.Read();)
                {
                    //依序印出資料列的欄位
                    for (int i=0;i<reader.FieldCount;i++)
                    {
                        lb_Data.Text += reader[i]+" ";
                    }
                    lb_Data.Text += "<br /><br />";
                }
                
                dbcon.Close();
            }catch(Exception exc)
            {
                Response.Write(exc.ToString());
            }
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            SqlConnection dbcon = new SqlConnection(sbcon);
            SqlCommand del = new SqlCommand("DELETE FROM Users WHERE Name = @Name", dbcon);
            del.Parameters.AddWithValue("@Name", tx_Name.Text);
            try
            {
                dbcon.Open();
                int delItem = del.ExecuteNonQuery();
                //刪除資料，名字可能重複，所以!=0
                if (delItem != 0)
                {
                    Response.Redirect("6HW.aspx", false);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lb_Hint.Text = "請輸入名字!!";
                }

                dbcon.Close();
            }
            catch (Exception exc)
            {
                Response.Write(exc.ToString());
            }
        }
    }
}