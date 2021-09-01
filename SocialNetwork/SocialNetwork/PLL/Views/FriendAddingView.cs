using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Modules;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddingView
    {
        FriendService friendService;

        public FriendAddingView(FriendService service) => friendService = service;

        public void Show(User user)
        {
            try
            {
                Console.Write("Введите почтовый адрес того, кого хотите добавить в друзья: ");
                string email = Console.ReadLine();
                friendService.Add(user, email);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
