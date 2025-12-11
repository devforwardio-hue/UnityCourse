using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Powerups : MonoBehaviour
{
    public enum PowerupType
    {
        MoveSpeed,
        Gravity,
        JumpForce
    }

    public PowerupType type = PowerupType.MoveSpeed;
    public bool multiply = false;
    public float value = 1f;
    public bool destroyOnPickup = true;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col != null) col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<PlayerController>();
        if (player == null) return;

        Apply(player);

        if (destroyOnPickup)
        {
            Destroy(gameObject);
        }
    }

    private void Apply(PlayerController player)
    {
        switch (type)
        {
            case PowerupType.MoveSpeed:
                player.moveSpeed = multiply ? player.moveSpeed * value : player.moveSpeed + value;
                break;
            case PowerupType.Gravity:
                player.gravity = multiply ? player.gravity * value : player.gravity + value;
                break;
            case PowerupType.JumpForce:
                player.jumpForce = multiply ? player.jumpForce * value : player.jumpForce + value;
                break;
        }
    }
}
