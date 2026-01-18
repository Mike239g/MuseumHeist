using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Token"))
        {
            PlayerScore.instance.IncreaseScore();
            Destroy(other.gameObject);
        }
    }
}
