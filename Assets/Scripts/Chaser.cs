using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Director))]
public class Chaser : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
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
            Vector3 velocity = _director.GetDirectionToTarget(_target, _speed, _stopDistance);
            velocity.y = _rigidbody.linearVelocity.y;
            _rigidbody.linearVelocity = velocity;
        }
    }
}
