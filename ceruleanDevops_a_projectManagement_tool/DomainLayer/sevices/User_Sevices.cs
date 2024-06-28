using AutoMapper;
using BusinessLOgic.IServices;
using DAL.Entites;
using DAL.Irepositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class User_Sevices : IUserSerivce
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository userRespository;

        public User_Sevices(IUserRepository workItemsRespository, IMapper mapper)
        {
            _mapper = mapper;
            userRespository = workItemsRespository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRespository.GetUsers();
        }
    }
}
