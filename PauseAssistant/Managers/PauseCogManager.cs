using HMUI;
using IPA.Utilities;
using PauseAssistant.Collectors;
using PauseAssistant.Models;
using SiraUtil.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PauseAssistant.Managers
{
    internal class PauseCogManager : IInitializable, IDisposable
    {
        private readonly SiraLog _siraLog;
        private readonly DiContainer _container;
        private readonly AssetStore _assetStore;
        private readonly PauseMenuManager _pauseMenuManager;
        private readonly PauseCogUIManager _pauseCogUIManager;
        private readonly IMenuButtonTrigger _menuButtonTrigger;
        private readonly List<AssistantModule> _assistantModules;

        public PauseCogManager(SiraLog siraLog, DiContainer container, AssetStore assetStore, PauseMenuManager pauseMenuManager, PauseCogUIManager pauseCogUIManager, HoverHintController hoverHintController,
                                [Inject] List<AssistantModule> assistantModules, IMenuButtonTrigger menuButtonTrigger)
        {
            _siraLog = siraLog;
            _container = container;
            _assetStore = assetStore;
            _pauseMenuManager = pauseMenuManager;
            _assistantModules = assistantModules;
            _pauseCogUIManager = pauseCogUIManager;
            _menuButtonTrigger = menuButtonTrigger;
            hoverHintController.transform.SetParent(pauseMenuManager.transform);
        }

        public void Initialize()
        {
            _siraLog.Info(_assetStore.SettingsButtonTemplate != null);
            Button newButton = _container.InstantiatePrefabForComponent<Button>(_assetStore.SettingsButtonTemplate!.gameObject);
            Button continueButton = _pauseMenuManager.GetField<Button, PauseMenuManager>("_continueButton");

            newButton.transform.SetParent(continueButton.transform.parent, false);
            newButton.transform.localPosition = new Vector3(60f, -5.5f);
            newButton.onClick.RemoveAllListeners();

            _pauseCogUIManager.Build(_assistantModules);
            _pauseCogUIManager.Screen.SetParent(_pauseMenuManager.transform, true);
            newButton.onClick.AddListener(() =>
            {
                if (_pauseCogUIManager.isInViewControllerHierarchy)
                {
                    _pauseCogUIManager.Hide();
                }
                else
                {
                    _pauseCogUIManager.Show();
                }
            });

            _menuButtonTrigger.menuButtonTriggeredEvent += PauseMenuManager_didPressContinueButtonEvent;
            _pauseMenuManager.didPressContinueButtonEvent += PauseMenuManager_didPressContinueButtonEvent;
            _pauseMenuManager.didFinishResumeAnimationEvent += PauseMenuManager_didPressContinueButtonEvent;
        }

        private void PauseMenuManager_didPressContinueButtonEvent()
        {
            _pauseCogUIManager.Hide();
        }

        public void Dispose()
        {
            _menuButtonTrigger.menuButtonTriggeredEvent -= PauseMenuManager_didPressContinueButtonEvent;
            _pauseMenuManager.didPressContinueButtonEvent -= PauseMenuManager_didPressContinueButtonEvent;
            _pauseMenuManager.didFinishResumeAnimationEvent -= PauseMenuManager_didPressContinueButtonEvent;
        }
    }
}
