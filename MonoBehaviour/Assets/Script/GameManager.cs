using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager MainInstance
    {
        get
        {
            if (m_instance == (null))
            {
                m_instance = FindObjectOfType<GameManager>();
                return m_instance;
            }
            else
                return m_instance;
        }
    }
    private static GameManager m_instance;
    [Header("Player References")]
    [SerializeField] private GameObject PlayerGameObject;

    [Header("References UI")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text coinleft;

}