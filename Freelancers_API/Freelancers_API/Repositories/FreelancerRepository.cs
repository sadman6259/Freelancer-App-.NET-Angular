using Freelancers_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freelancers_API.Repositories
{
    public class FreelancerRepository
    {
        private readonly FreelancerDbContext freelancerDbContext;
        public FreelancerRepository(FreelancerDbContext _freelancerDbContext)
        {
            this.freelancerDbContext = _freelancerDbContext;
        }

        public List<User> GetUserList()
        {
            try
            {
                List<User> userList = freelancerDbContext.Users.ToList();

                return userList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public User RegisterUser(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    freelancerDbContext.Users.Add(user);
                    freelancerDbContext.SaveChanges();
                }

                return user;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public User UpdateUser(User user,int id)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName) && user.Id > 0)
                {
                    freelancerDbContext.Users.Update(user);
                    freelancerDbContext.SaveChanges();
                }

                return user;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public int DeleteUser(int id)
        {
            try
            {
                int res = -1;
                User? user = freelancerDbContext.Users.FirstOrDefault(x => x.Id == id);

                if (user != null && !string.IsNullOrEmpty(user.UserName))
                {
                    freelancerDbContext.Users.Remove(user);
                    freelancerDbContext.SaveChanges();
                    res = 0;
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
