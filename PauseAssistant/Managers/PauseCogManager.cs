using IPA.Utilities;
using PauseAssistant.Collectors;
using PauseAssistant.Models;
using SiraUtil.Tools;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PauseAssistant.Managers
{
    internal class PauseCogManager : IInitializable
    {
        private readonly SiraLog _siraLog;
        private readonly DiContainer _container;
        private readonly AssetStore _assetStore;
        private readonly PauseMenuManager _pauseMenuManager;
        private readonly PauseCogUIManager _pauseCogUIManager;

        public PauseCogManager(SiraLog siraLog, DiContainer container, AssetStore assetStore, PauseMenuManager pauseMenuManager, PauseCogUIManager pauseCogUIManager)
        {
            _siraLog = siraLog;
            _container = container;
            _assetStore = assetStore;
            _pauseMenuManager = pauseMenuManager;
            _pauseCogUIManager = pauseCogUIManager;
        }

        public void Initialize()
        {
            _siraLog.Info(_assetStore.SettingsButtonTemplate != null);
            Button newButton = _container.InjectGameObjectForComponent<Button>(_assetStore.SettingsButtonTemplate!.gameObject);
            Button continueButton = _pauseMenuManager.GetField<Button, PauseMenuManager>("_continueButton");

            newButton.transform.SetParent(continueButton.transform.parent, false);
            newButton.transform.localPosition = new Vector3(60f, -5.5f);
            newButton.onClick.RemoveAllListeners();

            _pauseCogUIManager.Build(newButton.transform.parent, Array.Empty<IAssistantModule>());
            newButton.onClick.AddListener(() => { _pauseCogUIManager.Show(); });
            _pauseCogUIManager.Screen.SetParent(_pauseMenuManager.transform, true);
        }
    }
}
