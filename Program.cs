using System;
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
    }
        //Om det inte blir vinst
    else
    {
        WriteLine("Tyvärr det blev ingen vinst denna gång!");

        //Tar bort förlusten från saldot 
        balance -= betAmount; 
    }

    WriteLine($"Ditt nya saldo är: {balance}$");
}
