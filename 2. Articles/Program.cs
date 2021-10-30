using System;

namespace _2._Articles
{
    public class Article 
    {
        private string titel_;
        private string content_;
        private string author_;
                 
        //defaut condition
        
        //Constructor with parameters
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Content
        {
            get => this.content_;
            set => this.content_ = value;
        }
        public string Title
        {
            get => this.titel_;
            set => this.titel_ = value;
        }
        public string Author
        {
            get => this.author_;
            set => this.author_ = value;
        }
        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;
        public void Rename(string title) => Title = title;
        

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
   
        

        
    class Program
    {
        static void Main(string[] args)
        {
            string[] title = Console.ReadLine().Split(", ");
            Article article = new Article(title[0], title[1], title[2]);

            int numOfCmd = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCmd; i++)
            {
                string[] tokens = Console.ReadLine().Split(": ");
                string currCmd = tokens[0];
                string argument = tokens[1];
                switch (currCmd)
                {
                    case "Edit":
                        article.Edit(argument);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(argument);
                        break;
                    case "Rename":
                        article.Rename(argument);
                        break;
                        
                }
                
            }
                Console.WriteLine(article);
        }
    }
}
