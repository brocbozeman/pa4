using api.Interfaces;
using MySql.Data.MySqlClient;
using api.Models;
using System;

namespace api.Database
{
    public class UpdateSong : IUpdateSongs
    {
        public void Update(Song song)
        {
            int id = song.SongID;
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE playlist SET title = @title WHERE id = {id} ";

            using var cmd = new MySqlCommand(stm, con);
            System.Console.WriteLine("What would you like to change the title to?");
            string y = Console.ReadLine();

            cmd.Parameters.AddWithValue("@title", y);

            cmd.ExecuteNonQuery();
        }
    }
}