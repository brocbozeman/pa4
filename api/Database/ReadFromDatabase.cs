using System.Xml.Serialization;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using api.Interfaces;
using api.Models;

namespace api.Database
{
    public class ReadFromDatabase : IReadSongs
    {
        public List<Song> GetAll()
        {
            List<Song> mySongs = new List<Song>();
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"select * from playlist where isDeleted = 'n' order by dateAdded desc";

            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                Song temp = new Song(){SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Deleted = rdr.GetString(3), Favorited = rdr.GetString(4)};
                mySongs.Add(temp);
            }
            return mySongs;
        }

        public Song GetOne(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}