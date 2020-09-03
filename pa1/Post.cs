using System;
using System.Collections.Generic;
using System.IO;

namespace pa1
{
    public class Post : IComparable<Post>
    {
      public int Id {get; set;}
      public string postText {get; set;}

      public DateTime Date { get; set; }

      public int CompareTo(Post temp)
        {
            return this.Date.CompareTo(temp.Date);
        }

        public static int CompareDate(Post p1, Post p2)
        {
            return p1.Date.CompareTo(p2.Date);
        }

        public override string ToString()
        {
            return Id + ": " + postText + "  " + Date + " ";
        }
    }

}