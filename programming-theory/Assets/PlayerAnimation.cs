using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private const string _speedString = "Speed";

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float relativeSpeed = _navMeshAgent.velocity.magnitude / _navMeshAgent.speed;
        Debug.Log("RelativeSpeed: " + relativeSpeed);
        _animator.SetFloat(_speedString, relativeSpeed);
    }
}
