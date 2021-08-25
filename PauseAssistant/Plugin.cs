using IPA;
using PauseAssistant.Collectors;
using PauseAssistant.Installers;
using SiraUtil;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;

namespace PauseAssistant
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            zenjector.On<PCAppInit>().Pseudo(Container =>
            {
                Container.BindLoggerAsSiraLogger(logger);
                Container.Bind<AssetStore>().AsSingle();
            });
            zenjector.On<MainSettingsMenuViewControllersInstaller>().Pseudo(Container =>
            {
                Container.BindInterfacesTo<MenuAssetCollector>().AsSingle();
            });
            zenjector.OnGame<GamePauseCoreInstaller>();
            zenjector.OnGame<VanillaModuleInstaller>();
        }

        [OnEnable]
        public void OnEnable()
        {

        }

        [OnDisable]
        public void OnDisable()
        {

        }
    }
}