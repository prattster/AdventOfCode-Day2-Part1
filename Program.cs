using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalPosition = ReadLines()
                .Select(line => new {direction = line.Split(' ')[0], magnitude = int.Parse(line.Split(' ')[1])})
                .Select(instruction =>
                {
                    switch (instruction.direction)
                    {
                        case "forward":
                            return new {horizontal = instruction.magnitude, depth = 0};
                        case "down":
                            return new {horizontal = 0, depth = instruction.magnitude};
                        case "up":
                            return new {horizontal = 0, depth = -instruction.magnitude};
                        default:
                            throw new Exception($"invalid instruction {instruction.magnitude} {instruction.direction}");
                    }

                })
                .Aggregate((sum, next) => new
                    {horizontal = sum.horizontal + next.horizontal, depth = sum.depth + next.depth});

            Console.WriteLine(finalPosition.depth * finalPosition.horizontal);
                
                
            Console.ReadKey();
        }

        static IEnumerable<string> ReadLines()
        {
            return File.ReadLines(@"input.txt");
        }
        
    }
}
