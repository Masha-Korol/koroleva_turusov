using AutoMapper;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;

namespace TasksSystem.Repos
{
    public class CommentRepository
    {
        private readonly ClassLibraryContext _context;
        private readonly IMapper _mapper;
        public CommentRepository(ClassLibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(_mapper.Map<Comment, CommentDb>(comment));
            _context.SaveChanges();
        }

        public List<Comment> GetAllComments()
        {
            return _mapper.Map<List<CommentDb>, List<Comment>>(_context.Comments.AsNoTracking().ToList());
        }

        public Comment GetCommentById(int? id)
        {
            var comment = _context.Comments.AsNoTracking().FirstOrDefault(p => p.Id == id);
            return _mapper.Map<CommentDb, Comment>(comment);
        }

        public void RemoveComment(Comment comment)
        {
            _context.Comments.Remove(_mapper.Map<Comment, CommentDb>(comment));
            _context.SaveChanges();
        }
    }
}
