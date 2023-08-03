using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TheVulnBank.Models.Data;

namespace TheVulnBank.Repositories
{
    public class QuestionsRepository
    {
        private SqlConnection connection;

        public QuestionsRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public void AddQuestion(int userId, string question)
        {
            List<Question> result = new List<Question>();
            SqlCommand command = new SqlCommand("INSERT INTO Questions (UserId, Question) VALUES (@userId, @question);", this.connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@question", question);
            this.connection.Open();
            command.ExecuteNonQuery();
            this.connection.Close();
        }

        public List<Question> GetQuestions(int userId)
        {
            List<Question> result = new List<Question>();
            SqlCommand command = new SqlCommand("SELECT * FROM Questions WHERE UserId = @userId", this.connection);
            command.Parameters.AddWithValue("@userId", userId);
            this.connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Question
                {
                    Id = reader.SafeGetInt32("Id", -1),
                    UserId = reader.SafeGetInt32("UserId", -1),
                    AgentId = reader.SafeGetInt32("AgentId", -1),
                    Text = reader.SafeGetString("Question", null),
                    Answer = reader.SafeGetString("Answer", null),
                });
            }

            reader.Close();
            this.connection.Close();
            return result;
        }

        public void RemoveQuestions(int userId) {
            SqlCommand command = new SqlCommand("DELETE FROM Questions WHERE UserId = @userId", this.connection);
            command.Parameters.AddWithValue("@userId", userId);
            this.connection.Open();
            command.ExecuteNonQuery();
            this.connection.Close();
        }

        public void RemoveAllQuestions()
        {
            SqlCommand command = new SqlCommand("DELETE FROM Questions WHERE Id IS NOT NULL", this.connection);
            this.connection.Open();
            command.ExecuteNonQuery();
            this.connection.Close();
        }
    }
}