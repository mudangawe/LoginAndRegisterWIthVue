using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginWebBackEnd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWebBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ProfileContext _profileContext;
        //[HttpGet]
        //public IEnumerable<LoginData> Get()
        //{
        //    return " ";
        //}

        public LoginController(ProfileContext profile)
        {
            _profileContext = profile;
        }
        [HttpPost]
        public object Post([FromBody] LoginData obj)
        {

            var isAvaluable = _profileContext.loginData.FirstOrDefault(row => obj.Email == row.Email);
            ReturnData returnData = new ReturnData();
           
            if (isAvaluable != null && obj.Name == null)
            {
                if (isAvaluable.Password == obj.Password)
                {
                    returnData.OutPut = true;
                    returnData.message = "Login succefully";
                    return (returnData);
                }
                else
                {
                    returnData.OutPut = false;
                    returnData.message = "Incorrect password";
                    return returnData;
                }
            }
            if (isAvaluable == null && obj.Surname != null)
            {
                _profileContext.loginData.Add(obj);
                _profileContext.SaveChanges();
                returnData.OutPut = true;
                returnData.message = "Register successfully";
                return (returnData);
            }
            else if (isAvaluable != null && obj.Surname != null)
            {
                returnData.OutPut = false;
                returnData.message = "Email already exist";
                return returnData;
            }
            returnData.OutPut = false;
            returnData.message = "Email does not exist";
            return returnData;

        }
        [HttpDelete]
        public void Delete()
        {
            var all = from c in _profileContext.loginData select c;
            if (all != null)
            {
                _profileContext.loginData.RemoveRange(all);
                _profileContext.SaveChanges();
            }

        }
    }
}