using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MeleeAttackComponent : MonoBehaviour
{
    [Header("Hedef ve Hasar")]
    public string targetTag;
    public int damage = 1;

    private bool hasHit = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasHit) return;

        if (collision.gameObject.CompareTag(targetTag))
        {
            hasHit = true;

            HealthComponent health = collision.gameObject.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
