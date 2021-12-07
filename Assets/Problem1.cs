using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem1 : MonoBehaviour
{
    string[] inputs;
    void Start()
    {
        inputs = InputReader.ReadInputInLines(1,1);
        Part2();
    }

    public void Part1()
    {
        int increments = 0;
        for(int i = 1; i<inputs.Length; i++)
        {
            int currentN = int.Parse(inputs[i]);
            int lastN = int.Parse(inputs[i-1]);
            if (currentN > lastN)
            {
                increments++;
            }
        }
        print(increments);
    }

    public void Part2()
    {
        List<int> convertedInputs = new List<int>();
        List<int> finalValues = new List<int>();

        foreach(string s in inputs)
        {
            convertedInputs.Add(int.Parse(s));
        }

        for(int i = 0; i<convertedInputs.Count - 2; i++)
        {
            int sum = convertedInputs[i] + convertedInputs[i + 1] + convertedInputs[i + 2];
            finalValues.Add(sum);
        }
        finalValues.Add(convertedInputs[convertedInputs.Count -2] + convertedInputs[convertedInputs.Count - 1]);
        finalValues.Add(convertedInputs[convertedInputs.Count - 1]);

        int increments = 0;

        for (int i = 1; i < finalValues.Count; i++)
        {
            if (finalValues[i] > finalValues[i-1])
            {
                increments++;
            }
        }
        print(increments);
    }
}
