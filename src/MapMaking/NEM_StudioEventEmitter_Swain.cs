using FMOD.Studio;
using FMODUnity;
using NotEnoughMadness.Classes;
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

        NEM_StudioEventEmitter_Swain()
        {
            MapManager.OnCreateMapComponents += OnCreateMapComponents;
            //MapManager.OnConnectMapComponents += OnConnectMapComponents;
        }

        void OnCreateMapComponents(object sender, EventArgs e)
        {
            StudioEventEmitter_Swain emitter = gameObject.AddComponent<StudioEventEmitter_Swain>();

            emitter.Event = eventPath;

            emitter.PlayEvent = (EmitterGameEvent)(int)playEvent;
            emitter.StopEvent = (EmitterGameEvent)(int)stopEvent;

            emitter.CollisionTag = collisionTag;

            emitter.AllowFadeout = allowFadeOut;

            emitter.TriggerOnce = triggerOnce;

            emitter.Preload = preload;

            ParamRef[] newParams = new ParamRef[paramRefs.Length];
            for (int i = 0; i < paramRefs.Length; i++)
            {
                ParamRef newRef = new ParamRef();

                newRef.Name = paramRefs[i].name;
                newRef.Value = paramRefs[i].value;

                newParams[i] = newRef;
            }

            emitter.Params = newParams;

            emitter.OverrideAttenuation = overrideAttenuation;

            emitter.mySoundType = (SwainAudio.AudioTypes)(int)mySoundType;

            emitter.EarsRelativeToViewTarget = earsRelativeToViewTarget;

            emitter.rangeMult = rangeMult;
            emitter.volumeMult = volumeMult;

            emitter.RestartSoundOnDisable = restartSoundOnDisable;
            emitter.DestroyOnDisable = destroyOnDisable;

            emitter.ForceLoop = forceLoop;

            emitter.DisableOnStopped = disableOnStopped;

            emitter.RandomizeStart = randomizeStart;

            emitter.FadeMeInScale = fadeMeInScale;

            emitter.CurrentState = (PLAYBACK_STATE)(int)currentState;
        }
        //void OnConnectMapComponents(object sender, EventArgs e)
        //{

        //}
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