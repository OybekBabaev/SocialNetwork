using SocialNetwork.BLL.Modules;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class UserDataUpdateView
    {
        UserService userService;

        public UserDataUpdateView(UserService service) => userService = service;

        public void Show(User user)
        {
            Console.Write("Меня зовут:");
            user.FirstName = Console.ReadLine();

            Console.Write("Моя фамилия:");
            user.LastName = Console.ReadLine();

            Console.Write("Ссылка на моё фото:");
            user.Photo = Console.ReadLine();

            Console.Write("Мой любимый фильм:");
            user.FavoriteMovie = Console.ReadLine();

            Console.Write("Моя любимая книга:");
            user.FavoriteBook = Console.ReadLine();

            userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
