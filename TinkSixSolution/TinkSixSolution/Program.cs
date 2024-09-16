using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinkSixSolution
{
    internal class Program
    {
        class Process
        {
            public int processTime { get; set; }
            public int[] processRelative { get; set; }
        }

        static void Main(string[] args)
        {
            int numberProc = Convert.ToInt32(Console.ReadLine());


            List<Process> process = new List<Process>();
            for (int i = 0; i < numberProc; i++)
            {
                Console.WriteLine("Введите колчество секунд и зависимые процессы");
                string infoProc = Console.ReadLine();
                int processTime = Convert.ToInt32(infoProc.Trim().Split(' ')[0]);
                int[] processRelative = new int[infoProc.Trim().Split(' ').Length - 1];
                for (int j = 0; j < infoProc.Trim().Split(' ').Length - 1; j++)
                {
                    processRelative[j] = Convert.ToInt32(infoProc.Trim().Split(' ')[j + 1]);
                }
                process.Add(new Process()
                {
                    processTime = processTime,
                    processRelative = processRelative
                });
            }
            int? result = 0;
            bool check = true;
            while (check)
            {
                bool[] chekers = new bool[numberProc];
                int proccesNumber = 0;
                foreach (Process proc in process)
                {
                    if (proc.processTime <= 0)
                    {
                        chekers[proccesNumber] = true;
                        proccesNumber++;
                        continue;
                    }
                    if (proc.processRelative == null)
                    {
                        proc.processTime -= 1;
                    }
                    bool inProcessChecker = true;
                    for (int i = 0; i < proc.processRelative.Length; i++)
                    {
                        int relativeNum = proc.processRelative[i];
                        if (process[relativeNum - 1].processTime != 0)
                        {
                            inProcessChecker = false;
                            break;
                        }
                    }
                    if (inProcessChecker)
                        proc.processTime -= 1;

                    proccesNumber++;
                }

                if (chekers.Contains(false))
                {
                    result++;
                }
                else
                {
                    check = false;
                    break;
                }

            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
