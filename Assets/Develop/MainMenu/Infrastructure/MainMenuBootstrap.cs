using Assets.Develop.CommonServices.SceneManagment;
using Assets.Develop.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBootstrap : MonoBehaviour
{
    private DIContainer _container;

    public IEnumerator Run(DIContainer container, MainMenuInputArgs mainMenuInputArgs)
    {
        _container = container;

        Debug.Log("Бутстрап главного меню.");

        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _container.Resolve<SceneSwitcher>().ProccesSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(2)));
        }
    }
}
