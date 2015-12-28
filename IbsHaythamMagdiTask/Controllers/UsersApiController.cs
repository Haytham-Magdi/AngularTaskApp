using IbsHaythamMagdiTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//using System.Data.Entity.ex;
using EntityFramework.Extensions;
using Newtonsoft.Json;

namespace IbsHaythamMagdiTask.Controllers
{
    public class UsersApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<User> Get(string email)
        //public IEnumerable<User> Get()
        {
            //string email = "";

            var dc = new IbsHaythamMagdiTaskDBEntities();

            var ret = (from user in dc.Users
                       where (string.IsNullOrEmpty(email) || user.Email.Contains(email))
                       select user).ToList();

            return ret;
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            var dc = new IbsHaythamMagdiTaskDBEntities();

            var ret = dc.Users.SingleOrDefault(x => x.Id == id);

            return ret;
        }

        // POST api/<controller>
        //public void Post(User user)
        public void Post(string FirstName)
        {
            var user = new User
            {
                FirstName = FirstName,
                LastName = "any",
                Email = "any",
                UserName = "any",
                Password = "any",
                IsActive = true,
            };

            var dc = new IbsHaythamMagdiTaskDBEntities();



            dc.Users.Add(user);
            dc.SaveChanges();
        }

        // PUT api/<controller>/5
        //public void Put(User user)
        //public void Put(int Id, string FirstName, string userJson)
        public void Put(string userJson)
        {
            //var parParts = userJson.Replace("\"", "").Replace("{", "").Replace("}", "")
            //    .Split(new string[] { ":", "," }, StringSplitOptions.None);

            //var user = new User
            //{
            //    Id = Id,
            //    FirstName = FirstName,
            //};

            //Product product = new Product();
            //product.Name = "Apple";
            //product.Expiry = new DateTime(2008, 12, 28);
            //product.Sizes = new string[] { "Small" };


            //string json = JsonConvert.SerializeObject(user);

            var user = JsonConvert.DeserializeObject<User>(userJson);

            //string name = m.Name;

            var dc = new IbsHaythamMagdiTaskDBEntities();

            var orgUser = dc.Users.SingleOrDefault(x => x.Id == user.Id);

            //FrameworkTypeUtility.SetProperties(data, originalData);

            orgUser.FirstName = user.FirstName;

            dc.SaveChanges();
            //throw new NotImplementedException();

            //dc.Users.up
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //try
            {

                //throw new Exception();

                var dc = new IbsHaythamMagdiTaskDBEntities();

                //dc.Users.Delete(x => x.Id == id);
                dc.Users.Where(x => x.Id == id).Delete();


                //throw new NotImplementedException();


            }
            //catch(Exception exp)
            {

            }

        }
    }
}