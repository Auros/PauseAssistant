using IPA.Utilities;

namespace PauseAssistant
{
    internal static class Accessors
    {
        public static readonly FieldAccessor<BasicBeatmapObjectManager, MemoryPoolContainer<GameNoteController>>.Accessor GameNotePool = FieldAccessor<BasicBeatmapObjectManager, MemoryPoolContainer<GameNoteController>>.GetAccessor("_gameNotePoolContainer");
        public static readonly FieldAccessor<BasicBeatmapObjectManager, MemoryPoolContainer<BombNoteController>>.Accessor BombNotePool = FieldAccessor<BasicBeatmapObjectManager, MemoryPoolContainer<BombNoteController>>.GetAccessor("_bombNotePoolContainer");
        public static readonly FieldAccessor<NoteCutSoundEffectManager, MemoryPoolContainer<NoteCutSoundEffect>>.Accessor NoteCutPool = FieldAccessor<NoteCutSoundEffectManager, MemoryPoolContainer<NoteCutSoundEffect>>.GetAccessor("_noteCutSoundEffectPoolContainer");
    }
}