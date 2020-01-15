using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeeklyTalks.Helpers;
using WeeklyTalks.Models;

namespace WeeklyTalks.Services
{
    public interface IUserService
    {
        Users Authenticate(string email, string password);
        IEnumerable<Users> GetAll(int officeId);
        Users GetById(long id);
        Users Create(Users user, string password);
        Users Update(Users user);
        Users ChangePassword(Users user);
        void Delete(long id);
    }
    public class UserService : IUserService
    {
        private db_weeklytalksContext _context;

        public UserService(db_weeklytalksContext context)
        {
            _context = context;
        }

        public Users Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Email == email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<Users> GetAll(int officeId)
        {
            return _context.Users.Where(u => u.OfficeId == officeId).ToList();
        }

        public Users GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public Users Create(Users user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Email == user.Email))
                throw new AppException("Username \"" + user.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Password = "";
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public Users ChangePassword(Users userParam)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");


            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(userParam.Password))
            {
                CreatePasswordHash(userParam.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public Users Update(Users userParam)
        {
            var user = _context.Users.Find(userParam.Id);

            if (user == null)
                throw new AppException("User not found");

            if (!string.IsNullOrWhiteSpace(userParam.Password))
            {
                CreatePasswordHash(userParam.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            user.OfficeId = userParam.OfficeId;
            user.Password = "";
            user.UpdatedAt = DateTime.Now;
            _context.Users.Update(user);
            _context.SaveChanges();
                
            return user;
        }    

        public void Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
