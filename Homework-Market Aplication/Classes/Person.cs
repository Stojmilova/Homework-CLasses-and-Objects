using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Market_Aplication.Classes
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        public int SecurityNumber;
        public bool BuyerCard;

  
        public Person(string firstName, string lastName, DateTime dateOfBirth, int securityNumber, bool buyerCard)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            SecurityNumber = securityNumber;
            BuyerCard = buyerCard;
        }
        
        public Person()
        {

        }
    }
}
