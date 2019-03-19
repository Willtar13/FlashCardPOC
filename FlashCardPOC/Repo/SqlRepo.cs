using FlashCardPOC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlashCardPOC.Repo
{
    public class SqlRepo
    {

        private SqlConnection connection;
        
        public SqlRepo()
        {
            String connectionString = null;
            try
            {
                connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=FlashCardTest;Integrated Security=True";
                connection = new SqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public FlashCard GetQuestion(int? j)
        {
            int i = j.GetValueOrDefault();

            FlashCard flashCard = new FlashCard();

            connection.Open();

            string sqlCommand = "Select * FROM FlashCardTest WHERE ID = " + i;

            try
            {
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        flashCard.ID = reader.GetInt32(0);
                        flashCard.category = reader.GetString(1);
                        flashCard.style = reader.GetString(2);
                        flashCard.question = reader.GetString(3);
                        flashCard.answer = reader.GetString(4);
                        flashCard.numAttempts = reader.GetInt32(5);
                        flashCard.numRight = reader.GetInt32(6);
                        flashCard.numWrong = reader.GetInt32(7);
                        flashCard.percentageRight = reader.GetDecimal(8);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            connection.Close();

            return flashCard;

        }

        public Boolean PostCardToDB(ViewDataDictionary dict)
        {
            connection.Open();
            String insertionCommand = "INSERT INTO " + dict["category"].ToString() + " (style, question, answer, subCategory1, subCategory2, subcategory3) " +
                "Values(@style, @question, @answer, @subCategory1, @subCategory2, @subCategory3)";
            try
            {
                using (SqlCommand command = new SqlCommand(
                    insertionCommand, connection))
                {
                    command.Parameters.Add(new SqlParameter("style", dict["style"]));
                    command.Parameters.Add(new SqlParameter("question", dict["question"]));
                    command.Parameters.Add(new SqlParameter("answer", dict["answer"]));
                    command.Parameters.Add(new SqlParameter("subCategory1", dict["subCategory1"]));
                    command.Parameters.Add(new SqlParameter("subCategory2", dict["subCategory2"]));
                    command.Parameters.Add(new SqlParameter("subCategory3", dict["subCategory3"]));
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            connection.Close();

            return true;
        }

        public FlashCard LogCorrectResult(int? j)
        {
            int i = j.GetValueOrDefault();

            connection.Open();

            string sqlCommandCorrect = "UPDATE FlashCardTest SET numRight = numRight + 1 WHERE ID = " + i;
            string sqlCommandAttempts = "UPDATE FlashCardTest SET numAttempts = numAttempts +1 WHERE ID = " + i;

            try
            {
                SqlCommand command = new SqlCommand(sqlCommandCorrect, connection);
                int a = command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand(sqlCommandAttempts, connection);
                int b = command2.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

            connection.Close();

            return GetQuestion(i);
        }

        public FlashCard LogInCorrectResult(int? j)
        {
            int i = j.GetValueOrDefault();

            connection.Open();

            string sqlCommandinCorrect = "UPDATE FlashCardTest SET numWrong = numRight - 1 WHERE ID = " + i;
            string sqlCommandAttempts = "UPDATE FlashCardTest SET numAttempts = numAttempts + 1 WHERE ID = " + i;

            try
            {
                SqlCommand command = new SqlCommand(sqlCommandinCorrect, connection);
                int a = command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand(sqlCommandAttempts, connection);
                int b = command2.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

            connection.Close();

            return GetQuestion(i);
        }
    }
}