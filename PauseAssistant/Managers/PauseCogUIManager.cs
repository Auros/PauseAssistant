using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using PauseAssistant.Models;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PauseAssistant.Managers
{
    [ViewDefinition("PauseAssistant.UI.pause-ui.bsml")]
    [HotReload(RelativePathToLayout = @"../UI/pause-ui.bsml")]
    internal class PauseCogUIManager : BSMLAutomaticViewController
    {
        [UIComponent("main-modal")]
        private readonly RectTransform _mainModal = null!;

        [UIParams]
        protected readonly BSMLParserParams _parserParams = null!;

        [UIValue("modules")]
        private readonly List<AssistantModule> _modules = new List<AssistantModule>();

        [UIValue("size")]
        private float _size;

        private FloatingScreen _floatingScreen = null!;
        private Canvas _screenCanvas = null!;

        public Transform Screen => _floatingScreen.transform;

        public void Build(IEnumerable<AssistantModule> assistantModules)
        {
            foreach (var module in assistantModules)
            {
                if (module is SliderModule slider)
                {
                    _modules.Add(slider);
                }
                else if (module is BoolModule @bool)
                {
                    _modules.Add(@bool);
                }
            }
            _size = _modules.Count * 8;
        }

        public void Show()
        {
            _floatingScreen.SetRootViewController(this, AnimationType.In);
            _parserParams.EmitEvent("show");
        }

        public void Hide()
        {
            _floatingScreen.SetRootViewController(null, AnimationType.Out);
            if (_parserParams != null)
                _parserParams.EmitEvent("hide");
        }

        [Inject]
        protected void Construct()
        {
            _floatingScreen = FloatingScreen.CreateFloatingScreen(new Vector2(60f, 45f), false, new Vector3(1.5f, 1.4f, 1.2f), Quaternion.Euler(0, 60, 0));
            _screenCanvas = _floatingScreen.GetComponent<Canvas>();
            _floatingScreen.name = "Pause Assistant Panel";
            _screenCanvas.sortingOrder = 31;
        }

        [UIAction("#post-parse")]
        protected void Parsed()
        {
            _mainModal.GetComponentInChildren<ImageView>().enabled = false;
        }
    }
}