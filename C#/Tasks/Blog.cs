using System;
using System.Text;
using System.Collections.Generic;
/*
 * Article(title, content), Blog(list<Article>,title, addArticle, event ), Reader(name, email, List<Blog>, )
 * є бллоги в яких публікуються статі
 * є читаті які читають вікно
 * кожного разу коли додається стаття в блог, то на пошту читатча, який підписаний на блог приходить сповіщення
 */
namespace ConsoleApplication
{
    class Article
    {
        private string title;
        private string content;

        public string Title { get { return title; } }

        public Article(string t, string c)
        {
            title = t;
            content = c;
        }

        public override string ToString()
        {
            return new StringBuilder("Title: ").AppendLine(title).ToString();
        }
    }
    class EventMessage : EventArgs
    {
        private Article a;
        public EventMessage(Article a)
        {
            this.a = a;
        }
        public string message()
        {
            return new StringBuilder("New Article: ").Append(a.Title).ToString();
        }
    }
    class Blog
    {
        private List<Article> ArticleList = new List<Article>();

        public event EventHandler<EventMessage> subscribe;
        public void addArticle(Article A)
        {
            ArticleList.Add(A);
            subscribe?.Invoke(this, new EventMessage(A));
        }
    }

    class Reader
    {
        private string name = $"Name {id++}";
        private List<string> message = new List<string>();

        static int id = 0;
        public List<string> Message { get { return message; } }
        public void follow(object o, EventMessage e)
        {
            message.Add(String.Concat( name , " Get Message ", e.message()));
        }
        public void Messages()
        {
            foreach (string s in Message)
            {
                Console.WriteLine(s);
            }
        }
    }
    class MainEntryPoint
    {
        static void Main()
        {
            Reader r1 = new Reader(), r2 = new Reader();
            Blog blog = new Blog();

            blog.subscribe += r1.follow;
            blog.subscribe += r2.follow;
            blog.addArticle(new Article("About nature", "Nature is good"));
            blog.subscribe -= r2.follow;
            blog.addArticle(new Article("About car", "Car is very good"));


            r1.Messages();
            r2.Messages();

            Console.ReadKey();
        }
    }
}