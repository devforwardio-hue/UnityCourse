using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    [Tooltip("Amount of health removed when the player collides with this object.")]
    public float damage = 5f;

    // Called for Trigger colliders
    private void OnTriggerEnter(Collider other)
    {
        TryApplyDamage(other.gameObject);
    }

    // Called for non-trigger physics collisions
    private void OnCollisionEnter(Collision collision)
    {
        TryApplyDamage(collision.gameObject);
    }

    private void TryApplyDamage(GameObject target)
    {
        if (target == null) return;

        // Try to find a PlayerHealth component on the collided object (or on a parent).
        var health = target.GetComponent<PlayerHealth>() ?? target.GetComponentInParent<PlayerHealth>();
        if (health == null) return;

        health.Health = Mathf.Max(0f, health.Health - damage);
        Debug.Log($"Applied {damage} damage to {target.name}. New health: {health.Health}");
    }
}
