using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Space_JALS_Gyms
{
//    Override Checkin(Club club)
//Check if member is allowed to check in to specific club.Spoiler they will.
//Void PointCheck()
//Check how many points the member has.Add points on check in.
//Override PrintInfo()
//Print member info
//fName
//lName

    class MultiMember : Member
    {
        #region Properties
        //public int MemberPoints { get; set; }
        #endregion

        #region Constructors
        public MultiMember() { }
        public MultiMember(int memberID, string fName, string lName, int memberFees, bool paidBill, int memberPoints) : base (memberID, fName, lName, memberFees, paidBill, memberPoints)
        {
        }
        #endregion

        #region Methods
        public override void CheckIn(Club club, int memberID)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Access Granted!");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Welcome to Space JALS: Sector - {club.Name}!");
            IncreaseMemberPoints(memberID);
            Console.WriteLine(MemberPoints);

        }
        public override void PrintInfo()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            if (PaidBill == false)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Balance: {MemberFees} Star Specks");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No current balance.");
                Console.ResetColor();
            }
            Console.WriteLine();
            //CheckPoints();
        }


        public void IncreaseMemberPoints(int memberID)
        {
            int points = 0;
            Console.WriteLine($"Current JALS Gorgals: {MemberPoints}");

            points = CheckPoints(memberID);
            points++;

            MemberPoints = points;

            Console.WriteLine($"Current JALS Gorgals: {MemberPoints}");

        }
        public int CheckPoints(int memberID)
        {
            int points = 0;

            foreach (Member member in ClubController.MemberInfo)
            {
                if (member.MemberID == memberID)
                {
                    points = member.MemberPoints;
                    break;
                }
            }

            Console.WriteLine($"Current JALS Gorgals: {points}");

            return points;
        }
        #endregion
    }
}
