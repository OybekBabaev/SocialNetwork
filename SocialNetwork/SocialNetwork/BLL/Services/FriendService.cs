using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Modules;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public void Add(User user, string email)
        {
            var friendUserEntity = userRepository.FindByEmail(email);

            if (friendUserEntity is null)
                throw new UserNotFoundException();

            FriendEntity friendEntity = new()
            {
                user_id = user.Id,
                friend_id = friendUserEntity.id
            };

            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
