using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private CharacterController _characterController;
    private Mover _mover;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            Vector3 direction = _mover.GetDirection(_speed);

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