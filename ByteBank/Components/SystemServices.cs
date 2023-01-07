using ByteBank.Entities;

namespace ByteBank.Components
{
    public class SystemServices
    {
        public static void StartProgram()
        {
            VirtualAssistant.EvaWrite("Oii, eu sou a Eva, serei sua assistente virtual no nosso sistema bancário, seja bem-vindo ao\n");
            Thread.Sleep(200);

            Animate.ShowBanner(ASCII.byteBank, 15, ConsoleColor.DarkGreen); Thread.Sleep(500);

            VirtualAssistant.EvaWrite("Deseja entrar na sua conta?\n");

            if (Validate.ConfirmChoice() == true)
            {
                User.LoginAdm();
            } else
            {
                 FinishProgram();
            }
        }

        public static void ShowMainMenu()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.menu, 7, ConsoleColor.DarkYellow);

            int chosenOption;

            do
            {
                VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[1]");
                Console.WriteLine(" - Cadastrar novo usuário"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[2]");
                Console.WriteLine(" - Detalhar usuário"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[3]");
                Console.WriteLine(" - Deletar uma conta"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[4]");
                Console.WriteLine(" - Listar usuários"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Green, "[5]");
                Console.WriteLine(" - Realizar operação bancária"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Green, "[6]");
                Console.WriteLine(" - Mostrar montante total no banco"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Red, "[7]");
                Console.WriteLine(" - Sair da conta"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite(ConsoleColor.Red, "[0]");
                Console.WriteLine(" - Para sair do programa"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite("Digite a opção desejada: ");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                chosenOption = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (chosenOption)
                {
                    case 1:
                        User.RegisterUser();
                        break;
                    case 2:
                        User.DetailUser();
                        break;
                    case 3:
                        User.DeleteUser();
                        break;
                    case 4:
                        User.ListAllUsers();
                        break;
                    case 5:
                        Bank.DoBanking();
                        break;
                    case 6:
                        Bank.ShowTotalBankBalance();
                        break;
                    case 7:
                        User.LogoutUser();
                        break;
                    case 0:
                        FinishProgram();
                        break;
                    default:
                        VirtualAssistant.EvaWrite("Opção inválida, insira uma opção de 0 a 6:\n");
                        break;
                }

            } while (chosenOption != 0);
        }

        public static void ShowSubMenu()
        {
            VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[1]");
            Console.WriteLine(" - Voltar ao MENU");

            VirtualAssistant.EvaWrite(ConsoleColor.Red, "[0]");
            Console.WriteLine(" - Sair do Programa");

            VirtualAssistant.EvaWrite("Digite a opção desejada: ");
            int chosenOption;

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                chosenOption = int.Parse(Console.ReadLine());
                Console.ResetColor();

                switch (chosenOption)
                {
                    case 1:
                        ShowMainMenu();
                        break;
                    case 0:
                        FinishProgram();
                        break;
                    default:
                        VirtualAssistant.EvaWrite(ConsoleColor.Red, "Opção inválida, escolha [0] ou [1]: ");
                        break;
                }

            } while (chosenOption != 0);
        }

        public static void FinishProgram()
        {
            VirtualAssistant.EvaWrite("Estou encerrando o programa");
            Animate.LoadPoints();
            VirtualAssistant.EvaWrite(ConsoleColor.Red, "Sistema encerrado.\n");
            Environment.Exit(0);
        }
    }
}