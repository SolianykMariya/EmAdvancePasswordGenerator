using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        class Base
        {
            public int Lenguage = 0;
            public int Length = 0;
            public string Numbers = "1234567890";
            public string Symbols = "@#$%";

            public Base(int length, int lenguage)
            {
                if (length < 6)
                {
                    throw new ArgumentException("You can`t generate password shorter than 6 symbols");
                }
                this.Length = length;
                this.Lenguage = lenguage;
            }

        }
        class EngPassword : Base
        {
            public EngPassword(int length) : base(length, 0) { }

            private string LowerChars = "abcdefghijklmnopqrstuvwxyz";
            private string UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            private char Randomizer(Random random)
            {
                string allChars = LowerChars + UpperChars + Numbers;
                return allChars[random.Next(allChars.Length)];
            }
            public string GenerateEngPassword()
            {
                StringBuilder password = new StringBuilder();
                Random random = new Random();

                password.Append(UpperChars[random.Next(UpperChars.Length)]);
                password.Append(LowerChars[random.Next(LowerChars.Length)]);
                password.Append(Numbers[random.Next(Numbers.Length)]);

                for (int i = 3; i < Length; i++)
                {
                    if (i > 0 && i % 5 == 0)
                    {
                        password.Append(Symbols[random.Next(Symbols.Length)]);
                    }
                    else
                    {
                        password.Append(Randomizer(random));
                    }
                }
                return password.ToString();


            }
        }
        class UaPassword : Base
        {
            public UaPassword(int length) : base(length, 1) { }

            private string LowerChars = "абвгдеєжзиїйклмнопрстуфхцчшщьюя";
            private string UpperChars = "АБВГҐДЕЄЖЗИЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";

            private char Randomizer(Random random)
            {
                string allChars = LowerChars + UpperChars + Numbers;
                return allChars[random.Next(allChars.Length)];
            }
            public string GenerateUaPassword()
            {
                StringBuilder password = new StringBuilder();
                Random random = new Random();
                password.Append(UpperChars[random.Next(UpperChars.Length)]);
                password.Append(LowerChars[random.Next(LowerChars.Length)]);
                password.Append(Numbers[random.Next(Numbers.Length)]);

                for (int i = 3; i < Length; i++)
                {
                    if (i > 0 && i % 5 == 0)
                    {
                        password.Append(Symbols[random.Next(Symbols.Length)]);
                    }
                    else
                    {
                        password.Append(Randomizer(random));
                    }
                }
                return password.ToString();

            }

        }


        static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("Enter the length of password(6 symbols min)");
                int length = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter and index of lenguage of your password:\n0 for English\n1 for Ukrainian");
                int lenguage = Convert.ToInt32(Console.ReadLine());

                if (lenguage == 0)
                {
                    EngPassword engPassword = new EngPassword(length);
                    string EngPassword = engPassword.GenerateEngPassword();
                    Console.WriteLine("Generated english password:" + EngPassword);
                }
                else if (lenguage == 1)
                {
                    UaPassword uaPassword = new UaPassword(length);
                    string UaPassword = uaPassword.GenerateUaPassword();
                    Console.WriteLine("Generated ukrainian password:" + UaPassword);
                }
                else
                {
                    throw new Exception("Invalid lenguage index!!! Try again");
                }
            }
            
        }
    }
}
