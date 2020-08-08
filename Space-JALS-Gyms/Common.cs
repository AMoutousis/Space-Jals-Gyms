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
    }
}
