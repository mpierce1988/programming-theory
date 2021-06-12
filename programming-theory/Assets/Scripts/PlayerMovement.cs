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
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


        Vector2 desiredMovement = inputDirection * (_movementSpeed * Time.deltaTime);
        Vector3 desiredMovementVector3 = new Vector3(desiredMovement.x, 0f, desiredMovement.y);

        //_navMeshAgent.Move(desiredMovementVector3);
        Vector3 desiredPosition = transform.position + desiredMovementVector3;
        _navMeshAgent.SetDestination(desiredPosition);
    }
}
