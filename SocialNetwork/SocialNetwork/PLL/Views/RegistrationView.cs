﻿using SocialNetwork.BLL.Modules;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService service) => userService = service;

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите ваше имя:");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия:");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль:");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Почтовый адрес:");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при регистрации.");
            }
        }
    }
}
