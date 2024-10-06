using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MouseManager : MonoBehaviour
{
    private MouseState m_CurrentMouseState;
    private MouseState m_lastMoveState;

    [SerializeField] MouseState m_idleState;
    [SerializeField] MouseState m_moveState;
    [SerializeField] MouseState m_cheeseState;
    [SerializeField] MouseState m_sneakyState;
    [SerializeField] Animator m_animator;

    [SerializeField] Item m_currentItem;

    private void Start() {
        m_CurrentMouseState = m_idleState;
        m_lastMoveState = m_moveState;
    }

    public void UpdateMoveState(MouseState mouseState)
    {
        m_lastMoveState = mouseState;
        if(m_CurrentMouseState != m_idleState)
        {
            UpdateState(mouseState);
        }
    }

    public void UpdateState(MouseState mouseState)
    {
        m_CurrentMouseState = mouseState;
    }

    public MouseState GetMouseState()
    {
        return m_CurrentMouseState;
    }

    public void MoveOnEvent(Vector3 movePos)
    {
        if(movePos != Vector3.zero)
        {
            UpdateState(m_lastMoveState);
            m_animator.SetBool("idle",false);
        } 
        else
        {
            UpdateState(m_idleState);
            m_animator.SetBool("idle",true);
        }
    }

    public void PickUpItem(Item item)
    {
        //TODO: What happens if multiple Items in Range?? --> check for Range
        if(m_currentItem != null)
        {
            DropItem();
        }
        m_currentItem = item;
        item.gameObject.SetActive(false);
        m_animator.SetBool("cheese",true);
        UpdateMoveState(m_cheeseState);
    }

    public void DropItem()
    {
        if(m_currentItem == null)
        {
            Debug.Log("WTF WERE YOU HOLDING? Dropping Empty Item");
            return;
        }
        m_currentItem.gameObject.transform.position = transform.position;
        m_animator.SetBool("cheese",false);
        m_currentItem.gameObject.SetActive(true);
        UpdateMoveState(m_moveState);
        m_currentItem = null;
    }
}
