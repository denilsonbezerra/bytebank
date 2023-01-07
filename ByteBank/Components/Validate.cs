namespace ByteBank.Components
{
    internal class Validate
    {
        internal static string ValidateName()
        {
            VirtualAssistant.EvaWrite("Digite o nome da conta: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string username = Console.ReadLine().ToUpper();
            Console.ResetColor();

            while (username.Contains("0") || username.Contains("1") || username.Contains("2") || username.Contains("3") || username.Contains("4") || username.Contains("5") || username.Contains("6") || username.Contains("7") || username.Contains("8") || username.Contains("9"))
            {
                VirtualAssistant.EvaWrite(ConsoleColor.Red, "Nome inválido!\n"); Thread.Sleep(200);

                VirtualAssistant.EvaWrite("Por favor, digite um nome válido (sem números): ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                username = Console.ReadLine();
                Console.ResetColor();
            }

            return username;
        }

        internal static string ValidateCPF()
        {
            string cpf;

            do
            {
                VirtualAssistant.EvaWrite("Digite o cpf do proprietário (Ex: XXX.XXX.XXX-XX): ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                cpf = (Console.ReadLine());
                Console.ResetColor();

                if (cpf.Length != 14)
                {
                    VirtualAssistant.EvaWrite(ConsoleColor.DarkYellow, "CPF inválido, digite um CPF válido.\n");
                }
            } while (cpf.Length != 14);

            return cpf;
        }

        internal static string ValidatePassword()
        {
            string userPassword, confirmPassword;

            do
            {
                VirtualAssistant.EvaWrite("Digite uma senha com no mínimo 6 caracteres: ");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                userPassword = HidePassword();
                Console.ResetColor();

                VirtualAssistant.EvaWrite("Digite novamente para confirmar: ");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                confirmPassword = HidePassword();
                Console.ResetColor();


                if (userPassword.Length < 6)
                {
                    VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "Senha muito pequena.\n");
                    continue;
                } else if (userPassword != confirmPassword)
                {
                    Animate.LoadPoints();
                    VirtualAssistant.EvaWrite(ConsoleColor.Red, "As senhas não coincidem, tente novamente.\n");
                }

            } while (userPassword != confirmPassword && userPassword.Length >= 6);
            return userPassword;
        }

        internal static string HidePassword()
        {
            List<char> senha = new List<char>();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace)
                {
                    int posicaoX = Console.CursorLeft;
                    int posicaoY = Console.CursorTop;

                    if (senha.Count() > 0)
                    {
                        Console.SetCursorPosition(posicaoX - 1, posicaoY);
                        Console.Write(" ");
                        Console.SetCursorPosition(posicaoX - 1, posicaoY);
                        Console.Write("");
                        senha.RemoveAt(senha.Count() - 1);
                    }
                } else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                } else
                {
                    senha.Add(key.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return string.Join("", senha);
        }

        internal static decimal ValidateBalance()
        {
            VirtualAssistant.EvaWrite("Digite um valor para o primeiro depósito: ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            decimal balance = (decimal.Parse(Console.ReadLine()));
            Console.ResetColor();

            Animate.LoadBar();
            VirtualAssistant.EvaWrite(ConsoleColor.Green, $"Depósito de R$ {balance:F2} realizado com sucesso!");

            return balance;
        }

        internal static bool ConfirmChoice()
        {
            do
            {
                VirtualAssistant.EvaWrite(ConsoleColor.Green, "SIM ");
                VirtualAssistant.EvaWrite("ou ");
                VirtualAssistant.EvaWrite(ConsoleColor.Red, "NÃO");
                Console.Write(": ");
                string inputChoice = Console.ReadLine().ToUpper();

                if (inputChoice == "SIM")
                {
                    return true;
                } else if (inputChoice == "NAO" || inputChoice == "NÃO")
                {
                    return false;
                }

                VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "Por favor, escolha uma opção válida.\n");
            } while (true);
        }
    }
}
