using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwartz_hoseynzadeh2
{
    static class Program
    {
        public static Manager Dombledour = new Manager();
        public static Teacher[] Teachers = new Teacher[1000];
        public static Student[] Students = new Student[1000];
        public static Plants Garden = new Plants();
        public static Group[] Groups = new Group[4];
        public static ProjectMethodsLibrary MyMethods = new ProjectMethodsLibrary();
        public static int TeacherIndex = 0, StudentIndex = 0;
        public static Group Gryffindor = new Group();
        public static Group Hufflepuff = new Group();
        public static Group Ravenclaw = new Group();
        public static Group Slytherin = new Group();
        public static List<Lesson> Cources = new List<Lesson>();
        public static int GryffindorMaleDormMembers = 0, HufflepuffMaleDormMembers = 0, RavenclawMaleDormMembers = 0, SlytherinMaleDormMembers = 0, GryffindorFemaleDormMembers = 0, HufflepuffFemaleDormMembers = 0, RavenclawFemaleDormMembers = 0, SlytherinFemaleDormMembers = 0;

        static void Main(string[] args)
        {
            //Definitions
            for (int i = 0; i < 1000; i++)
            {
                Students[i] = new Student();
                Teachers[i] = new Teacher();
            }
            Gryffindor.Groupname = "Gryffindor";
            Hufflepuff.Groupname = "Hufflepuff";
            Slytherin.Groupname = "Slytherin";
            Ravenclaw.Groupname = "Ravenclaw";
            //ReadingFile
            MyMethods.ReadingFile();
            //UI
            while (1 == 1)
            {
                //Console.Clear();
                //RUN PROGRAM
                //Choose Role
                string[] Roles = new string[4] { "Dombledour", "Teacher", "Student", "New Student" };
                int Role = MyMethods.Choise(Roles, "Hello! Who are you?");
                switch (Role)
                {
                    //Dombledour Actions
                    case 1:
                        if (Dombledour.Login())
                        {
                            bool Exit = false;
                            Console.Clear();
                            while (!Exit)
                            {
                                switch (MyMethods.Choise(Dombledour.Actions, "welcome Dombledour! What do You want?"))
                                {
                                    case 1:
                                        Dombledour.LetterProcess();
                                        //MyMethods.DelayRerun(3);
                                        break;

                                    case 2:
                                        Dombledour.PlantProcess();
                                        MyMethods.DelayRerun(5);
                                        break;
                                    case 3:
                                        Exit = true;
                                        Console.Clear();
                                        break;
                                }
                            }
                        }
                        break;


                    //Teacher Actions
                    case 2:
                        int TeacherLoginNumber = Teachers[0].Login();
                        if (TeacherLoginNumber != -1)
                        {
                            bool Exit = false;
                            Console.Clear();
                            while (!Exit)
                            {
                                        if (Teachers[TeacherLoginNumber].HaveCourse)
                                        {
                                            Teachers[TeacherLoginNumber].Actions = new string[3] { "Grading an student", "Define a new homework.", "Exit" };
                                        }
                                        else
                                        {
                                            Teachers[TeacherLoginNumber].Actions = new string[4] { "Grading an student", "Define a new homework.", "Exit", "Choose course." };
                                        }
                                switch (MyMethods.Choise(Teachers[TeacherLoginNumber].Actions, $"welcome {Teachers[TeacherLoginNumber].Name} {Teachers[TeacherLoginNumber].Family}! What do You want?"))
                                {
                                    case 1:
                                        Teachers[TeacherLoginNumber].Grading(TeacherLoginNumber);
                                        Program.MyMethods.DelayRerun(3);
                                        break;
                                    case 2:
                                        Teachers[TeacherLoginNumber].DefineHomework(TeacherLoginNumber);
                                        MyMethods.DelayRerun(3);
                                        break;
                                    case 3:
                                        Exit = true;
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Teachers[TeacherLoginNumber].ChooseCourse(Teachers[TeacherLoginNumber],TeacherLoginNumber);
                                        MyMethods.DelayRerun(5);
                                        break;
                                }
                            }
                        }
                        break;
                        

                    //Student Actions
                    case 3:
                        int StudentLoginNumber = Students[0].Login();
                        if (StudentLoginNumber != -1)
                        {
                            bool Exit = false;
                            Console.Clear();
                            while (!Exit)
                            {
                                if (Students[StudentLoginNumber].IsHeInHogwartz == false)
                                {
                                    Students[StudentLoginNumber].Actions = new string[4] { "Read my letters", "Request a ticket.", "Boarding the train.", "Exit" };
                                }
                                else
                                {
                                    Students[StudentLoginNumber].Actions = new string[7] { "Read my letters.", "Request a ticket.", "Boarding the Train.", "Exit", "Choose my Courses.", "Doing my phytology homeworks.","See my informations."};
                                }
                                switch (MyMethods.Choise(Students[StudentLoginNumber].Actions, $"welcome {Students[StudentLoginNumber].Name} {Students[StudentLoginNumber].Family}! What do You want?"))
                                {
                                    case 1:
                                        MyMethods.showList(Students[StudentLoginNumber].Letters, $"Hello! I.m your {Students[StudentLoginNumber].pet}. Your letters are:");
                                        MyMethods.DelayRerun(Students[StudentLoginNumber].Letters.Count*4+1);
                                        Students[StudentLoginNumber].Letters.Clear();
                                        break;
                                    case 2:
                                        Students[StudentLoginNumber].LetterProcess(StudentLoginNumber);
                                        MyMethods.DelayRerun(3);
                                        break;
                                    case 3:
                                        if (Students[StudentLoginNumber].Ticket)
                                        {
                                            Students[StudentLoginNumber].Ticket = false;
                                            Students[StudentLoginNumber].IsHeInHogwartz = !Students[StudentLoginNumber].IsHeInHogwartz;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("\n\nYou are in the train. You will be in destination soon!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\n\nYou haven't any ticket!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        MyMethods.DelayRerun(3);
                                        break;
                                    case 4:
                                        Exit = true;
                                        Console.Clear();
                                        break;
                                    case 5:
                                        if (Cources.Count == 0)
                                        {
                                            Console.WriteLine("We have not any presented course yet.");

                                        }
                                        else
                                        {
                                            Students[StudentLoginNumber].ChooseCourse(Students[StudentLoginNumber], StudentLoginNumber);
                                        }
                                        MyMethods.DelayRerun(5);
                                        break;
                                    case 6:
                                        Students[StudentLoginNumber].HomeworkProcess(StudentLoginNumber);
                                        MyMethods.DelayRerun(3);
                                        break;
                                    case 7:
                                        Students[StudentLoginNumber].ShowInformation(Students[StudentLoginNumber]);
                                        break;
                                }
                            }
                        }
                        break;
                    //Add new student
                    case 4:
                        Students[0].NewStudent();
                        MyMethods.DelayRerun(20);
                        break;

                }

            }
        }
    }
}