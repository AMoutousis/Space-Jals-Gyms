using System;

namespace Space_JALS_Gyms
{
    class Program
    {
        public static int CurrentClub;
        public static int clubLocationIndex;
        static void Main(string[] args)
        {
            ClubController cc = new ClubController();

            cc.ReadFromFile();
            cc.WriteClubInfoToList();
            CurrentClub = cc.InitializeClubLocation(out clubLocationIndex);
            cc.WelcomeToGym();

        }
    }
}
