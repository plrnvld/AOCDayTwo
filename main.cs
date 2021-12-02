using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");

    var inputs = ReadFile("Input.txt").Select(ParseLine);
    var aim = 0;
    var forward = 0;
    var depth = 0;

    foreach(var (dir, num) in inputs)
    {
      switch(dir)
      {
        case Direction.Up: aim -= num; break;
        case Direction.Down: aim += num; break;
        case Direction.Forward: forward += num; depth += aim * num; break;

        default: throw new Exception("Everything is wrong.");
      }      
    }

    Console.WriteLine ($"Forward:{forward}, Depth:{depth}, Res:{forward * depth}.");
  }

  public static IEnumerable<string> ReadFile(string fileName)
  {
    return File.ReadAllLines(fileName);
  }

  static (Direction dir, int num) ParseLine(string line)
  {
    var parts = line.Split(' ');
    Direction direction;
    switch(parts[0])
    {
      case "up": direction = Direction.Up; break;
      case "down": direction = Direction.Down; break;
      case "forward": direction = Direction.Forward; break;
      default: throw new Exception($"'{line}' is not parsable.");
    }

    var num = int.Parse(parts[1]);

    return (direction, num);
  } 

  public enum Direction
  {
    Up,
    Down,
    Forward
  }
}