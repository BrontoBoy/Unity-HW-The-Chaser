using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Director))]
public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _stopDistance = 2f;
    [SerializeField] private Transform _target;
    
    private Rigidbody _rigidbody;
    private Director _director;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _director = GetComponent<Director>();
    }
    
    private void Update()
    {
        if (_rigidbody != null && _target != null)
        {
            Vector3 direction = _director.GetDirectionToTarget(_target, _speed, _stopDistance);
            
            _rigidbody.linearVelocity = direction + Physics.gravity;
        }
    }
}
