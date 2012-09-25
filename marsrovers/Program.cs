using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using marsrovers.Entities;

namespace marsrovers
{
    class Program
    {
        /* MARS ROVERS by Acaz
         *
         * I comment some assumptions along the code of my design as my recruiter asked.
         * 
         * I tried to make a simple code without an over-engineering but is also flexible to change.
         */
        static void Main(string[] args)
        {
            string[] inputData = File.ReadAllLines("InputData.txt");

            var plateauLength = inputData[0].Split(' ');
            var rover1Position = inputData[1].Split(' ');
            var rover1Instructions = inputData[2];
            var rover2Position = inputData[3].Split(' ');
            var rover2Instructions = inputData[4];

            var plateau = new Plateau(Convert.ToInt32(plateauLength[0]), Convert.ToInt32(plateauLength[1]));

            //Rover 1
            plateau.InsertRover(new Rover(), new Position(Convert.ToInt32(rover1Position[0]), Convert.ToInt32(rover1Position[1]), ConvertToOrientation(Convert.ToChar(rover1Position[2]))));
            foreach (char instruction in rover1Instructions)
            {
                plateau.Rovers[0].ExecuteCommandByLetter(instruction);
            }
            Console.WriteLine(plateau.Rovers[0].ReportPosition());

            //Rover 2
            plateau.InsertRover(new Rover(), new Position(Convert.ToInt32(rover2Position[0]), Convert.ToInt32(rover2Position[1]), ConvertToOrientation(Convert.ToChar(rover2Position[2]))));
            foreach (char instruction in rover2Instructions)
            {
                plateau.Rovers[1].ExecuteCommandByLetter(instruction);
            }
            Console.WriteLine(plateau.Rovers[1].ReportPosition());

            Console.ReadLine();
        }

        /* I left this method here because I thought the responsibility that the conversion of input data would be where there is input data.
         * The way the input data will vary depending of the context/environment.
         */
        private static Orientation ConvertToOrientation(char orientationLetter)
        {
            switch (orientationLetter)
            {
                case 'N':
                    return Orientation.North;
                case 'E':
                    return Orientation.East;
                case 'S':
                    return Orientation.South;
                case 'W':
                    return Orientation.West;
                default:
                    return Orientation.North;
            }
        }
    }
}
