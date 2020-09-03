using System;
using System.IO;
using System.Collections.Generic;

namespace pa1
{
    public class postFile
    {
        //creating method that will return an array of posts
        public static List<Post> GetPosts()
        {
            List<Post> post = new List<Post>();
            StreamReader inFile = null;

            try
            {
                inFile = new StreamReader("posts.txt");
            }
            catch(FileNotFoundException e)
            {
                //Console.WriteLine("something went wrong {0}", e);    ... another way of doing it
                Console.WriteLine("Something went wrong... returning blank list" + e);
                return post;
            }
            //read in first line
            string line = inFile.ReadLine(); // priming read 
            while(line!=null)
            {
                string[] temp = line.Split('#'); // splits lines by the delimeter 
                post.Add(new Post(){Id = int.Parse(temp[0]), postText = temp[1], Date = DateTime.Parse(temp[2]) });
                line = inFile.ReadLine(); // update read
            }
            inFile.Close();

            return post;
        }
    }
    
}