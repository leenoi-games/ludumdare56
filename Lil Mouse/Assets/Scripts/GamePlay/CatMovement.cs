using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class CatMovement : MonoBehaviour
{
    [SerializeField] Transform m_target;
    private CatManager m_catManager;
    [SerializeField] float m_rotationSpeed = 360f;

    private NavMeshAgent m_agent;
    private Transform m_lastKnownPosition;
    private bool m_startedStroll = false;

    private void Start()
    {
        m_catManager = GetComponent<CatManager>();
        m_agent = GetComponent<NavMeshAgent>();
        m_lastKnownPosition = transform;
        m_agent.updateRotation = false;
        m_agent.updateUpAxis = false;
    }

    private void Update() 
    {
        if(m_catManager.IsChasing())
        {
            m_startedStroll = false;
            Chase();
        }
        else if(m_catManager.IsStrolling())
        {
            
            Stroll();
        }
        else
        {
            m_startedStroll = false;
            m_agent.SetDestination(transform.position);
        }
    }

    private void Chase()
    {
        m_agent.speed = m_catManager.GetSpeed();
        m_agent.SetDestination(m_target.position);
        m_lastKnownPosition = m_target;

        var vel = m_agent.velocity;
        vel.z = 0;
        if (vel != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward,vel);
        }
    }

    private void Stroll()
    {
        if(m_startedStroll == false)
        {
            m_startedStroll = true;
            m_agent.SetDestination(m_lastKnownPosition.position);
            m_agent.speed = m_catManager.GetSpeed();
        }
        var vel = m_agent.velocity;
        vel.z = 0;
        if (vel != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward,vel);
        }
    }
}
