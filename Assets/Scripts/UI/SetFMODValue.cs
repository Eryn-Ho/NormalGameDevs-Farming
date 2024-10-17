using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

public class SetFMODValue : SetSliderValue
{
    [SerializeField] private string _fmodParameter;

    public override void SetValue(float value)
    {
        base.SetValue(value);

        if(!string.IsNullOrEmpty(_fmodParameter))
        {
            float param = GetRemappedValue(value);
            // result gives us information on possible failures
            RESULT result = RuntimeManager.StudioSystem.setParameterByName(_fmodParameter, param);
            if(result != RESULT.OK)
            {
                UnityEngine.Debug.LogWarning($"FMOD param set fail: {result}, paramName: {_fmodParameter}");
            }
        }
    }
}