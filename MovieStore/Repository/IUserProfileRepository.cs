using MovieStore.Models;
using System.Linq;

namespace MovieStore.Repository
{
    public interface IUserProfileRepository
    {
        IQueryable<UserProfile> UserProfiles { get; }
        UserProfile SaveProfile(UserProfile userProfile);
    }
}
