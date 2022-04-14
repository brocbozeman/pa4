using api.Interfaces;
using MySql.Data.MySqlClient;
namespace api.Database
{
    public class DeleteSong : IDeleteSongs
    {
        public void DropPlaylistTable(){
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DROP TABLE IF EXISTS playlist";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();
            System.Console.WriteLine(id);

            string stm = $@"UPDATE playlist SET isDeleted = @deleted WHERE id = {id} ";

            using var cmd = new MySqlCommand(stm, con);
            string y = "y";

            cmd.Parameters.AddWithValue("@deleted", y);

            cmd.ExecuteNonQuery();
        }

    }
}