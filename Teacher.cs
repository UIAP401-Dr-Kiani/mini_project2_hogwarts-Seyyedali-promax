using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwartz_hoseynzadeh2
{
    class Teacher : AouthorizedHuman
    {
        public string[] Actions = new string[4] { "Grading the students", "Define a new homework.", "Exit", "Choose course." };
        public List<int> IndexesOfStudents = new List<int>();
        public bool examplevariable = false;
        public bool TeachSameTime = false;
        public bool HaveCourse = false;
        public string HisLesson;
        public Lesson HisLessons = new Lesson();
        public int Login()
        {
            Console.Clear();
            Console.WriteLine("Enter Your username:");
            string InputUsername = Console.ReadLine();
            Console.WriteLine("EnterYour Password:");
            string InputPassword = Console.ReadLine();
            //Background
            int Result = -1;
            bool ValidAcoount = false;
            for (int i = 0; i < Program.TeacherIndex; i++)
            {
                if (Program.Teachers[i].Username == InputUsername)
                {
                    ValidAcoount = true;
                    if (Program.Teachers[i].Password == InputPassword)
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
        //Lesson
        public void ChooseCourse(Teacher Teacher, int Whichone)
        {
            Lesson Result = new Lesson();
            string[] YesNo = new string[2] { "Yes", "No" };
            int CanSameTime = Program.MyMethods.Choise(YesNo, "Can you teach with another teacher on 1 class?");
            switch (CanSameTime)
            {
                case 1:
                    Program.Teachers[Whichone].TeachSameTime = true;
                    break;
                case 2:
                    Program.Teachers[Whichone].TeachSameTime = false;
                    break;
            }
            string[] Lessons = new string[4] { "Chimistry", "Phytology", "Sport", "Magicology" };
            Result.Name = Lessons[Program.MyMethods.Choise(Lessons, "What you can teach?") - 1];
            string[] Days = new string[5] { "Saturday", "Sunday", "Monday", "Thusday", "Wednesday" };
            Result.Whichday = Program.MyMethods.Choise(Days, "When you can teach?") - 1;
            Result.TeaacherOfCource = Teacher.Name + " " + Teacher.Family;
            Result.TeacherNumber = Whichone;
            Program.Teachers[Whichone].LessonSchedule[Result.Whichday] = Result.Name;
            Program.Teachers[Whichone].HaveCourse = true;
            Program.Cources.Add(Result);
            Program.Teachers[Whichone].HisLessons = Program.Cources[Program.Cources.Count - 1];
        }
        public void DefineHomework(int WhichTeacher)
        {
            Console.WriteLine("Enter the message of homework:");
            string InputHomework = Console.ReadLine();
            for (int i = 0; i < Program.Teachers[WhichTeacher].IndexesOfStudents.Count; i++)
            {
                Program.Students[Program.Teachers[WhichTeacher].IndexesOfStudents[i]].Letters.Add(InputHomework);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe homework added successfuly.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // grade
        public void Grading(int TeacherLoginNumber)
        {

            if (Program.Teachers[TeacherLoginNumber].IndexesOfStudents.Count > 0)
            {
                string[] StudentNames = new string[Program.Teachers[TeacherLoginNumber].IndexesOfStudents.Count];
                for (int i = 0; i < Program.Teachers[TeacherLoginNumber].IndexesOfStudents.Count; i++)
                {
                    StudentNames[i] = ((Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[i]].Name) + " " + Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[i]].Family);
                }
                int Grading = Program.MyMethods.Choise(StudentNames, "Who?") - 1;
                int Grade = Program.MyMethods.Grading("How much from 20?", 20);
                bool Ispassed = false;
                for (int i = 0; i<4;i++)
                {
                    if (Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].PassedCourses[i]== Program.Teachers[TeacherLoginNumber].HisLessons.Name)
                    {
                        Ispassed = true;
                    }
                }
                if (Grade >= 10 & !Ispassed)
                {
                    Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].Letters.Add($"You passed the {Program.Teachers[TeacherLoginNumber].HisLessons.Name} Course!");
                    Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].PassedCourses[(Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].PassedCoursesInt)] = Program.Teachers[TeacherLoginNumber].HisLessons.Name;
                    Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].PassedCoursesInt++;
                    Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].LessonSchedule[Program.Teachers[TeacherLoginNumber].HisLessons.Whichday] = "";
                }
                else if (Grade<10)
                {
                    Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].Letters.Add($"You failed the {Program.Teachers[TeacherLoginNumber].HisLessons.Name} Course!");
                }
                Program.Students[Program.Teachers[TeacherLoginNumber].IndexesOfStudents[Grading]].LessonSchedule[Program.Teachers[TeacherLoginNumber].HisLessons.Whichday] = "";
                Program.Teachers[TeacherLoginNumber].IndexesOfStudents.RemoveAt(Grading);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nYou have not any student!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
