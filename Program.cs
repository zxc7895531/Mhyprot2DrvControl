using MhyProt2Drv.Driver;
using MhyProt2Drv.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MhyProt2Drv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            DrvLoader loader = new DrvLoader();
            loader.Load();
            MhyProt2 mhyprot = new MhyProt2();
            mhyprot.OpenDrv();
            bool res = mhyprot.InitDrv((ulong)Process.GetCurrentProcess().Id);
            if (!res)
            {
                Console.WriteLine("Init Error!");
            }
            else
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("请输入一个进程名!")
                }
                else
                {
                    string name = args[0].ToString()
                    Console.WriteLine("Getting pid...");
                    uint pid = (uint)Process.GetProcessesByName(name)[0].Id;
                    Console.WriteLine(pid);
                    Console.WriteLine("Killing...");
                    mhyprot.KillProcess(pid);
                }
            }
            mhyprot.CloseHandle();
            loader.UnLoad();
        }
    }
}
