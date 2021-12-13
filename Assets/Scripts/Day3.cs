using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day3 : MonoBehaviour
{
    [SerializeField] List<int> checkRaw;
    // Start is called before the first frame update
    void Start()
    {
        Problem2();
        Problem22();
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
        List<List<int>> raws = new List<List<int>>();
        string[] rawInput = InputReader.ReadInputInLines(3, 0);      

        for (int i = 0; i < rawInput.Length; i++)
        {
            raws.Add(new List<int>());
            for (int j = 0; j < rawInput[0].Length; j++)
            {
                int convertedN = int.Parse(rawInput[i][j].ToString());
                raws[i].Add(convertedN);
            }          
        }

        for (int i = 1; i < raws[0].Count; i++)
        {
            int currentMain = GetMain(GetColumnOf(raws, i-1));
           
            for (int j = 0; j < raws.Count; j++)
            {
                if (GetColumnOf(raws, i-1)[j] != currentMain)
                {
                    raws[j][i] = -1;
                }
            }
        }

        string sol = string.Empty;

        for (int i = 0; i < raws[0].Count; i++)
        {
            sol += GetMain(GetColumnOf(raws, i));
        }
        print(sol);
    }

    public void Problem22()
    {
        List<List<int>> raws = new List<List<int>>();
        string[] rawInput = InputReader.ReadInputInLines(3, 0);

        for (int i = 0; i < rawInput.Length; i++)
        {
            raws.Add(new List<int>());
            for (int j = 0; j < rawInput[0].Length; j++)
            {
                int convertedN = int.Parse(rawInput[i][j].ToString());
                raws[i].Add(convertedN);
            }
        }

        for (int i = 1; i < raws[0].Count; i++)
        {
            int currentMain = GetNotMain(GetColumnOf(raws, i - 1));

            for (int j = 0; j < raws.Count; j++)
            {
                if (GetColumnOf(raws, i - 1)[j] != currentMain)
                {
                    raws[j][i] = -1;
                }
            }
        }

        string sol = string.Empty;

        checkRaw = GetColumnOf(raws,2);
        for (int i = 0; i < raws[0].Count; i++)
        {
            sol += GetNotMain(GetColumnOf(raws, i));
        }
        print(sol);
    }

    public List<int> GetColumnOf(List<List<int>> rawList ,int index)
    {
        List<int> column = new List<int>();

        for (int i = 0; i < rawList.Count; i++)
        {
            column.Add(rawList[i][index]);
        }
        return column;
    }


    public int GetMain(List<int> numbers)
    {
        int zeroAmount = 0;
        int oneAmount = 0;
        int main = 1;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == 0)
            {
                zeroAmount++;
            }
            if (numbers[i] == 1)
            {
                oneAmount++;
            }
        }

        if (zeroAmount > oneAmount)
        {
            main = 0;
        }
        if (zeroAmount == 0)
        {
            main = 1;
        }
        if (oneAmount == 0)
        {
            main = 0;
        }
        return main;
    }
    public int GetNotMain(List<int> numbers)
    {
        int zeroAmount = 0;
        int oneAmount = 0;
        int main = 0;

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == 0)
            {
                zeroAmount++;
            }
            if (numbers[i] == 1)
            {
                oneAmount++;
            }
        }

        if (oneAmount > zeroAmount)
        {
            main = 0;
        }
        else
        {
            main = 1;
            if (oneAmount == zeroAmount)
            {
                main = 0;
            }
        }
        if (zeroAmount == 0)
        {
            main = 1;
        }
        if (oneAmount == 0)
        {
            main = 0;
        }

        return main;
    }
}
