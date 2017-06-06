using System;

namespace Blackjack
{
    public class Program
    {
       
        static int[] playerCards = new int[2];
        static int[] computerCards = new int[2];
        static string yesOrNo = "";
        public static string strTest = "";
        public static int playerTotal = 0;
        public static int computerTotal = 0;
        static Random cardRandomizer = new Random();

     
        static void Main(string[] args)
        {
            Console.Title = "Denz's Blackjack!";
            Console.WriteLine("Welcome to Blackjack!\n");
            Start();
        }

        static void Start()
        {
            playerCards[0] = GetCard();
            playerCards[1] = GetCard();
            playerTotal = playerCards[0] + playerCards[1];
            computerCards[0] = GetCard();
            computerCards[1] = GetCard();
            computerTotal = computerCards[0] + computerCards[1];

            do
            {
                Console.WriteLine("Your Cards: " + playerCards[0] + " " + playerCards[1] + " = " + playerTotal);
                Console.WriteLine("Computers Cards: " + computerCards[0] + " " + computerCards[1] + " = " + computerTotal);
                Console.Write("\nDo you want another card (y/n)? ");
                yesOrNo = Console.ReadLine().ToLower();
            } while (!yesOrNo.Equals("y") && !yesOrNo.Equals("n"));

            Game();
        }


        static void Game()
        {

            if (yesOrNo.Equals("y"))
            {
                Hit();
            }
            else if (yesOrNo.Equals("n"))
            {

                if (computerTotal < 17)
                {
                    while (true)
                    {
                        if (computerTotal >= 17 && computerTotal <= 21)
                        {
                            break;
                        }
                        else if (computerTotal > 21)
                        {
                            break;
                        }
                        else
                        {
                            int card = GetCard();
                            computerTotal += card;
                            Console.WriteLine("\nThe computer takes a card: " + card);
                        }
                    }
                }
            }


            ViewResults(false);

        }


        public static void ViewResults(bool uTest)
        {
            

            Console.WriteLine("\nYour score: " + playerTotal);
            Console.WriteLine("Computer score: " + computerTotal);


            if (playerTotal > computerTotal && playerTotal <= 21 || computerTotal > playerTotal && computerTotal > 21)
            {
                Console.WriteLine("\nCongrats! You won!");
                strTest = "Congrats! You won!";
            }
            else if (computerTotal > playerTotal && computerTotal <= 21 || playerTotal > computerTotal && playerTotal > 21)
            {
                Console.WriteLine("\nSorry, you lost!");
                strTest = "Sorry, you lost!";
            }
            else if (computerTotal == playerTotal)
            {
                Console.WriteLine("\nDraw!");
                strTest = "Draw!";
            }

            if (uTest) goto skip; // Skip this part when running Unit Test
            // ============================================================
            Console.Write("\nDo you want to play again (y/n)? ");
            yesOrNo = Console.ReadLine().ToLower();

            if (yesOrNo.Equals("y"))
            {
                Console.Clear();
                Start();
            }
            else if (yesOrNo.Equals("n"))
            {
                Environment.Exit(0);
            }
            // ============================================================
            skip: ;

        }


        static int GetCard()
        {
            return cardRandomizer.Next(1, 10);         
        }

       
        static void Hit()
        {

            int hit = GetCard();
            playerTotal += hit;
            Console.WriteLine("Hit: " + hit + " Your total is " + playerTotal);
         
            do
            {
                Console.Write("\nDo you want another card (y/n)? ");
                yesOrNo = Console.ReadLine().ToLower();

            } while (!yesOrNo.Equals("y") && !yesOrNo.Equals("n"));

            Game();

        }

        



    }
}
