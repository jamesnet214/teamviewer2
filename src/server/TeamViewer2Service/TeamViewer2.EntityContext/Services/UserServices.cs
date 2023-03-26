using TeamViewer2.EntityContext.Context;
using TeamViewer2.EntityContext.Entites;

namespace TeamViewer2.EntityContext.Services
{
        public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }
    }
}
