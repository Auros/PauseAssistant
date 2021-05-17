﻿using IPA;
using PauseAssistant.Collectors;
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
            zenjector.On<MenuInstaller>().Pseudo(Container =>
            {
                Container.BindInterfacesTo<MenuAssetCollector>().AsSingle();
            });
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