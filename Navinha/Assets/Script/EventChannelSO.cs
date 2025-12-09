using UnityEngine;
using System;

[CreateAssetMenu(menuName = "GalacticWarfare/EventChannelHUD")]
public class EventChannelSO : ScriptableObject
{
    public event Action<HUDData> OnEventRaised;

    public void Raise(HUDData data)
    {
        OnEventRaised?.Invoke(data);
    }
}
