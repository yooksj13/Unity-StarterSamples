
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private EventReference m_Round1Sound;
    
    private EventInstance m_ItemEquipOnGoingSoundInstance;


    private readonly int m_OpacityId = Shader.PropertyToID("_Opacity");

    private void Start()
    {
        FMODUtil.UpdateEventInstancePosition(m_ItemEquipOnGoingSoundInstance, this.transform.position);
        m_ItemEquipOnGoingSoundInstance = FMODUtil.PlaySound(m_Round1Sound, true, this.transform.position);
    }
}
