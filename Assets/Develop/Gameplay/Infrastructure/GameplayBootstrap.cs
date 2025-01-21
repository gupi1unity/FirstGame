using Assets.Develop.CommonServices.AssetsManagment;
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

        Debug.Log($"Запуск уровня {gameplayInputArgs.Gamemode.ToString()}");

        RegisterArrayGenerator(container);
        RegisterPlayerArrayChecker(container);

        PlayerArrayChecker playerArrayChecker = _container.Resolve<PlayerArrayChecker>();
        playerArrayChecker.Initialize(_container, gameplayInputArgs.Gamemode);

        yield return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _container.Resolve<SceneSwitcher>().ProccesSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
        }
    }

    private void RegisterArrayGenerator(DIContainer container)
    {
        container.RegisterAsSingle<ArrayGenerator>(c => new ArrayGenerator());
    }

    private void RegisterPlayerArrayChecker(DIContainer container)
    {
        container.RegisterAsSingle<PlayerArrayChecker>(c =>
        {
            ResourcesAssetLoader resourcesAssetLoader = c.Resolve<ResourcesAssetLoader>();
            PlayerArrayChecker playerArrayChecker = resourcesAssetLoader.LoadResource<PlayerArrayChecker>("Infrastructure/PlayerArrayChecker");
            return Instantiate(playerArrayChecker);
        });
    }


}
