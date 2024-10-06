using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    private CatManager m_catManager;
    [SerializeField] float m_rotationSpeed = 50f;

    private NavMeshAgent agent;

    private void Start() 
    {
        m_catManager = GetComponent<CatManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() 
    {
        if(m_catManager.IsChasing())
        {
            agent.SetDestination(target.position);
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, target.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,360);
        }
    }
}
