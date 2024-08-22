using Freelancers_API.Models;

namespace Freelancers_API.Interfaces
{
    public interface IFreelancerService
    {
        List<User> GetUserList();
        User RegisterUser(User user);

        User UpdateUser(User user, int id);

        int DeleteUser(int id);

    }
}
