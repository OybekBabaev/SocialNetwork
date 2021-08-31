using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public int Create(FriendEntity friendEntity) =>
            Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);

        public IEnumerable<FriendEntity> FindAllByUserId(int userId) =>
            Query<FriendEntity>("select * from friends where user_id = :user_id", new { user_id = userId });

        public int Delete(int id) =>
            Execute(@"delete from friends where id = :id_p", new { id_p = id });
    }
}
