using PauseAssistant.Models;
using PauseAssistant.Modules;
using System;
using Zenject;

namespace PauseAssistant.Installers
{
    internal class VanillaModuleInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind(typeof(AssistantModule)).To<StaticLightsModule>().AsSingle();
            Container.Bind(typeof(AssistantModule), typeof(IDisposable)).To<VolumeSliderModule>().AsSingle();
        }
    }
}