using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingConsoleGame
{
    public class Player
    {
        public DateTime PlayerBirthDate { get; set; }

        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - PlayerBirthDate;
                double totalAgeInYears = ageSpan.TotalDays / 365.25;
                int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
                return yearsOfAge;
            }

        }



        
    }



}
