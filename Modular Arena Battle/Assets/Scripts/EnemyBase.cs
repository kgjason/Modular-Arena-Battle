using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDirection, IDeathHandler, IMovementBorder
{
    public int damage = 1;
    public GameObject player;
    public Vector2 spawnLocation;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    public Vector2 GetDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }
    public void HandleDeath()
    {
        Destroy(gameObject);
    }
    public void SetBorder()
    {
        int x = Random.Range(-11, 11);
        int y = Random.Range(-11, 11);
        spawnLocation = new Vector2(x, y);
    }
}
