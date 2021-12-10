using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day7 : MonoBehaviour
{
    [SerializeField] List<int> convertedInputs;

    void Start()
    {
        Problem1();
    }
    public void Problem1()
    {
        string[] rawInput = InputReader.ReadInputInLines(7, 0);
        convertedInputs = new List<int>();
        string[] splittedInput = rawInput[0].Split(',');

        for (int i = 0; i < splittedInput.Length; i++)
        {
            convertedInputs.Add(int.Parse(splittedInput[i]));
        }


        long minCalcles = 99999999999;
        int bestN = 0;

        int max = 0;

        for (int i = 0; i < convertedInputs.Count; i++)
        {
            if (convertedInputs[i] > max)
            {
                max = convertedInputs[i];
            }
        }


        for (int i = 0; i < max; i++)
        {
            long currentCalcles = 0;
            for (int j = 0; j < convertedInputs.Count; j++)
            {
                int diff = Mathf.Abs(convertedInputs[j] - i);
                //currentCalcles += diff;
                currentCalcles += (long)(diff * (diff + 1) / 2f);
                if (currentCalcles > minCalcles)
                {
                    break;
                }
            }
            if (minCalcles > currentCalcles)
            {
                bestN = i;
                minCalcles = currentCalcles;
            }
        }

        print(minCalcles);
        print(bestN);
    }
}