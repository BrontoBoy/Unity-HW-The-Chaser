using UnityEngine;
using UnityEngine.Serialization;

public class Climber : MonoBehaviour
{
    private const float MinVelocityThreshold = 0.1f;
    private const float StepClimbFactor = 0.5f;
    
    [SerializeField] private float _maxStepHeight = 0.3f;
    [SerializeField] private float _obstacleDetectionRange = 0.2f;
    
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        float minVelocitySqr = MinVelocityThreshold * MinVelocityThreshold;
        
        if (_rigidbody.linearVelocity.sqrMagnitude > minVelocitySqr)
        {
            TryClimb();
        }
    }
    
    private void TryClimb()
    {
        Vector3 movementDirection = transform.forward;
        
        if (Physics.Raycast(transform.position, movementDirection, _obstacleDetectionRange))
        {
            Vector3 stepTopPosition = transform.position + Vector3.up * _maxStepHeight;
            
            if (Physics.Raycast(stepTopPosition, movementDirection, _obstacleDetectionRange) == false)
            {
                _rigidbody.position += Vector3.up * _maxStepHeight * StepClimbFactor;
            }
        }
    }
}
