using Library.WordPress.Models;
using System;

namespace CLI.WordPress //Add gitignore to our repository
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to WordPress!");
            List<Blog?> blogPosts = new List<Blog?>();
            bool cont = true;
            do
            {
                Console.WriteLine("C. Create a Blog Post");
                Console.WriteLine("R. List all Blog Posts");
                Console.WriteLine("U. Update a Blog Post");
                Console.WriteLine("D. Delete a BLog Post");
                Console.WriteLine("Q. Quit");

                var userChoice = Console.ReadLine();
                
                switch (userChoice)
                {
                    case "C":
                    case "c":
                        var blog = new Blog();
                        blog.Title = Console.ReadLine();
                        blog.Content = Console.ReadLine();
                        var maxId = -1;
                        if(blogPosts.Any())
                        {
                            maxId = blogPosts.Select(b => b?.Id ?? -1).Max();
                        }
                        else
                        {
                            maxId = 0;
                        }
                        blog.Id = ++maxId;
                        blogPosts.Add(blog);
                        break;
                    case "R":
                    case "r":
                        foreach(var b in blogPosts)
                        {
                            Console.WriteLine(b);
                        }
                        break;
                    case "U":
                    case "u":
                        {
                            blogPosts.ForEach(Console.WriteLine);
                            Console.WriteLine("Blog to Delete (Id): ");
                            //get a seletion from the user
                            var selection = Console.ReadLine();
                            //make the selection an int
                            if (int.TryParse(selection ?? "0", out int intSelection))
                            {
                                //get the blog to delete
                                var blogToUpdate = blogPosts
                                    //dont consider null blogs
                                    .Where(b => b != null)
                                    //grab the first one that mathces the blog given id
                                    .FirstOrDefault(b => (b?.Id ?? -1) == intSelection);
                                //remove it!
                                if(blogToUpdate != null)
                                {
                                    blogToUpdate.Title = Console.ReadLine();
                                    blogToUpdate.Content = Console.ReadLine();
                                }

                            }
                            break;
                        }

                    case "D":
                    case "d":
                        {
                            blogPosts.ForEach(Console.WriteLine);
                            Console.WriteLine("Blog to Delete (Id): ");
                            //get a seletion from the user
                            var selection = Console.ReadLine();
                            //make the selection an int
                            if (int.TryParse(selection ?? "0", out int intSelection))
                            {
                                //get the blog to delete
                                var blogToDelete = blogPosts
                                    //dont consider null blogs
                                    .Where(b => b != null)
                                    //grab the first one that mathces the blog given id
                                    .FirstOrDefault(b => (b?.Id ?? -1) == intSelection);
                                //remove it!
                                blogPosts.Remove(blogToDelete);
                            }
                        }
                        break;
                    case "Q":
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;

                }

            } while (cont);
        }
    }
}
