using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;

namespace Lesson_7
{
    public class Person
    {
        public Person(string NameP, int AgeP, int GrowthP, string PlaseOfBerthP)
        {
            this.name = NameP;
            this.age = AgeP;
            this.growth = GrowthP;
            this.plaseOfBirth = PlaseOfBerthP;
        }
        public Person()
        {

        }
        string lines = string.Empty;
        string allText = string.Empty;
        private int id;
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        private string dateTime;

        private DateTime dateOfBirth = new DateTime();       

        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        private int age;
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        private int growth;
        public int Growth
        {
            get { return this.growth; }
            set { this.growth = value; }
        }
        private string plaseOfBirth;
        public string PlaseOfBirth
        {
            get { return this.plaseOfBirth; }
            set { this.plaseOfBirth = value; }
        }

        public void EditPerson()
        {
            string lines = File.ReadAllText(@"h:\dataTest.txt");
            string[] lineMasive = lines.Split('#');            

            Console.WriteLine("Выберите строку для редактирования");
            int strok = int.Parse(Console.ReadLine());
            Console.WriteLine("Выберите значение для редоктирвания\n" +
                "1 Для редоктирования имени\n"+
                "2 Для редоктирования возроста\n" +
                "3 Для редоктирования роста\n" +
                "4 Для редоктирования даты рождения\n" +
                "5 Для редоктирования места рождения");
            int choice = int.Parse(Console.ReadLine());
            
            switch(choice)
            {
                case 1:
                    lineMasive[strok * 8 - 5] = GetName();
                    break;

                case 2:
                    lineMasive[strok * 8 - 4] = Convert.ToString( GetAge());
                    break;

                case 3:
                    lineMasive[strok * 8 - 3] = Convert.ToString(GetGrowth());
                    break;

                case 4:
                    lineMasive[strok * 8 - 2] = Convert.ToString(GetBirthday());
                    break;

                case 5:
                    lineMasive[strok * 8 - 1] = GetPlaseofBith();
                    break;
            }
            string allText = string.Empty;
           

            for (int i = 0; i < lineMasive.Length; i++)
            {               

                allText =allText+ lineMasive[i] + "#";
              
            }

            int countText = allText.Length-1;
            string newAllText= allText.Remove(countText);

            File.WriteAllText(@"h:\dataTest.txt", newAllText);

        }
        /// <summary>
        /// Метод создает строку
        /// </summary>
        public void CreateFileAndRead()
        {

            ID = GetID();
            dateTime = DateTime.Now.ToString("g");
            Name = GetName();
            Age = GetAge();
            Growth = GetGrowth();
            dateOfBirth = GetBirthday();
            PlaseOfBirth = GetPlaseofBith();

            int count = GetID() + 1;

            string text = $"#{ID}#{dateTime}#{name}#{age}#{growth}#{dateOfBirth:d}#{plaseOfBirth}#";
            if (IsFile() == true)
            {
                lines = File.ReadAllText(@"h:\dataTest.txt");
                allText = $"{lines}\n{text}";                               
                File.WriteAllText(@"h:\dataTest.txt", allText);
            }
            else
            {
                File.WriteAllText(@"h:\dataTest.txt", text);
            }
        }
        /// <summary>
        /// Метод удоляет строку
        /// </summary>
        public void DeletPerson()
        {
            Console.WriteLine("Укажиде какую строку хотите удалить");
            int stroc = Convert.ToInt32(Console.ReadLine());

            if (IsFile() == true)
            {
                string[] linesMasive = File.ReadAllLines(@"h:\dataTest.txt");
                string[] newLinemasive;
                
                Array.Clear(linesMasive, stroc-1,1);
                Array.Sort(linesMasive);
                Array.Clear(linesMasive, linesMasive.Length, 0);

                List<string> list = new List<string>();

                foreach(string i in linesMasive)
                {
                    if (i == "" || i == null)
                    {
                       
                    }
                    else
                    {
                        list.Add(i);
                    }
                }
                newLinemasive = list.ToArray();              
              

                File.WriteAllLines(@"h:\dataTest.txt", newLinemasive);
                
            }
            else
            {
                Console.WriteLine("Файла не существует");
            }
        }

        static int GetID()
        {
            int id = 1;
            string line = string.Empty;
            if (IsFile() == true)
            {
                string lin = File.ReadAllText(@"h:\dataTest.txt");
                string[] masivLan = lin.Split('#');
                int lastIndex = Convert.ToInt32(masivLan[masivLan.Length-8]);
                id = lastIndex+1;
                
                //string[] lines = File.ReadAllLines(@"h:\dataTest.txt");


               // id = lines.Length + 1;
            }
            else
            {
                id = 1;
            }
            return id;
        }
        /// <summary>
        /// Проверяет существует ли фйл
        /// </summary>
        /// <returns>Возвращает булквое значение</returns>
        static bool IsFile()
        {
            bool flag = File.Exists(@"h:\dataTest.txt") ? true : false;
            return flag;
        }
        static string GetName()
        {
            string name;
            Console.WriteLine("Введите Ф.И.О");
            name = Console.ReadLine();
            return name;
        }
        public static int GetAge()
        {
            int age = 0;
            bool flag = false;

            while (flag == false)
            {
                Console.WriteLine("Введите возраст");
                age = Convert.ToInt32(Console.ReadLine());
                if (age > 0 && age < 110)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Не родившихся и бессмертных не вносят в список");
                    flag = false;
                }
            }
            return age;
        }
        static int GetGrowth()
        {
            int growth = 0;

            bool flag = false;

            while (flag == false)
            {
                Console.WriteLine("Введите рост в сантиметрах");
                growth = Convert.ToInt32(Console.ReadLine());
                if (growth > 10 && growth < 270)
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Не стоит шутить со мной великановый каратышка");
                    flag = false;
                }
            }

            return growth;
        }
        static DateTime GetBirthday()
        {
            DateTime birthday = new DateTime();
            Console.WriteLine("Введите дату рождения d.m.y");
            birthday = Convert.ToDateTime(Console.ReadLine());

            return birthday;
        }
        static string GetPlaseofBith()
        {
            string plase = string.Empty;
            Console.WriteLine("Введите город рождения");
            plase ="город "+ Console.ReadLine();

            return plase;
        }
        /// <summary>
        /// Получает от пользователя номер метода
        /// </summary>
        /// <returns>Номер метода</returns>
        public static int NumerMethod()
        {
            int method = 0;
            bool flag = false;

            while (flag == false)
            {
                Console.WriteLine("Если хотите вывести данные, нажмите 1" +
                    "\nЕсли хотите заполнить данные в конце строки, нажмите 2" +
                    "\nДля удаления записи, нажмите 3" +
                    "\nДля редоктирования зписи, нажмите 4" +
                    "\nДля загрузки записи в выбранном диапазоне дат, нажмите 5"+
                    "\nДля сортировки по возрастанию и убыванию дат, нажмите 6"+
                    "\nДля выхода нажмите 7");
                string Smethod = Console.ReadLine();
                if (Smethod == "1" || Smethod == "2" || Smethod == "3"|| Smethod == "4" || Smethod == "5" || Smethod == "6" || Smethod =="7")
                {
                    method = Convert.ToInt32(Smethod);
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Такого значения нет");
                    flag = false;
                }
            }
            return method;
        }
        public static void ChekAndShow()
        {
            if (IsFile() == true)
            {
                ShowContent();
            }
            else
            {
                Console.WriteLine("Файл не создан");
            }
        }
        static void ShowContent()
        {
            SortID();

            string[] linesMasive = File.ReadAllLines(@"h:\dataTest.txt");
            string[] newLinemasive;
                        
            Array.Sort(linesMasive);
            Array.Clear(linesMasive, linesMasive.Length, 0);

            List<string> list = new List<string>();

            foreach (string i in linesMasive)
            {
                if (i == "" || i == null)
                {

                }
                else
                {
                    list.Add(i);
                }
            }
            newLinemasive = list.ToArray();


            File.WriteAllLines(@"h:\dataTest.txt", newLinemasive);

            string lines = File.ReadAllText(@"h:\dataTest.txt");
            string[] line = lines.Split('#');

            foreach (var l in line)

            {
                Console.Write(l+" ");
            }
            Console.WriteLine();
        }
        
        public void SortingByData()
        {
            Console.WriteLine("Введите наименьшую дату для сортировки");
            DateTime minDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите наибольшую дату для сортировки");
            DateTime maxDate = Convert.ToDateTime(Console.ReadLine());

            using (StreamReader sr = new StreamReader(@"h:\dataTest.txt"))
            {
                while(!sr.EndOfStream)
                {
                    //sr.Read();
                    string [] args=sr.ReadLine().Split('#');
                    if(minDate < Convert.ToDateTime(args[2]) && Convert.ToDateTime(args[2])<maxDate)
                    {
                        foreach (var v in args)
                            Console.Write($"{v} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void SortDate()
        {
            bool maxOrmin = false;
            int choice = 1;
            bool flag = false;

            while(flag == false)
            {
                Console.WriteLine("Если вы хотите сортировать даты создания от меньшей к большей нажимте 1\n" +
                    "Если вы хотите сортировать даты создания от большей к меньшей нажмите 2 ");
                string varibl = Console.ReadLine();
                if(varibl == "1" || varibl == "2")
                {
                    choice = Convert.ToInt32(varibl);
                    flag = true;
                }
                else
                {
                    Console.WriteLine("Такого значенния нет");
                    flag = false;
                }
            }

            switch (choice)
            {
                case 1:
                    maxOrmin = false;
                    break;
                case 2:
                    maxOrmin = true;
                    break;
            }

            SortDateByMinMax(maxOrmin);

        }
        private void SortDateByMinMax (bool maxOrmin)
        {
            bool maxvalue = maxOrmin;

            string path = @"h:\dataTest.txt";
            using(StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                string[] masText = text.Split("#");

                
                Dictionary<DateTime, string> printDictionary = new Dictionary<DateTime, string>();

                int b = 0;
                for (int i = 0; i < (masText.Length)/8; i++)
                {
                    printDictionary.Add(Convert.ToDateTime(masText[b + 2]), $"{masText[b + 1]} {masText[b + 2]}" +
                        $" {masText[b + 3]} {masText[b + 4]} {masText[b + 5]} {masText[b + 6]} {masText[b + 7]} {masText[b+8]}");

                    b = b + 8;
                }

                List<DateTime> dateList = new List<DateTime>();

                for (int i = 2; i < masText.Length;)
                {
                    dateList.Add(Convert.ToDateTime(masText[i]));
                    i = i + 8;
                }

                dateList.Sort();

                if(maxvalue == true)
                {
                    dateList.Reverse();
                }

                foreach(var v in dateList)
                {
                    if (printDictionary.ContainsKey(v))
                    {
                        Console.WriteLine(printDictionary[v]);
                    }
                }
            }
        }

        private static void SortID()
        {
            string path = @"h:\dataTest.txt";
            string[] newMasiv;
            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadToEnd();
                string[] masText = text.Split("#");


                Dictionary<int, string> IDDictionary = new Dictionary<int, string>();
                //заполняю словарь
                int b = 0;
                for (int i = 0; i < (masText.Length) / 8; i++)
                {
                    IDDictionary.Add(Convert.ToInt32(masText[b + 1]), $"#{masText[b + 1]}#{masText[b + 2]}" +
                        $"#{masText[b + 3]}#{masText[b + 4]}#{masText[b + 5]}#{masText[b + 6]}#{masText[b + 7]}#{masText[b + 8]}");

                    b = b + 8;
                }

                //лист для сортировки ключей словоря
                List<int> IDList = new List<int>();

                for (int i = 1; i < masText.Length;)
                {
                    IDList.Add(Convert.ToInt32(masText[i]));
                    i = i + 8;
                }

                IDList.Sort();

                //записываю новый масиив для записи файла
                newMasiv=new string [IDList.Count];

                for (int i = 0; i < IDList.Count; i++)
                {

                    newMasiv[i] = IDDictionary[IDList[i]];
                }                                         
                                                  

            }
            File.WriteAllLines(@"h:\dataTest.txt", newMasiv);
        }
    }
}
