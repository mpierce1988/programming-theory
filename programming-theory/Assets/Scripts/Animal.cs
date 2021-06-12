using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Animal : MonoBehaviour
{
    [SerializeField]
    protected float _wanderRange = 5f;
    [SerializeField]
    protected float _aiTickTime = 3f;

    public event Action OnEat = delegate { };
    public event Action OnGrabbed = delegate { };
    public event Action OnAIDisabled = delegate { };
    

    protected int _layerMask = -1;

    protected NavMeshAgent _navMeshAgent;
    protected bool _aiActive = true;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected void Start()
    {
        StartCoroutine(AITick());
    }

    #region Movement
    // ABSTRACTION
    private void MoveToRandomPosition()
    {
        MoveToPosition(GetRandomNavMeshPosition(this.transform.position, _wanderRange, _layerMask));
    }
    // ABSTRACTION
    protected void MoveToPosition(Vector3 position)
    {
        _navMeshAgent.SetDestination(position);
    }

    protected Vector3 GetRandomNavMeshPosition(Vector3 origin, float distance, int layermask)
    {        
        Vector3 randomDirection = RandomDirectionFromOrigin(origin, distance); 
        return ClosestNavHitToPoint(randomDirection, distance, layermask);
    }

    Vector3 ClosestNavHitToPoint(Vector3 randomDirection, float distance, LayerMask layerMask)
    {
        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);

        return navHit.position;
    }

    Vector3 RandomDirectionFromOrigin(Vector3 origin, float distance)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        return randomDirection += origin;
    }

    #endregion

    #region AI
    protected bool WantsToEat()
    {
        bool result = UnityEngine.Random.Range(0f, 1f) > 0.5f ? true : false;
        return result;
    }

    protected void MakeDecision()
    {
        if (WantsToEat())
        {
            // play eat animation
            OnEat.Invoke();
        }
        else
        {
            MoveToRandomPosition();
        }
    }    

    protected IEnumerator AITick()
    {
        while (_aiActive)
        {
            MakeDecision();

            yield return new WaitForSeconds(_aiTickTime);
        }
    }

    public void DisableAI()
    {
        _aiActive = false;
        _navMeshAgent.enabled = false;
        OnAIDisabled.Invoke();
    }

    public virtual void CaptureAnimal()
    {
        OnGrabbed.Invoke();
        Debug.Log("Invoking OnGrabbed event on " + this.gameObject.name);
        DisableAI();
    }
    #endregion
}
