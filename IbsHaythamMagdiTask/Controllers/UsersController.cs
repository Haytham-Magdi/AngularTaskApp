using IbsHaythamMagdiTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework.Extensions;
using System.Diagnostics;

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

                //user.Id = user0.Id;
                //user.FirstName = user0.FirstName;
                //user.LastName = user0.LastName;
                //user.UserName = user0.UserName;
                //user.Password = user0.Password;
                //user.IsActive = user0.IsActive;


                //var qry1 = from userRole in user.UserRoles
                //           select userRole;
                //qry1.dele

                dc.Database.ExecuteSqlCommand("delete from UserWithUserRoles where UserId = {0}", user.Id);

                //throw new Exception();

                //user.UserRoles.

                //user.UserRoles.Clear();

                //var list_UserRoles = user.UserRoles.ToList();

                //list_UserRoles.Clear();


                //dc.det .Users.deta Attach(user);
                //dc.Entry<User>.

                //dc.Users.em
                //var user1 = dc.Users.FirstOrDefault();

                //var list_UserRoles = dc.UserRoles.ToList();

                //var list_UserRoles = new List<UserRole>();

                //list_UserRoles.Add(new UserRole { Id = 1 });
                //list_UserRoles.Add(new UserRole { Id = 2 });
                ////list_UserRoles.Add(new UserRole { Id = 3 });

                //foreach (var userRole in list_UserRoles)
                //{
                //    dc.UserRoles.Attach(userRole);
                //    user.UserRoles.Add(userRole);
                //}


                var list_UserWithUserRoles = new List<UserWithUserRole>();

                list_UserWithUserRoles.Add(new UserWithUserRole { UserId = 1, UserRoleId = 1 });
                list_UserWithUserRoles.Add(new UserWithUserRole { UserId = 1, UserRoleId = 2 });
                list_UserWithUserRoles.Add(new UserWithUserRole { UserId = 1, UserRoleId = 3 });

                //list_UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 1 });
                //list_UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 2 });
                //list_UserWithUserRoles.Add(new UserWithUserRole { UserRoleId = 3 });

                foreach (var userWithUserRole in list_UserWithUserRoles)
                {
                    //dc.UserWithUserRoles.Attach(userWithUserRole);
                    //user.UserWithUserRoles.Add(userWithUserRole);

                    dc.UserWithUserRoles.Add(userWithUserRole);
                }

                
                dc.SaveChanges();

                txn.Commit();

            }


            //var dc = new IbsHaythamMagdiTaskDBEntities();

            //dc.Users.Where(x => x.Id == userId).Update(x => new User() { IsActive = active });


            //return null;

            return View("Index");
        }



    }
}