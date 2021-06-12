using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animal))]
public class AnimalAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private const string _eatString = "Eat";
    private const string _speedString = "Speed";

    private NavMeshAgent _navMeshAgent;
    private Animal _animal;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animal = GetComponent<Animal>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _animal.OnEat += PlayEatAnimation;
    }

    private void Update()
    {
        UpdateAnimationSpeedVariable();
    }

    private void OnDestroy()
    {
        _animal.OnEat -= PlayEatAnimation;
    }

    void PlayEatAnimation()
    {
        _animator.SetTrigger(_eatString);

    }

    void UpdateAnimationSpeedVariable()
    {
        _animator.SetFloat(_speedString, CurrentSpeed());
    }

    float CurrentSpeed()
    {
        return _navMeshAgent.velocity.magnitude / _navMeshAgent.speed;
    }
}
