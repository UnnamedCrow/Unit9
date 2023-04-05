using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Event_Homework.Program;

namespace Event_Homework
{

    internal class Program
    {
              
        public static void Sort(int Number)
        {
            switch (Number)
            {
                // Sort from A to Z 
                case 1: SortEventAZ.Invoke(PersonArray); break;
                // Sort from Z to A 
                case 2: SortEventZA.Invoke();  break;
            }
        }
   
        public static void SortAZ(Person[] PersonList)
        {
            for (int i = 0; i < PersonList.Length; i++)
                for (int j = 1; i < PersonList.Length - i; j++)
                if (PersonList[j - 1] > PersonList[j])
                    (PersonList[j - 1], PersonList[j]) = (PersonList[j], PersonList[j - 1]);
        }

        public static void SortZA(Person[] PersonList) 
        {
            for (int i = 0; i < PersonList.Length; i++)
                for (int j = 1; i < PersonList.Length - i; j++)
                    if (PersonList[j - 1] < PersonList[j])
                        (PersonList[j - 1], PersonList[j]) = (PersonList[j], PersonList[j - 1]);
        }

        public delegate void SortDelegate(Person[] PersonList);
        public static event SortDelegate SortEventAZ;
        public static event SortDelegate SortEventZA;
        static void Main(string[] args)
        {
            
            Person[] PersonArray = new Person[5];
            PersonArray[0] = new Person("Lee");
            PersonArray[1] = new Person("Week");
            PersonArray[2] = new Person("Smith");
            PersonArray[3] = new Person("Freeman");
            PersonArray[4] = new Person("Shtirlich");

            SortEventAZ += SortAZ;
            SortEventZA += SortZA;

            ReadNumber reader = new ReadNumber();
            reader.ReadNumberEvent += Sort;
            try
            {
                reader.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong format");
            }
            catch (UserException ex)
            {
                Console.WriteLine(ex.Message, ex.Value);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Sorting out of range array");
            }
        }
    }

}
