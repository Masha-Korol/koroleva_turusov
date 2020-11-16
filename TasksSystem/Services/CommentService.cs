using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;
using TasksSystem.Repos;

namespace TasksSystem.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepo;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepo = commentRepository;
        }

        public void CreateComment(Comment comment)
        {
            _commentRepo.CreateComment(comment);
        }

        public List<Comment> GetAllComments()
        {
            return _commentRepo.GetAllComments();
        }

        public Comment GetCommentById(int? id)
        {
            return _commentRepo.GetCommentById(id);
        }

        public void RemoveComment(Comment comment)
        {
            _commentRepo.RemoveComment(comment);
        }
    }
}
