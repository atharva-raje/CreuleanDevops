using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Entites;
using DAL.Irepositeries;
using DAL.repositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class Comments_sevices : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IcommentRepository commentRepository;

        public Comments_sevices(IcommentRepository _IcommentRepository, IMapper mapper)
        {
            _mapper = mapper;
            commentRepository = _IcommentRepository;
        }

        public async Task<Comments> AddComment(CommentModel comment)
        {
            Comments newComment = new Comments
            {
                 
                Description = comment.Description,
                UserId = comment.userid,
                DateTime = comment.dateTime,
                WorkItemId = comment.workItemId

            };
            var result = await commentRepository.AddComment(newComment);
            return result;
        }

        public async Task<IEnumerable<Comments>> GetCommentsById(string id)
        {
             return await commentRepository.GetCommentsById(id);
        }
    }
}
