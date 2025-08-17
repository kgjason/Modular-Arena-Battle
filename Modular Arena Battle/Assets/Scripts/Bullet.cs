using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDirection, IMovementBorder
{
    public float speed = 10f;
    public GameObject player;
    public int damage = 1;
    public string targetTag = "Enemy";

    private Vector2 dir;

    private void Awake()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player");

        dir = GetDirection();
    }

    private void Update()
    {
        Move();
        SetBorder();
    }

    private void Move()
    {
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }

    public Vector2 GetDirection()
    {
        // Player'dan mermiye yön
        return (transform.position - player.transform.position).normalized;
    }
    public void SetBorder()
    {
        Vector3 pos = transform.position;
        if (Mathf.Abs(pos.x) > 10f || Mathf.Abs(pos.y) > 10f)
        {
            Destroy(gameObject);
        }
    }
}
