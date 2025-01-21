using Assets.Develop.CommonServices.SceneManagment;
using Assets.Develop.DI;
using Assets.Develop.MainMenu;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerArrayChecker : MonoBehaviour
{
    private DIContainer _container;
    private ArrayGenerator _arrayGenerator;
    private Gamemods _gamemode;

    private int[] _randomArrayNumbers;
    private string[] _randomArrayWords;

    private int _arrayLength = 3;

    private bool _isWordsGamemode;
    private bool _isNumbersGamemode;
    private bool _isGameActive;

    private int _currentIndex;

    public void Initialize(DIContainer container, ArrayGenerator arrayGenerator, Gamemods gamemode)
    {
        _container = container;
        _arrayGenerator = arrayGenerator;
        _gamemode = gamemode;
        _isGameActive = true;
        _currentIndex = 0;

        switch (gamemode)
        {
            case Gamemods.WordArray:
                _randomArrayWords = arrayGenerator.GenerateRandomWordsArray(_arrayLength);
                _isWordsGamemode = true;
                break;
            case Gamemods.NumbersArray:
                _randomArrayNumbers = arrayGenerator.GenerateRandomNumbersArray(_arrayLength);
                _isNumbersGamemode = true;
                break;
        }
    }

    private void Update()
    {
        if (_isGameActive == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                switch (_gamemode)
                {
                    case Gamemods.WordArray:
                        _randomArrayWords = _arrayGenerator.GenerateRandomWordsArray(_arrayLength);
                        break;
                    case Gamemods.NumbersArray:
                        _randomArrayNumbers = _arrayGenerator.GenerateRandomNumbersArray(_arrayLength);
                        break;
                }

                _currentIndex = 0;
                _isGameActive = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _container.Resolve<SceneSwitcher>().ProccesSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
            }
        }

        if (_isWordsGamemode == true)
        {
            string inputWord = Input.inputString;

            if (Input.anyKeyDown && _currentIndex < _randomArrayWords.Length)
            {
                if (!string.IsNullOrEmpty(inputWord) && inputWord != "r")
                {
                    if (inputWord == _randomArrayWords[_currentIndex])
                    {
                        _currentIndex += 1;
                        Debug.Log("Вы нажали " + inputWord);
                    }
                    else
                    {
                        _isGameActive = false;
                        Debug.Log("Вы проиграли. Для перезапуска нажмите - R. Для выхода в главное меню нажмите - Space");
                    }
                }

                if (_currentIndex == _randomArrayWords.Length)
                {
                    _isGameActive = false;
                    Debug.Log("Вы победили. Для перезапуска нажмите - R. Для выхода в главное меню нажмите - Space");
                }
            }

        }

        if (_isNumbersGamemode == true)
        {
            string inputWord = Input.inputString;

            if (Input.anyKeyDown && _currentIndex < _randomArrayNumbers.Length)
            {
                if (!string.IsNullOrEmpty(inputWord) && inputWord != "r")
                {
                    int inputIntWord = Convert.ToInt32(inputWord);

                    if (inputIntWord == _randomArrayNumbers[_currentIndex])
                    {
                        _currentIndex += 1;
                        Debug.Log("Вы нажали " + inputWord);
                    }
                    else
                    {
                        _isGameActive = false;
                        Debug.Log("Вы проиграли. Для перезапуска нажмите - R. Для выхода в главное меню нажмите - Space");
                    }
                }

                if (_currentIndex == _randomArrayNumbers.Length)
                {
                    _isGameActive = false;
                    Debug.Log("Вы победили. Для перезапуска нажмите - R. Для выхода в главное меню нажмите - Space");
                }
            }

        }
    }
}
