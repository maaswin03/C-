using Microsoft.EntityFrameworkCore;
using Task_10.Models;
using Task_10.Data;

namespace Task_10.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        //Add new user
        public async Task<User?> AddUser(User user)
        {
            try
            {
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == user.Username);

                if (existingUser != null)
                    return null;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Validate user
        public async Task<User?> ValidateUser(string username, string password)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}