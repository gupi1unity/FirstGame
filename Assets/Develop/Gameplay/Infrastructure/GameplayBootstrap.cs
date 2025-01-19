using Assets.Develop.CommonServices.SceneManagment;
using Assets.Develop.DI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayBootstrap : MonoBehaviour
{
    private DIContainer _container;

    public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
    {
        _container = container;

        Debug.Log($"Запуск уровня {gameplayInputArgs.LevelNumber}");

        yield return new WaitForSeconds(1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _container.Resolve<SceneSwitcher>().ProccesSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
        }
    }
}
