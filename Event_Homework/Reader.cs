using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Homework
{
    class ReadNumber
    {
        public delegate void ReadNumberDelegate(int Number);
        public event ReadNumberDelegate ReadNumberEvent;
        public void Read()
        {
            Console.WriteLine("1 - sorting from A to Z, 2 - sorting from Z to A");
            int Number;
            if (int.TryParse(Console.ReadLine(), out Number))
            {
                if (Number != 1 && Number != 2)
                    throw new UserException("Number must be 1 or 2", Number);
            }
            else
                throw new FormatException();
            ReadNumberEvent(Number);

        }

    }
}
