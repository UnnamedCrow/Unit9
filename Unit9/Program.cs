using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Unit9
{
    // Class with my exception
    class UserException : Exception
    {
        public int Value { get; set; }
        public UserException() { }
        public UserException(string message, int Value) : base(message) 
        {
            this.Value = Value;
        }
   
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            // Array with 5 types of Exceptions
            Exception[] ExceptionArray = new Exception[5];
            ExceptionArray[0] = new UserException();
            ExceptionArray[1] = new FormatException();
            ExceptionArray[2] = new ArgumentException();
            ExceptionArray[3] = new IndexOutOfRangeException();
            ExceptionArray[4] = new DivideByZeroException();
            Console.WriteLine("Enter number from 1 to 10");
            try
            {
                int Number_A;
                if (!int.TryParse(Console.ReadLine(), out Number_A))
                    throw new FormatException();
                if (Number_A < 1 || Number_A > 10)
                    throw new UserException("Number must be from 1 to 10", Number_A);
                int Number_B;
                Number_B = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Number_A / Number_B);
            }
            catch(UserException ex)
            { 
                Console.WriteLine(ex.Message, ex.Value);
            }
            catch(FormatException)
            {
                Console.WriteLine("Wront format");
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Number_B = 0");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Wrong argument");
            }
            Console.ReadLine();
        }
    }
}
