using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{

    [SerializeField] CatState m_currentState;

    [SerializeField] CatState m_sleepState;
    [SerializeField] CatState m_alertState;
    [SerializeField] CatState m_chaseState;
    [SerializeField] Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_currentState = m_sleepState;
    }

    public void UpdateState(CatState catState)
    {
        m_animator.SetBool(m_currentState.GetAnimatorVariable(), !m_currentState.GetAnimatorState());
        m_currentState = catState;
        m_animator.SetBool(m_currentState.GetAnimatorVariable(), m_currentState.GetAnimatorState());
        Debug.Log("Update Mouse State to " + catState.ToString());
    }

    public CatState GetCatState()
    {
        return m_currentState;
    }

    public bool IsChasing()
    {
        if(m_currentState == m_chaseState)
        {
            return true;
        }
        return false;
    }
}
