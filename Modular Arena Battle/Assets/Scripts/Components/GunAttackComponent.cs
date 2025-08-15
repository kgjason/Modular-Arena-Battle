using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackComponent : MonoBehaviour, IAttacker
{
    public GameObject bulletPrefab;
    public float fireRate = 0.15f;
    private float nextFireTime = 0;
    public IDirection direction;
    private Vector2 lastDirection = Vector2.up;
    private void Awake()
    {
        direction = GetComponent<IDirection>();
    }
    public void Attack()
    {
        if (Time.time > nextFireTime && direction != null)
        {
            Vector2 dir = direction.GetDirection();
            if (dir != Vector2.zero)
            {
                lastDirection = dir.normalized;
            }
            Vector2 spawnPos = (Vector2)transform.position + lastDirection * 1f;
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }
    }
}
