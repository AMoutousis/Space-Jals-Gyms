using System;
using System.Collections.Generic;
using System.Text;

namespace Space_JALS_Gyms
{
    class SingleMember
    {
        //Constructor
        public SingleMember()
        {

        }
        public SingleMember(int ID, string firstName, string lastName) : base(ID, firstName, lastName)
        {
            this.MemberID = ID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        //Methods
        public override void PrintInfo()
        {
            Console.WriteLine($"ID: {MemberID}");
            Console.WriteLine($"First Name: {FirstName}");
            Console.WriteLine($"Last Name: {LastName}");
        }
        public override void CheckIn(Club club)
        {
            //club.ID
            if (MemberID >= 1 && MemberID < 100)
            {
                Console.WriteLine(club.Earth);
            }
            else if (MemberID >= 100 && MemberID < 200)
            {
                Console.WriteLine(club.Pluto);
            }
            else if (MemberID >= 200 && MemberID < 300)
            {
                Console.WriteLine(club.Krypton);
            }
            else if (MemberID >= 300 && MemberID < 400)
            {
                Console.WriteLine(club.Mars);
            }
            else if (MemberID >= 400 && MemberID < 500)
            {
                Console.WriteLine(club.Tatooine);
            }
            else if (MemberID >= 500 && MemberID < 600)
            {
                Console.WriteLine(club.Gallifrey);
            }
            else
            {
                Console.WriteLine("This chicken is not a member at any location.");
                Console.WriteLine("Sign up or get space gains somewhere else.");
            }
        }
    }
}
