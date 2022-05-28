using System;

namespace Lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            bool exit = false;
            while (exit == false)
            {
                int numberMethod = Person.NumerMethod();

                switch (numberMethod)
                {
                    case 1:
                        Person.ChekAndShow();
                        break;

                    case 2:
                        person.CreateFileAndRead();
                        break;

                    case 3:
                        person.DeletPerson();
                        break;
                    case 4:
                        person.EditPerson();
                        break;
                    case 5:
                        person.SortingByData();
                        break;
                    case 6:
                        person.SortDate();
                        break;
                    case 7:
                        exit = true;
                        break;
                }
            }

        }
    }
    
}
