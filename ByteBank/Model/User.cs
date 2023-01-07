using ByteBank.Components;

namespace ByteBank.Entities
{
    internal class User
    {
        internal static List<string> name = new List<string>();
        internal static List<string> cpf = new List<string>();
        internal static List<string> password = new List<string>();
        internal static List<decimal> balance = new List<decimal>();

        public static void RegisterUser()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.register, 7, ConsoleColor.DarkYellow);

            string registerName, registerCPF, registerPassword;
            decimal registerBalance;

            registerName = Validate.ValidateName();

            registerCPF = Validate.ValidateCPF();

            registerPassword = Validate.ValidatePassword();
            
            name.Add(registerName); cpf.Add(registerCPF); password.Add(registerPassword); 

            Animate.LoadPoints();
            VirtualAssistant.EvaWrite(ConsoleColor.Green, "Usuário criado com sucesso!\n"); Thread.Sleep(1500);
            Console.Clear();

            VirtualAssistant.EvaWrite("Deseja fazer um primeiro depósito na sua conta?\n");

            if (Validate.ConfirmChoice() == true)
            {
                balance.Add(Validate.ValidateBalance());

                SystemServices.ShowMainMenu();
            } else
            {
                balance.Add(0.00m);

                SystemServices.ShowMainMenu();
            }
        }

        public static void DetailUser()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.detailAccount, 7, ConsoleColor.DarkYellow);

            VirtualAssistant.EvaWrite("Digite o CPF da conta: ");
            string userCPF = Console.ReadLine();

            for (int i = 0; i < cpf.Count; i++)
            {
                if (userCPF == cpf[i])
                {
                    Console.WriteLine(
                    $"\nNome: {cpf[i]}   |   CPF:{cpf[i]} \n" +
                    $"Saldo: R${balance[i]:F2}");
                }
            }
        }

        public static void DeleteUser()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.deleteAccount, 7, ConsoleColor.Red);

            Console.Write("\nDigite o CPF da conta que deseja deletar: ");
            string cpfDeleteUser = Console.ReadLine();

            bool foundUser = false;

            for (int i = 0; i < cpf.Count(); i++)
            {
                if (cpfDeleteUser == cpf[i])
                {
                    foundUser = true;

                    Animate.LoadPoints();

                    VirtualAssistant.EvaWrite(ConsoleColor.Green, "Conta encontrada!\n");

                    VirtualAssistant.EvaWrite($"A conta no nome de {name[i]} com saldo de R$ {User.balance[i]} irá ser deletada, os dados não poderão ser recuperados, quer continuar a exclusão?\n");

                    if (Validate.ConfirmChoice() == true)
                    {
                        Console.WriteLine($"\nA conte de {name[i]} foi deletada!\n");

                        name.Remove(name[i]);
                        cpf.Remove(cpf[i]);
                        password.Remove(password[i]);
                        balance.Remove(balance[i]);

                        Thread.Sleep(1500);
                        Console.Clear();

                        SystemServices.ShowMainMenu();
                    } else
                    {
                        VirtualAssistant.EvaWrite("\nOperação cancelada!\n"); Thread.Sleep(500);
                        Console.Clear();

                        SystemServices.ShowMainMenu();
                    }
                }
            }

            if (foundUser == false)
            {
                Animate.LoadPoints();
                VirtualAssistant.EvaWrite(ConsoleColor.Red, "Nenhuma conta foi encontrada com esse CPF. \nVoltando ao MENU principal."); Thread.Sleep(1000);
            }

            Console.Clear();
            SystemServices.ShowMainMenu();
        }

        public static void ListAllUsers()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.listAccounts, 7, ConsoleColor.White);

            for (int i = 0; i < cpf.Count; i++)
            {
                Console.WriteLine(
                    $"\nNome: {name[i]}   |   CPF:{cpf[i]} \n" +
                    $"Saldo: R${balance[i]:F2}\n\n" +
                    $"-----------------------------------");
            }


        }

        public static void LoginAdm()
        {
            Animate.ShowBanner(ASCII.login, 7, ConsoleColor.White);

            string loginName, loginPassword;

            do
            {
                VirtualAssistant.EvaWrite("Digite o nome de acesso: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                loginName = Console.ReadLine();
                Console.ResetColor();

                VirtualAssistant.EvaWrite("Digite sua senha: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                loginPassword = Validate.HidePassword();
                Console.ResetColor();

                if (loginName != "admin" || loginPassword != "admin")
                {
                    VirtualAssistant.EvaWrite(ConsoleColor.Red, "Nome ou senha de acesso incorreto, tente novamente.\n");
                }
            } while (loginName != "admin" && loginPassword != "admin");

            SystemServices.ShowMainMenu();
        }

        public static void LogoutUser()
        {
            VirtualAssistant.EvaWrite($"Sessão da conta foi encerrada. \nEntre em alguma conta para usar o programa"); Thread.Sleep(1500);

            LoginAdm();
        }
    }
}