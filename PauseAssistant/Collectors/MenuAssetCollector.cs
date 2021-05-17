using IPA.Utilities;
using PauseAssistant.Collectors;
using UnityEngine.UI;
using Zenject;

namespace PauseAssistant
{
    internal class MenuAssetCollector : IInitializable
    {
        public MenuAssetCollector(AssetStore assetStore, MainMenuViewController mainMenuViewController)
        {
            assetStore.SettingsButtonTemplate = mainMenuViewController.GetField<Button, MainMenuViewController>("_optionsButton");
        }

        public void Initialize()
        {

        }
    }
}