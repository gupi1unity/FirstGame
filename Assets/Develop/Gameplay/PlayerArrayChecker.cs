using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrayChecker : MonoBehaviour
{
    private ArrayGenerator _arrayGenerator;

    private int[] _randomArrayNumbers;
    private string[] _randomArrayWords;

    public void Initialize(ArrayGenerator arrayGenerator)
    {
        _arrayGenerator = arrayGenerator;

        _randomArrayNumbers = _arrayGenerator.GenerateRandomNumbersArray(3);
        _randomArrayWords = _arrayGenerator.GenerateRandomWordsArray(3);

        Debug.Log(_randomArrayNumbers);
        Debug.Log(_randomArrayWords);
    }
}
