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

        public void WelcomeToGym()
        { 
        
        }
        public void AddMember()
        {
            string strFName = Common.GetUserInput("Please enter First Name");
            string strLName = Common.GetUserInput("Please enter Last Name");
            int ID = 100;
            // Uncomment after method is changed *********************************
            //WriteToFile(strFName, strLName, ID);
        }
        public void RemoveMember()
        { 
        }
        public void CheckMembership()
        { 
        }
        public void CreateBill()
        { 
        }
        public void WriteToFile()//List<string> Memberinfo list of data that will be written to the file
        {
            List<string> MemberInfo = new List<string>();

            string fileName = "../../../Memberinfo.txt";
            StreamWriter writer = new StreamWriter(fileName);

            foreach (string info in MemberInfo)
            {
                writer.WriteLine($"{info.ID}|{info.fName}|{info.lName}");
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
            while (line != null)
            {
                string[] info = line.Split('|');
            }

            reader.Close();
        
        }
        
    }

}
