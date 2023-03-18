using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;


namespace Pre_Assignment.Repository
{
    public class CommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository()
        {
            _context = new ApplicationDBContext();
        }
        public bool SaveComment(Comments comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYour Comment have been saved!\n");
            return true;
        }
        public List<Comments> GetComment()
        {
            List<Comments> comment = _context.Comments.ToList();
            return comment;
        }
    }
}
