using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using UserInfo.Entity;

namespace UserInfo.Model
{
    class DataAccess
    {
        public DataAccess()
        {
            CreateDataBase();
        }

        string db = string.Empty;
        SqliteConnection conn = null;
        private void CreateDataBase() 
        {
            string DataBaseName = "UserData.db3";
            string document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            db = Path.Combine(document,DataBaseName);
            bool flag = File.Exists(db);
            if (!flag)
            {
                SqliteConnection.CreateFile(db);
            }
            CreateTable();
        }

        private void CreateTable()
        {
            conn = new SqliteConnection("Data Source="+db);
            var sql = "create table if not exists user(id int primary key,name varchar(50),pwd varchar(200))";
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
                conn.Open();
                //conn.SetPassword("test");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool InsertData(User u)
        {
            bool flag = false;
            using (SqliteCommand cmd = new SqliteCommand(conn))
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into user(name,pwd)values('"+u.Name+"','"+u.Pwd+"')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return flag;
        }


        public DataTable QueryData()
        {
            DataTable dt = null;
            using (SqliteCommand cmd = new SqliteCommand(conn))
            {
                conn.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select name,pwd from user order by id limit 0,1";
                dt = new DataTable();
                SqliteDataAdapter sda = new SqliteDataAdapter(cmd);
                sda.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }
}
