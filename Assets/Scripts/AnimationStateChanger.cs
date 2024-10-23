using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        _animator = FindAnyObjectByType<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rb.velocity != Vector3.zero)
        {
            _animator.SetFloat("Speed", 1f);
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }
    }
}
