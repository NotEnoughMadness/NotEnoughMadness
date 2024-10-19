using System;
using UnityEngine;

namespace NotEnoughMadness.MapMaking
{
    public class NEM_StudioEventEmitter_Swain : NEM_Mobile_Object
    {
        [Header("NEM_StudioEventEmitter_Swain")]

        [Tooltip("FMOD Studio event path")]
        public string eventPath = "";

        public NEM_EmitterGameEvent playEvent = NEM_EmitterGameEvent.ObjectEnable;
        public NEM_EmitterGameEvent stopEvent = NEM_EmitterGameEvent.ObjectDisable;

        public string collisionTag = "";

        public bool allowFadeOut = true;

        public bool triggerOnce;

        public bool preload;

        public NEM_ParamRef[] paramRefs = new NEM_ParamRef[0];

        public float[] overrideAttenuation = new float[] { -1f, -1f };

        public NEM_SwainAudio.NEM_AudioTypes mySoundType = NEM_SwainAudio.NEM_AudioTypes.Ambient;

        public bool earsRelativeToViewTarget;

        public float rangeMult = 1f;
        public float volumeMult = 1f;

        public bool restartSoundOnDisable;
        public bool destroyOnDisable;

        public bool forceLoop;

        public bool disableOnStopped;

        public bool randomizeStart;

        public float fadeMeInScale = -1f;

        public NEM_PLAYBACK_STATE currentState = NEM_PLAYBACK_STATE.STOPPED;
    }

    [Serializable]
    public class NEM_ParamRef
    {
        public string name = "";
        public float value;
    }

    [Serializable]
    public enum NEM_PLAYBACK_STATE
    {
        PLAYING,
        SUSTAINING,
        STOPPED,
        STARTING,
        STOPPING
    }

    [Serializable]
    public enum NEM_EmitterGameEvent
    {
        None,
        ObjectStart,
        ObjectDestroy,
        TriggerEnter,
        TriggerExit,
        TriggerEnter2D,
        TriggerExit2D,
        CollisionEnter,
        CollisionExit,
        CollisionEnter2D,
        CollisionExit2D,
        ObjectEnable,
        ObjectDisable
    }
}