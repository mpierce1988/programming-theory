using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    
    private float _movementSpeed;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //_navMeshAgent.updatePosition = false;
        _movementSpeed = _navMeshAgent.speed;
        _navMeshAgent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    // ABSTRACTION

    private void MovePlayer()
    {        
        _navMeshAgent.SetDestination(GetNextPosition());
    }

    // ABSTRACTION
    Vector3 GetNextPosition()
    {
        Vector2 inputVector = GetInputDirection();
        Vector3 movementVector = MovementVector(inputVector);

        return transform.position + movementVector;
    }
    // ABSTRACTION
    Vector2 GetInputDirection()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }
    // ABSTRACTION
    Vector3 MovementVector(Vector2 inputDirection)
    {
        Vector2 desiredMovement = inputDirection * (_movementSpeed * Time.deltaTime);
        return new Vector3(desiredMovement.x, 0f, desiredMovement.y);
    }
}
