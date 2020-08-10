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
        public static List<Member> MemberInfo = new List<Member>();

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

                CheckMembership(sMember, mMember, memberID);

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
                string tempMemberID = Common.GetUserInput("Please enter your Member ID");
                int memberID = Common.CheckNumber(tempMemberID, false, 0);

                mMember.CheckPoints(memberID);
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

            int count = 1;
            foreach (Club clubSector in ClubLocations)
            {
                Console.WriteLine($"{count}. {clubSector.Name}");
                count++;
            }
            string sectorSelection = Common.GetUserInput("Please select the sector you would like to join!");
            int ID = Common.CheckNumber(sectorSelection, false, 0);

            if (int.Parse(sectorSelection) == 1)
            {
                ID = 10;

            }
            if (int.Parse(sectorSelection) == 2)
            {
                ID = 110;
            }
            if (int.Parse(sectorSelection) == 3)
            {
                ID = 210;
            }
            if (int.Parse(sectorSelection) == 4)
            {
                ID = 310;
            }
            if (int.Parse(sectorSelection) == 5)
            {
                ID = 410;
            }
            if (int.Parse(sectorSelection) == 6)
            {
                ID = 510;
            }


            WriteToFile(52, strFName, strLName, 10, true, 0);
        }
        public void RemoveMember()
        { 
        }
        public void CheckMembership(SingleMember sMember, MultiMember mMember, int memberID)
        { 
            string memberStatus = Common.CheckMemberStatus(memberID);

            if (memberStatus == "Single")
            {
                if (ClubLocations[Program.clubLocationIndex].ClubID == Program.CurrentClub)
                {
                    sMember.CheckIn(ClubLocations[Program.clubLocationIndex], memberID);
                }
                else
                {
                    Console.WriteLine("get out");
                }
            }
            else if (memberStatus == "Multi")
            {
                mMember.CheckIn(ClubLocations[Program.clubLocationIndex], memberID);
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
        public void WriteToFile(int ID, string fName, string lName, int fees, bool paidBill, int memberPoints)
        {
            MemberInfo = new List<Member>();

            string fileName = "../../../Memberinfo.txt";
            StreamWriter writer = new StreamWriter(fileName, true); //need to pass (x,true) in order to write to the end of file and not overwrite text file data

            writer.WriteLine($"{ID}|{fName}|{lName}|{fees}|{paidBill}|{memberPoints}");

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

            //string[] memberInfo;

            while (line != null)
            {
                string[] memberInfo = line.Split('|');
                if (int.Parse(memberInfo[5]) == 0)
                {
                    SingleMember newMember = new SingleMember(int.Parse(memberInfo[0]), memberInfo[1], memberInfo[2], int.Parse(memberInfo[3]), bool.Parse(memberInfo[4]));
                    MemberInfo.Add(newMember);
                }
                else
                {
                    MultiMember newMember = new MultiMember(int.Parse(memberInfo[0]), memberInfo[1], memberInfo[2], int.Parse(memberInfo[3]), bool.Parse(memberInfo[4]), int.Parse(memberInfo[5]));
                    MemberInfo.Add(newMember);
                }
                line = reader.ReadLine();
            }

            reader.Close();
        
        }
        public void WriteClubInfoToList()
        {
            List<Club> cl = new List<Club>() { };

            string fileName = "../../../ClubInfo.txt";

            StreamReader reader = new StreamReader(fileName, true);

            string line = reader.ReadLine();

            while (line != null)
            {
                string[] clubInfo = line.Split('|');
                Club newClub = new Club(int.Parse(clubInfo[0]), clubInfo[1], clubInfo[2]);
                cl.Add(newClub);
                line = reader.ReadLine();
            }

            reader.Close();

            ClubLocations = cl;

        }
        public int InitializeClubLocation(out int clubIndex)
        {
            List<int> clubID = new List<int>() { };
            int count = 1;
            foreach (Club clubSector in ClubLocations)
            {
                Console.WriteLine($"{count}. {clubSector.Name}");
                clubID.Add(clubSector.ClubID);
                count++;
            }

            string sectorSelection = Common.GetUserInput("Please select the club you're currently working at.");

            int ID = Common.CheckNumber(sectorSelection, true, 6);

            int currentClubID = 0;
            clubIndex = 0;

            for (int i = 0; i < clubID.Count; i++)
            {

                if (ID-1 == i)
                {
                    currentClubID = clubID[i];
                    clubIndex = i;
                    break;
                }
            }

            return currentClubID;
        }

    }

}
