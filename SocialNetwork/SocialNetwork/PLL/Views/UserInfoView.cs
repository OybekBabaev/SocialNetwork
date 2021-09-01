using SocialNetwork.BLL.Modules;
using SocialNetwork.DAL.Repositories;
using System;
using System.Linq;

namespace SocialNetwork.PLL.Views
{
    public class UserInfoView
    {     
        public void Show(User user)
        {
            UserRepository userRepository = new();
            FriendRepository friendRepository = new();

            Console.WriteLine("Информация о моем профиле");
            Console.WriteLine("Мой идентификатор: {0}", user.Id);
            Console.WriteLine("Меня зовут: {0}", user.FirstName);
            Console.WriteLine("Моя фамилия: {0}", user.LastName);
            Console.WriteLine("Мой пароль: {0}", user.Password);
            Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
            Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
            Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
            Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
            Console.Write("Мои друзья:");

            var friends = friendRepository.FindAllByUserId(user.Id);
            if (!friends.Any())
                Console.WriteLine(" -");
            else
            {
                Console.WriteLine();
                foreach (var f in friends)
                {
                    var theFriend = userRepository.FindById(f.friend_id);
                    Console.WriteLine("-> {0} {1} ({2})",
                        theFriend.firstname,
                        theFriend.lastname,
                        theFriend.email);
                }
                    
            }
        }
    }
}
