using System;
using System.Threading;
using static System.Console;

class Program
{
    static void Main()
    {
        while (true) { 
        WriteLine("Välkommen till Grupp 2 Roulett-spel!");

        Thread.Sleep(2000);

        WriteLine("Vänligen skriv hur mycket du vill sätta in på ditt Konto!: ");
        int balance = int.Parse(ReadLine());

        WriteLine($"Ditt nuvarande Saldo är: ${balance}");

        Thread.Sleep(2000);

        while (balance > 0)
        {
            Write("Vänligen välj för att spela: \n" +
                  "1. Slump\n" +
                  "2. Udda\n" +
                  "3. Jemt\n" +
                  "4. Svart\n" +
                  "5. Red\n" +
                  "0. Logga ut\n" +
                  "Ditt val: ");
            int choice = int.Parse(ReadLine());

            switch (choice)
            {
                case 0:
                    return;

                case 1:
                    PlayRoulette("slump", ref balance);
                    break;

                case 2:
                    PlayRoulette("udda",ref balance);
                    break;

                case 3:
                    PlayRoulette("jemt", ref balance);
                    break;

                case 4:
                    PlayRoulette("svart", ref balance);
                    break;

                case 5:
                    PlayRoulette("red", ref balance);
                    break;

                default:
                    WriteLine("Ogiltigt val. Välj ett nummer mellan 0 och 5.");
                    break;
            }

        //    WriteLine($"Ditt saldo är: ${balance}");

            if (balance == 0)
            {
                Write("Spela igen? (ja/nej): ");
                string playAgain = Console.ReadLine().ToLower();

                if (playAgain == "nej")
                {
                    WriteLine("Tack för att du spelade !");
                    return;  //exit hela program
                }
                else if (playAgain == "ja")
                {
                    break;// börja om spel meny
                }
        
            }

           // WriteLine("Fyll på ditt konto $0.");
        }
    }

    static void PlayRoulette(string selected,ref int balance)
    {
        Write($"Placera din satsning för {selected}: $");
        int betAmount = int.Parse(ReadLine());

        if (betAmount > balance)
        {
            WriteLine("Tyvärr! Du har inte tillräckligt med saldo för denna satsning.");
            return;
        }

        Random random = new Random();
        int winNumber = random.Next(0, 37);
        int slump = -1; 
    // deklarerar slump variable ,säkerställer att `slump` har ett känt värde innan man försöker läsa från input 
        if (selected == "slump")
            {
                Write("Ange ditt eget nummer (0-36): ");
                if (!int.TryParse(ReadLine(), out slump) || slump < 0 || slump > 36)
                {
                    WriteLine("Ogiltigt nummer. Välj ett nummer mellan 0 och 36.");
                    return;
                }
            }
        string winColor = (winNumber == 0 || (winNumber >= 11 && winNumber <= 18) || (winNumber >= 29 && winNumber <= 36)) ? "svart" : "red";

        Thread.Sleep(2000);

        if ((selected == "slump" && slump == winNumber) )
        {
            int winAmount = betAmount * 35;
            WriteLine($"Grattis! Du vann {winAmount}$ vinnande {winNumber} ({winColor}).");
            balance += winAmount;
            WriteLine($"Ditt saldo är: ${balance}");
        }
        else if ((selected == "red" || selected == "svart") && selected == winColor)
        {
       
            WriteLine($"Grattis! Du vann på färgen {winColor} ({winNumber}).");
            balance += betAmount;
            WriteLine($"Ditt saldo är: ${balance}");
        }
        else if ((selected == "jemt" || selected == "udda") && ((selected == "jemt" && winNumber % 2 == 0) || (selected == "udda" && winNumber % 2 == 1)))
        {
            WriteLine($"Grattis! Du vann på {selected} ({winNumber} - {winColor}).");
            balance += betAmount ;
            WriteLine($"Ditt saldo är: ${balance}");
        }
        else
        {
            Thread.Sleep(2000);
            WriteLine($"Tyvärr, du förlorade {betAmount}$ vinnande nummer {winNumber} ({winColor}).");
            balance -= betAmount;
            WriteLine($"Ditt saldo är: ${balance}");
        }
    }
}
}

