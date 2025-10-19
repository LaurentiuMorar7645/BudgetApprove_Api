using BudgetApprovedApi.Data;
using BudgetApprovedApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BudgetApprovedApi.Services
{
    // Implementarea IUserService. Conține logica de business și accesul la date.
    public class UserService : IUserService
    {
        private readonly DatabaseService _context;

        // Dependency Injection: Primeste DatabaseService (DbContext) în constructor.
        public UserService(DatabaseService context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            // Mutăm logica de acces la date din Controller în Service.
            if (_context.Users == null)
            {
                // De obicei, aruncăm o excepție logată sau returnăm o listă goală,
                // lăsând Controller-ul să decidă răspunsul HTTP (NotFound).
                return new List<UserModel>();
            }
            
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            if (_context.Users == null)
            {
                throw new InvalidOperationException("Setul de entități 'Users' este null.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
