using Microsoft.EntityFrameworkCore;
using Pre_Assignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pre_Assignment.Entity;


namespace Pre_Assignment.Service
{
    public class CommentService
    {
        public void RegisterComment(Comments comment)
        {
            CommentRepository commentRepository = new CommentRepository();
            commentRepository.SaveComment(comment);
        }
        public void ShowAllComments()
        {
            CommentRepository commentRepository = new CommentRepository();
            List<Comments> comment = commentRepository.GetComment();

            foreach (Comments newComment in comment)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"CommentID: {newComment.ID}");
                Console.WriteLine($"Comment: {newComment.Description}");
            }
        }
    }
}
