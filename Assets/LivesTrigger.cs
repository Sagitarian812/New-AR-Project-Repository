using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            PlayerStats.Lives--;
        }
    }
}
