﻿using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IPriorityRepository
    {
        Task<Priorities> GetPriorityId(string priorityName);
        Task<IEnumerable<Priorities>> GetPriorities();
        Task<Priorities> GetPriorityName(int priorityid);
    }
}
