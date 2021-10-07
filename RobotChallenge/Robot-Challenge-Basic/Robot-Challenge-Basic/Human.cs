﻿using System;

namespace Robot_Challenge_Basic
{
    class Human
    {
        //Attributes
        //There is only one human user and at least one human user, so it is better to declare static attributes.
        public static Robot rob = new Robot();
        public static int CommLocX { get; set; }
        public static int CommLocY { get; set; }
        public static Enumerations.Direction CommLocF { get; set; }
        public static Enumerations.Command Comm { get; set; }

        //Methods
        //There is only one human user and at least one human user, so it is better to declare static methods.
        //Because the first command has to be a place command, 
        //thus separate the first command checking from the command checking would optimise the efficiency, and user would be more clear to input command.
        public static void AnalyseFirstCommand(string userInput)
        {
            if (userInput.ToLower() == "exit")
            {
                Comm = Enumerations.Command.exit;
            }
            else if (userInput.ToLower().StartsWith("place "))
            {
                string[] placeLoc = userInput.Substring(6).Split(',');
                if (int.TryParse(placeLoc[0], out int x) && int.TryParse(placeLoc[1], out int y) && Enum.IsDefined(typeof(Enumerations.Direction), placeLoc[2]))
                {
                    if (Ground.CheckOntable(x, y))
                    {
                        Enumerations.Direction f = (Enumerations.Direction)Enum.Parse(typeof(Enumerations.Direction), placeLoc[2]);
                        Comm = Enumerations.Command.place;
                        CommLocX = x;
                        CommLocY = y;
                        CommLocF = f;
                    }
                    else
                    {
                        Console.WriteLine("This robot is not on the table, this command would not execute, you MUST place the robot on the table.");
                        Comm = Enumerations.Command.unrecognise;
                    }
                }
                else
                {
                    Console.WriteLine("Please input a valid PLACE command as the first command.");
                    Comm = Enumerations.Command.unrecognise;
                }
            }
            else
            {
                Console.WriteLine("The first command has to be PLACE command, please try again.");
                Comm = Enumerations.Command.unrecognise;
            }
        }

        //Separate the validity checking would make the project easier to modify and update.
        public static void AnalyseCommand(string userInput)
        {
            if (userInput.ToLower().StartsWith("place "))
            {
                string[] commLoc = userInput.Substring(6).Split(',');
                if (int.TryParse(commLoc[0], out int x) && int.TryParse(commLoc[1], out int y) && Enum.IsDefined(typeof(Enumerations.Direction), commLoc[2]))
                {
                    if (Ground.CheckOntable(x, y))
                    {
                        Enumerations.Direction f = (Enumerations.Direction)Enum.Parse(typeof(Enumerations.Direction), commLoc[2]);
                        Comm = Enumerations.Command.place;
                        CommLocX = x;
                        CommLocY = y;
                        CommLocF = f;
                    }
                    else
                    {
                        Console.WriteLine("This robot is not on the table, this command would not execute, you MUST place the robot on the table.");
                        Comm = Enumerations.Command.unrecognise;
                    }
                }
                else
                {
                    Console.WriteLine("Please input a valid PLACE command.");
                    Comm = Enumerations.Command.unrecognise;
                }
            }            
            else if (Enum.IsDefined(typeof(Enumerations.Command), userInput))
            {
                Comm = (Enumerations.Command)Enum.Parse(typeof(Enumerations.Command), userInput);
            }
            else
            {
                Console.WriteLine("Invalid command input, please try again.");
                Comm = Enumerations.Command.unrecognise;
            }
        }
        public static void Instruction()
        {
            Console.WriteLine("Dear user,");
            Console.WriteLine("");
            Console.WriteLine("The application is a simulation of a robot moving on a square tabletop, of dimensions 5 units x 5 units.");
            Console.WriteLine("There are no other obstructions on the table surface, the robot is free to roam around the surface of the table.But any movement that would result in the robot falling from the table would be ignored with an alarming message.");
            Console.WriteLine("");
            Console.WriteLine("There are also some rules for the command:");
            Console.WriteLine("The first command must be PLACE command.");
            Console.WriteLine("");
            Console.WriteLine("PLACE should be like PLACE X, Y, direction. For example: ");
            Console.WriteLine("PLACE 2, 3, NORTH");
            Console.WriteLine("PLACE will put the robot in position X, Y and facing NORTH, SOUTH, EAST or WEST.");
            Console.WriteLine("PLACE command is not allowed to place the robot on the ground, it MUST place the robot on the table.");
            Console.WriteLine("");
            Console.WriteLine("MOVE command will move the robot one unit forward in the direction it is currently facing. For example: ");
            Console.WriteLine("MOVE");
            Console.WriteLine("");
            Console.WriteLine("ROTATE command would rotate the robot 90 degrees, the effective command contains LEFT and RIGHT. For example: ");
            Console.WriteLine("LEFT");
            Console.WriteLine("");
            Console.WriteLine("REPORT command will announce the X, Y and facing of the robot. For example: ");
            Console.WriteLine("REPORT");
            Console.WriteLine("");
            Console.WriteLine("EXIT command will exit the program. For example: ");
            Console.WriteLine("EXIT");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("If you understand this INTRODUCTION, please input: UNDERSTAND");
            string introInput;
            while (true)
            {
                introInput = Console.ReadLine().ToLower();
                if (introInput == "understand")
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid PLACE command as the first command.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please input UNDERSTAND.");
                }
            }
        }
        public static void Place()
        {
            rob.RobLocX = CommLocX;
            rob.RobLocY = CommLocY;
            rob.RobLocF = CommLocF;
        }
       

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
