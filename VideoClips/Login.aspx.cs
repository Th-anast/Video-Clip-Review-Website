using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideoClips
{
    public partial class Login : System.Web.UI.Page
    {
        Query q = new Query();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            q.Login(TextBox1.Text, TextBox2.Text);            
            Label1.ForeColor = Color.Red;
            if (TextBox1.Text.Equals("") || TextBox2.Text.Equals(""))
            {
                Label1.Text = "Κάποιο πεδίο είναι κενό!!!";
            }
            else
            {
                Label1.Text = "Λάθος username ή/και password!!!";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }            
        }        
    }
}