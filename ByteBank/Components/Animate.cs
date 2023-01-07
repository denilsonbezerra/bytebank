namespace ByteBank.Components
{

    public class Animate
    {

        public static void ShowBanner(string ascii, int height, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            string[] asciiLine = ascii.Split(Environment.NewLine);

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(asciiLine[i]);
                Thread.Sleep(100 - i * (height / 3));
            }

            Console.ResetColor();
        }

        public static void LoadPoints()
        {

            for (int i = 0; i < 3; i++)
            {

                Console.Write(".");
                Thread.Sleep(1000);

            }

            Console.SetCursorPosition(0, Console.CursorTop); Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);

        }

        public static void LoadBar()
        {

            int loadBar = 25;

            Console.WriteLine("\n");

            for (int i = 0; i <= 25; i++)
            {

                Console.Write($"Realizando operação: {new string('\u2588', i)}{new string(' ', loadBar - i)}{i * 4}%");
                Thread.Sleep(100);

                Console.SetCursorPosition(0, Console.CursorTop); Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);

            }

        }

    }

}
