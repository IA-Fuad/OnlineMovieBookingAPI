using Microsoft.EntityFrameworkCore;
using OnlineMovieBookingAPI.Data;
using OnlineMovieBookingAPI.Models.EntityModels;
using OnlineMovieBookingAPI.Models.ResponseModels;
using System.Linq;

namespace OnlineMovieBookingAPI.ControllerServices
{
    public interface IUserServices
    {
        UserResponse GetUser(int id);
        bool UpdateUser(UserEntity userEntity);
    }

    public class UserServices : IUserServices
    {
        private readonly OnlineMovieBookingContext db;

        public UserServices(OnlineMovieBookingContext context)
        {
            db = context;
        }

        public UserResponse GetUser(int id)
        {
            UserEntity userEntity = db.Users.Find(id);

            if (userEntity == null)
            {
                return null;
            }

            return Converter.UserEntityToResponse(userEntity);
        }

        public bool UpdateUser(UserEntity userEntity)
        {
            db.Entry(userEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.Users.Any(e => e.Id == userEntity.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }
    }
}
