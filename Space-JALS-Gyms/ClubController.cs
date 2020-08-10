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
        public bool lContinue = true;

        public void WelcomeToGym()
        {
            while(lContinue)
            { 
                SingleMember sMember = new SingleMember();
                MultiMember mMember = new MultiMember();
                Club club = new Club();

                Console.WriteLine($"Welcome to {ClubLocations[Program.clubLocationIndex].Name}!");
                Console.WriteLine("What would you like to do?");

                Console.WriteLine("1. Check-in");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Remove Member");
                Console.WriteLine("4. Check Points");
                Console.WriteLine("5. Create Bill");
                Console.WriteLine("6. Show Member Info");
                Console.WriteLine("7. Quit");

                
                string selection = Common.GetUserInput("Please enter a number 1-7");
                int option = Common.CheckNumber(selection, true, 7);

                bool validID = true;


                if (option == 1)
                {
                    string tempMemberID = Common.GetUserInput("Please enter your Member ID");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);

                    Common.CheckMemberStatus(memberID, out validID);

                    if (validID)
                    {
                        CheckMembership(sMember, mMember, memberID);
                    }
                    else
                    {
                        Console.WriteLine("This doesn't appear to be your club. Back to your spaceship!");
                    }

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
                    Common.CheckMemberStatus(memberID, out validID);
                    Console.WriteLine($"Club controller: {mMember.CheckPoints(memberID)}");
                }
                else if (option == 5)
                {
                    string tempMemberID = Common.GetUserInput("Please enter your Member ID");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);
                    Common.CheckMemberStatus(memberID, out validID);

                    CreateBill(memberID);
                }
                else if (option == 6)
                {
                    string tempMemberID = Common.GetUserInput("Please enter your Member ID");
                    int memberID = Common.CheckNumber(tempMemberID, false, 0);

                    Common.CheckMemberStatus(memberID, out validID);

                    int index = 0;

                    if (validID)
                    { 

                        for (int i = 0; i < MemberInfo.Count; i++)
                        {
                            if (memberID == MemberInfo[i].MemberID)
                            {
                                index = i;
                                break;
                            }
                        }

                        Console.WriteLine($"First Name: {MemberInfo[index].FirstName}");
                        Console.WriteLine($"Last Name: {MemberInfo[index].LastName}");
                        Console.WriteLine($"Member ID: {MemberInfo[index].MemberID}");

                        if (MemberInfo[index].PaidBill == true)
                        {
                            Console.WriteLine($"You do not have an outstanding balance.");
                        }
                        else
                        {
                            Console.WriteLine($"You have a balance of {MemberInfo[index].MemberFees} Star Specks");
                        }
                        if (memberID >= 5000)
                        {
                            Console.WriteLine($"Your Gorgal balance is: {MemberInfo[index].MemberPoints}");
                        }
                    }


                }
                else if (option == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for coming to the gym!");
                    Console.WriteLine("Enjoy your day!");
                    lContinue = false;
                }
                Console.WriteLine("Press any space key to continue!");
                Console.ReadKey();
                Console.Clear();
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
            string sectorSelection = Common.GetUserInput("Please select the sector you would like to join!\nPress 7 to blast off as a multi-club member!");
            int ID = Common.CheckNumber(sectorSelection, true, 7);

            if (int.Parse(sectorSelection) == 1)
            {
                int minID = 0;
                int maxID = 99;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                    Console.WriteLine($"{strFName} has been added to the list!");
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }

            }
            else if (int.Parse(sectorSelection) == 2)
            {
                int minID = 100;
                int maxID = 199;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }
            }
            else if (int.Parse(sectorSelection) == 3)
            {
                int minID = 200;
                int maxID = 299;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }
            }
            else if (int.Parse(sectorSelection) == 4)
            {
                int minID = 300;
                int maxID = 399;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }
            }
            else if (int.Parse(sectorSelection) == 5)
            {
                int minID = 400;
                int maxID = 499;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }
            }
            else if (int.Parse(sectorSelection) == 6)
            {
                int minID = 500;
                int maxID = 599;
                int newID = NewMemberID(minID, maxID, minID);

                SingleMember newMember = new SingleMember(newID, strFName, strLName, 10, true);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }
            }
            else if (int.Parse(sectorSelection) == 7)
            {
                int minID = 5000;
                int maxID = 50000;
                int newID = NewMemberID(minID, maxID, minID);

                MultiMember newMember = new MultiMember(newID, strFName, strLName, 25, true, 0);
                Console.WriteLine($"Are you sure you want to add {strFName} {strLName}?");
                string confirmation = Common.YesNoChecker();
                if (confirmation == "y")
                {
                    MemberInfo.Add(newMember);
                }
                else
                {
                    Console.WriteLine("Member has not been added.");
                }
            }


        }
        public int NewMemberID(int min, int max, int highestMemberID)
        {
            try
            {
                foreach (Member memID in MemberInfo)
                {
                    if (memID.MemberID > min && memID.MemberID < max)
                    {
                        if (memID.MemberID > highestMemberID)
                        {
                            highestMemberID = memID.MemberID;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("hire new programmers");
            }

            return (highestMemberID + 1);
        }
        public void RemoveMember()
        {
            bool foundMember = false;
            string input = Common.GetUserInput("Which unlucky Chicken is fried today?");
            int tempInput = Common.CheckNumber(input, false, 0);
            
            foreach (Member removedMember in MemberInfo)
            {
                if (removedMember.MemberID == tempInput)
                {
                    foundMember = true;
                    Console.WriteLine($"Are you sure you want to remove {removedMember.FirstName}?");
                    string confirmation = Common.YesNoChecker();
                    if (confirmation == "y")
                    {
                        MemberInfo.Remove(removedMember);
                        Console.WriteLine(removedMember.FirstName + " has been removed from the Member List");
                    }
                    else
                    {
                        Console.WriteLine($"{removedMember.FirstName} has not been removed from the list");
                    }
                    break;
                }
            }
            if (foundMember == false)
            {
                Console.WriteLine("This isn't the ID you're looking for.");
            }
        }
        public void CheckMembership(SingleMember sMember, MultiMember mMember, int memberID)
        {
            bool validID = true;
            string memberStatus = Common.CheckMemberStatus(memberID, out validID);

            if (memberStatus == "Single")
            {
                if (ClubLocations[Program.clubLocationIndex].ClubID == Program.CurrentClub)
                {
                    sMember.CheckIn(ClubLocations[Program.clubLocationIndex], memberID);
                }
                else
                {
                    Console.WriteLine("You are not permitted to use this Space.");
                }
            }
            else if (memberStatus == "Multi")
            {
                mMember.CheckIn(ClubLocations[Program.clubLocationIndex], memberID);
            }
        }
        public void CreateBill(int memberID)
        {

            foreach (Member memBill in MemberInfo)
            {
                if (memberID == memBill.MemberID)
                {
                    if (memBill.PaidBill == true)
                    {
                        Console.WriteLine("Your bill has been paid! Thank you!");
                    }
                    else
                    {
                        if (memBill.MemberID < 5000)
                        {
                            GenerateBill(memBill, 10);
                            Console.WriteLine($"Would you like to pay your bill?");
                            string payBill = Common.YesNoChecker();
                            if (payBill == "y")
                            {
                                PayBill(memBill);
                            }
                            else
                            {
                                Console.WriteLine("I'm sorry, members with an outstanding balance are not permitted into the club.");
                            }
                        }
                        else
                        {
                            GenerateBill(memBill, 25);
                            Console.WriteLine($"Would you like to pay your bill?");
                            string payBill = Common.YesNoChecker();
                            if (payBill == "y")
                            {
                                PayBill(memBill);
                            }
                            else
                            {
                                Console.WriteLine("I'm sorry, members with an outstanding balance are not permitted into the club.");
                            }
                        }
                    }
                }
            }
        }
        public void PayBill(Member paidMember)
        {
            Console.WriteLine("Thank you for paying your bill on time!");
            Console.WriteLine("Have a great day!");

            paidMember.PaidBill = true;

        }
        public void GenerateBill(Member memBill, int fee)
        {
            Console.WriteLine("SPACE JALS GYMS BILL");
            Console.WriteLine("-*--*--*--*--*--*--*--*--*-");
            Console.WriteLine($"Hello, {memBill.FirstName} {memBill.LastName}!");
            Console.WriteLine($"You owe {fee}!");

            if (memBill.MemberID > 5000)
            {
                Console.WriteLine($"You have {memBill.MemberPoints} Gorgals!");
            }
        }
        public void WriteToFile()
        {
            string fileName = "../../../Memberinfo.txt";
            StreamWriter writer = new StreamWriter(fileName, false); //need to pass (x,true) in order to write to the end of file and not overwrite text file data

            foreach (Member memData in MemberInfo)
            {
                writer.WriteLine($"{memData.MemberID}|{memData.FirstName}|{memData.LastName}|{memData.MemberFees}|{memData.PaidBill}|{memData.MemberPoints}");
            }

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

            string sectorSelection = Common.GetUserInput("Please select the club console you are using.");

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
            Console.Clear();
            return currentClubID;
        }

    }

}
