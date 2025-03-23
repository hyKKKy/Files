

namespace ConsoleApp25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1();
            //task2("hello", "bye");
            Moderator("start.txt", "end.txt");
        }

        static void task1()
        { 
            Random r = new Random();
            List<int> primeList = new List<int>();
            List<int> fibonacciList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int number = r.Next(1,101);
                if (IsPrime(number))
                {
                    primeList.Add(number);
                }
                if (IsFibonacci(number))
                {
                    fibonacciList.Add(number);
                }
            }
            File.WriteAllLines("prime.txt", primeList.ConvertAll(n => n.ToString()));

            File.WriteAllLines("fibonacci.txt", fibonacciList.ConvertAll(n => n.ToString()));

        }

        static void task2(string input, string change)
        {
            string words = File.ReadAllText("words.txt");
            if (words.Contains(input))
            {
                string newWords = words.Replace(input, change);
                File.WriteAllText("words.txt", newWords);
            }
        }
        static void Moderator(string path1, string path2)
        {
            string words1 = File.ReadAllText(path1);
            string[] words2 = File.ReadAllLines(path2);
            foreach (string word in words2) 
            { 
                string stars = new string('*', word.Length);
                words1 = words1.Replace(word, stars);
            }
            File.WriteAllText(path1, words1);
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;

            for (int i = 5; i * i <= number; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static bool IsFibonacci(int number)
        {
            int a = 0, b = 1;
            while (b < number)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b == number || number == 0;
        }
    }
}
