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
    public partial class SignUp : System.Web.UI.Page
    {
        Query q = new Query();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!(TextBox1.Text.Equals("") || TextBox2.Text.Equals("")))
            {
                try
                {
                    q.SignUp(TextBox1.Text, TextBox2.Text);
                }
                catch (Exception)
                {
                    Label1.ForeColor = Color.Red;
                    Label1.Text = "Το Username υπάρχει ήδη από άλλον χρήστη!!!";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                }
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Κάποιο πεδίο είναι κενό!!!";
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
    }
}