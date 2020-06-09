using System;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new BloggingContext())
            {   
                // Create
                System.Console.WriteLine("Inserting a new Blog");
                db.Add(new Blog{ Url = "http://blogs.thedineshbabu.com/data"});
                db.SaveChanges();

                //Read
                System.Console.WriteLine("Querying for a blog");
                var blog = db.Blogs.OrderBy(s=>s.BlogId).First();

                //Update
                System.Console.WriteLine("Updating a Blog and adding a post");
                blog.Url = "";
                blog.Posts.Add(new Post()
                {
                    Title = "Post Updated",
                    Content = "Sample Content EF"
                });
                db.SaveChanges();

                //Delete
                System.Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();

            }
        }
    }
}
