using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Modules;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using System;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthentificationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        static void Main()
        {
            Console.InputEncoding = Console.OutputEncoding = System.Text.Encoding.Unicode;

            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthentificationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(userService, messageService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();

            while (true) mainView.Show();
        }
    }
}
