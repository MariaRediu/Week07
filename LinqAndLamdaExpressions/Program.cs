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
            // 3 - print number of posts for each user. (CORECT)

            /*
            var numberId = from x in allPosts.GroupBy(x => x.UserId)
                           select new
                           {
                               count = x.Count(),
                               x.First().UserId
                           };
            foreach (var elem in numberId)
            {
                Console.WriteLine(elem);
            }
              Console.ReadLine();

           */
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 4 numberId lat and long negative.(CORECT)
            /*
            var number = allUsers.Where(x => x.Address.Geo.Lat<0 && x.Address.Geo.Lng<0).ToList();

            foreach (var elem in number)
            {
                Console.WriteLine($"The ID   {elem.Id} is with  lat {elem.Address.Geo.Lat} and long {elem.Address.Geo.Lng}");
            }

            Console.ReadLine();
            */
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // 5 - find the post with longest body.  (CORECT)


            //var longest = allPosts.OrderByDescending(x => x.Body.Length).First();
            //Console.WriteLine($"The post with id {longest.Id}  has the longest body : {longest.Body}  ");
            //Console.ReadLine();


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 6 - print the name of the employee that have post with longest body. ??????

            //var nume = from a in allUsers
            //           join b in allPosts on a.Name equals b.Body.Length
            //           select new { Nume = a.Name, Posts = b.Body };

            //Console.WriteLine(nume);
            //Console.ReadLine();


          
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 7 - select all addresses in a new List<Address>. print the list. (CORECT)
            /*
            var result = (from s in allUsers
                          group s.Address by new { s.Address.Street, s.Address.Suite, s.Address.City, s.Address.Zipcode } into g
                          select new
                          {
                              Street = g.Key.Street,
                              Suite = g.Key.Suite,
                              City = g.Key.City,
                              Zipcode = g.Key.Zipcode
                          });
            foreach (var elem in result)
            {
                Console.WriteLine(elem);
            }
            Console.ReadLine();
            */
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 8 - print the user with min lat  (CORECT)

            //var minLatitude = allUsers.OrderBy(x => x.Address.Geo.Lat).Select(s=> new { s.Name, s.Address.Geo.Lat }).FirstOrDefault();

            //Console.WriteLine(minLatitude);
            //Console.ReadLine();




            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 9 - print the user with max long  (CORECT)

            //var maxLongitude = allUsers.OrderBy(x => x.Address.Geo.Lng).Select(s => new { s.Name, s.Address.Geo.Lng }).LastOrDefault();
            //Console.WriteLine(maxLongitude);
            //Console.ReadLine();

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
            // 12 - order users by number of posts =>>>>(CORECT)
            //var userOrder = allUsers.Join(allPosts,
            //                                user => user.Id,
            //                                post => post.UserId,
            //                                (user, post) => new { user.Id, user.Name, postId = post.Id })
            //                       .GroupBy(x => new { x.Id, x.Name })
            //                       .Select(x => new { x.Key.Id, x.Key.Name, TotalPosts = x.Count() })
            //                       .OrderBy(x => x.TotalPosts);





            //Console.ReadLine();
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
