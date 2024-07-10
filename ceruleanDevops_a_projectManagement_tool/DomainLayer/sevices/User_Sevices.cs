using AutoMapper;
using BusinessLOgic.IServices;
using DAL.Entites;
using DAL.Irepositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
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

        public async Task<string> GetUser(int userId)
        {
            var result = await userRespository.GetUser(userId);
            return result.UserName;
        }
        public async Task<int> GetUserIdByName(string name)
        {
            var result = await userRespository.GetUserIdByName(name);
            return result.UserId;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRespository.GetUsers();
        }
    }
}
