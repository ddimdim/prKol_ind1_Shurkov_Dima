using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stack<int> numbers = new Stack<int>();
                Stack<char> mp = new Stack<char>();
                StreamReader sr = new StreamReader("math.txt");
                string line = sr.ReadLine();
                foreach (char ch in line)
                {
                    if (ch == 'm' || ch == 'p')
                    {
                        mp.Push(ch);
                    }
                    else if (char.IsDigit(ch))
                    {
                        numbers.Push(int.Parse(ch.ToString()));
                    }
                    else if (ch == ')')
                    {
                        int b = numbers.Pop();
                        int a = numbers.Pop();
                        if (mp.Pop() == 'p')
                        {
                            numbers.Push((a + b) % 10);
                        }
                        else 
                        {
                            numbers.Push((a - b) % 10);
                        }
                    }
                }
                Console.WriteLine($"{line} = {numbers.Pop()}");
                sr.Close();
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Файл с примером был не найден или пример был введен некорректно");
                Console.ReadKey();
            }
        }
    }
}
