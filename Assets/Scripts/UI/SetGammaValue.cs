using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class SetGammaValue : SetSliderValue
{
    [SerializeField] private VolumeProfile _profile;

    public override void SetValue(float value)
    {
        base.SetValue(value);

        // check for existing LiftGammaGain component
        if(_profile.TryGet(out LiftGammaGain liftGammaGain))
        {
            float gammaValue = GetRemappedValue(value);
            liftGammaGain.gamma.value = Vector4.one * gammaValue;
        }
        else
        {
            Debug.LogWarning("No LiftGammaGain component found on volume profile!", _profile);
        }
    }

    private void OnEnable()
    {
        // check for correct profile and slider component
        if(_profile.TryGet(out LiftGammaGain liftGammmaGain) && TryGetComponent(out Slider slider))
        {
            // get current gamma (x == red value)
            float current = liftGammmaGain.gamma.value.x;
            // remap current gamma to normalized 0 to 1 value
            float normalizedValue = Mathf.InverseLerp(_outMinMax.x, _outMinMax.y, current);
            // find slider value
            float sliderValue = normalizedValue * _sliderMaxValue;

            // set slider value WITHOUT triggering Unity event
            slider.SetValueWithoutNotify(sliderValue);
        }
    }
}