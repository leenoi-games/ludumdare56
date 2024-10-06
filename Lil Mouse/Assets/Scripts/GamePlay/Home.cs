using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] IntVariable m_cheeseCounter;

    private void Start() 
    {
        m_cheeseCounter.SetDefault();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cheese"))
        {
            m_cheeseCounter.AddValue(1);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Cheese"))
        {
            if(m_cheeseCounter.GetValue()!= 0)
            {
                m_cheeseCounter.AddValue(-1);
            }
        }
    }
}
