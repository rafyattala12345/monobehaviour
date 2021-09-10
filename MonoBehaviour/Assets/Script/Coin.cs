using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] int scoreAmount;

    [Header("Effect Settings")]
    [SerializeField] private GameObject m_effectParticle;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 20f, 50f) * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}