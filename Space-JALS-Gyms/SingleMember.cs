using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{
    class SingleMember : Member
    {
        //Constructor
        public SingleMember()
        {

        }
        public SingleMember(int ID, string firstName, string lastName) : base(ID, firstName, lastName)
        {
        }
        //Methods
        public override void PrintInfo()
        {
            Console.WriteLine($"ID: {MemberID}");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
        }
        public override void CheckIn(Club club, int MemberID)
        {
            //club.ID
            if (club.ClubID == 100 && MemberID >= 1 && MemberID < 100)
            {
                Console.WriteLine($"Welcome to your club. Sector - {club.Name}");
            }
            else if (club.ClubID == 200 && MemberID >= 100 && MemberID < 200)
            {
                Console.WriteLine($"Welcome to your club. Sector - {club.Name}");
            }
            else if (club.ClubID == 300 && MemberID >= 200 && MemberID < 300)
            {
                Console.WriteLine($"Welcome to your club. Sector - {club.Name}");
            }
            else if (club.ClubID == 400 && MemberID >= 300 && MemberID < 400)
            {
                Console.WriteLine($"Welcome to your club. Sector - {club.Name}");
            }
            else if (club.ClubID == 500 && MemberID >= 400 && MemberID < 500)
            {
                Console.WriteLine($"Welcome to your club. Sector - {club.Name}");
            }
            else if (club.ClubID == 600 && MemberID >= 500 && MemberID < 600)
            {
                Console.WriteLine($"Welcome to your club. Sector - {club.Name}");
            }
            else
            {
                Console.WriteLine("Go home");
            }
        }
    }
}
