using UnityEngine;
using UnityEngine.AI;

public class FliyngEnemyAI : MonoBehaviour
{
    [SerializeField] public Transform Target;

    private NavMeshAgent _navMeshAgent;
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void FixedUpdate()
    {
        _navMeshAgent.destination = Target.position;
    }
}
