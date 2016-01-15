using IbsHaythamMagdiTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Extensions;
using System.Diagnostics;
using System.Data.Entity;

namespace IbsHaythamMagdiTask.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        public ActionResult Index()
        {
            if (false)
            {

                //var dc = new IbsHaythamMagdiTaskDBEntities();

                //dc.Users.Add(new User
                //{
                //    FirstName = "Haytham",
                //    LastName = "Magdi",
                //    Email = "h1@h.com",
                //    UserName = "user1",
                //    Password = "1234",
                //    IsActive = true,
                //});

                //dc.Users.Add(new User
                //{
                //    FirstName = "Ahmed",
                //    LastName = "Ali",
                //    Email = "h2@h.com",
                //    UserName = "user2",
                //    Password = "1234",
                //    IsActive = true,
                //});

                //dc.Users.Add(new User
                //{
                //    FirstName = "Tamer",
                //    LastName = "Mohamed",
                //    Email = "h3@h.com",
                //    UserName = "user3",
                //    Password = "1234",
                //    IsActive = true,
                //});

                //dc.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        public JsonResult Activate(int userId, bool active)
        {
            var dc = new IbsHaythamMagdiTaskDBEntities();

            dc.Users.Where(x => x.Id == userId).Update(x => new User() { IsActive = active });


            return null;
        }

        //[HttpPost]
        public ActionResult Try2()
        {
            var dc = new IbsHaythamMagdiTaskDBEntities();

            dc.Database.Log = message => Trace.WriteLine(message);
            //dc.Database.Log


            using (var txn = dc.Database.BeginTransaction())
            //using (var txn = new TransactionScope())
            {
                //var user0 = dc.Users.FirstOrDefault();

                var user = new User();

                user.Id = 1;
                dc.Users.Attach(user);

                //var user = dc.Users.FirstOrDefault(x => x.Id == 1);

                //user.FirstName = "user0.FirstName";
                //user.LastName = "user0.LastName";
                //user.Email = "user0.Email";
                //user.UserName = "user0.UserName";
                //user.Password = "user0.Password";
                //user.IsActive = true;

                //dc.Users.Add(user);

                var uwur = new UserWithUserRole { UserRoleId = 2, UserId = user.Id };
                dc.UserWithUserRoles.Attach(uwur);
                //user.UserWithUserRoles.Remove(uwur);

                //var uwur77 = dc.UserWithUserRoles.Find(new { UserRoleId = 2, UserId = user.Id });
                var uwur77 = dc.UserWithUserRoles.Find(user.Id, 2);
                //user.UserWithUserRoles.Fin

                user.UserWithUserRoles.Clear();

                ////dc.Database.ExecuteSqlCommand("delete from UserWithUserRoles where UserId = {0}", user.Id);
                //dc.UserWithUserRoles.Where(x => x.UserId == user.Id).Delete();

                //user.UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 1 });
                //user.UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 2 });
                //user.UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 3 });


                //var list_UserWithUserRoles = new List<UserWithUserRole>();

                //list_UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 1 });
                //list_UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 2 });
                //list_UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 3 });

                //foreach (var userWithUserRole in list_UserWithUserRoles)
                //{
                //    //dc.UserWithUserRoles.Attach(userWithUserRole);

                //    //var userRole = dc.UserRoles.Attach(new UserRole { Id = userWithUserRole.UserRoleId });
                //    //userRole.UserWithUserRoles.Add(userWithUserRole);

                //    user.UserWithUserRoles.Add(userWithUserRole);

                //    //dc.UserWithUserRoles.Add(userWithUserRole);
                //}


                dc.SaveChanges();

                txn.Commit();

            }


            //var dc = new IbsHaythamMagdiTaskDBEntities();

            //dc.Users.Where(x => x.Id == userId).Update(x => new User() { IsActive = active });


            //return null;

            return View("Index");
        }

        public ActionResult Try3()
        {
            var dc = new IbsHaythamMagdiTaskDBEntities();

            dc.Database.Log = message => Trace.WriteLine(message);

            {
                //var list1 = from member1 in dc.Members.Where(x => x.Id == 1)
                //var list1 = from member1 in dc.Members
                //             //join book1 in member1.Books
                //             join book1 in dc.Books on member1.Id equals book1.Id

                //             select book1;

                //var list1 = (from member1 in dc.Members.Where(x => x.Id == 1)
                //             from book1 in member1.Books
                //             select book1).ToList();

                //var list2 = (from user1 in dc.Users
                //             where user1.Id == 1
                //             from cmt in user1.UserComments
                //             select cmt).ToList();

            }

            using (var txn = dc.Database.BeginTransaction())
            //using (var txn = new TransactionScope())
            {
                //var member0 = dc.Members.FirstOrDefault();

                var member = new Member();

                member.Id = 1;
                dc.Members.Attach(member);

                //member.Name = "member0.Name";

                //dc.Members.Add(member);

                //var book = new Book { Id = 2 };
                //dc.Books.Attach(book);
                //member.Books.Remove(book);

                //member.Books.Clear();

                //var list1 = (from member1 in dc.Members.Where(x => x.Id == member.Id)

                //            from book1 in member1.Books
                //            select book1).ToList();


                // important to revise.
                //var list1 = (from member1 in dc.Members
                //             .Include(x => x.Books)
                //                 .Where(x => x.Id == member.Id)

                //             from book1 in member1.Books
                //             select member1).ToList();

                var list1 = (from member1 in dc.Members
                                 .Where(x => x.Id == member.Id)
                             .Include(x => x.Books)

                             from book1 in member1.Books
                             select member1).ToList();



                dc.Database.ExecuteSqlCommand("delete from MemberWithBooks where MemberId = {0}", member.Id);


                var list_Books = new List<Book>();

                list_Books.Add(new Book { Id = 1 });
                list_Books.Add(new Book { Id = 2 });
                list_Books.Add(new Book { Id = 3 });

                foreach (var book in list_Books)
                {
                    dc.Books.Attach(book);

                    member.Books.Add(book);
                }


                dc.SaveChanges();

                txn.Commit();

            }


            //var dc = new IbsHaythamMagdiTaskDBEntities();

            //dc.Members.Where(x => x.Id == memberId).Update(x => new Member() { IsActive = active });


            //return null;

            return View("Index");
        }


    }
}