using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day10 : MonoBehaviour
{
    string inChars = "([{<";
    string outChars = ")]}>";
    [SerializeField] string[] rawInput;
    [SerializeField] bool next;
    int currentRaw = 0;
    [SerializeField] long totalPoints = 0;
    [SerializeField] List<long> scores;
 

    void Start()
    {
        rawInput = InputReader.ReadInputInLines(10, 0);
        Problem2();
    }
    void Problem2()
    {
        char inChar;
        char outChar;
        bool finded = false;

        if (currentRaw < rawInput.Length)
        {
            for (int i = 0; i < rawInput[currentRaw].Length; i++)
            {
                if (rawInput[currentRaw][i].ToString() == "X")
                {
                    currentRaw++;
                    Problem2();
                    break;
                }
                if (outChars.Contains(rawInput[currentRaw][i].ToString()))
                {
                    inChar = rawInput[currentRaw][i - 1];
                    outChar = rawInput[currentRaw][i];

                    if (outChar == ')')
                    {
                        outChar = '(';
                    }
                    else if (outChar == ']')
                    {
                        outChar = '[';
                    }
                    else if (outChar == '}')
                    {
                        outChar = '{';
                    }
                    else
                    {
                        outChar = '<';
                    }
                    finded = true;

                    if (inChar == outChar)
                    {
                        rawInput[currentRaw] = rawInput[currentRaw].Remove(i - 1, 2);
                        Problem2();
                    }
                    else
                    {
                        rawInput[currentRaw] = "X";
                        currentRaw++;
                        Problem2();
                    }
                    break;
                }
            }
            if (!finded)
            {
                currentRaw++;
                Problem2();
            }
        }
        else
        {
            FinalChecker();
        }
    }

    void FinalChecker()
    {
        for (int i = 0; i < rawInput.Length; i++)
        {
            totalPoints = 0;
            for (int j = 0; j < rawInput[i].Length; j++)
            {
                char outChar = rawInput[i][rawInput[i].Length - 1 - j];
                if (outChar != 'X')
                {
                    totalPoints *= 5;

                    if (outChar == '(')
                    {
                        totalPoints += 1;
                    }
                    else if (outChar == '[')
                    {
                        totalPoints += 2;
                    }
                    else if (outChar == '{')
                    {
                        totalPoints += 3;
                    }
                    else
                    {
                        totalPoints += 4;
                    }
                }
            }
            if (totalPoints > 0)
            {
                scores.Add(totalPoints);
            }
        }
        scores.Sort();
        print(scores[scores.Count/2]);
    }

    void Problem1()
    {
        char inChar;
        char outChar;
        bool finded = false;
        int stackedPoints = 0;

        if (currentRaw < rawInput.Length)
        {
            for (int i = 0; i < rawInput[currentRaw].Length; i++)
            {
                if (outChars.Contains(rawInput[currentRaw][i].ToString()))
                {
                    inChar = rawInput[currentRaw][i - 1];
                    outChar = rawInput[currentRaw][i];

                    if (outChar == ')')
                    {
                        outChar = '(';
                        stackedPoints = 3;
                    }
                    else if (outChar == ']')
                    {
                        outChar = '[';
                        stackedPoints = 57;
                    }
                    else if (outChar == '}')
                    {
                        outChar = '{';
                        stackedPoints = 1197;
                    }
                    else
                    {
                        outChar = '<';
                        stackedPoints = 25137;
                    }
                    finded = true;
                    if (inChar == outChar)
                    {
                        rawInput[currentRaw] = rawInput[currentRaw].Remove(i - 1, 2);
                        Problem1();
                        break;
                    }
                    else
                    {
                        totalPoints += stackedPoints;
                        currentRaw++;
                        Problem1();
                        break;
                    }
                }
            }
            if (!finded)
            {
                currentRaw++;
                Problem1();
            }
        }
        
    }
}
