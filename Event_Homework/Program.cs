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
                case 1: Console.WriteLine("Entered 1"); break;
                case 2: Console.WriteLine("Entered 2"); break;
            }
        }

        // Sorting Person[] from A to Z
        public static void SortAZ(Person[] PersonList)
        {
            for (int i = 0; i < PersonList.Length; i++)
                for (int j = 1; j < PersonList.Length - i; j++)
                if (PersonList[j - 1] > PersonList[j])
                    (PersonList[j - 1], PersonList[j]) = (PersonList[j], PersonList[j - 1]);
        }

        // Sorting Person[] from Z to A
        public static void SortZA(Person[] PersonList) 
        {
            for (int i = 0; i < PersonList.Length; i++)
                for (int j = 1; j < PersonList.Length - i; j++)
                    if (PersonList[j - 1] < PersonList[j])
                        (PersonList[j], PersonList[j - 1]) = (PersonList[j - 1], PersonList[j]);
        }

        public delegate void SortDelegate(Person[] PersonList);
        public static event SortDelegate SortEventAZ;
        public static event SortDelegate SortEventZA;

        static void Main(string[] args)
        {
            // Create array Person[5]
            Person[] PersonArray = new Person[5];
            PersonArray[0] = new Person("Lee");
            PersonArray[1] = new Person("Week");
            PersonArray[2] = new Person("Smith");
            PersonArray[3] = new Person("Freeman");
            PersonArray[4] = new Person("Shtirlich");

            // Registr events
            SortEventAZ += SortAZ;
            SortEventZA += SortZA;

            ReadNumber reader = new ReadNumber();
            reader.ReadNumberEvent += Sort;
            while (true)
            {
                try
                {
                    switch(reader.Read())
                    {
                        // Sorting PersonArray from A to Z by event 
                        case 1:SortEventAZ.Invoke(PersonArray);break;
                        // Sorting PersonArray from Z to A by event 
                        case 2:SortEventZA(PersonArray);break;
                    }      
                }

                // Catching exceptions from user
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format");
                }
                catch (UserException ex)
                {
                    Console.WriteLine(ex.Message, ex.Value);
                }
            }
        }
    }
}
