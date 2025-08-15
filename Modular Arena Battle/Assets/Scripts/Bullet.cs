using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDirection, IMovementBorder
{
    public GameObject player;
    public Vector2 dir;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        dir = GetDirection();
    }
    private void Update()
    {
        SetBorder();
    }
    public Vector2 GetDirection()
    {
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
