using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] public float EffectiveRange { get; protected set; } = 5f;
    [SerializeField] public float Cooldown { get; protected set; } = 1f;
    [SerializeField] public float Duration { get; protected set; } = 1f;


    [SerializeField] public Animator Animator { get; protected set; }
    [SerializeField] public string AnimationTrigger { get; protected set; }
    [SerializeField] public float ActionSpeed { get; protected set; } = 1f;

    private float _lastActionTime;
    protected Vector3 _aimPosition;
    protected int _team;
    protected GameObject _instigator;

    private void OnValidate()
    {
        if (Animator == null) Animator = GetComponentInParent<Animator>();
    }

    public bool TryUse(Vector3 aimPosition, int team, GameObject instigator)
    {
        if (Time.time < _lastActionTime + Cooldown) return false;
        _lastActionTime = Time.time;

        _aimPosition = aimPosition;
        _team = team;
        _instigator = instigator;

        Animator.SetFloat("ActionSpeed", ActionSpeed);

        Use(aimPosition, team, instigator);
        return true;
    }

    protected virtual void Use(Vector3 aimPosition, int team, GameObject instigator)
    {
        // play animation if trigger exists
        if (!string.IsNullOrEmpty(AnimationTrigger)) Animator.SetTrigger(AnimationTrigger);
        // play one shot FMOD event, checking for null
    }

    // optional override function based on animations
    public virtual void ActionAnimEvent(int attackIndex)
    {

    }
}
