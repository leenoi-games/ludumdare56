using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_winUI;
    [SerializeField] GameObject m_loseUI;
    [SerializeField] GameObject m_inGameUI;
 
    private void Start() 
    {
        m_loseUI.SetActive(false);
        m_winUI.SetActive(false);
        m_inGameUI.SetActive(true);
    }

    public void OnLose()
    {
        m_loseUI.SetActive(true);
        m_winUI.SetActive(false);
        m_inGameUI.SetActive(false);
    }

    public void OnWin()
    {
        m_loseUI.SetActive(false);
        m_winUI.SetActive(true);
        m_inGameUI.SetActive(false);
    }
}
