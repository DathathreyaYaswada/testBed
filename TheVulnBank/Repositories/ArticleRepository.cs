using System.Collections.Generic;
using System.Data.SqlClient;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class ArticleRepository
    {
        private SqlConnection connection;

        public ArticleRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public Article GetArticle(int articleId)
        {
            Article result = new Article();

            //using (this.connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Articles WHERE Id='" + articleId + "';", this.connection);
                this.connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    result = new Article
                    {
                        Id = reader.SafeGetInt32("Id", -1),
                        Title = reader.SafeGetString("Title", null),
                        Text = reader.SafeGetString("Text", null),
                        Internal = reader.SafeGetBoolean("Internal", false),
                    };
                }

                reader.Close();
                this.connection.Close();
            }

            return result;
        }

        public List<Article> SearchArticles(string query, string noOfItems)
        {
            List<Article> result = new List<Article>();
            SqlCommand command = new SqlCommand("SELECT TOP " + noOfItems + " * FROM Articles WHERE Text LIKE @query OR Title LIKE @query;", this.connection);
            command.Parameters.AddWithValue("@query", "%" + query + "%");
            this.connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Article
                {
                    Id = reader.SafeGetInt32("Id", -1),
                    Title = reader.SafeGetString("Title", null),
                    Text = reader.SafeGetString("Text", null),
                    Internal = reader.SafeGetBoolean("Internal", false),
                });
            }

            reader.Close();
            this.connection.Close();
            return result;
        }
    }
}