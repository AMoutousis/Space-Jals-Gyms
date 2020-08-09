using System;

namespace Space_JALS_Gyms
{
    class Program
    {
        static void Main(string[] args)
        {
            ClubController cc = new ClubController();

            cc.WriteClubInfoToList();
            cc.WelcomeToGym();

        }
    }
}
