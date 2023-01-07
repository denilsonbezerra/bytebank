namespace ByteBank.Components
{

    public class VirtualAssistant
    {

        public static void EvaWrite(string text)
        {
            Random randomicTime = new Random();

            foreach (char character in text)
            {
                int outputSpeed = randomicTime.Next(100);

                Console.Write(character);

                if (outputSpeed % 10 == 0)
                {
                    outputSpeed = randomicTime.Next(120);
                    Thread.Sleep(outputSpeed);
                } else
                {
                    Thread.Sleep(outputSpeed);
                }
            }
        }

        public static void EvaWrite(ConsoleColor color, string text)
        {
            Random randomicTime = new Random();

            Console.ForegroundColor = color;

            foreach (char character in text)
            {

                int outputSpeed = randomicTime.Next(100);

                Console.Write(character);

                if (outputSpeed % 10 == 0)
                {

                    outputSpeed = randomicTime.Next(120);
                    Thread.Sleep(outputSpeed);

                } else Thread.Sleep(outputSpeed);

            }

            Console.ResetColor();
        }

    }

}
