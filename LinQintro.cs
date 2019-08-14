using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var mount = from artist in Artists 
            where artist.Hometown == "Mount Vernon"
            select artist;
            Console.WriteLine(mount);
            foreach(var i in mount){
                Console.WriteLine(i.ArtistName + " is " + i.Age);
            }
            Artists.Where(h => h.Hometown == "Mount Vernon");

            //Who is the youngest artist in our collection of artists?
            var youngest = Artists.Min( x => x.Age);
            var youngest1 = from artist in Artists  

            where artist.Age == Artists.Min(x => x.Age) 
            select new { artist.ArtistName, artist.Age };
            Console.WriteLine(youngest1);
            foreach(var i in youngest1)
            {
                Console.WriteLine(i.ArtistName + " is " + i.Age);
            }
            Artists.Where(a => a.Age == Artists.Min(x => x.Age));

            //Display all artists with 'William' somewhere in their real name

            var name = from artist in Artists 
            where artist.RealName.Contains("William") 
            select new {artist.ArtistName, artist.RealName};
            foreach(var c in name)
            {
                Console.WriteLine(c.ArtistName + "--" + c.RealName);
            }

            Artists.Where(a => a.RealName.Contains("William"));


            //Display the 3 oldest artist from Atlanta

            var oldest = (from artist in Artists orderby artist.Age descending 
            select new { artist.ArtistName, artist.Age }).Take(3);
            foreach(var c in oldest)
            {
                Console.WriteLine(c.ArtistName + " is " + c.Age);
            }
            Artists.OrderByDescending(a => a.Age).Take(3);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	        Console.WriteLine(Groups.Count);
        }
    }
}
