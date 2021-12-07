using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2 : MonoBehaviour
{

    void Start()
    {
        Problem1();
    }

    public void Problem1()
    {
        string[] rawInput = InputReader.ReadInputInLines(2, 0);
        List<string> directions = new List<string>();
        List<int> amounts = new List<int>();
        foreach (string s in rawInput)
        {
            string[] spl = s.Split(' ');
            directions.Add(spl[0]);
            amounts.Add(int.Parse(spl[1]));
        }

        int aim = 0;
        int horizontal = 0;
        int depth = 0;

        for (int i = 0; i < directions.Count; i++)
        {
            if (directions[i] == "up")
            {
                aim -= amounts[i];
            }
            else if (directions[i] == "down")
            {
                aim += amounts[i];
            }
            else
            {
                horizontal += amounts[i];
                depth += aim * amounts[i];
            }
        }

        print(depth * horizontal);
    }
}
