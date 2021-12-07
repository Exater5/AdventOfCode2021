using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InputReader
{
    public static string[] ReadInputInLines(int day, int part)
    {
        string[] lines = File.ReadAllLines($"{Application.dataPath}/Resources/Inputs/day{day}_{part}.txt");
        return lines;
    }
}
