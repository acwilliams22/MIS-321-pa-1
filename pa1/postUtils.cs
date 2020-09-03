using System;
using System.Collections.Generic;
using System.IO;

namespace pa1
{
    class postUtils
    {  
       public static void PrintAllPosts(List<Post> posts)
       {
            posts.Sort(Post.CompareDate);
            posts.Reverse();
              foreach(Post post in posts)
            {


                Console.WriteLine(post.ToString());

            }
       }

       public static void AddPost(List<Post> posts)
       {
           Console.WriteLine("The following are your current posts");
           Console.WriteLine("");

           PrintAllPosts(posts);
           Console.WriteLine("");

            int genID = posts[0].Id + 1;

            Console.WriteLine("Enter the text for the next post");
            string userChoice1 = Console.ReadLine();

            Post newPosts = new Post(){Id = genID , postText = userChoice1 , Date =DateTime.Now };             

            posts.Add(newPosts);  
            List<Post> Post = postFile.GetPosts();

       }
       public static void DeletePost(List<Post> posts)
       {

           Console.WriteLine("The following are your current posts");
           Console.WriteLine("");

           PrintAllPosts(posts);
           Console.WriteLine("");

           Console.WriteLine("Understanding deleting...");
           Console.WriteLine("Index = <ID - 1> // ex: if ID equals 2 then index equals 1");
           Console.WriteLine("select the index to the post you would like to delete");

            int userchoice3 = int.Parse(Console.ReadLine());

            int foundIndex = posts.FindIndex(tempPost => tempPost.Id == userchoice3);
            if(foundIndex != -1)
            {
                posts.RemoveAt(foundIndex);
            }
            List<Post> Post = postFile.GetPosts();
       }

       public static void Menu()
       {
           int menuInput = 0;
            

            while(menuInput != 3)
            {
                List<Post> post = postFile.GetPosts();

                Console.WriteLine("enter 1: <-show all posts-> || enter 2: <-add a post-> || enter 3: <-delete post by ID->");
                try
                {
                menuInput = int.Parse(Console.ReadLine());
		        if(menuInput < 1 || menuInput > 3)
			    {
				throw new Exception("Not a valid menu choice");
			    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if(menuInput == 1)
                    {
                        Console.WriteLine("<-show all posts->");
				        menuInput =0;
                        
                        PrintAllPosts(post);
                    }
                    else if(menuInput == 2)
                    {
                        Console.WriteLine("<-add a post->");
				        menuInput =0;

                        AddPost(post);
                    }
                    else 
                    {
                        Console.WriteLine("<-delete post by ID->");
                        menuInput =0;
                        
                        DeletePost(post);
                    }
                
                }
            }
       }
    }

    
}