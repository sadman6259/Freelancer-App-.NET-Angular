using Freelancers_API.Interfaces;
using Freelancers_API.Models;
using Freelancers_API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Freelancers_API.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly FreelancerRepository repo = null;
        private readonly FreelancerDbContext context;
        public FreelancerService(IConfiguration Config)
        {
            this.context = new FreelancerDbContext(Config);
            this.repo = new FreelancerRepository(this.context);

        }
     
        public List<User> GetUserList()
        {
            try
            {
                return repo.GetUserList();
            }
            catch(Exception) { throw; }
        }

        public User RegisterUser(User user)
        {
            try
            {
                return repo.RegisterUser(user);
            }
            catch (Exception) { throw; }
        }

        public User UpdateUser(User user, int id)
        {
            try
            {
                return repo.UpdateUser(user,id);
            }
            catch (Exception) { throw; }
        }

        public int DeleteUser(int id)
        {
            try
            {
                return repo.DeleteUser(id);
            }
            catch (Exception) { throw; }
        }
    }
}
