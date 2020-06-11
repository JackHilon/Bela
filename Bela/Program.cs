using System;

namespace Bela
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bela problem
            // https://open.kattis.com/problems/bela

            // card number = {A, K, Q, J, T, 9, 8, 7}
            // suit = {S, H, D, C}

            //  Number                    Value
            //                    Dominant  |   Not Dominant
            //..............................|.....................
            //    A                  11     |       11
            //    k                   4     |        4
            //    Q                   3     |        3
            //    J                  20     |        2
            //    T                  10     |        10
            //    9                  14     |        0
            //    8                   0     |        0
            //    7                   0     |        0
            //..............................|......................


            Console.WriteLine(MyProgram());
        }

        private static int MyProgram()
        {
            var myFirstLine = EnterFirstLine();
            int NumOfHands = (int)myFirstLine[0];
            string DominantSuit = (string)myFirstLine[1];

            int myCount = NumOfHands * 4;

            int myVal = 0;
            for (int i = 0; i < myCount; i++)
            {
                myVal = myVal + ReadCardValue(DominantSuit);
            }
            return myVal;
        }

        private static int ReadCardValue(string suit)
        {
            string str = " ";
            try
            {
                str = Console.ReadLine();
                if(CardValidate(str) == false)
                    throw new FormatException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message +" || " + ex.GetType().ToString());
                return ReadCardValue(suit);
            }
            var str1 = str[0];
            var str2 = str[1].ToString();
            switch (str1)
            {
                case 'A':
                    return 11;
                case 'K':
                    return 4;
                case 'Q':
                    return 3;
                case 'J':
                    if (str2 == suit)
                        return 20;
                    else return 2;
                case 'T':
                    return 10;
                case '9':
                    if (str2 == suit)
                        return 14;
                    else return 0;
                default:
                    return 0;
            }
        }

        private static bool CardValidate(string s)
        {
            // card number = {A, K, Q, J, T, 9, 8, 7}
            // suit = {S, H, D, C}
            var s1 = s[0];
            var s2 = s[1];
            if (s.Length != 2)
                return false;
            if ((s1 == 'A' || s1 == 'K' || s1 == 'Q' || s1 == 'J' || s1 == 'T' || s1 == '9' ||
                s1 == '8' || s1 == '7') && (s2 == 'S' || s2 == 'H' || s2 == 'D' || s2 == 'C'))
                return true;
            else
                return false;
        }

        private static object[] EnterFirstLine()
        {
            object[] result = new object[2] { 1, "S" };
            int a = 1;
            string b = " ";
            var strArr = new string[2] { " ", " "};
            var str = "";
            str = Console.ReadLine();
            str = str.ToUpper();
            try
            {
                strArr = str.Split(' ', 2);
                a = int.Parse(strArr[0]);
                if (a <= 0)
                    throw new ArgumentException();
                b = strArr[1];
                if(SuitCheck(b) == false)
                    throw new ArgumentException();
                result[0] = a;
                result[1] = b;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.GetType().ToString());
                result = EnterFirstLine();
                return result;
            }
            return result;
        }

        private static bool SuitCheck(string s)
        {
            if (s == "S" || s == "H" ||
                s == "D" || s == "C")
                return true;
            else
                return false;
        }
    }
}
