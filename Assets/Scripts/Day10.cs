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
    void Start()
    {
        rawInput = InputReader.ReadInputInLines(10, 0);
        Problem1();
    }

    void Problem1()
    {
        char inChar;
        char outChar;
        for (int i = 1; i < rawInput[currentRaw].Length; i++)
        {
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

                if (inChar == outChar)
                {
                    rawInput[currentRaw] = rawInput[currentRaw].Remove(i - 1, 2);
                    Problem1();
                }
                else
                {
                    print(outChar);
                    currentRaw++;
                }
                break;
            }
        }
    }
}
