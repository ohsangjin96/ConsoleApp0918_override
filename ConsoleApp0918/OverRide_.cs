using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0918
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }
        public override string ToString()
        {
            string str = "성: {this.FirstName} 이름: {this.LastName}";      //문자열은 더하면 안좋은 코드다

            return str;
        }

        public override bool Equals(object obj)
        {
         //if (obj is Person)
            //{
            //    Person temp = (Person)obj;

            //    if (this.FirstName == temp.FirstName && this.LastName==temp.LastName) return true;
            //    else return false;
            //}
            //else
            //    return false;   

           return obj is Person temp && FirstName == temp.FirstName && LastName == temp.LastName;
        }

        public override int GetHashCode()
        {
            int result = EqualityComparer<string>.Default.GetHashCode(FirstName);
            result += EqualityComparer<string>.Default.GetHashCode(LastName);

            return result;
        }
    }


    class OverRide_
    {
        static void Main(string[] args)
        {
           
            Person per = new Person("류", "현진");
          
            Console.WriteLine(per.ToString());

            Person per2 = new Person("류", "현진");

            if(per.Equals(per2))//Equals는 인스턴스가 같냐 안같냐를 알려주는 함수(new를 할때마다 인스턴스가 생기므로 false가 계속 나온다)
                Console.WriteLine("동일한 이름입니다.");
            else
                Console.WriteLine("다른 이름입니다.");

            string str = "류현진";
            string str2 = "류현진";
            if (str.Equals(str2))
                Console.WriteLine("동일한 이름입니다.");
            else
                Console.WriteLine("다른 이름입니다.");
            //Type t1= per.GetType()
            //Type t2 = typeof(Person);
            Console.WriteLine(per.GetHashCode());
            Console.WriteLine(per2.GetHashCode());

        }
    }
}
//this= 클래스 내부에서 자기 자신의 멤버를 가르킬때
//정적(static)일때는 this안쓰고 class 명을 쓴다.