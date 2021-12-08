using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day5 : MonoBehaviour
{
    [SerializeField] List<Vector2> origins, targets;

    // Start is called before the first frame update
    void Start()
    {
        origins = new List<Vector2>();
        targets = new List<Vector2>();
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
            origins.Add(new Vector2(int.Parse(firstSplit[0]), int.Parse(firstSplit[1])));
            targets.Add(new Vector2(int.Parse(firstSplit[2]), int.Parse(firstSplit[3])));   
        }

        //MAX
        int maxX = 0;
        int maxY = 0;
        for (int i = 0; i < origins.Count; i++)
        {
            if (origins[i].x > maxX)
            {
                maxX = (int)origins[i].x;
            }
            if (targets[i].x > maxX)
            {
                maxX = (int)origins[i].x;
            }
            if (origins[i].y > maxY)
            {
                maxY = (int)origins[i].y;
            }
            if (targets[i].y > maxY)
            {
                maxY = (int)origins[i].y;
            }
        }
        maxX++;
        maxY++;
        //MAX



        List<List<int>> matrix = new List<List<int>>();
        for (int i = 0; i < maxY; i++)
        {
            matrix.Add(new List<int>());
            for (int j = 0; j < maxX; j++)
            {
                matrix[i].Add(0);
            }
        }


        //Origenes
        //matrix[aY[i]][aX[i]]++;
        //matrix[bY[i]][bX[i]]++;

        for (int i = 0; i < 1; i++)
        {
            matrix[(int)origins[i].x][(int)origins[i].y]++;
            matrix[(int)targets[i].x][(int)targets[i].y]++;
            bool xOrBigger = false, yOrBigger = false;
            Vector2 targetMark;

            if (origins[i].x > targets[i].x)
            {
                xOrBigger = true;
                targetMark = new Vector2(origins[i].x, origins[i].y);
            }
            else
            {
                targetMark = new Vector2(targets[i].x, targets[i].y);
            }
            if (origins[i].y > targets[i].y)
            {
                yOrBigger = true;
            }

            for (int j = 1; j < (int)Vector2.Distance(origins[i], targets[i]) -1; j++)
            {
                if (targetMark.x -1 > origins[i].x)
                {
                    targetMark.x--;
                }
                matrix[(int)targetMark.y][(int)targetMark.x]++;
            }
        }




        //Matrix Console Writer 
        string rMatrix = string.Empty;
        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                rMatrix += matrix[i][j];
            }
            rMatrix += "\n";
        }
        print(rMatrix);
        //Matrix Console Writer
    }
}
