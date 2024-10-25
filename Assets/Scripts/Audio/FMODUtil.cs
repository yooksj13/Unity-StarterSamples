using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class FMODUtil
{
    public enum EventType
    {
        Timeline,
        Action
    }

    public enum PlayOnEvent
    {
        Enter,
        Exit
    }
    
    public static EventInstance CreateEventInstance(EventReference sound)
    {
        EventInstance instance = RuntimeManager.CreateInstance(sound);
        return instance;
    }
    
    public static EventInstance PlaySound(EventReference sound, bool isSpatial, Vector3 position = default)
    {
        EventInstance instance;

        if (isSpatial)
        {
            instance = RuntimeManager.CreateInstance(sound);
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));
            instance.start();
        }
        else
        {
            instance = RuntimeManager.CreateInstance(sound);
            instance.start();
        }

        return instance;
    }

    public static void StopSound(EventInstance instance)
    {
        if (instance.isValid())
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }
    }
    
    public static void PlayOneShot(EventReference sound, bool isSpatial, Vector3 position = default)
    {
        if (isSpatial)
        {
            RuntimeManager.PlayOneShot(sound, position);
        }
        else
        {
            RuntimeManager.PlayOneShot(sound);
        }
    }
    
    public static void UpdateEventInstancePosition(EventInstance instance, Vector3 position)
    {
        if (instance.isValid())
        {
            instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));
        }
    }
}