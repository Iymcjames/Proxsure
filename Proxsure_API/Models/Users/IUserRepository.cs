using System.Threading.Tasks;

namespace Proxsure_API.Models.Users
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Register(ApplicationUser User);
    }
}