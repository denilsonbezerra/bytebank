using ByteBank.Components;

namespace ByteBank.Entities
{
    internal class Bank
    {
        public static void DoBanking()
        {
            Console.WriteLine("[Operações Bancárias]");
            VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[1]");
            Console.WriteLine(" - Sacar"); Thread.Sleep(200);

            VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[2]");
            Console.WriteLine(" - Depositar"); Thread.Sleep(200);

            VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[3]");
            Console.WriteLine(" - Transfererir"); Thread.Sleep(200);

            VirtualAssistant.EvaWrite(ConsoleColor.Yellow, "[0]");
            Console.WriteLine(" - Voltar ao MENU"); Thread.Sleep(200);

            int inputOption;

            do
            {
                VirtualAssistant.EvaWrite("Digite a opção desejada: ");
                inputOption = int.Parse(Console.ReadLine());
                switch (inputOption)
                {
                    case 1:
                        DoWithdraw();
                        break;
                    case 2:
                        DoDeposit();
                        break;
                    case 3:
                        DoTransfer();
                        break;
                    case 0:
                        SystemServices.ShowMainMenu();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, escolha uma opção de 0 a 3");
                        break;
                }
            } while (inputOption != 0);
        }

        private static void DoWithdraw()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.withdraw, 7, ConsoleColor.DarkBlue);

            VirtualAssistant.EvaWrite("Digite o CPF do usuário que deseja realizar Saque: ");
            string cpfWithdraw = Console.ReadLine();

            VirtualAssistant.EvaWrite("Digite o valor a sacar: ");
            decimal withdrawValue = decimal.Parse(Console.ReadLine());

            bool foundCpf = false;

            for (int i = 0; i < User.cpf.Count(); i++)
            {
                if (User.cpf[i] == cpfWithdraw)
                {
                    foundCpf = true;

                    if (withdrawValue > User.balance[i])
                    {
                        VirtualAssistant.EvaWrite(ConsoleColor.Red, "Não é possivel sacar, pois você não tem esse valor em conta");
                        Console.WriteLine($"Valor atual da conta: {User.balance[i]:F2}");

                        break;
                    } else if (User.balance[i] >= withdrawValue)
                    {
                        User.balance[i] -= withdrawValue;

                        Console.WriteLine($"\nValor sacado: {withdrawValue:F2}");
                        Console.WriteLine($"Valor atual da conta: {User.balance[i]:F2}");

                        break;

                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {User.balance[i]:F2}\n");
                        break;

                    }
                }
            }

            if (foundCpf == false)
            {
                VirtualAssistant.EvaWrite(ConsoleColor.Red, "Não encontrei nenhum usuário com esse CPF.");

                Thread.Sleep(1000);
            }

            SystemServices.ShowSubMenu();
        }

        private static void DoDeposit()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.deposit, 7, ConsoleColor.DarkBlue);

            VirtualAssistant.EvaWrite("Digite o CPF do cliente que deseja realizar o deposito: ");
            string userCpf = Console.ReadLine();

            Console.Write("Digite o valor a depositar: ");
            decimal depositValue = decimal.Parse(Console.ReadLine());

            bool foundCpf = false;

            for (int i = 0; i < User.cpf.Count(); i++)
            {
                if (User.cpf[i] == userCpf)
                {
                    foundCpf = true;

                    if (depositValue > 0)
                    {
                        User.balance[i] += depositValue;

                        Console.WriteLine($"Valor depositado: {depositValue:F2}");
                        Console.WriteLine($"Valor atual da conta: {User.balance[i]:F2}");

                    } else
                    {
                        VirtualAssistant.EvaWrite(ConsoleColor.Red, "Não é possível depositar um valor menor ou igual a R$ 0,00\n");
                    }
                }
            }

            if (foundCpf == true)
            {
                VirtualAssistant.EvaWrite(ConsoleColor.DarkYellow, "Conta não encontrad.\n");

                Thread.Sleep(1000);
            }

            SystemServices.ShowSubMenu();
        }

        private static void DoTransfer()
        {
            Console.Clear();

            Animate.ShowBanner(ASCII.transfer, 7, ConsoleColor.DarkBlue);

            decimal balanceTransfer = 0.00m;
            decimal balanceReceive = 0.00m;

            Console.Write("Digite o valor a transferir: ");
            decimal valueToTransfer = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o CPF do usuário que vai realizar a transferência: ");
            string cpfTransfer = Console.ReadLine();

            Console.Write("Digite o CPF do usuário que vai receber a transferência: ");
            string cpfReceive = Console.ReadLine();

            for (int i = 0; i < User.cpf.Count(); i++)
            {
                if (User.cpf[i] == cpfTransfer)
                {
                    User.balance[i] -= valueToTransfer;
                } else if (User.cpf[i] == cpfReceive)
                {
                    User.balance[i] += valueToTransfer;
                }
            }

            Animate.LoadBar();
            VirtualAssistant.EvaWrite(ConsoleColor.Green, $"Transferência de R$ {valueToTransfer:F2} realizada com sucesso!\n");

            Thread.Sleep(1000);

            SystemServices.ShowSubMenu();
        }

        public static void ShowTotalBankBalance()
        {
            decimal totalBankBalance = 0.0m;

            for (int i = 0; i < User.balance.Count(); i++)
            {
                totalBankBalance += User.balance[i];
            }

            VirtualAssistant.EvaWrite("O montante total depositado no sistema da ByteBank é de ");
            VirtualAssistant.EvaWrite(ConsoleColor.Green, $"R$ {totalBankBalance:F2}\n");

            SystemServices.ShowSubMenu();
        }
    }
}
