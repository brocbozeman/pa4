namespace api
{
    public class ConnectionString
    {
        public string cs { get; set; }
        public ConnectionString(){
            string server = "wb39lt71kvkgdmw0.cbetxkdyhwsb.us-east-1.rds.amazonaws.com	";
            string database = "msse087u7f6ltyp2";
            string port = "3306";
            string username = "pmmi5ub9t425fg61	";
            string password = "ccdjnq9c6jdy2isn";

            cs = $@" server = {server}; user = {username}; database = {database}; port = {port}; password = {password}; convert zero datetime=True";

        }
    }
}