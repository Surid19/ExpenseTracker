using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService
    {
        private static readonly IMapper mapper;

        static UserService()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>().ReverseMap();
            });
            mapper = cfg.CreateMapper();
        }

        public static UserDTO Create(UserDTO userDto)
        {
            var user = mapper.Map<User>(userDto);
            var createdUser = DataAccessFactory.UserData().Create(user);
            return mapper.Map<UserDTO>(createdUser);
        }

        public static bool Delete(string username)
        {
            return DataAccessFactory.UserData().Delete(username);
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();
            return mapper.Map<List<UserDTO>>(data);
        }

        public static UserDTO Get(string username)
        {
            var data = DataAccessFactory.UserData().Read(username);
            return mapper.Map<UserDTO>(data);
        }

        public static UserDTO Update(UserDTO userDto)
        {
            var user = mapper.Map<User>(userDto);
            var updatedUser = DataAccessFactory.UserData().Update(user);
            return mapper.Map<UserDTO>(updatedUser);
        }
    }
}
