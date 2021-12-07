using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day5 : MonoBehaviour
{
    [SerializeField] List<int> aX, aY, bX, bY;

    // Start is called before the first frame update
    void Start()
    {
        aX = new List<int>();
        aY = new List<int>();
        bX = new List<int>();
        bY = new List<int>();
        Problem1();
    }

    public void Problem1()
    {
        string[] rawInput = InputReader.ReadInputInLines(5, 0);
        
        for (int i = 0; i < rawInput.Length; i++)
        {
            string[] firstSplit;
            string targetSplit = string.Empty;
            for (int j = 0; j < rawInput[i].Length; j++)
            {
                if (rawInput[i][j] != ' ' && rawInput[i][j] != '>')
                {
                    targetSplit += rawInput[i][j];
                }
            }
            firstSplit = targetSplit.Split(',', '-');
            aX.Add(int.Parse(firstSplit[0]));
            aY.Add(int.Parse(firstSplit[1]));
            bX.Add(int.Parse(firstSplit[2]));
            bY.Add(int.Parse(firstSplit[3]));
        }



    }
}
