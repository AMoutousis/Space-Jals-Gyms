using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Text;


namespace Space_JALS_Gyms
{
    
    class ClubController
    {
        //all methods are set inititally set to void to avoid errors while writing code. That will change as logic is added.
        public static List<Club> ClubLocations;

        public void WelcomeToGym()
        {
            SingleMember sMember = new SingleMember();
            MultiMember mMember = new MultiMember();
            Club club = new Club();

            Console.WriteLine("Welcome to our Gym!");
            Console.WriteLine("What would you like to do?");

            Console.WriteLine("1. Check-in");
            Console.WriteLine("2. Add Member");
            Console.WriteLine("3. Remove Member");
            Console.WriteLine("4. Check Points");
            Console.WriteLine("5. Create Bill");
            Console.WriteLine("6. Quit");

            string selection = Common.GetUserInput("Please enter a number 1-6");
            int option = Common.CheckNumber(selection, true, 6);

            if (option == 1)
            {
                string tempMemberID = Common.GetUserInput("Please enter your Member ID");
                int memberID = Common.CheckNumber(tempMemberID, false, 0);

                CheckMembership(sMember, mMember, club, memberID);

            }
            else if (option == 2)
            {
                AddMember();
            }
            else if (option == 3)
            {
                RemoveMember();
            }
            else if (option == 4)
            {
                mMember.CheckPoints();
            }
            else if (option == 5)
            {
                //CreateBill();
                //need to add logic for PaidBill in Single(ladies) and Multi member classes
            }
            else if (option == 6)
            { 
                //Common.Quit();
                //need to create a method in Common that quits the program
            }



        }
        public void AddMember()
        {
            string strFName = Common.GetUserInput("Please enter First Name");
            string strLName = Common.GetUserInput("Please enter Last Name");
            int ID = 100;
            //need to add logic for the ID

            WriteToFile(ID, strFName, strLName);
        }
        public void RemoveMember()
        { 
        }
        public void CheckMembership(SingleMember sMember, MultiMember mMember, Club club, int memberID)
        { 
            string memberStatus = Common.CheckMemberStatus(memberID);
            if (memberStatus == "Single")
            {
                sMember.CheckIn(club, memberID);
            }
            else if (memberStatus == "Multi")
            {
                mMember.CheckIn(club, memberID);
            }
        }
        public void CreateBill(bool PaidBill, Member member)
        { 
            if (PaidBill == true)
            {
                Console.WriteLine("Your balance is paid. Carrey on with Space Gains.");
            }
            else
            {
                if (member.MemberID >= 100 && member.MemberID <= 600)
                {
                    Console.WriteLine("You owe 10 Star Specks.");
                }
                if (member.MemberID >= 5000)
                {
                    Console.WriteLine("You owe 25 Star Specks. *gurmble* rich chicken *grumble*");
                }
            }
        }
        public void WriteToFile(int ID, string fName, string lName)
        {
            List<string> MemberInfo = new List<string>();

            string fileName = "../../../Memberinfo.txt";
            StreamWriter writer = new StreamWriter(fileName, true); //need to pass (x,true) in order to write to the end of file and not overwrite text file data

            writer.WriteLine($"{ID}|{fName}|{lName}");

            writer.Close();


        }
        public void ReadFromFile() //string fileName
        {
            //may need logic in the future that dictates which file to read from (memberinfo or Clubinfo)
            //string fileName = "../../../ClubInfo.txt"; can uncomment for future use if needed
            string fileName = "../../../Memberinfo.txt";

            StreamReader reader = new StreamReader(fileName);
            List<string> readInfo = new List<string>();

            //currently set to read the entire file, once logic for info has been put in place, we will set up the reader to read specific lines.
            string line = reader.ReadLine();
            string[] info = System.IO.File.ReadAllLines(fileName); //reads all lines of specific text file

            reader.Close();
        
        }
        public static void WriteClubInfoToList()
        {
            List<Club> cl = new List<Club>() { };
            string[] clubInfo = new string[3];

            string fileName = "../../../Memberinfo.txt";

            StreamReader reader = new StreamReader(fileName, true);

            string line = reader.ReadLine();

            while (line != null)
            {
                clubInfo = line.Split('|');
                Club newClub = new Club(int.Parse(clubInfo[0]), clubInfo[1], clubInfo[2]);
                cl.Add(newClub);
            }

            reader.Close();

            ClubLocations = cl;

        }
        
    }

}
