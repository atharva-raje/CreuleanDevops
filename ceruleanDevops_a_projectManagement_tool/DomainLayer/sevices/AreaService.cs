﻿using AutoMapper;
using BusinessLOgic.IServices;
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
    public class AreaService : IAreaService
    {
        private readonly IMapper _mapper;
        private readonly IAreaRepository areaRepository;

        public AreaService(IAreaRepository _statusRepository, IMapper mapper)
        {
            _mapper = mapper;
            areaRepository = _statusRepository;
        }

        public async Task<string> GetAreaName(int name)
        {
            var result = await areaRepository.GetAreaName(name);
            return  result.AreaName;
        }

        public async Task<IEnumerable<Areas>> GetAreas()
        {
            return await areaRepository.GetAreas();
        }
    }

























































































































































































































































































































































































}
