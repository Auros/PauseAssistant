using PauseAssistant.Models;
using System;

namespace PauseAssistant.Modules
{
    internal class StaticLightsModule : BoolModule
    {
        private readonly IDifficultyBeatmap _difficultyBeatmap;
        private readonly BasicBeatmapObjectManager _basicBeatmapObjectManager;
        private readonly GameplayCoreSceneSetupData _gameplayCoreSceneSetupData;
        private readonly BeatmapObjectCallbackController _beatmapObjectCallbackController;

        private bool _value;
        public override bool Value
        {
            get => _value;
            set
            {
                _value = value;
                SetStaticLights(_value);
            }
        }

        public override string Name => "Static Lights";

        public StaticLightsModule(IDifficultyBeatmap difficultyBeatmap, BasicBeatmapObjectManager basicBeatmapObjectManager, GameplayCoreSceneSetupData gameplayCoreSceneSetupData, BeatmapObjectCallbackController beatmapObjectCallbackController)
        {
            _difficultyBeatmap = difficultyBeatmap;
            _basicBeatmapObjectManager = basicBeatmapObjectManager;
            _gameplayCoreSceneSetupData = gameplayCoreSceneSetupData;
            _beatmapObjectCallbackController = beatmapObjectCallbackController;
            _value = ((_difficultyBeatmap.difficulty == BeatmapDifficulty.ExpertPlus) ? _gameplayCoreSceneSetupData.playerSpecificSettings.environmentEffectsFilterExpertPlusPreset : _gameplayCoreSceneSetupData.playerSpecificSettings.environmentEffectsFilterDefaultPreset) == EnvironmentEffectsFilterPreset.NoEffects;
        }

        private void SetStaticLights(bool value)
        {
            var basicBOM = _basicBeatmapObjectManager;
            foreach (var item in Accessors.GameNotePool(ref basicBOM).activeItems)
            {
                item.hide = false;
                item.pause = false;
                item.enabled = true;
                item.gameObject.SetActive(true);
                item.Dissolve(0f);
            }

            foreach (var item in Accessors.BombNotePool(ref basicBOM).activeItems)
            {
                item.hide = false;
                item.pause = false;
                item.enabled = true;
                item.gameObject.SetActive(true);
                item.Dissolve(0f);
            }

            foreach (var item in _basicBeatmapObjectManager.activeObstacleControllers)
            {
                item.hide = false;
                item.pause = false;
                item.enabled = true;
                item.gameObject.SetActive(true);
            }

            value = !value;
            EnvironmentEffectsFilterPreset environmentEffectsFilterPreset = value ? (_difficultyBeatmap.difficulty == BeatmapDifficulty.ExpertPlus) ? _gameplayCoreSceneSetupData.playerSpecificSettings.environmentEffectsFilterExpertPlusPreset : _gameplayCoreSceneSetupData.playerSpecificSettings.environmentEffectsFilterDefaultPreset : EnvironmentEffectsFilterPreset.NoEffects;
            IReadonlyBeatmapData readonlyBeatmapData = BeatmapDataTransformHelper.CreateTransformedBeatmapData(_difficultyBeatmap.beatmapData, _gameplayCoreSceneSetupData.previewBeatmapLevel, _gameplayCoreSceneSetupData.gameplayModifiers, _gameplayCoreSceneSetupData.practiceSettings, _gameplayCoreSceneSetupData.playerSpecificSettings.leftHanded, environmentEffectsFilterPreset, _gameplayCoreSceneSetupData.environmentInfo.environmentIntensityReductionOptions);
            _beatmapObjectCallbackController.SetNewBeatmapData(readonlyBeatmapData);
        }
    }
}