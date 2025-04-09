using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Include(p => p.User).Include(p => p.Comments).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.Include(p => p.User).Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Post> GetPostByIdUser(int id)
        {
            return await _context.Posts.Include(p => p.User).Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //go
        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
        {
            // This query returns all posts by the specified user,
            // including the related User and Comments if needed.
            return await _context.Posts
                                 .Include(p => p.User)
                                 .Include(p => p.Comments)
                                 .Where(p => p.UserId == userId)
                                 .ToListAsync();
        }
    }

}
