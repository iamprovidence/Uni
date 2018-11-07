using System;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using FillingInYourDataBase.Entities;

namespace FillingInYourDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            // INITIALIZE DATA
            EntitiesGenerator generator = new EntitiesGenerator();
            Random random = new Random();
            List<string> readersCode = new List<string>(10000);

            // PostgeSQL-style connection string
            string connectionString = String.Format("Server={0};Port={1};" +
                "User Id={2};Password={3};Database={4};",
                "127.0.0.1", 5432, "postgres",
                1111, "Librarie");

            // Making connection with Npgsql provider
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            string sql;
            conn.Open();
            IDbCommand command = conn.CreateCommand();

            // READERS
            for (int j = 0; j < 10000; ++j)
            {
                Reader reader = generator.GetReader();
                sql = string.Concat(
                        "INSERT INTO \"Readers\"",
                        "(\"name\", \"surname\", \"age\", \"city name\", \"phone number\", \"code\")",
                        $"VALUES('{reader.Name}', '{reader.Surname}', {reader.Age}, '{reader.CityName}', '{reader.PhoneNumber}', '{reader.Code}');");

                command.CommandText = sql;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("READER  - " + ex.Message);
                    continue;
                }
                readersCode.Add(reader.Code);
            }

            try
            {
                int authorId = 5;// 5 cuz DB already has some data
                int readerCodeIndex = 0;
                
                for (int i = 0; i < 100; ++i)
                {

                    PublishingHouse publishHouse = generator.GetPublishingHouse();
                    // PUBLISH HOUSE
                    sql = string.Concat("INSERT INTO \"Publishing house\"",
                                        "(\"name\", \"country\")",
                                        $"VALUES('{publishHouse.Name}', '{publishHouse.Country}');");
                    try
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("PUBLISH HOUSE - " + ex.Message);
                        continue;
                    }
                }
                for (int i = 0; i < 100000; ++i)
                {
                    GC.Collect();
                    List<Book> books = generator.GetBooks();
                    Author author = generator.GetAuthor(books);

                    // AUTHOR
                    sql = string.Concat(
                        "INSERT INTO \"Authors\"",
                        "(\"name\", \"surname\")",
                        $"VALUES('{author.Name}', '{author.Surname}');");
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    

                    foreach (Book book in books)
                    {
                        // BOOK
                        sql = string.Concat("INSERT INTO \"Books\"",
                            "(\"isbn\", \"name\", \"year\", \"total amount\", \"amount to read home\", \"amount to repair\")",
                            $"VALUES('{book.ISBN}', '{book.Name}', {book.Year}, {book.TotalAmount}, {book.AmountToReadHome}, {book.AmountToRepair});");

                        try
                        {
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine("BOOK - " + ex.Message);
                            continue;
                        }

                        // BOOK - AUTHOR
                        sql = string.Concat(
                            "INSERT INTO \"BookAuthor\"",
                            "(\"isbn\", \"author id\")",
                            $"VALUES('{book.ISBN}', '{authorId}'); ");


                        command.CommandText = sql;
                        command.ExecuteNonQuery();

                        // BOOK - PUBLISH HOUSE
                        sql = string.Concat(
                            "INSERT INTO \"BookPublishingHouse\"",
                            "(\"isbn\", \"publishing house id\")",
                            $"VALUES('{book.ISBN}', '{random.Next(1, 100)}'); ");
                        
                        command.CommandText = sql;
                        command.ExecuteNonQuery();

                        // ABONNEMENT
                        int abonnementAmount = random.Next(1, 5);
                        for (int j = 0; j < abonnementAmount; ++j)
                        {
                            Abonnement abonnemet = generator.GetAbonnement();

                            if (abonnemet.ReturnBookDate != null)
                            {
                                sql = string.Concat(
                                    "INSERT INTO \"Abonnement\"",
                                    "(\"reader code\", \"isbn\", \"book amount\", \"take book date\", \"return book date\")",
                                    $"VALUES('{readersCode[readerCodeIndex++]}', '{book.ISBN}', {abonnemet.BookAmount}, '{abonnemet.TakeBookDate}', '{abonnemet.ReturnBookDate}');");

                            }
                            else
                            {
                                sql = string.Concat(
                                "INSERT INTO \"Abonnement\"",
                                "(\"reader code\", \"isbn\", \"book amount\", \"take book date\")",
                                $"VALUES('{readersCode[readerCodeIndex++]}', '{book.ISBN}', {abonnemet.BookAmount}, '{abonnemet.TakeBookDate}');");
                            }

                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                            readerCodeIndex %= readersCode.Count;
                        }
                    }
                    ++authorId;                   
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Console.ReadLine();
        }
    }
}
