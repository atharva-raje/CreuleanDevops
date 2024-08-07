﻿using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.IServices
{
    public interface IPriorityService
    {
        Task<int> GetPriorityId(string priorityName);
        Task<IEnumerable<Priorities>> GetPriorities();
        Task<string> GetPriorityName(int id);
    }
}
