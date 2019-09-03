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
        [HttpGet]
        public IEnumerable<LoginData> Get()
        {
            return _profileContext.loginData.ToList();
        }

        public LoginController(ProfileContext profile)
        {
            _profileContext = profile;
        }
        [HttpPost]
        public bool Post([FromBody] LoginData obj)
        {

            var isAvaluable = _profileContext.loginData.FirstOrDefault(row => obj.Email == row.Email);

            if (isAvaluable != null && obj.Name == null)
            {
                if (isAvaluable.Password == obj.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            else if (obj.Name != null)
            {
                obj.CreationDate = DateTime.Now;
                _profileContext.loginData.Add(obj);
                _profileContext.SaveChanges();
                return true;
            }
            else { return false; }


        }
    }
}