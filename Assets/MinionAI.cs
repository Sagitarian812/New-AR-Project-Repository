using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionAI : MonoBehaviour
{
    public float speed;

    public int health = 200;
    private float currentHealth;

    private Transform target;
    private int wavepointIndex = 0;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start()
    {
        target = Waypoints.points[0];
        currentHealth = health;
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.01f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length-1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(amount);
        health -= amount;

        healthBar.fillAmount = health / currentHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void EndGame()
    {
        Time.timeScale = 0;
        Debug.Log("GAMEOVER NERD");
    
    }

}
