using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public int speed;
    public IDirection direction;
    private void Awake()
    {
        direction = GetComponent<IDirection>();
    }
    void Update()
    {
        if (direction != null)
        {
            Vector2 moveDir = direction.GetDirection();
            transform.position += (Vector3)(moveDir * speed * Time.deltaTime);
        }      
    }
}
