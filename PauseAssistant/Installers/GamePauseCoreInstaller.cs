using PauseAssistant.Collectors;
using PauseAssistant.Managers;
using SiraUtil;
using Zenject;

namespace PauseAssistant.Installers
{
    internal class GamePauseCoreInstaller : Installer
    {
        private readonly AssetStore _assetStore;

        public GamePauseCoreInstaller(AssetStore assetStore)
        {
            _assetStore = assetStore;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(UnityEngine.Object.Instantiate(_assetStore.HoverHintControllerTemplate!));
            Container.Bind<PauseCogUIManager>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesTo<PauseCogManager>().AsSingle();
        }
    }
}