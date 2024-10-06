using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CatState", menuName = "GamePlay/CatState", order = 0)]
public class CatState : ScriptableObject
{
    [SerializeField] float m_speed;
    [SerializeField] string m_animator_variable;
    [SerializeField] bool m_animator_variable_state;

    public float GetSpeed()
    {
        return m_speed;
    }

    public string GetAnimatorVariable()
    {
        return m_animator_variable;
    }

    public bool GetAnimatorState()
    {
        return m_animator_variable_state;
    }
}
