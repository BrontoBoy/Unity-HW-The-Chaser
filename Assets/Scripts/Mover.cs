using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const float MaxMagnitude = 1f;
    
    public Vector3 GetDirection(float speed)
    {
        Vector3 direction =new Vector3(Input.GetAxis(Horizontal),0, Input.GetAxis(Vertical));
        float sqrMaxMagnitude = MaxMagnitude * MaxMagnitude;
        
        if (direction.sqrMagnitude > sqrMaxMagnitude)
            direction = direction.normalized;
        
        Vector3 moveDelta = direction * (Time.deltaTime * speed);
        
        return moveDelta;
    }
}