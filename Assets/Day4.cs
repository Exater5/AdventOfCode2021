using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day4 : MonoBehaviour
{
    [SerializeField] string[] rawInput, possibleN;
    [SerializeField] List<int> bingoNumbers;
    [SerializeField] List<List<int>> tickets;
    List<int> targetNumbers;
    int _currentTry = 4;
    [SerializeField] List<int> ticketWinners;

    // Start is called before the first frame update
    void Start()
    {
        bingoNumbers = new List<int>();
        ticketWinners = new List<int>();
        tickets = new List<List<int>>();
        Problem1();
    }

    public void Problem1()
    {
        rawInput = InputReader.ReadInputInLines(4, 0);
        possibleN = rawInput[0].Split(',');
        foreach (string s in possibleN)
        {
            bingoNumbers.Add(int.Parse(s));
        }

        tickets.Add(new List<int>());
        for (int i = 2; i< rawInput.Length; i++)
        {
            if (rawInput[i].Length != 0)
            {
                string[] numbers = rawInput[i].Split(' ');
                foreach(string s in numbers)
                {
                    if(s != "")
                    {
                        tickets[tickets.Count - 1].Add(int.Parse(s));
                    }
                }
            }
            else
            {
                tickets.Add(new List<int>());
            }
        }
        targetNumbers = new List<int>();
        targetNumbers.Add(bingoNumbers[0]);
        targetNumbers.Add(bingoNumbers[1]);
        targetNumbers.Add(bingoNumbers[2]);
        targetNumbers.Add(bingoNumbers[3]);
        targetNumbers.Add(bingoNumbers[_currentTry]);

        for (int i = 0; i < bingoNumbers.Count; i++)
        {
            for (int j = 0; j < tickets.Count; j++)
            {
                CheckTicket(j);
            }
            if (i <bingoNumbers.Count -1)
            {
                _currentTry++;
                targetNumbers.Add(bingoNumbers[_currentTry]);
            }

        }
    }

    public void CheckTicket(int ticketIndex)
    {
        int foundsAmount;

        //Vertical
        for (int i = 0; i < 5; i++)
        {
            if (targetNumbers.Contains(tickets[ticketIndex][i]))
            {
                foundsAmount = 1;
                for (int k = 1; k < 5; k++)
                {
                    if (targetNumbers.Contains(tickets[ticketIndex][i + k*5]))
                    {
                        foundsAmount++;
                    }
                }
                if (foundsAmount == 5)
                {
                    if (!ticketWinners.Contains(ticketIndex))
                    {
                        ticketWinners.Add(ticketIndex);
                        print(Sum(ticketIndex) + " * " + targetNumbers[targetNumbers.Count - 1]);
                    }
                }
            }
        }
        //Horizontal
        for (int i = 0; i < 5; i++)
        {
            if (targetNumbers.Contains(tickets[ticketIndex][i * 5]))
            {
                foundsAmount = 1;
                for (int k = 1; k < 5; k++)
                {
                    if (targetNumbers.Contains(tickets[ticketIndex][(i * 5) + k]))
                    {
                        foundsAmount++;
                    }
                }
                if (foundsAmount == 5)
                {
                    if (!ticketWinners.Contains(ticketIndex))
                    {
                        ticketWinners.Add(ticketIndex);
                        print(Sum(ticketIndex) + " * " + targetNumbers[targetNumbers.Count - 1]);
                    }
                }
            }
        }
    }

    public int Sum(int ticketIndex)
    {
        int sum = 0;
        for (int j = 0; j < tickets[ticketIndex].Count; j++)
        {
            if (!targetNumbers.Contains(tickets[ticketIndex][j]))
            {
                sum += tickets[ticketIndex][j];
            }
        }
        return sum;
    }
}
