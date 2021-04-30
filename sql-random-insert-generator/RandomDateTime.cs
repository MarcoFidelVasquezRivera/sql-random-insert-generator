using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Random_Insert_Generator
{
    public class RandomDateTime
    {
        DateTime start;
        Random gen;
        int range;
        
        public RandomDateTime(DateTime dateMinimum, DateTime dateMaximum)
        {
            start = dateMinimum;
            gen = new Random();
            range = (dateMaximum - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range));
        }
    }
}
