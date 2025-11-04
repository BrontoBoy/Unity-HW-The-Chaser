using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Director))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private CharacterController _characterController;
    private Director _director;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _director = GetComponent<Director>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            Vector3 direction = _director.GetDirection(_speed);

            if (_characterController.isGrounded == true)
            {
                _characterController.Move(direction + Physics.gravity);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
            }
        }
    }
}