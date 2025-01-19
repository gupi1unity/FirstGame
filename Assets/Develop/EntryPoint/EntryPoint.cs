using Assets.Develop.CommonServices.AssetsManagment;
using Assets.Develop.CommonServices.CoroutinePerformer;
using Assets.Develop.CommonServices.DataManagment;
using Assets.Develop.CommonServices.LoadingScreen;
using Assets.Develop.CommonServices.SceneManagment;
using Assets.Develop.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Develop.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Bootstrap _gameBootstrap;

        private void Awake()
        {
            SetupAppSettings();

            DIContainer projectContainer = new DIContainer();

            RegisterResourcesAssetLoader(projectContainer);
            RegisterCoroutinePerformer(projectContainer);
            RegisterLoadingCurtain(projectContainer);
            RegisterSceneLoader(projectContainer);
            RegisterSceneSwitcher(projectContainer);
            RegisterSaveLoadService(projectContainer);

            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(_gameBootstrap.Run(projectContainer));
        }

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 144;
        }

        private void RegisterResourcesAssetLoader(DIContainer container)
        {
            container.RegisterAsSingle(c => new ResourcesAssetLoader());
        }

        private void RegisterCoroutinePerformer(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinePerformer>(c =>
            {
                ResourcesAssetLoader resourcesAssetLoader = c.Resolve<ResourcesAssetLoader>();
                CoroutinePerformer coroutinePerformer = resourcesAssetLoader.LoadResource<CoroutinePerformer>("Infrastructure/CoroutinePerformer");
                return Instantiate(coroutinePerformer);
            });
        }

        private void RegisterLoadingCurtain(DIContainer container)
        {
            container.RegisterAsSingle<ILoadingCurtain>(c =>
            {
                ResourcesAssetLoader resourcesAssetLoader = c.Resolve<ResourcesAssetLoader>();
                StandartLoadingCurtain loadingCurtain = resourcesAssetLoader.LoadResource<StandartLoadingCurtain>("Infrastructure/StandartLoadingCurtain");
                return Instantiate(loadingCurtain);
            });
        }

        private void RegisterSceneLoader(DIContainer container)
        {
            container.RegisterAsSingle<ISceneLoader>(c => new DefaultSceneLoader());
        }

        private void RegisterSceneSwitcher(DIContainer container)
        {
            container.RegisterAsSingle<SceneSwitcher>(c => new SceneSwitcher(c.Resolve<ICoroutinePerformer>(), c.Resolve<ILoadingCurtain>(), c.Resolve<ISceneLoader>(), container));
        }

        private void RegisterSaveLoadService(DIContainer container)
        {
            container.RegisterAsSingle<ISaveLoadService>(c => new SaveLoadService(new JsonSerializer(), new LocalDataRepository()));
        }
    }
}
