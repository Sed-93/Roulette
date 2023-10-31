/*using System;
using static System.Console;

// Totala Saldo att börja med
int balance = 1000;
// Välkomnar till spelet 
WriteLine("Välkommen till Grupp 2 Roulett-spel!");
//Förklarar nuvarande saldo 
WriteLine($"Ditt nuvarande Saldo är: ${balance}");

// Om saldot är över $0 ber consolen om ett nummer mellan 0-36 
while (balance > 0)
{
    Write("Vänligen välj ett nummer mellan 0 och 36: ");
    int selectedNumber = int.Parse(ReadLine());
    
    // Om nummer är minder än noll alltså -1 eller högre än 36 säger consolen ifrån 
    if (selectedNumber < 0 || selectedNumber > 36)
    {
        WriteLine("Felaktigt nummer. Välj ett nummer mellan 0 och 36.");
        break;
    }
    // Consolen ber spelaren om hur mycket man vill satsa
    Write("Placera din satsning: $");
    int betAmount = int.Parse(ReadLine());
    // Om du inte har tillräckligt med saldo kommer consolen att säga ifrån och inte låta dig spela
    if (betAmount > balance)
    {
        WriteLine("Tyvärr! du har inte tillräckligt med saldo för denna satsning.");
        break;
    }

        // Genererar ett random nummer som ger vinst
    Random random = new Random();
    int winNumber = random.Next(0,37);

    //If sats kollar om det blev vinst
    if (selectedNumber == winNumber)
    {   
        //Beräknar vinsten
        int winAmount = betAmount * 35;
        WriteLine($"Grattis du vann{winAmount}$!");

        //Lägger till vinsten till saldot
        balance += winAmount; 
        WriteLine($"Ditt nya saldo är: {balance}$");
    }
        //Om det inte blir vinst
    else
    {
        WriteLine("Tyvärr det blev ingen vinst denna gång!");

        //Tar bort förlusten från saldot 
        balance -= betAmount; 
    }

        WriteLine($"Ditt nya saldo är: {balance}$");
     // Alternativ att spela spel med färg
   

    while (true)
    {
        Console.WriteLine($"Your balance: ${balance}");
        Console.Write("Enter your bet (red/black): ");
        string bet = Console.ReadLine().ToLower();

        if (bet != "red" && bet != "black")
        {
            Console.WriteLine("Invalid bet. Choose red or black.");
            continue;
        }

        Console.Write("Enter your bet amount: $");
        if (!int.TryParse(Console.ReadLine(), out int rouletteBetAmount) || rouletteBetAmount <= 0 || rouletteBetAmount > balance)
        {
            Console.WriteLine("Invalid bet amount.");
            continue;
        }

        int winningNumber = new Random().Next(0, 36);
        bool isRed = (winningNumber > 0 && winningNumber <= 10) || (winningNumber > 18 && winningNumber <= 28);
        bool isBlack = !isRed;

        Console.WriteLine($"The winning number is {winningNumber}.");
        Console.WriteLine(isRed ? "Red" : "Black");

        if ((bet == "red" && isRed) || (bet == "black" && isBlack))
        {
            balance += rouletteBetAmount;
            Console.WriteLine($"You win ${rouletteBetAmount}!");
        }
        else
        {
            balance -= rouletteBetAmount;
            Console.WriteLine($"You lose ${rouletteBetAmount}.");
        }
    }

    Console.WriteLine("Game over. Your balance is $0.");
    Console.Write("Play again? (yes/no): ");
    string playAgain = Console.ReadLine().ToLower();
    if (playAgain != "yes")
    {
        break;
    }


Console.WriteLine("Thanks for playing!");
}




*/




/*
/*
using System;
using System.Threading;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine("Välkommen till Grupp 2 Roulett-spel!");

        Thread.Sleep(2000);

        WriteLine("Vänligen skriv hur mycket du vill sätta in på din Konto!: "); 
        int balance = int.Parse(ReadLine());

        WriteLine($"Ditt nuvarande Saldo är: ${balance}");

        Thread.Sleep(2000);

        while (balance > 0)
        {
            Write("Vänligen välj för att spela: slump, udda, jemt, svart eller red:  ---- för att logga ut tryck 0: ");
            string selected = Console.ReadLine().ToLower();

            if (selected == "0")
            {
                return;
            }

            if (selected != "jemt" && selected != "udda" && selected != "red" && selected != "svart" && selected != "slump")
            {
                WriteLine("Ogiltigt val. Välj 'jemt', 'udda', 'red', 'svart' eller 'slump'.");
                continue;
            }

            Write("Placera din satsning: $");
            int betAmount = int.Parse(ReadLine());

            if (betAmount > balance)
            {
                WriteLine("Tyvärr! du har inte tillräckligt med saldo för denna satsning.");
                continue;
            }

            Random random = new Random();
            int winNumber = random.Next(0, 37);

            if (selected == "slump")
            {
                Write("Ange ditt eget nummer (0-36): ");
                int slump = int.Parse(Console.ReadLine());

                if (slump < 0 || slump > 36)
                {
                    WriteLine("Ogiltigt nummer. Välj ett nummer mellan 0 och 36.");
                    continue;
                }
            }


            string winColor = (winNumber == 0 || (winNumber >= 11 && winNumber <= 18) || (winNumber >= 29 && winNumber <= 36)) ? "svart" : "red";

            Thread.Sleep(2000);

            if (selected == "slump" && betAmount == winNumber)
            {
            
                int winAmount = betAmount * 35;
                WriteLine($"Grattis! Du vann {winAmount}$ vinnande {winNumber} ({winColor}).");
                balance += winAmount;
            }
            else if (selected != "slump" && int.TryParse(selected, out int selectedNumber) && selectedNumber == winNumber)
            {
                
                int winAmount = betAmount * 35;
                WriteLine($"Grattis! Du vann {winAmount}$ vinnade {winNumber} ({winColor}).");
                balance += winAmount;
            }
            else if ((selected == "red" || selected == "svart") && selected == winColor)
            {
                int winAmount = betAmount * 2;
                WriteLine($"Grattis! Du vann på färgen {winColor} ({winNumber}).");
                balance += betAmount;
            }
            else if ((selected == "jemt" || selected == "udda") && ((selected == "jemt" && winNumber % 2 == 0) || (selected == "udda" && winNumber % 2 == 1)))
            {
                WriteLine($"Grattis! Du vann på {selected} ({winNumber} - {winColor}).");
                balance += betAmount;
            }

           

            else
            {
                 Thread.Sleep(2000);

                WriteLine($"Tyvärr, du förlorade {betAmount}$ vinnande nummer {winNumber} ({winColor}).");
                balance -= betAmount;
            }

            WriteLine($"Ditt saldo är: ${balance}");


        if (balance == 0)
        {
            Write("Spela igen? (ja/nej): ");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain == "ja")
            {
                return;
            }
            else if (playAgain == "nej"){
                break;
            }
            WriteLine("Tack för att du spelade !");

        }

        WriteLine("Fyll på ditt konto $0.");


        }
    }
}*/
// Ivy code : jag lägga till Switch meny baserad på Senat code:





using System;
using System.Threading;
using static System.Console;

class Program
{
    static void Main()
    {
        While (true) { 
        WriteLine("Välkommen till Grupp 2 Roulett-spel!");

        Thread.Sleep(2000);

        WriteLine("Vänligen skriv hur mycket du vill sätta in på din Konto!: ");
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

                if (playAgain == "ja")
                {
                    return;
                }
                else if (playAgain == "nej")
                {
                    break;
                }
                WriteLine("Tack för att du spelade !");
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

        if (selected == "slump")
        {
            Write("Ange ditt eget nummer (0-36): ");
            int slump = int.Parse(Console.ReadLine());

            if (slump < 0 || slump > 36)
            {
                WriteLine("Ogiltigt nummer. Välj ett nummer mellan 0 och 36.");
                return;
            }
        }

        string winColor = (winNumber == 0 || (winNumber >= 11 && winNumber <= 18) || (winNumber >= 29 && winNumber <= 36)) ? "svart" : "red";

        Thread.Sleep(2000);

        if ((selected == "slump" && betAmount == winNumber) ||
            (selected != "slump" && int.TryParse(selected, out int selectedNumber) && selectedNumber == winNumber))
        {
            int winAmount = betAmount * 35;
            WriteLine($"Grattis! Du vann {winAmount}$ vinnande {winNumber} ({winColor}).");
            balance += winAmount;
            WriteLine($"Ditt saldo är: ${balance}");
        }
        else if ((selected == "red" || selected == "svart") && selected == winColor)
        {
            int winAmount = betAmount * 2;
            WriteLine($"Grattis! Du vann på färgen {winColor} ({winNumber}).");
            balance += betAmount;
            WriteLine($"Ditt saldo är: ${balance}");
        }
        else if ((selected == "jemt" || selected == "udda") && ((selected == "jemt" && winNumber % 2 == 0) || (selected == "udda" && winNumber % 2 == 1)))
        {
            WriteLine($"Grattis! Du vann på {selected} ({winNumber} - {winColor}).");
            balance += betAmount;
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

