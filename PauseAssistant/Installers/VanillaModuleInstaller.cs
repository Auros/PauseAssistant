using PauseAssistant.Models;
using PauseAssistant.Modules;
using Zenject;

namespace PauseAssistant.Installers
{
    internal class VanillaModuleInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<AssistantModule>().To<VolumeSliderModule>().AsSingle();
        }
    }
}