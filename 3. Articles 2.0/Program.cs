using System;
using System.Collections.Generic;

namespace _3._Articles_2._0
{
    class Article
    {
        private string title_;
        private string content_;
        private string author_;

        public Article(string title, string content, string author)
        {
            TitleProperty = title;
            ContentProperty = content;
            AuthorProperty = author;


        }
        public string TitleProperty
        {
            get => this.title_;
            set => this.title_ = value;



        }
        public string ContentProperty
        {
            get => this.content_;
            set => this.content_ = value;
        }

        public string AuthorProperty
        {
            get => this.author_;
            set => this.author_ = value;

        }
        public override string ToString()
        {
            return $"{TitleProperty} - {ContentProperty}: {AuthorProperty}";
        }
        class Program
        {
            static void Main(string[] args)
            {
                int numOfArticles = int.Parse(Console.ReadLine());
                List<Article> articles = new List<Article>();
                for (int i = 0; i < numOfArticles; i++)
                {
                    string[] currArticle = Console.ReadLine().Split(", ");
                    Article article = new Article(currArticle[0], currArticle[1], currArticle[2]);
                    articles.Add(article);

                }
                string criteria = Console.ReadLine();
                switch (criteria)
                {
                    case "title":
                        articles.Sort((artical1, artical2) => artical1.TitleProperty.CompareTo(artical2.TitleProperty));
                        break;
                    case "content":
                        articles.Sort((artical1, artical2) => artical1.ContentProperty.CompareTo(artical2.ContentProperty));
                        break;
                    case "author":
                        articles.Sort((artical1, artical2) => artical1.AuthorProperty.CompareTo(artical2.AuthorProperty));
                        break;
                    default:
                        break;
                }
                foreach (Article article in articles)
                {
                    Console.WriteLine(article);
                }
            }
        }
    }
}
