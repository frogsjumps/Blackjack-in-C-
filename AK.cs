using System.ComponentModel;
using System.Security.Cryptography;

int betnumber;
int balance = 1000;
int playButton;
int num01;
int playerCards = 2;
int hit = 2;
int hitOrStand;
int cardChoices = 2;
int grandtotal = 0;
int cardcoins = 0;
string enter;
int playertotal = 0;

Console.WriteLine("Welcome to BlackJack!, press 1 for rules or press 2 to play!");
playButton = Convert.ToInt32(Console.ReadLine());

if (playButton == 1)
{
    Console.WriteLine("\nIn blackjack, players attempt to reach a score of 21—without exceeding it—before the dealer hits 17. You can win if you don't bust(go over 21) and your total is higher than the dealer cards. Hitting exactly 21 can mean even bigger winnings.");
} else if (playButton == 2)
{     
    Console.Clear();
    //while (balance != 0)
    //{
        Console.Write("How much would you like to bet?");
        Console.Write("\t\t\t\t\t\t\t\t\tYour balance: " + balance + "\n");
        betnumber = Convert.ToInt32(Console.ReadLine());
    if (betnumber <= balance)
    {
            balance = balance - betnumber;
            Console.Clear();
            Console.Write("\t\t\t\t\t\t\t\t\t\t\t\tYour balance: " + balance + "\n");
            
            List<int> cardDraw = new List<int>();

        for (int i = 0; i <= playerCards; i++)
        {
            Random numberGen = new Random();
            num01 = numberGen.Next(1,11);
            cardDraw.Add(num01);
        }
        Console.WriteLine("You drew:");
        for (int i = 0; i < hit; i++)
        {
           Console.WriteLine($" ___\n|   |\n| {cardDraw[i]} |\n|___|");
           cardcoins++;
        }

        while (cardChoices < 4)
        {
        Console.WriteLine("Would you like to 1) hit or 2) stand ");
        hitOrStand = Convert.ToInt32(Console.ReadLine());
        if (hitOrStand == 1)
        {
            Console.Clear();
            cardChoices++;
            hit++;
            cardcoins++;
             for (int i = 0; i < hit; i++)
             {
                Random numberGen = new Random();
                num01 = numberGen.Next(1,11);
                cardDraw.Add(num01);
                Console.WriteLine($" ___\n|   |\n| {cardDraw[i]} |\n|___|");
             } 

               for (int i = 0; i < cardcoins; i++)
            {
                playertotal += cardDraw[i];
            }

        if (playertotal < 21)
        {
            
        } else if (playertotal == 21)
        {
            Console.WriteLine("Blackjack!");
            cardChoices = 4;
        } else 
        {
            Console.WriteLine("You busted");
            cardChoices = 4;
        }
            
        }

        else if (hitOrStand == 2)
        {
            for (int i = 0; i < cardcoins; i++)
            {
                grandtotal = grandtotal + cardDraw[i];
            }
            Console.WriteLine("You stand. You end your turn with a grand total of: " + grandtotal);
            cardChoices = 4;
        } else 
        {
            Console.WriteLine("You have chosen an invalid option"); 
        }
        }
        if (cardcoins == 4)
        {
            for (int i = 0; i < cardcoins; i++)
            {
                grandtotal += cardDraw[i];
            }
            Console.WriteLine("Your grand total is " + grandtotal);
        }
        Console.WriteLine("Press enter to continue");
        enter = Console.ReadLine();

        Console.Clear();
    }else 
    {
        Console.WriteLine("You cannot bet more than you have.");
    }
        
    
    
}

Console.ReadKey();





