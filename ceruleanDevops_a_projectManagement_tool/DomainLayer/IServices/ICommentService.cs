﻿using BusinessLOgic.Models;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public  interface ICommentService
    {
        Task<IEnumerable<Comments>> GetComments();
        Task<Comments> AddComment(CommentModel comment);
    }
}