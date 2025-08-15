using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDirection, IDeathHandler, IMovementBorder
{
    public float borderValue = 8.5f;
    private IAttacker attacker;
    private void Awake()
    {
        attacker = GetComponent<IAttacker>();    
    }
    void Update()
    {
        SetBorder();
        FireBullet();
    }
    public Vector2 GetDirection()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, y).normalized;
    }
    public void HandleDeath()
    {
        Destroy(gameObject);
    }
    public void SetBorder()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -borderValue, borderValue);
        pos.y = Mathf.Clamp(pos.y, -borderValue, borderValue);

        transform.position = pos;
    }
    public void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attacker.Attack();
        }
    }
}
