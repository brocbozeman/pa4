using MySql.Data.MySqlClient;
namespace api.Database

{
    public class FavoriteSong
    {
        public void Favorite(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            // string stm = $@"UPDATE playlist SET isFavorited = @favorited WHERE id = {id} ";

            // using var cmd = new MySqlCommand(stm, con);
            // if song.favorited = y set n and vice versa
            if(id < 0){
                id = -id;
                string stm = $@"UPDATE playlist SET isFavorited = @favorited WHERE id = {id} ";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@favorited", "n");
                cmd.ExecuteNonQuery();
            }
            else{
                string stm = $@"UPDATE playlist SET isFavorited = @favorited WHERE id = {id} ";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@favorited", "y");
                cmd.ExecuteNonQuery();
            }
            
            

            

            
        }
    }
}