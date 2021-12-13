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
        List<int> mains = new List<int>();
        List<List<int>> correctIndexes = new List<List<int>>();
        List<List<int>> columns = new List<List<int>>();
        string[] rawInput = InputReader.ReadInputInLines(3, 0);      

        for (int i = 0; i < rawInput[0].Length; i++)
        {
            columns.Add(new List<int>());
            correctIndexes.Add(new List<int>());
        }
        for (int i = 0; i < rawInput.Length; i++)
        {
            for (int j = 0; j < rawInput[0].Length; j++)
            {
                int convertedN = int.Parse(rawInput[i][j].ToString());
                columns[j].Add(convertedN);
            }          
        }
        for (int i = 0; i < columns.Count; i++)
        {
            mains.Add(GetMain(columns[i]));
        }

        for (int i = 0; i < columns[0].Count; i++)
        {
            if (columns[0][i] == mains[0])
            {
                correctIndexes[0].Add(i);
            }
        }

        for (int i = 1; i < columns.Count; i++)
        {
            int currentCount = 0;
            List<int> validNumbersList = new List<int>();
            for (int j = 0; j < correctIndexes[i].Count; j++)
            {
                validNumbersList.Add(columns[i][correctIndexes[i][j]]);
            }
            int nMain = GetMain(validNumbersList);
            for (int j = 0; j < columns[i].Count; j++)
            {
                if (columns[i][j] == nMain && correctIndexes[i - 1].Contains(i))
                {
                    currentCount++;
                    correctIndexes[i].Add(j);
                }
            }
        }

        string result = string.Empty;

        for (int i = 0; i < columns.Count; i++)
        {
            if(correctIndexes[i].Count > 0)
            {
                List<int> validNumbersList = new List<int>();
                for (int j = 0; j < correctIndexes[i].Count; j++)
                {
                    validNumbersList.Add(columns[i][correctIndexes[i][j]]);
                }
                result += GetMain(validNumbersList);
            }
            else
            {
                result += mains[i];
            }
        }

        print(result);
    }

    public int GetMain(List<int> numbers)
    {
        int zeroAmount = 0;
        int main = 1;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == 0)
            {
                zeroAmount++;
                if (zeroAmount > numbers.Count/2)
                {
                    main = 0;
                    break;
                }
            }
        }
        return main;
    }
}
