
int betAmount; // variable that stores the value of the bet made by player
int balance = 1000; // balance that player starts off with and can bet with.
int playButton; // lets player choose between 1(rules) or 2(casino)
int num01; // variable to add the randomly generated cards to cardDraw list
int playerCards = 2; // the first 2 cards draw by player, this is always guarunteed
int hit = 2; // incremented value for however many times the player wants to hit. Player can only hit up till 4 cards
int hitOrStand; // allows the player the option to hit(draw a card) or stand(end turn)
int cardChoices = 2; // allows player to make upto 4 choices with their cards. Any more than that and the loop will shut off as the limit to the players cards is 4
int grandtotal = 0; // calculates the grandtotal of all the players randomly generated cards
int cardcoins = 0; // increments per draw and acts as a throwaway variable that does almost the same function as cardChoices
string enter; // placeholder string to clear the program without any bugs
int playertotal = 0; // the total of the player in each progression, every hit will cumulatively be added to this, and the end of the turn will be calculated by grandTotal
int dealerCards = 2; // same as playerCards but for the dealer, as to not mix up and cause confusion
int dealertotal = 0; // same as playertotal but for the dealer, as to not mix up and cause confusion
bool grandTotalSwitch = true; // acts as a way for me to set cardChoices to 4, to stop the loop, while still not displaying the grandtotal. The reason for this is because when one busts their grand total is 0 and I do not want to display their full grandtotal.
int num02; // same function as num01 but for dealer, as to not mix up and cause confusion

// gives user option to see rules or to play game, uses variable playButton to get answer.
Console.WriteLine("Welcome to BlackJack!, press 1 for rules or press 2 to play!");
playButton = Convert.ToInt32(Console.ReadLine());

if (playButton == 1) // just gives rules.
{
    Console.WriteLine("\nIn blackjack, players attempt to reach a score of 21—without exceeding it—before the dealer hits 17. You can win if you don't bust(go over 21) and your total is higher than the dealer cards. Hitting exactly 21 can mean even bigger winnings.");

} else if (playButton == 2) // sets off the game sequence
{     
    Console.Clear(); // clears previous prompt

            List<int> cardDraw = new List<int>();

    while (balance != 0)
    {
        Console.Write("How much would you like to bet?");
        Console.Write("\t\t\t\t\t\t\t\t\tYour balance: " + balance + "\n"); // displays balance on top-right corner
        betAmount = Convert.ToInt32(Console.ReadLine()); // reads the bet amount

    if (betAmount <= balance)
    {
            balance = balance - betAmount;
            Console.Clear();
            Console.Write("\t\t\t\t\t\t\t\t\t\t\t\tYour balance: " + balance + "\n");

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
        if (cardDraw[0] == cardDraw [1] && cardDraw[0] + cardDraw[1] <= 11 && cardDraw[0] + cardDraw[1] >= 9)
        {
             Console.WriteLine("1) hit  ||  2) stand  ||  3) Double  ||  4) Split"); // gives user the basic blackjack options
             hitOrStand = Convert.ToInt32(Console.ReadLine()); // reads the corresponding NUMBER to the action user wants to do
        } 
        else if (cardDraw[0] + cardDraw[1] <= 11 && cardDraw[0] + cardDraw[1] >= 9)
        {
            Console.WriteLine("1) hit  ||  2) stand  ||  3) Double");
            hitOrStand = Convert.ToInt32(Console.ReadLine()); // reads the corresponding NUMBER to the action user wants to do
        } 
        else if (cardDraw[0] == cardDraw [1])
        {
            Console.WriteLine("1) hit  ||  2) stand  ||  4) split");
            hitOrStand = Convert.ToInt32(Console.ReadLine()); // reads the corresponding NUMBER to the action user wants to do
        } 
        else 
        {
             Console.WriteLine("1) hit  ||  2) stand  ");
             hitOrStand = Convert.ToInt32(Console.ReadLine()); // reads the corresponding NUMBER to the action user wants to do
        }
        if (hitOrStand == 1) // hit
        {
            Console.Clear();
            Console.Write("\t\t\t\t\t\t\t\t\t\t\t\tYour balance: " + balance + "\n");
            cardChoices++; // increments card choices, so player cant hit over 4
            hit++; // increments hit so user can draw another card
            cardcoins++; // increments because its a throwaway variable that does the same as cardchoices

             for (int i = 0; i < hit; i++) // draw card
             {
                Random numberGen = new Random();
                num01 = numberGen.Next(1 ,11);
                cardDraw.Add(num01);
                Console.WriteLine($" ___\n|   |\n| {cardDraw[i]} |\n|___|");
             } 

               for (int i = 0; i < cardcoins; i++) // counts cards for the bust feature and the blackjack feature
            {
                playertotal += cardDraw[i];
            }

        if (playertotal < 21) // does nothing, user can go again
        {
            
        } else if (playertotal == 21) // blackjack! ends the loop immediatly as user hit 21
        {
            Console.WriteLine("Blackjack!");
            cardChoices = 4;
        } else  // bust. ends loop immediatly as user busted.
        {
            Console.WriteLine("You busted. Your grandtotal is 0");
            cardChoices = 5;
            grandTotalSwitch = false;
        }
            playertotal = 0; // resets total as to not stack playertotal values in loop
        }

        else if (hitOrStand == 2) // stand, counts the total value of the cards
        {
            grandtotal = 0; // resets grandtotal

            for (int i = 0; i < cardcoins; i++) // counts value
            {
                grandtotal = grandtotal + cardDraw[i];
            }

            Console.WriteLine("You stand. You end your turn with a grand total of: " + grandtotal);
            cardChoices = 4;
            grandTotalSwitch = false; // bool turns false as to not trigger the count for 4 cards

        } else if (hitOrStand == 3)
        {
            betAmount *= 2;
            Console.WriteLine("Your bet has doubled. Your new bet amount is: " + betAmount + "\nPress enter to continue the game.");
            enter = Console.ReadLine();
            
            Console.Clear();

        Console.WriteLine("You drew:");
        for (int i = 0; i < hit; i++)
        {
           Console.WriteLine($" ___\n|   |\n| {cardDraw[i]} |\n|___|");
        }
        hitOrStand = 1;
        }
        else 
        {
            Console.WriteLine("You have chosen an invalid option"); 
        }
        }
        if (cardcoins == 4 && grandTotalSwitch == true || cardChoices == 4 && grandTotalSwitch == true)
        {
            for (int i = 0; i < cardcoins; i++)
            {
                grandtotal += cardDraw[i];
            }
            Console.WriteLine("Your grand total is " + grandtotal);
        }

        Console.WriteLine("Press enter to continue");
        enter = Console.ReadLine();
        //                  -----------------------------DEALER-TURN-------------------

        Console.Clear();
        Console.WriteLine("It is now the dealers turn");
        hit = 2;
        cardChoices = 2;
        cardcoins = 0;

        List<int> dealerDraw = new List<int>();

        for (int i = 0; i < dealerCards; i++)
        {
            Random numGen = new Random();
            num02 = numGen.Next(1,11);
            dealerDraw.Add(num02);
        }

        Console.WriteLine("\nThe dealer drew:");
        for (int i = 0; i < hit; i++)
        {
           Console.WriteLine($" ___\n|   |\n| {dealerDraw[i]} |\n|___|");
           cardcoins++;
        }

        for (int i = 0; i < cardcoins; i++)
            {
                dealertotal += dealerDraw[i];
            }

        while (dealertotal < 17 && cardChoices != 4)
        {
            dealerCards++;
            hit++;

            for (int i = 2; i < hit; i++)
             {
                Random numberGen = new Random();
                num02 = numberGen.Next(1,11);
                dealerDraw.Add(num02);
                Console.WriteLine($" ___\n|   |\n| {dealerDraw[i]} |\n|___|");
                cardcoins++;
             } 

             

            for (int i = 0; i < cardcoins; i++)
            {
                dealertotal += dealerDraw[i];
            }

            if (dealertotal > 21)
            {
                Console.WriteLine("The dealer busted! The dealers grand total is now 0");
                cardChoices = 4;
                dealertotal = 0;
            } 
            else if (dealertotal == 21)
            {
                Console.WriteLine("The dealer got a blackjack!");
                cardChoices = 4;
            }

            dealertotal = 0;

        }
        Console.WriteLine("The dealers total is: " + dealertotal + "\n\nPress enter to continue");
        enter = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Your total: " + grandtotal);
        Console.WriteLine("Dealer total: " + dealertotal);
        if (grandtotal > dealertotal)
        {
            betAmount  *= 2;
            Console.WriteLine("\nCongrats you won! Here is your winnings: +" + betAmount);
            balance += betAmount;
            Console.WriteLine("Your Balance: " + balance);
        } 
        else if (grandtotal == dealertotal)
        {
            balance += betAmount;
            Console.WriteLine("\nPush. You get your bet back: +" + betAmount);
            Console.WriteLine("Your Balance: " + balance);
        } 
        else 
        {
            balance = 1000;
            balance -= betAmount;
            Console.WriteLine("\nYou lost. You lose your bet amount: -" + betAmount);
            Console.WriteLine("Your Balance: " + balance);
        }
        
        Console.WriteLine("Please press enter if you would like to continue");
        enter = Console.ReadLine();

        for (int i = 0; i < cardDraw.Count; i++)
        {
            cardDraw.RemoveAt(i);
        }
        
         playertotal = 0; // the total of the player in each progression, every hit will cumulatively be added to this, and the end of the turn will be calculated by grandTotal
         dealerCards = 2;
         dealertotal = 0;
         hit = 2;
        cardChoices = 2;
        cardcoins = 0;

        Console.Clear();
        

    }else 
    {
        Console.WriteLine("You cannot bet more than you have."); // prevents user from betting more than their balance
    }

    }   
    
    
}

Console.ReadKey();
