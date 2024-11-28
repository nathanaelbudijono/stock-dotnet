using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dto.comment;
using api.interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentExist = await _context.Comments.FirstOrDefaultAsync(item => item.Id == id);

            if (commentExist is null)
            {
                return null;
            }
            _context.Comments.Remove(commentExist);
            await _context.SaveChangesAsync();
            return commentExist;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(item => item.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context
                .Comments.Include(item => item.AppUser)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (comment is null)
            {
                return null;
            }
            return comment;
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto updateComment)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(item =>
                item.Id == id
            );
            if (existingComment is null)
            {
                return null;
            }

            existingComment.Title = updateComment.Title;
            existingComment.Content = updateComment.Content;

            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}
