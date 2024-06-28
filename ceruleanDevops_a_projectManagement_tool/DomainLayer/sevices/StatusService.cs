﻿using AutoMapper;
using BusinessLOgic.IServices;
using BusinessLOgic.Models;
using DAL.Entites;
using DAL.Irepositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class StatusService : IStatusService
    {
        private readonly IMapper _mapper;
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository _statusRepository, IMapper mapper)
        {
            _mapper = mapper;
            statusRepository = _statusRepository;
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            return await statusRepository.GetStatuses();
        }

        public async Task<int> GetStatusId(string name)
        {
            var result = await statusRepository.GetStatusId(name);
            return result.Id;
        }

        public async Task<string> GetStatusName(int  statusId)
        {
            var result = await statusRepository.GetStatusName(statusId);
            return result.Name;
        }
    }
}