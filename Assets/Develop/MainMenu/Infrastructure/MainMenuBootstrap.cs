using Assets.Develop.CommonServices.SceneManagment;
using Assets.Develop.DI;
using Assets.Develop.MainMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBootstrap : MonoBehaviour
{
    private DIContainer _container;

    private const string _numbersLevelName = "Numbers";
    private const string _wordsLevelName = "Words";

    public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
    {
        _container = container;

        Debug.Log("Бутстрап главного меню.");

        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _container.Resolve<SceneSwitcher>().ProccesSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(Gamemods.NumbersArray)));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _container.Resolve<SceneSwitcher>().ProccesSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(Gamemods.WordArray)));
        }
    }
}
