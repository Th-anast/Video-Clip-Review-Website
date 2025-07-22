using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace VideoClips
{
    public class Query
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source=" + HttpContext.Current.Server.MapPath("bin\\") + "DB_users.db;Version=3;");
        String title, username, video, description = "";
        String user_id = "(Select ID from Users where Username='" + HttpContext.Current.Request.QueryString["username"] + "')";
        String reviewUsername;

        public void Login(String username, String password)
        {
            conn.Open();
            String selectQuery = "Select * from Users where Username=@user and Password=@pass";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(3).Equals("User"))
                {
                    HttpContext.Current.Response.Redirect("~/User.aspx?username=" + reader.GetString(1));
                }
                else
                {
                    HttpContext.Current.Response.Redirect("~/Admin.aspx?username=" + reader.GetString(1));
                }
            }
            conn.Close();
        }

        public void SignUp(String username, String password)
        {
            conn.Open();
            String insertQuery = "Insert into Users(Username,Password,Category) values(@user,@pass,@categ)";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            cmd.Parameters.AddWithValue("@categ", "User");
            int count = cmd.ExecuteNonQuery();
            HttpContext.Current.Response.Redirect("~/User.aspx?username=" + username);
            conn.Close();
        }

        public void Upload(String filename,String description)
        {
            conn.Open();
            String path = "Uploads\\" + filename;
            String insertQuery = "Insert into Videos(Title,User_ID,Path,Description) values(@title," + user_id + ",@path,@descr)";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@title", filename);
            cmd.Parameters.AddWithValue("@path", path);
            cmd.Parameters.AddWithValue("@descr", description);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public String ShowAllVideos(bool guest, bool admin)
        {
            conn.Open();            
            String selectQuery = "Select ID,Path from Videos order by ID desc";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                video = "<video width='550' height='350' preload='metadata'><source src=" + reader.GetString(1) + "#t=6 type='video/mp4'></video>";
                builder.Append("<a href='Video.aspx?id="+ reader.GetInt16(0) + "&username=" + HttpContext.Current.Request.QueryString["username"] + "&guest=" + guest + "&admin=" + admin + "' style='text - decoration: none; '>" + video + "</a>&emsp;&emsp;&emsp;&emsp;");
            }
            conn.Close();
            return builder.ToString();
        }

        public String ShowMyVideos(bool guest,bool admin)
        {
            conn.Open();
            String selectQuery = "Select ID,Path from Videos where User_ID=" + user_id + " order by ID desc";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                video = "<video width='550' height='350' preload='metadata'><source src=" + reader.GetString(1) + "#t=6 type='video/mp4'></video>";
                builder.Append("<a href='Video.aspx?id=" + reader.GetInt16(0) + "&username="+ HttpContext.Current.Request.QueryString["username"] + "&guest=" + guest + "&admin=" + admin + "' style='text - decoration: none;'>" + video + "</a>&emsp;&emsp;&emsp;&emsp;");
            }
            conn.Close();
            return builder.ToString();
        }

        public (String,String) WatchVideo(String id)
        {
            conn.Open();
            String selectQuery = "Select * from Videos where ID=@id";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                title = reader.GetString(1);
                video = "<video width='1000' height='560' controls><source src=" + reader.GetString(3) + " type='video/mp4'></video>";
                description = reader.GetString(4);
            }
            selectQuery = "Select Username from Users where ID=@user_id";
            cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@user_id", reader.GetInt16(2));
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                username = "<p>Uploaded by <b>" + reader.GetString(0)+ "</b></p>";
            }
            String user_vid_descr = username + video + "<p>" + description+"</p>";
            conn.Close();
            return (title, user_vid_descr);
        }

        public void WriteReview(String comment, String video_id, String date)
        {
            conn.Open();
            String insertQuery = "Insert into Reviews(Comment,User_ID,Video_ID,Date) values(@comment,"+ user_id + ",@video_id,@date)";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@video_id", video_id);
            cmd.Parameters.AddWithValue("@date", date);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public String ShowVideoReviews(String video_id)
        {
            conn.Open();
            String selectQuery = "Select * from Reviews where Video_ID=@video_id order by ID desc";
            SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn);
            cmd.Parameters.AddWithValue("@video_id", video_id);
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                String selectUsername= "Select Username from Users where ID=@id";
                SQLiteCommand cmd1 = new SQLiteCommand(selectUsername, conn);
                cmd1.Parameters.AddWithValue("@id", reader.GetInt16(2));
                SQLiteDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    reviewUsername = reader1.GetString(0);
                }
                String review= "Written by <b>" + reviewUsername + "</b> - " + reader.GetString(4);                
                builder.Append("<p><u>" + review + "</u></p>" + reader.GetString(1)+"<hr>");
            }
            conn.Close();
            return builder.ToString();
        }

        public (String, String) ShowUsers()
        {
            var (users_count,videos_count, reviews_count) = (0,0,0);            
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand("Select * from Users where Category='User'", conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            StringBuilder builder = new StringBuilder();
            while (reader.Read())
            {
                users_count += 1;
                SQLiteCommand cmd1 = new SQLiteCommand("Select * from Videos where User_ID=@user_id", conn);
                cmd1.Parameters.AddWithValue("@user_id", reader.GetInt16(0));
                SQLiteDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    videos_count += 1;
                }
                SQLiteCommand cmd2 = new SQLiteCommand("Select * from Reviews where User_ID=@user_id", conn);
                cmd2.Parameters.AddWithValue("@user_id", reader.GetInt16(0));
                SQLiteDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    reviews_count += 1;
                }
                builder.Append(reader.GetInt16(0).ToString()).Append(", ").Append(reader.GetString(1)).Append(", ").Append(videos_count).Append(", ").Append(reviews_count).Append("<br/>");
                (videos_count,reviews_count) = (0,0);
            }
            conn.Close();
            return (users_count.ToString(), builder.ToString());
        }
    }
}