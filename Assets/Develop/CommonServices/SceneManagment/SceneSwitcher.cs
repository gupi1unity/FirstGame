using Assets.Develop.CommonServices.CoroutinePerformer;
using Assets.Develop.CommonServices.LoadingScreen;
using Assets.Develop.DI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public class SceneSwitcher
    {
        private const string ErrorSceneTransitionMessage = "Данный переход невозможен";

        private readonly ICoroutinePerformer _coroutinePerformer;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly DIContainer _projectContainer;

        private DIContainer _currentSceneContainer;

        public SceneSwitcher(ICoroutinePerformer coroutinePerformer, ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, DIContainer projectContainer)
        {
            _coroutinePerformer = coroutinePerformer;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _projectContainer = projectContainer;
        }

        public void ProccesSwitchSceneFor(IOutputSceneArgs outputSceneArgs)
        {
            switch (outputSceneArgs)
            {
                case OutputBootstrapArgs outputBootstrapArgs:
                    _coroutinePerformer.StartPerform(ProccesSwitchFromBoostrapScene(outputBootstrapArgs));
                    break;

                case OutputMainMenuArgs outputMainMenuArgs:
                    _coroutinePerformer.StartPerform(ProccesSwitchFromMainMenuScene(outputMainMenuArgs));
                    break;

                case OutputGameplayArgs outputGameplayArgs:
                    _coroutinePerformer.StartPerform(ProccesSwitchFromGameplayScene(outputGameplayArgs));
                    break;
                    
            }
        }

        private IEnumerator ProccesSwitchFromBoostrapScene(OutputBootstrapArgs outputBootstrapArgs)
        {
            switch (outputBootstrapArgs.NextSceneInputArgs)
            {
                case MainMenuInputArgs mainMenuInputArgs:
                    yield return ProccesSwitchToMainMenu(mainMenuInputArgs);
                    break;

                default:
                    throw new Exception(ErrorSceneTransitionMessage);
            }
        }

        private IEnumerator ProccesSwitchFromMainMenuScene(OutputMainMenuArgs outputMainMenuArgs)
        {
            switch (outputMainMenuArgs.NextSceneInputArgs)
            {
                case GameplayInputArgs gameplayInputArgs:
                    yield return ProccesSwitchToGameplay(gameplayInputArgs);
                    break;

                default:
                    throw new Exception(ErrorSceneTransitionMessage);
            }
        }

        private IEnumerator ProccesSwitchFromGameplayScene(OutputGameplayArgs outputGameplayArgs)
        {
            switch (outputGameplayArgs.NextSceneInputArgs)
            {
                case MainMenuInputArgs mainMenuInputArgs:
                    yield return ProccesSwitchToMainMenu(mainMenuInputArgs);
                    break;

                default:
                    throw new Exception(ErrorSceneTransitionMessage);
            }
        }

        private IEnumerator ProccesSwitchToMainMenu(MainMenuInputArgs mainMenuInputArgs)
        {
            _loadingCurtain.Show();

            yield return _sceneLoader.LoadAsync(SceneID.Empty);
            yield return _sceneLoader.LoadAsync(SceneID.MainMenu);

            MainMenuBootstrap mainMenuBootstrap = Object.FindAnyObjectByType<MainMenuBootstrap>();

            if (mainMenuBootstrap == null)
            {
                throw new Exception(nameof(mainMenuBootstrap));
            }

            _currentSceneContainer = new DIContainer(_projectContainer);

            yield return mainMenuBootstrap.Run(_currentSceneContainer, mainMenuInputArgs);

            _loadingCurtain.Hide();
        }

        private IEnumerator ProccesSwitchToGameplay(GameplayInputArgs gameplayInputArgs)
        {
            _loadingCurtain.Show();

            yield return _sceneLoader.LoadAsync(SceneID.Empty);
            yield return _sceneLoader.LoadAsync(SceneID.Gameplay);

            GameplayBootstrap gameplayBootstrap = Object.FindAnyObjectByType<GameplayBootstrap>();

            if (gameplayBootstrap == null)
            {
                throw new Exception(nameof(gameplayBootstrap));
            }

            _currentSceneContainer = new DIContainer(_projectContainer);

            yield return gameplayBootstrap.Run(_currentSceneContainer, gameplayInputArgs);

            _loadingCurtain.Hide();
        }
    }
}
