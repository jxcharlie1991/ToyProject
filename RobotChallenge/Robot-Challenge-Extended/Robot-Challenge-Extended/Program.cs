// This project is for the ioof's requirement.
// Date 2/Oct/2021
// Author Li Chai
using System;

namespace Robot_Challenge_Extended
{
    class Program
    {
        static void Main()
        {
            string input;
            Human.Instruction();

            //Read Human user's first command.
            do
            {
                input = Console.ReadLine();
                Human.AnalyseFirstCommand(input);
                if (Human.Comm == Enumerations.Command.place)
                {
                    Human.Place();
                }
            } while (Human.Comm != Enumerations.Command.place);

            //Read Human user's command
            do
            {
                input = Console.ReadLine();
                Human.AnalyseCommand(input);
                Human.robs[Human.ManipulateSerial - 1].ExecuteCommand();
            } while (true);
        }
    }
}
