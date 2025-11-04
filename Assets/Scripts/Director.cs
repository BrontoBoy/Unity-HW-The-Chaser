using UnityEngine;

public class Director : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const float MaxMagnitude = 1f;
    
    public Vector3 GetDirection(float speed)
    {
        Vector3 direction =new Vector3(Input.GetAxis(Horizontal),0, Input.GetAxis(Vertical));
        
        if (direction.magnitude > MaxMagnitude)
            direction = direction.normalized;
        
        direction *= Time.deltaTime * speed;
        
        return direction;
    }
    
    public Vector3 GetDirectionToTarget(Transform target, float speed, float stopDistance = 0f)
    {
        Vector3 direction = new Vector3 (target.position.x - stopDistance, target.position.y - stopDistance, 
            target.position.z - stopDistance) - transform.position;
        direction *= speed - stopDistance;
        
        return direction;
    }
}