using System;
using System.Collections.Generic;
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
        public void WriteToFile()//string fileName
        { 

        }
        public void ReadFromFile() //string fileName
        { 
        
        }
        
    }

}
