using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ArrayGenerator
{
    private string[] _words = { "a","b","c" };

    public int[] GenerateRandomNumbersArray(int length)
    {
        int[] generatedNumbers = new int[length];

        for (int i = 0; i < length; i++)
        {
            generatedNumbers[i] = Random.Range(0,9);
        }

        return generatedNumbers;
    }

    public string[] GenerateRandomWordsArray(int length)
    {
        string[] generatedWords = new string[length];

        for (int i = 0; i < length; i++)
        {
            generatedWords[i] = _words[Random.Range(0,_words.Length-1)];
        }

        return generatedWords;
    }
}
