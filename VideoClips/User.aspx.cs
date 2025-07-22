using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VideoClips
{
    public partial class User : System.Web.UI.Page
    {
        Query q = new Query();
        public static bool flag = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Welcome, " + Request.QueryString["username"];
            if (flag)
            {
                Literal1.Text = q.ShowAllVideos(false, false);
                Button2.Text = "Show only my videos";
            }
            else
            {
                Literal1.Text = q.ShowMyVideos(false, false);
                Button2.Text = "Show all videos";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.ForeColor = Color.Red;            
            if (FileUpload1.HasFile && !TextBox1.Text.Equals(""))
            {
                if (Path.GetExtension(FileUpload1.FileName) == ".mp4")
                {
                    q.Upload(Path.GetFileName(FileUpload1.FileName), TextBox1.Text);
                    Label2.ForeColor = Color.Green;
                    Label2.Text = "Video Uploaded!!!";
                    if (!flag)
                    {
                        Literal1.Text = q.ShowMyVideos(false, false);
                    }
                    else
                    {
                        Literal1.Text = q.ShowAllVideos(false, false);
                    }
                }
                else
                {
                    Label2.Text = "Only .mp4 type of video";
                }
            }
            else
            {
                if (TextBox1.Text.Equals(""))
                {
                    Label2.Text = "You must write a description for the video";
                }
                else
                {
                    Label2.Text = "Can't upload video";
                }
            }
            TextBox1.Text = "";
            Label2.Visible = true;
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                Literal1.Text = q.ShowMyVideos(false, false);
                Button2.Text = "Show all videos";
                flag = false;
            }
            else
            {
                Literal1.Text = q.ShowAllVideos(false, false);                
                Button2.Text = "Show only my videos";
                flag = true;
            }
            Label2.Visible = false;
        }
    }
}