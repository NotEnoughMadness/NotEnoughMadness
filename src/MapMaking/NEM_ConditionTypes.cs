using System;

namespace NotEnoughMadness.MapMaking
{
    [Serializable]
    public enum NEM_ConditionTypes
    {
        None,

        __________UNITS = 200,

        CharacterDies,
        UNUSED_CharacterKills,
        FactionDead,

        __________ITEMS = 250,

        ItemKilled,

        __________WORLD = 300,

        MapStart,
        BringItemToArea,
        BringCharacterToArea,
        EnterRoom,

        __________STATS = 400,
        __________GLOBAL_STATS = 500,
        __________VARIABLES = 600,

        BooleanIs,
        CheckWorldChange,

        __________STAGES = 700,

        StageStatusIs,
        WaveCount,
        WaveComplete,
        TimedEvent,
        WavesRemaining,
        TrackedEvent,
        EventPurposesRemaining,
        CheckStageWasCompleted

    }
}
