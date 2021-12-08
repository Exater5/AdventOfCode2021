using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Problem2();
    }

    public void Problem1()
    {
        string[] rawInput = InputReader.ReadInputInLines(3, 0);
        List<List<int>> convertedNumbers = new List<List<int>>();

        for (int i = 0; i<rawInput.Length; i++)
        {
            convertedNumbers.Add(new List<int>());
            for (int j = 0; j<rawInput[0].Length; j++)
            {
                int convertedN = int.Parse(rawInput[i][j].ToString());
                convertedNumbers[i].Add(convertedN);
            }
        }


        List<int> zeroAmount = new List<int>();
        List<int> oneAmount = new List<int>();

        for (int  i = 0; i<convertedNumbers[0].Count; i++)
        {
            zeroAmount.Add(0);
            oneAmount.Add(0);
        }

        for (int i = 0; i<convertedNumbers.Count; i++)
        {
            for(int j = 0; j<convertedNumbers[0].Count; j++)
            {
                if (convertedNumbers[i][j] == 1)
                {
                    oneAmount[j]++;
                }
                else
                {
                    zeroAmount[j]++;
                }
            }
        }

        string result = string.Empty;
        for(int i = 0; i<zeroAmount.Count; i++)
        {
            if (zeroAmount[i] > oneAmount[i])
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
        }
    }


    public void Problem2()
    {
        string[] rawInput = InputReader.ReadInputInLines(3, 0);
        List<List<int>> convertedNumbers = new List<List<int>>();

        for (int i = 0; i < rawInput.Length; i++)
        {
            convertedNumbers.Add(new List<int>());
            for (int j = 0; j < rawInput[0].Length; j++)
            {
                int convertedN = int.Parse(rawInput[i][j].ToString());
                convertedNumbers[i].Add(convertedN);
            }
        }


        List<int> zeroAmount = new List<int>();
        List<int> oneAmount = new List<int>();

        for (int i = 0; i < convertedNumbers[0].Count; i++)
        {
            zeroAmount.Add(0);
            oneAmount.Add(0);
        }
    }
}
