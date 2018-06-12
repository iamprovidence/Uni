using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    /*
         * класс Стаття: назва, зміст, персона автор
         * персонa: імя, фаміліяю, чи ревювер поле
         * режим ревювера для деяких
         * можна переглядати і давати коментарі
         * 3 ревювера(поганий з ворогами якщо автор ворог то пише погане, звичайний норм коменти, гарний, всім гарне)
         * 
         * є масив статей і масив персонів, деякі ревювери деякі ні і кожну статю вивести в форматі автор назва коментарі
         */

    interface IReviewer:ICloneable
    {
        Comment Review(Article article, Person commentator);
    }
    class BadReviewer : IReviewer
    {
        private List<Person> enemies = new List<Person>();
        public Comment Review(Article article, Person commentator)
        {
            if (enemies.Contains(article.Author))
            {
                return new Comment("Bad Bad Bad Bad Bad", commentator);
            }
            return new Comment("Bad", commentator);
        }
        public void NewEnemy(Person enemy)
        {
            enemies.Add(enemy);
        }
        public override string ToString()
        {
            StringBuilder bad = new StringBuilder("Bad Reviewer\n");
            bad.AppendLine("Enemy list:");
            for(int i = 0; i < enemies.Count; ++i)
            {
                bad.AppendFormat("{0}. {1}\n", i + 1, enemies[i].Name());
            }
            return bad.ToString();
        }

        public object Clone()
        {
            BadReviewer br = (BadReviewer)this.MemberwiseClone();
            br.enemies = new List<Person>();
            return br;
        }
    }
    class NormalReviewer : IReviewer
    {
        public Comment Review(Article article, Person commentator)
        {
            string[] text = article.Content.Split();
            StringBuilder replay = new StringBuilder("Not bad, just ok\t");
            replay.AppendFormat("First world is {0}\t", text[0]);
            replay.AppendFormat("Last world is {0}\t", text[text.Length - 2]);

            return new Comment(replay.ToString(), commentator);
        }
        public override string ToString()
        {
            return "Normal Reviewer";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    class GoodReviewer : IReviewer
    {
        public Comment Review(Article article, Person commentator)
        {
            if (article.Content.Split().Length > 25)
            {
                return new Comment("Good, very good", commentator);
            }
            else return new Comment("OK", commentator);
        }
        public override string ToString()
        {
            return "Good Reviewer";
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    struct Comment
    {
        string text;
        Person author;

        public Comment(string text, Person a)
        {
            this.text = text;
            this.author = a;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Text: \n");
            builder.AppendLine(text);
            builder.AppendFormat("AUTHOR: {0}\n", author.Name());
            return builder.ToString();
        }
    }
    class Article
    {
        string title;
        string content;
        List<Comment> comments = new List<Comment>();
        Person author;

        public Person Author { get { return author; } }
        public string Content { get { return content; } }
        public Comment Comments { set { comments.Add(value); } }

        public Article(string t, string c, Person a)
        {
            title = t;
            content = c;
            author = a;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Title: ");
            builder.AppendLine(title);
            builder.AppendLine(author.Name());
            if(comments.Count > 0)
            {
                builder.AppendLine(comments.Count.ToString() + " comments");
                foreach (Comment c in comments)
                {
                    builder.AppendLine(c.ToString());
                }
            }
            else
            {
                builder.AppendLine("No Comments");
            }
            
            return builder.ToString();
        }
    }
    class Person
    {
        string name;
        string surname;
        IReviewer ReviewMode;

        public IReviewer ReviewMODE
        {
            get
            {
                return ReviewMode;
            }
        }

        public Person(string n, string s, IReviewer rm = null)
        {
            name = n;
            surname = s;
            ReviewMode = rm;
        }
        public void ReadArticle(Article article)
        {
            if(ReviewMode != null)
            {
                article.Comments = ReviewMode.Review(article, this);
            }
        }
        public string Name()
        {
            return string.Format("Name: {0}, Surname: {1}", name, surname);
        }
        public override string ToString()
        {
            StringBuilder person_info = new StringBuilder();
            person_info.AppendFormat("Name: {0}, Surname: {1}",name, surname);
            if(ReviewMODE != null)
            {
                person_info.Append("\nReviewer:\t");
                person_info.Append(ReviewMODE.ToString());
            }
            return person_info.ToString();
        }
    }

    
    class MainEntryPoint
    {
        static void Main()
        {
            string[] words = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In condimentum luctus diam, vitae laoreet justo. Donec et dapibus elit, a fermentum mauris. Nullam condimentum nulla est. Mauris lorem arcu, tempor eu risus eget, blandit maximus risus. Phasellus at malesuada eros. Quisque commodo luctus nisl nec lobortis. Curabitur semper enim at metus sollicitudin vestibulum. Integer nulla ligula, varius sit amet faucibus non, scelerisque a erat. Aenean eget ante faucibus, dictum turpis vitae, ultricies risus. Pellentesque odio sem, facilisis vitae interdum ut, pharetra non nisl. Sed volutpat tellus est, a euismod erat luctus id.".ToLower().Replace(",","").Replace(".","").Split();
            string[] name = { "Aaron", "Abner", "Addison", "Amery", "Brian", "Broderick", "Casper", "Cyril" };
            string[] surname = { "Enlightened", "Father", "Breath", "Eagle", "Bearded", "Industrious" };
            IReviewer[] reviewer = { new BadReviewer(), new NormalReviewer(), new GoodReviewer() };
            Random random = new Random();
            
            //створений масив авторів
            int PERSON_ARR_SIZE = random.Next(5, 25);
            Person[] PersonArr = new Person[PERSON_ARR_SIZE];
            for(int i = 0; i < PERSON_ARR_SIZE; ++i)
            {
                int IS_REVIEWER = random.Next(0, 4);
                PersonArr[i] = new Person(
                    name[random.Next(0, name.Length)],
                    surname[random.Next(0, surname.Length)],
                    IS_REVIEWER == 3 ? null : (IReviewer)reviewer[IS_REVIEWER].Clone()
                    );
            }
            
            //створений масив статей
            int ARTICLE_ARR_SIZE = random.Next(5, 50);
            Article[] ArticleArr = new Article[ARTICLE_ARR_SIZE];
            for(int i =0; i < ARTICLE_ARR_SIZE; ++i)
            {
                int ARTICLE_AMOUNT_OF_WORDS = random.Next(2, words.Length);
                StringBuilder content = new StringBuilder();
                for(int j = 0; j < ARTICLE_AMOUNT_OF_WORDS; ++j)
                {
                    content.AppendFormat("{0} ", words[j]);
                }

                ArticleArr[i] = new Article($"Article N{i + 1}",content.ToString(), PersonArr[random.Next(0, PERSON_ARR_SIZE)]);
            }
            
            //додати декому ворогів
            for(int i = 0; i < PERSON_ARR_SIZE; ++i)
            {
                if(PersonArr[i].ReviewMODE is BadReviewer)
                {
                    for(int j = 0; j < random.Next(1,5);++j)
                    {
                        int ENEMY_ID = random.Next(0, PERSON_ARR_SIZE);
                        if(i != ENEMY_ID)
                        {
                            ((BadReviewer)PersonArr[i].ReviewMODE).NewEnemy(PersonArr[ENEMY_ID]);
                        }
                    }
                }
            }
            
            //усі люди читають випадкову кількість статей[1-5), деякі статті можеть бути непрочитані
            for(int i = 0; i < PERSON_ARR_SIZE; ++i)
            {
                for(int j = 0; j< random.Next(1,5); ++j)
                {
                    PersonArr[i].ReadArticle(ArticleArr[random.Next(0, ARTICLE_ARR_SIZE)]);
                }
            }
            //вивід
            Console.WriteLine("***\tPERSON\t***");
            for(int i = 0; i < PERSON_ARR_SIZE; ++i)
            {
                Console.WriteLine(PersonArr[i]);
            }

            Console.WriteLine();
            Console.WriteLine("***\tARTICLE\t***");
            //виводимо всі статті
            for(int i = 0; i < ARTICLE_ARR_SIZE; ++i)
            {
                Console.WriteLine(ArticleArr[i].ToString());
            }
            
            Console.ReadLine();
        }
    }

}