namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var allUsers = ReadUsers("users.json");
            var allPosts = ReadPosts("posts.json");

            // 1 - find all users having email ending with ".net".
            /*   var users1 = from u in allUsers
                   where u.Email.EndsWith(".net")
                   select u;

               var users2 = allUsers.Where(x => x.Email.EndsWith(".net"));

               var emails = allUsers.Select(x => x.Email).ToList();

               // 2 - find all posts for users having email ending with ".net".

               IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                          where user.Email.EndsWith(".net")
                                                          select user.Id;

               IEnumerable<Post> posts = from post in allPosts
                                         where usersIdsWithDotNetMails.Contains(post.UserId)
                                         select post;

               foreach (var post in posts)
               {
                   Console.WriteLine(post.Id + " " + "user: " + post.UserId);
               }
               */




            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 3 - print number of posts for each user.
            /*

               var numberId = allPosts.Select(s => s.Id);
              foreach (var elem in numberId)
              {
                  Console.WriteLine(elem);
              }
              Console.ReadLine(); 

            */
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 4 numberId lat and long negative.(CORECT)
            
            var number = allUsers.Where(x => x.Address.Geo.Lat<0 && x.Address.Geo.Lng<0).ToList();

            foreach (var elem in number)
            {
                Console.WriteLine($"The ID   {elem.Id} is with  lat {elem.Address.Geo.Lat} and long {elem.Address.Geo.Lng}");
            }

            Console.ReadLine();
            
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // 5 - find the post with longest body.  
            /*

             var longest = allPosts.OrderByDescending(x => x.Body.Length).First();
              Console.WriteLine(longest.Id);
            */

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 6 - print the name of the employee that have post with longest body.
            /*
          var nume = allUsers.Where(x => x.Name.Equals(longest)).ToList();
            Console.WriteLine(nume);
            Console.ReadLine();

            */
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 7 - select all addresses in a new List<Address>. print the list. NU CRED CA E CORECT   ??????????????????
            /*
           List<Address> newAdress = new List<Address>();
             var adress = (from s in newAdress select new { s.Street, s.Suite, s.City, s.Zipcode, s.Geo }).ToList();
             foreach (var item in adress)
             {
                 Console.WriteLine(item.Suite, item.Suite, item.City, item.Zipcode, item.Geo);
             }
             Console.ReadLine();
             */
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 8 - print the user with min lat nu stiu cum sa fac print-ul
            /*
             var minLatitude = allUsers.Min(x => x.Address.Geo.Lat);
             Console.WriteLine($"Minim of latitude is {minLatitude}");
            */

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 9 - print the user with max long  nu stiu cum sa fac print-ul
            /*
            var maxLatitude = allUsers.Max(x => x.Address.Geo.Lng);
             Console.WriteLine($" Maximum of long is {maxLatitude}");
            
            */

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only     NU STIU!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!CUM AS PUTEA SA FAC?
            /*
                    List<UserPosts> userPosts = new List<UserPosts>();
                     UserPosts user1 = new UserPosts();
                  //   userPosts.AddRange();   ????????
                
             */




            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // 11 - order users by zip code (CORECT)
            /*
            var UserByZipCode = allUsers.OrderBy(x => x.Address.Zipcode).ToList();

               foreach (var elem in UserByZipCode)
               {
                   Console.WriteLine($" USER NAME: {elem.Name}, ZIPCODE:{ elem.Address.Zipcode}");
               }
               Console.ReadLine();  
            */
            /////////////////////////////////////////////////////////////////////////////////////////////////////
            // 12 - order users by number of posts  ?????????????????????????????????


        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
