using Freelancers_API.Interfaces;
using Freelancers_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Freelancers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        IFreelancerService freelancerService;
        public FreelancerController(IFreelancerService _freelancerService)
        {
            freelancerService = _freelancerService;
        }

        // GET: api/Freelancer
        [HttpGet]

        public IActionResult GetAllFreelancers()
        {
            try
            {
                List<User> freelancersList = freelancerService.GetUserList();
                return Ok(freelancersList);
            }
            catch (Exception )
            {
                throw ;
            }

        }


        // POST api/<FreelancersController>
        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                User registeredUser = freelancerService.RegisterUser(user);
                return Ok(registeredUser);
            }
            catch (Exception) { throw; }
        }

        // PUT api/<FreelancersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            try
            {
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    User newUser = freelancerService.UpdateUser(user, id);
                    return Ok(newUser);

                }


            }
            catch (Exception) { throw; }
        }

        // DELETE api/<FreelancersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                else
                {
                    int res = freelancerService.DeleteUser(id);
                    if(res == 0)
                    return Ok();
                    else
                    return NotFound();

                }


            }
            catch (Exception) { throw; }
        }

    }
}
