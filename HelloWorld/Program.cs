
/*
Activity 
Follow the instruction for each of the c# code segments below. Run the programs to answer the 
questions on TLZ (Processor Scheduling Quiz)  
Shortest Job Next 




using System;
using System.Collections.Generic;
using System.Linq;

public class Process
{
    public int Id { get; set; }
    public int ArrivalTime { get; set; }
    public int BurstTime { get; set; }
    public int WaitingTime { get; set; }
    public int TurnaroundTime { get; set; }
}

public class SJNSimulator
{
    public static void RunSimulation(List<Process> processes)
    {
        Console.WriteLine("ProcessId\tArrivalTime\tBurstTime\tWaitingTime\tTurnaroundTime");

        int currentTime = 0;
        int completed = 0;

        while (completed < processes.Count)
        {
            var currentProcess = processes
                .Where(p => p.ArrivalTime <= currentTime)
                .OrderBy(p => p.BurstTime)
                .ThenBy(p => p.ArrivalTime)
                .FirstOrDefault();

            if (currentProcess == null)
            {
                currentTime++;
                continue;
            }

            currentProcess.WaitingTime = currentTime - currentProcess.ArrivalTime;

            currentProcess.TurnaroundTime =
                currentProcess.WaitingTime + currentProcess.BurstTime;

            currentTime += currentProcess.BurstTime;

            Console.WriteLine($"{currentProcess.Id}\t\t{currentProcess.ArrivalTime}\t\t{currentProcess.BurstTime}\t\t{currentProcess.WaitingTime}\t\t{currentProcess.TurnaroundTime}");

            processes.Remove(currentProcess);

            completed++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>
            {
                new Process { Id = 1, ArrivalTime = 0, BurstTime = 8 },
                new Process { Id = 2, ArrivalTime = 1, BurstTime = 4 },
                new Process { Id = 3, ArrivalTime = 2, BurstTime = 9 },
                new Process { Id = 4, ArrivalTime = 3, BurstTime = 5 }
            };

            SJNSimulator.RunSimulation(processes);

            Console.ReadLine();
        }
    }
}

*/




//Round Robin  
//Complete and run the code segment below in order to calculate the waiting time and turnaround time 
//for each process. 

using System;
using System.Collections.Generic;

class Process {

    public int Id;
    public int BurstTime;
    public int RemainingTime;

    public Process(int id, int burstTime) {
        Id = id;
        BurstTime = burstTime;
        RemainingTime = burstTime;
    }
}

class RoundRobinSimulation {

    static void Main() {

        Queue<Process> queue = new Queue<Process>();

        queue.Enqueue(new Process(1, 8));
        queue.Enqueue(new Process(2, 4));
        queue.Enqueue(new Process(3, 9));
        queue.Enqueue(new Process(4, 5));

        int quantum = 3;
        int currentTime = 0;

        while (queue.Count > 0) {

            Process p = queue.Dequeue();

            int timeSpent = Math.Min(p.RemainingTime, quantum);

            p.RemainingTime -= timeSpent;

            currentTime += timeSpent;

            Console.WriteLine($"Time {currentTime}: Process {p.Id} runs, Remaining: {p.RemainingTime}");

            if (p.RemainingTime > 0) {
                queue.Enqueue(p); // Re-queue if not finished
            }
        }
    }
}