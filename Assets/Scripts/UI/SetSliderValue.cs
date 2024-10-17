using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSliderValue : MonoBehaviour
{
    [SerializeField] protected float _sliderMaxValue = 10f;
    [SerializeField] protected Vector2 _outMinMax = new Vector2(-0.5f, 0.5f);

    public virtual void SetValue(float value)
    {

    }

    protected float GetRemappedValue(float value)
    {
        // value is coming from slider input from user
        float normalizedValue = value / _sliderMaxValue;
        // remap to outMinMax range
        float remappedValue = Mathf.Lerp(_outMinMax.x, _outMinMax.y, normalizedValue);

        return remappedValue;
    }
}