using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwartz_hoseynzadeh2
{
    class AouthorizedHuman:Human
    {
      public Dorm DormOfStudent = new Dorm();
      public string[] LessonSchedule = new string[5] {"","","","",""};
      public string pet;
      public bool HaveBaggage;
      public Group HisGroup = new Group();
      public List<string> Letters = new List<string>(); 
    }
}
