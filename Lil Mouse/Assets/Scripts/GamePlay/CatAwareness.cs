using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAwareness : MonoBehaviour
{
    [SerializeField] float m_awareTimer = 0.0f;
    [SerializeField] float m_awareTimerThreshhold = 1.0f;
    [SerializeField] float m_chaseTimerThreshhold = 3.0f;
    [SerializeField] float m_stateTimerDecreaseSpeed = 0.5f;
    [SerializeField] CatManager m_catManager;
    [SerializeField] CatState m_catState;
    [SerializeField] CatState m_preconditionState;
    [SerializeField] CatState m_chase;

    private bool m_inRadius;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            m_inRadius = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            m_inRadius = false;
            if(m_awareTimer > m_awareTimerThreshhold)
            {
                m_awareTimer = m_awareTimerThreshhold;
            }
        }
    }

    void Update() 
    {
        UpdateTimer();
        if (m_awareTimer > m_awareTimerThreshhold && m_catManager.GetCatState()== m_preconditionState) 
        {
            m_catManager.UpdateState(m_catState);
        }

        if (m_awareTimer > m_chaseTimerThreshhold && m_catManager.GetCatState()== m_catState) 
        {
            m_catManager.UpdateState(m_chase);
        }

        if(m_awareTimer == 0 && m_catManager.GetCatState()== m_catState)
        {
            m_catManager.UpdateState(m_preconditionState);
        }
    }

    private void UpdateTimer()
    {
        if(m_inRadius == true)
        {
            m_awareTimer += Time.deltaTime;
        }
        else if(m_awareTimer > 0)
        {
            m_awareTimer -= Time.deltaTime * m_stateTimerDecreaseSpeed;
        }
        else
        {
            m_awareTimer = 0;
        }
    }

    
}
