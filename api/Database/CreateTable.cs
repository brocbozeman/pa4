using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class CreateTable : ICreateSongs
    {

        public void Create(){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE playlist(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, dateAdded DATETIME, isDeleted TEXT , isFavorited TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        public static void Add(Song song){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            
            string stm = @"INSERT INTO playlist(title, dateAdded, isDeleted , isFavorited) VALUES(@title, @dateAdded, @deleted, @favorited)";

            using var cmd = new MySqlCommand(stm, con);
        

            // cmd.Parameters.AddWithValue("@id", song.SongID);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@dateAdded", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@favorited", song.Favorited);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
        }

        public void Create(Song song)
        {
            throw new NotImplementedException();
        }
    }
}