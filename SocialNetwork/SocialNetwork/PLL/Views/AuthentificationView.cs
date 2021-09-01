﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Modules;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    public class AuthentificationView
    {
        UserService userService;

        public AuthentificationView(UserService service) => userService = service;

        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = userService.Authenticate(authenticationData);

                SuccessMessage.Show("Вы успешно вошли в социальную сеть!");
                SuccessMessage.Show("Добро пожаловать " + user.FirstName);

                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show("Пароль не корректный!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
