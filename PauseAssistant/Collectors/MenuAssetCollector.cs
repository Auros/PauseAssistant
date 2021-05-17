using HMUI;
using IPA.Utilities;
using PauseAssistant.Collectors;
using UnityEngine.UI;
using Zenject;

namespace PauseAssistant
{
    internal class MenuAssetCollector : IInitializable
    {
        private readonly AssetStore _assetStore;
        private readonly MainMenuViewController _mainMenuViewController;

        public MenuAssetCollector(AssetStore assetStore, HoverHintController hoverHintController, MainMenuViewController mainMenuViewController)
        {
            _assetStore = assetStore;
            _mainMenuViewController = mainMenuViewController;
            _assetStore.HoverHintControllerTemplate = hoverHintController;
        }

        public void Initialize()
        {
            _assetStore.SettingsButtonTemplate = _mainMenuViewController.GetField<Button, MainMenuViewController>("_optionsButton");
        }
    }
}