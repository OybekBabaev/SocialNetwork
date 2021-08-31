using SocialNetwork.DAL.Entities;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public int Create(MessageEntity messageEntity) =>
            Execute(@"insert into messages(content, sender_id, recipient_id) 
                             values(:content,:sender_id,:recipient_id)", messageEntity);

        public IEnumerable<MessageEntity> FindBySenderId(int senderId) =>
            Query<MessageEntity>("select * from messages where sender_id = :sender_id", new { sender_id = senderId });

        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId) =>
            Query<MessageEntity>("select * from messages where recipient_id = :recipient_id", new { recipient_id = recipientId });

        public int DeleteById(int messageId) => Execute("delete from messages where id = :id", new { id = messageId });
    }
}