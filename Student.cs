using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hogwartz_hoseynzadeh2
{
    class Student : AouthorizedHuman
    {
        public string[] Actions = new string[6] { "Read my letters.", "Give a ticket.", "Boarding the Train.", "Choose my Courses.", "Doing my homeworks.", "Exit" };
        public string[] PassedCourses = new string[10];
        public int NumberOfTerm = 1;
        public bool Ticket = false;
        public bool IsHeInHogwartz = false;
        public int BlueFlower = 0;
        public int GrayFlower = 0;
        public int RedFlower = 0;
        public int YellowFlower = 0;
        public int GreenFlower = 0;
        public int PinkFlower = 0;
        public int SunFlower = 0;
        //request ticket
        public void LetterProcess(int Whichone)
        {
            if (!Program.Students[Whichone].Ticket)
            {
                string Request = "Enter";
                if (Program.Students[Whichone].IsHeInHogwartz == true)
                {
                    Request = "Exit";
                }
                string[] Choises = new string[2] { "Yes", "No" };
                int Choise = Program.MyMethods.Choise(Choises, $"Do you want {Request} Hogwartz?");
                if (Choise == 1)
                {
                    Program.Dombledour.Letters.Add($"Hello Dombledour! i.m {Program.Students[Whichone].Name} {Program.Students[Whichone].Family}.\n I want {Request} Hogwartz.\n Please send me a ticket.");
                    Program.Dombledour.StudentOfDemands.Add(Whichone);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYour request sent successfuly.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYou already have ticket!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        // Log in
        public int Login()
        {
            //UI
            Console.Clear();
            Console.WriteLine("Enter Your username:");
            string InputUsername = Console.ReadLine();
            Console.WriteLine("EnterYour Password:");
            string InputPassword = Console.ReadLine();
            //Background
            int Result = -1;
            bool ValidAcoount = false;
            for (int i = 0; i < Program.StudentIndex; i++)
            {
                if (Program.Students[i].Username == InputUsername)
                {
                    ValidAcoount = true;
                    if (Program.Students[i].Password == InputPassword)
                    {
                        Result = i;
                    }

                }
            }
            if (!ValidAcoount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nInvalid Account! Try again.");
                Program.MyMethods.DelayRerun(3);
            }
            else if (Result == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nIncorrect password! Try again.");
                Program.MyMethods.DelayRerun(3);
            }
            Console.ForegroundColor = ConsoleColor.White;
            return Result;
        }
        //Homework
        public void HomeworkProcess(int StudentNumber)
        {
            Console.WriteLine($"Garden plants are:\n\n(1) Blue: {Program.Garden.BlueFlower} \n(2) Gray: {Program.Garden.GrayFlower} \n(3) Red: {Program.Garden.RedFlower} \n(4) Yellow: {Program.Garden.YellowFlower} \n(5) Green: {Program.Garden.GreenFlower} \n(6) Pink: {Program.Garden.PinkFlower} \n(7) Sunflower: {Program.Garden.SunFlower} ");

            string Chooseflower;
            int ChooseflowerInt = 0;
            while (1 == 1)
            {
                Console.WriteLine("--------------------\nChoose number of one of them for picking up");
                Chooseflower = (Console.ReadLine());
                try
                {
                    ChooseflowerInt = Convert.ToInt32(Chooseflower);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (ChooseflowerInt > 7 || ChooseflowerInt < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a valid number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            string HowMuch;
            int HowmuchInt = 0;
            while (1 == 1)
            {
                Console.WriteLine("How much? :");
                HowMuch = (Console.ReadLine());
                try
                {
                    HowmuchInt = Convert.ToInt32(HowMuch);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (HowmuchInt < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a valid number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            switch (ChooseflowerInt)
            {
                case 1:
                    Program.Students[StudentNumber].BlueFlower += HowmuchInt;
                    break;
                case 2:
                    Program.Students[StudentNumber].GrayFlower += HowmuchInt;
                    break;
                case 3:
                    Program.Students[StudentNumber].RedFlower += HowmuchInt;
                    break;
                case 4:
                    Program.Students[StudentNumber].YellowFlower += HowmuchInt;
                    break;
                case 5:
                    Program.Students[StudentNumber].GreenFlower += HowmuchInt;
                    break;
                case 6:
                    Program.Students[StudentNumber].PinkFlower += HowmuchInt;
                    break;
                case 7:
                    Program.Students[StudentNumber].SunFlower += HowmuchInt;
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe plants picked up successfuly.");
            Console.ForegroundColor = ConsoleColor.White;

        }
        //Course
        public void ChooseCourse(Student Student, int Whichone)
        {
            string[] WeekDays = new string[5] { "Saturday", "Sunday", "Monday", "Thusday", "Wednesday" };
            string[] CoursesArray = new string[Program.Cources.Count];
            for (int i = 0; i < Program.Cources.Count; i++)
            {
                CoursesArray[i] = Program.Cources[i].Name + " with " + Program.Cources[i].TeaacherOfCource + " in " + WeekDays[Program.Cources[i].Whichday];
            }
            int ChoosedCourseNumber = Program.MyMethods.Choise(CoursesArray, "Choose your course. The present courses are: ")-1;
            if (Student.LessonSchedule[Program.Cources[ChoosedCourseNumber].Whichday] != "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nThe lesson schedule have not capacity in this day.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Program.Students[Whichone].LessonSchedule[Program.Cources[ChoosedCourseNumber].Whichday] = Program.Cources[ChoosedCourseNumber].Name;
                Program.Teachers[Program.Cources[ChoosedCourseNumber].TeacherNumber].IndexesOfStudents.Add(Whichone);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nThe Course, added successfuly!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
            //New student
            public void NewStudent ()
            {
            string[] Human = new string[9];
            Console.WriteLine("Hello! Welcome to Hogwartz magic school!\nWhat is your first name?");
            while(1==1)
            {
                if ((Human[0] = Console.ReadLine())!= "")
                {
                    break;
                }
            }
            Console.WriteLine("What is your last name?");
            while (1 == 1)
            {
                if ((Human[1] = Console.ReadLine()) != "")
                {
                    break;
                }
            }
            string BY;
            int BYInt = 0;
            while (1 == 1)
            {
                Console.WriteLine("What is your Birth year?");
                BY = (Console.ReadLine());
                try
                {
                    BYInt = Convert.ToInt32(BY);
                }
                catch
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (BYInt > 9999 || BYInt < 1000)
                {
                    //Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a valid number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            Human[2] = Convert.ToString(BYInt);
            string[] Genders = new string[2] {"male","female"};
            int Gender = Program.MyMethods.Choise(Genders,"What is your gender?");
            switch (Gender)
            {
                case 1:
                    Human[3] = "male";
                    break;
                case 2:
                    Human[3] = "female";
                    break;
            }
            Console.WriteLine("What is your Father name?");
            while (1 == 1)
            {
                if ((Human[4] = Console.ReadLine()) != "")
                {
                    break;
                }
            }
            Console.WriteLine("Enter your desired username:");
            while (1 == 1)
            {
                if ((Human[5] = Console.ReadLine()) != "")
                {
                    break;
                }
            }
            Console.WriteLine("Enter your account password: (Notice username & password )");
            while (1 == 1)
            {
                if ((Human[6] = Console.ReadLine()) != "")
                {
                    break;
                }
            }
            string[] Bloods = new string[3] { "Pure blood", "Half blood" , "Muggle blood" };
            int BloodsInt = Program.MyMethods.Choise(Bloods, "What is your Race?");
            Human[7] = Bloods[BloodsInt-1];
            Human[8] = "student";
            //Human vars
            Program.Students[Program.StudentIndex].Name = Human[0];
            Program.Students[Program.StudentIndex].Family = Human[1];
            Program.Students[Program.StudentIndex].BirthYear = Human[2];
            Program.Students[Program.StudentIndex].gender = Human[3];
            Program.Students[Program.StudentIndex].FatherName = Human[4];
            Program.Students[Program.StudentIndex].Username = Human[5];
            Program.Students[Program.StudentIndex].Password = Human[6];
            Program.Students[Program.StudentIndex].Race = Human[7];
            Program.Students[Program.StudentIndex].Role = Human[8];
            //Aouthorized human vars
            Program.Students[Program.StudentIndex].HisGroup = Program.MyMethods.GroupDeterminator(Program.Students[Program.StudentIndex]);
            //
            string[] Pets = new string[4] { "Owl", "Cat", "Rat","Pigeon" };
            int PetsInt = Program.MyMethods.Choise(Pets, "What is your desired Pet?");
            Program.Students[Program.StudentIndex].pet = Pets[PetsInt - 1];
            string[] Bagage = new string[2] {"Yes","No"};
            int BagageInt = Program.MyMethods.Choise(Bagage, "Do you have any baggage?");
            switch (BagageInt)
            {
                case 1:
            Program.Students[Program.StudentIndex].HaveBaggage = true;
                    break;
                case 2:
                    Program.Students[Program.StudentIndex].HaveBaggage = false;
                    break;
            }
            //
            Program.Students[Program.StudentIndex].DormOfStudent = Program.MyMethods.DormDeterminator(Program.Students[Program.StudentIndex]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou added to Hogwarts sucessfuly!\nWise hat: You are in the {Program.Students[Program.StudentIndex].HisGroup.Groupname} Group!\nSeverus snape: Welcome to Hogwartz! I hope you will be a good student.\nyour bedroom is: {Program.Students[Program.StudentIndex].DormOfStudent.GroupOfDorm.Groupname}{Program.Students[Program.StudentIndex].gender} Dorm,  {Program.Students[Program.StudentIndex].DormOfStudent.Floor} Floor,  {Program.Students[Program.StudentIndex].DormOfStudent.Room} Room, {Program.Students[Program.StudentIndex].DormOfStudent.Bed} Bed.");
            Program.StudentIndex++;
        }
        //Show inf
        public void ShowInformation (Student Stu)
        {
            Console.WriteLine($"You are {Stu.Name} {Stu.Family}.");
            Console.WriteLine($"Your fater name is  {Stu.FatherName}");
            Console.WriteLine($"You were born in {Stu.BirthYear}.");
            Console.WriteLine($"You are {Stu.Race} and in {Stu.HisGroup.Groupname} group.");
            Console.WriteLine($"You have a cute {Stu.pet}.");
            Console.WriteLine($"Your dorm static code is {Stu.DormOfStudent.StaticCode}.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
