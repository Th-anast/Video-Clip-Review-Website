using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideoClips
{
    public partial class Video : System.Web.UI.Page
    {
        Query q = new Query();
        DateTime date = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["guest"].Equals("True"))
            {
                TextBox1.Visible = false;
                Button1.Visible = false;
                Literal2.Text = "<a href = 'Home.aspx'><b>Κεντρική</b></a><span style='padding-left:85%'><a href = 'Login.aspx'>Log In</a>&emsp;&emsp;<a href = 'SignUp.aspx'>Sign Up</a></span>";
            }
            else
            {
                TextBox1.Visible = true;
                Button1.Visible= true;
                if (Request.QueryString["admin"].Equals("True"))
                {
                    Literal2.Text = "<a href = 'Admin.aspx?username=" + Request.QueryString["username"] + "'><b>Κεντρική</b></a><span style='padding-left:90%'><a href = 'Home.aspx'>Log Out</a></span>";
                }
                else
                {
                    Literal2.Text = "<a href = 'User.aspx?username=" + Request.QueryString["username"] + "'><b>Κεντρική</b></a><span style='padding-left:90%'><a href = 'Home.aspx'>Log Out</a></span>";
                }                
            }
            (Title.Text, Literal1.Text) = q.WatchVideo(Request.QueryString["id"]);
            Literal3.Text = q.ShowVideoReviews(Request.QueryString["id"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!TextBox1.Text.Equals(""))
            {
                q.WriteReview(TextBox1.Text, Request.QueryString["id"], date.ToString("dd/MM/yyyy"));
                Literal3.Text = q.ShowVideoReviews(Request.QueryString["id"]);
                TextBox1.Text = "";
            }
        }
    }
}