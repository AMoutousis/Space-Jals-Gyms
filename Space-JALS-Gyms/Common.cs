using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{
    // This class will contain all the common methods that can be used by any class anytime as required
    // For the sake of clarity, they can be grouped as Console Methods, Calcuation Method etc as required
    public static class Common
    {
        #region Console Methods
        // This method will display the message parameter to the console.
        // It will then return the user input to the calling method
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        #endregion
        
        public static string YesNoChecker(string input)
        {
            string input1 = Console.ReadLine().ToLower();
            while (input1 != "y" && input1 != "n")
            {
                Console.Write("Invalid input. Please enter either \"y\" or \"n\": ");
                input1 = Console.ReadLine();
            }
            return input1;
        }

        public static int CheckNumber(string input, bool rangeCheck, int num)
        {
            int validNumber = 0;
            bool invalid = true;
            while (invalid)
            {
                try
                {
                    validNumber = int.Parse(input);
                    if (rangeCheck)
                    {
                        if (validNumber > 0 && validNumber <= num)
                        {
                            invalid = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have angered the Chickens of Space! I said enter a number from 1-" + num + ".");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Please try again: ");
                            Console.ResetColor();
                            input = Console.ReadLine();
                        }
                    }
                    else
                    {
                        invalid = false;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have angered the Chickens of Space! I said enter a number.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Please try again: ");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }
            return validNumber;
        }
        public static string CheckMemberStatus(int ID)
        {
            string status = "";

            if (ID > 0 && ID < 600)
            {
                status = "Single";
            }
            else if (ID > 5000)
            {
                status = "Multi";
            }
            else
            {
                Console.WriteLine("You are not a member, brah");
                Console.WriteLine("Join or get space gainzz somewhere else!");
                Console.WriteLine("or else...");
            }

            return status;

        }
    }
}
