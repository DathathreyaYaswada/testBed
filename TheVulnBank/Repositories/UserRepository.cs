using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class UserRepository
    {

        private SqlConnection connection;

        public UserRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public bool UserExists(string username)
        {
            bool result = false;
            //using(this.connection) 
            {
                SqlCommand command = new SqlCommand("SELECT Id FROM Users WHERE Username='" + username + "';", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                result = reader.Read();
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public bool LoginUser(string username, string password)
        {
            bool result = false;
            //using (this.connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id FROM Users WHERE Username='" + username + "' AND Password='" + CalculateMD5Hash(password) + "';", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                result = reader.Read();
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public User GetUser(int userId)
        {
            User result = new User();
            //using (this.connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName, Username FROM Users WHERE Id='" + userId + "';", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Username = reader.GetString(3),
                    };
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public User GetUser(string username)
        {
            User result = new User();
            //using (this.connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id, FirstName, LastName, Username FROM Users WHERE Username='" + username + "';", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Username = reader.GetString(3),
                    };
                }
                reader.Close();
                this.connection.Close();
            }
            return result;
        }

        public void ChangePassword(int userId, string password)
        {
            SqlCommand command = new SqlCommand("UPDATE Users SET Password='" + CalculateMD5Hash(password) + "' WHERE Id='" + userId + "';", this.connection);
            this.connection.Open();
            command.ExecuteNonQuery();
            this.connection.Close();
        }

        // http://blogs.msdn.com/b/csharpfaq/archive/2006/10/09/how-do-i-calculate-a-md5-hash-from-a-string_3f00_.aspx
        private string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
