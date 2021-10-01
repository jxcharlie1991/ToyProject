using System;

/// <summary>
/// This project is designed by object oriented modeling, which has two classes Robot and UserOperate.
/// Date 1/Oct/2021
/// Author Li Chai
/// </summary>
namespace Robot
{
    /// <summary>
    /// The robot class is the object of a robot, including its location, how it understands the command, how it follows the user's command.
    /// </summary>
    class Robot
    {
        //Initialise the object, the comm should be unrecognise.
        public Robot()
        {
            this.Comm = Command.unrecognise;
        }
        //Enumeration
        public enum Direction { east, south, west, north }
        public enum Command { place, move, left, right, report, unrecognise }

        //Attributes RobLocX, RobLocy, RobLocF are robot's location, Comm is for the user's command, OnTable is whether on the table.
        public int RobLocX { get; set; }
        public int RobLocY { get; set; }
        public Direction RobLocF { get; set; }
        public Command Comm { get; set; } //This Comm is for the developer's breakpoint debugging.
        public bool OnTable { get; set; } //True means robot is on the table, false means robot is not on the table. 

        //Methods
        //Because the first command has to be a place command, 
        //thus separate the first command checking from the command checking would optimise the efficiency, and user would be more clear to input command.
        public void FirstCommandValidity(string input)
        {
            if (input.ToLower().StartsWith("place "))
            {
                string[] placeLoc = input.Substring(6).Split(',');
                if (int.TryParse(placeLoc[0], out int x) && int.TryParse(placeLoc[1], out int y) && Enum.IsDefined(typeof(Direction), placeLoc[2]))
                {
                    Direction f = (Direction)Enum.Parse(typeof(Direction), placeLoc[2]);
                    Comm = Command.place;
                    Place(x, y, f);
                }
                else
                {
                    Console.WriteLine("Please input a valid PLACE command as the first command.");
                    Comm = Command.unrecognise;
                }
            }
            else
            {
                Console.WriteLine("The first command has to be PLACE command, please try again.");
                Comm = Command.unrecognise;
            }
        }

        //Separate the validity checking would make the project easier to modify and update.
        public void CommandValidity(string input)
        {
            if (input.ToLower().StartsWith("place "))
            {
                string[] placeLoc = input.Substring(6).Split(',');
                if (int.TryParse(placeLoc[0], out int x) && int.TryParse(placeLoc[1], out int y) && Enum.IsDefined(typeof(Direction), placeLoc[2]))
                {
                    Direction f = (Direction)Enum.Parse(typeof(Direction), placeLoc[2]);
                    Comm = Command.place;
                    Place(x, y, f);
                }
                else
                {
                    Console.WriteLine("Please input a valid PLACE command as the first command.");
                    Comm = Command.unrecognise;
                }
            }
            else if (Enum.IsDefined(typeof(Command), input))
            {
                Comm = (Command)Enum.Parse(typeof(Command), input);
                switch (Comm)
                {
                    case Command.left:
                        Rotate();
                        break;
                    case Command.right:
                        Rotate();
                        break;
                    case Command.move:
                        Move();
                        break;
                    case Command.report:
                        Report();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid command input, please try again.");
                Comm = Command.unrecognise;
            }
        }

        // Place method contains two functionalities, 1. checking whether robot is on table, 2. record the location.
        public void Place(int x, int y, Direction f)
        {
            if (x >= 0 && x <= 5 && y >= 0 && y <= 5)
            {
                OnTable = true;
            }
            else
            {
                Console.WriteLine("This robot is not on the table.");
                OnTable = false;
            }
            RobLocX = x;
            RobLocY = y;
            RobLocF = f;
        }

        // Move method should tell user whether robot is on the table, and ensure robot would not fall from the table.
        public void Move()
        {
            if (!OnTable)
            {
                Console.WriteLine("The robot is not on the table");
            }
            {
                switch (RobLocF)
                {
                    case Direction.east:
                        if (RobLocX < 5)
                        {
                            RobLocX++;
                        }
                        else
                        {
                            Console.WriteLine("The robot is going to fall from the table.");
                        }
                        break;
                    case Direction.south:
                        if (RobLocY > 0)
                        {
                            RobLocY--;
                        }
                        else
                        {
                            Console.WriteLine("The robot is going to fall from the table.");
                        }
                        break;
                    case Direction.west:
                        if (RobLocX > 0)
                        {
                            RobLocX--;
                        }
                        else
                        {
                            Console.WriteLine("The robot is going to fall from the table.");
                        }
                        break;
                    case Direction.north:
                        if (RobLocY < 5)
                        {
                            RobLocY++;
                        }
                        else
                        {
                            Console.WriteLine("The robot is going to fall from the table.");
                        }
                        break;
                }
            }
        }

        public void Rotate()
        {
            if (!OnTable)
            {
                Console.WriteLine("The robot is not on the table");

            }
            else
            {
                if (Comm == Command.left)
                {
                    switch (RobLocF)
                    {
                        case Direction.east:
                            RobLocF = Direction.north;
                            break;
                        case Direction.south:
                            RobLocF = Direction.east;
                            break;
                        case Direction.west:
                            RobLocF = Direction.south;
                            break;
                        case Direction.north:
                            RobLocF = Direction.west;
                            break;
                    }
                }
                else
                {
                    switch (RobLocF)
                    {
                        case Direction.east:
                            RobLocF = Direction.south;
                            break;
                        case Direction.south:
                            RobLocF = Direction.west;
                            break;
                        case Direction.west:
                            RobLocF = Direction.north;
                            break;
                        case Direction.north:
                            RobLocF = Direction.east;
                            break;
                    }
                }
            }
        }

        public void Report()
        {
            Console.WriteLine(RobLocX + ", " + RobLocY + ", " + RobLocF.ToString().ToUpper());
        }
    }


    /// <summary>
    /// The userOperate class is the object of a user's operation. The robot will react after the user gives the command.
    /// </summary>
    class UserOperate
    {
        static void Main()
        {
            Robot rob = new Robot();
            string input;
 
            //The first command has to be a PLACE command.
            do
            {
                input = Console.ReadLine();
                rob.FirstCommandValidity(input);
            } while (rob.Comm != Robot.Command.place);

            do
            {
                input = Console.ReadLine();
                rob.CommandValidity(input);
            } while (rob.Comm != Robot.Command.report);
        }
    }
}

