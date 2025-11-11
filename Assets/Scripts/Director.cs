using UnityEngine;

public class Director : MonoBehaviour
{
    public Vector3 GetDirection(Transform target, float speed, float stopDistance = 0f)
    {
        if (target == null) 
            return Vector3.zero;
        
        if (stopDistance > 0 && transform.position.IsEnoughClose(target.position, stopDistance))
            return Vector3.zero;
        
            Vector3 direction = target.position - transform.position;
            direction = direction.normalized * speed;
        
            return direction;
    }
}