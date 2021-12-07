using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day6 : MonoBehaviour
{
    List<int> initialNumbers;
    List<List<int>> newFishes;
    void Start()
    {
        Problem1();
    }

    public void Problem1()
    {
        string[] rawInput = InputReader.ReadInputInLines(6, 0);
        initialNumbers = new List<int>();
        newFishes = new List<List<int>>();
        for (int i = 0; i < 8; i++)
        {
            newFishes.Add(new List<int>());
        }

        foreach (char c in rawInput[0])
        {
            if (c != ',')
            {
                initialNumbers.Add(int.Parse(c.ToString()));
            }
        }

        Dictionary<int, long> fishes = new Dictionary<int, long>();

        for(int i = 0; i<9; i++)
        {
            fishes.Add(i,0);
        }


        for(int i = 0; i<initialNumbers.Count; i++)
        {
            fishes[initialNumbers[i]] = fishes[initialNumbers[i]] +1;
        }

        for (int i = 0; i < 256; i++)
        {
            long before = fishes[0];
            for (int j = 0; j < fishes.Count - 1; j++)
            {
                fishes[j] = fishes[j +1];
            }
            fishes[8] = before;
            fishes[6] += before;
        }

        long sum = 0;

        for (int i = 0; i < fishes.Count; i++)
        {
            sum += fishes[i];
        }
        print(sum);
    }
}
