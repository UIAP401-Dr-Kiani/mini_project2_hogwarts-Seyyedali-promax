using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hogwartz_hoseynzadeh2
{
    class ProjectMethodsLibrary
    {
        //Show
        public void show(string[] Members, string Introduction)
        {
            Console.WriteLine(Introduction + "\n--------------------\n");
            for (int i = 0; i < Members.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {Members[i]} \n");
            }
        }
        public void showList(List<string> Members, string Introduction)
        {
            Console.WriteLine(Introduction + "\n--------------------\n");
            for (int i = 0; i < Members.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {Members[i]} \n");
            }
        }
        //Choise
        public int Choise(string[] Choises, string Ask)
        {
            string Choise;
            int ChoiseInt = 0;
            while (1 == 1)
            {
                Console.WriteLine("--------------------\n" + Ask + "\n--------------------");
                for (int i = 0; i < Choises.Length; i++)
                {
                    Console.WriteLine($"({i + 1}) {Choises[i]}");
                }

                Choise = (Console.ReadLine());
                try
                {
                    ChoiseInt = Convert.ToInt32(Choise);
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (ChoiseInt > Choises.Length || ChoiseInt < 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a valid number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            return ChoiseInt;
        }
        //Reading File
        public void ReadingFile()
        {
            using (StreamReader File = new StreamReader("file.tsv"))
            {
                string ln;
                while ((ln = File.ReadLine()) != null)
                {
                    string[] Human = ln.Split('\t').ToArray<string>();
                    if (Human[8] == "teacher")
                    {
                        //Human vars
                        Program.Teachers[Program.TeacherIndex].Name = Human[0];

                        Program.Teachers[Program.TeacherIndex].Family = Human[1];
                        Program.Students[Program.StudentIndex].BirthYear = Convert.ToString(Human[2][0]) + Convert.ToString(Human[2][1]) + Convert.ToString(Human[2][2]) + Convert.ToString(Human[2][3]);
                        Program.Teachers[Program.TeacherIndex].gender = Human[3];
                        Program.Teachers[Program.TeacherIndex].FatherName = Human[4];
                        Program.Teachers[Program.TeacherIndex].Username = Human[5];
                        Program.Teachers[Program.TeacherIndex].Password = Human[6];
                        Program.Teachers[Program.TeacherIndex].Race = Human[7];
                        Program.Teachers[Program.TeacherIndex].Role = Human[8];
                        //Aouthorized human vars
                        Program.Teachers[Program.TeacherIndex].HisGroup = Program.MyMethods.GroupDeterminator(Program.Teachers[Program.TeacherIndex]);
                        Program.Teachers[Program.TeacherIndex].pet = Program.MyMethods.PetDeterminator(Program.Teachers[Program.TeacherIndex]);
                        Program.Teachers[Program.TeacherIndex].HaveBaggage = true;
                        Program.TeacherIndex++;

                    }
                    else if (Human[8] == "student")
                    {
                        //Human vars
                        Program.Students[Program.StudentIndex].Name = Human[0];
                        Program.Students[Program.StudentIndex].Family = Human[1];
                        Program.Students[Program.StudentIndex].BirthYear = Convert.ToString(Human[2][0]) + Convert.ToString(Human[2][1]) + Convert.ToString(Human[2][2]) + Convert.ToString(Human[2][3]);
                        Program.Students[Program.StudentIndex].gender = Human[3];
                        Program.Students[Program.StudentIndex].FatherName = Human[4];
                        Program.Students[Program.StudentIndex].Username = Human[5];
                        Program.Students[Program.StudentIndex].Password = Human[6];
                        Program.Students[Program.StudentIndex].Race = Human[7];
                        Program.Students[Program.StudentIndex].Role = Human[8];
                        //Aouthorized human vars
                        Program.Students[Program.StudentIndex].HisGroup = Program.MyMethods.GroupDeterminator(Program.Students[Program.StudentIndex]);
                        Program.Students[Program.StudentIndex].pet = Program.MyMethods.PetDeterminator(Program.Students[Program.StudentIndex]);
                        Program.Students[Program.StudentIndex].HaveBaggage = true;
                        Program.Students[Program.StudentIndex].DormOfStudent = DormDeterminator(Program.Students[Program.StudentIndex]);
                        //student vars
                        Program.Students[Program.StudentIndex].Ticket = true;
                        Program.StudentIndex++;
                    }
                }
                File.Close();
            }
        }
        //Random Group and pet determinating
        public Group GroupDeterminator(AouthorizedHuman Applicant)
        {
            Group Result = Program.Gryffindor;
            int RandomNumber = Convert.ToInt32(Applicant.Name[0]) + Convert.ToInt32(Applicant.Password[0]) + 14;
            Random Rnd = new Random(RandomNumber);
            switch (Rnd.Next(RandomNumber) % 4)
            {
                case 0:
                    Result = Program.Gryffindor;
                    break;
                case 1:
                    Result = Program.Hufflepuff;
                    break;
                case 2:
                    Result = Program.Ravenclaw;
                    break;
                case 3:
                    Result = Program.Slytherin;
                    break;
            }
            return Result;
        }
        public string PetDeterminator(AouthorizedHuman Applicant)
        {
            string pet = " ";
            int RandomNumber = Convert.ToInt32(Applicant.Name[0]) + Convert.ToInt32(Applicant.Family[0]) + 8;
            Random Rnd = new Random(RandomNumber);
            switch (Rnd.Next(RandomNumber) % 4)
            {
                case 0:
                    pet = "Owl";
                    break;
                case 1:
                    pet = "Cat";
                    break;
                case 2:
                    pet = "Rat";
                    break;
                case 3:
                    pet = "Pigeon";
                    break;
            }
            return pet;
        }
        //Dorm determinating
        public Dorm DormDeterminator(AouthorizedHuman Applicant)
        {
            //even floor = 20 room , even room = 4 bed
            Dorm Result = new Dorm();
            Result.Gender = 2;
            if (Applicant.gender == "male")
            {
                Result.Gender = 1;
            }
            if (Applicant.gender == "male" && Applicant.HisGroup.Groupname == "Gryffindor")
            {
                Result.GroupOfDorm = Program.Gryffindor;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.GryffindorMaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.GryffindorMaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.GryffindorMaleDormMembers % 80) % 20) % 4));
                Program.GryffindorMaleDormMembers++;
            }
            if (Applicant.gender == "female" && Applicant.HisGroup.Groupname == "Gryffindor")
            {

                Result.GroupOfDorm = Program.Gryffindor;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.GryffindorFemaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.GryffindorFemaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.GryffindorFemaleDormMembers % 80) % 20) % 4));
                Program.GryffindorFemaleDormMembers++;
            }
            if (Applicant.gender == "male" && Applicant.HisGroup.Groupname == "Hufflepuff")
            {
                Result.GroupOfDorm = Program.Hufflepuff;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.HufflepuffMaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.HufflepuffMaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.HufflepuffMaleDormMembers % 80) % 20) % 4));
                Program.HufflepuffMaleDormMembers++;
            }
            if (Applicant.gender == "female" && Applicant.HisGroup.Groupname == "Hufflepuff")
            {

                Result.GroupOfDorm = Program.Hufflepuff;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.HufflepuffFemaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.HufflepuffFemaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.HufflepuffFemaleDormMembers % 80) % 20) % 4));
                Program.HufflepuffFemaleDormMembers++;
            }
            if (Applicant.gender == "male" && Applicant.HisGroup.Groupname == "Ravenclaw")
            {

                Result.GroupOfDorm = Program.Ravenclaw;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.RavenclawMaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.RavenclawMaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.RavenclawMaleDormMembers % 80) % 20) % 4));
                Program.RavenclawMaleDormMembers++;
            }
            if (Applicant.gender == "female" && Applicant.HisGroup.Groupname == "Ravenclaw")
            {

                Result.GroupOfDorm = Program.Ravenclaw;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.RavenclawFemaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.RavenclawFemaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.RavenclawFemaleDormMembers % 80) % 20) % 4));
                Program.RavenclawFemaleDormMembers++;
            }
            if (Applicant.gender == "male" && Applicant.HisGroup.Groupname == "Slytherin")
            {

                Result.GroupOfDorm = Program.Slytherin;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.SlytherinMaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.SlytherinMaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.SlytherinMaleDormMembers % 80) % 20) % 4));
                Program.SlytherinMaleDormMembers++;
            }
            if (Applicant.gender == "female" && Applicant.HisGroup.Groupname == "Slytherin")
            {

                Result.GroupOfDorm = Program.Slytherin;
                Result.Floor = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble(Program.SlytherinFemaleDormMembers) / Convert.ToDouble(4 * 20)));
                Result.Room = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.SlytherinFemaleDormMembers % 80)) / Convert.ToDouble(4)));
                Result.Bed = 1 + Convert.ToInt32(Math.Floor(Convert.ToDouble((Program.SlytherinFemaleDormMembers % 80) % 20) % 4));
                Program.SlytherinFemaleDormMembers++;
            }
            Result.StaticCode = Result.Gender * 1000 + Result.Floor * 100 + Result.Room * 10 + Result.Bed * 1;
            return Result;
        }
        //Grading
        public int Grading(string Ask, int max)
        {
            string Choise;
            int ChoiseInt = 0;
            while (1 == 1)
            {
                Console.WriteLine("--------------------\n" + Ask + "\n--------------------");
                Choise = (Console.ReadLine());
                try
                {
                    ChoiseInt = Convert.ToInt32(Choise);
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (ChoiseInt > max || ChoiseInt < 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please enter a valid number.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }
            return ChoiseInt;
        }
        //Delay after process
        public void DelayRerun(int Time)
        {
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < Time; i++)
            {
                Console.WriteLine($"You will be returned to the previous window after {Time - i} seconds.");
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
    }
}
