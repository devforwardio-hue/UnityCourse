# 🧱 Collision and Trigger Events in Unity

Unity provides physics callbacks that fire when rigidbodies and colliders interact. Use these to drive gameplay like damage, pickups, and doors.

## Prerequisites

- Collision events require at least one `Rigidbody` and colliders set to non-trigger.
- Trigger events require at least one `Rigidbody` and at least one collider marked as `Is Trigger`.
- Objects must be on layers that collide per your Physics settings.

## Collision callbacks (non-trigger)

```csharp
void OnCollisionEnter(Collision collision)
{
    Debug.Log($"Collision Enter with {collision.gameObject.name}");
}

void OnCollisionStay(Collision collision)
{
    // Called every physics step while colliding
}

void OnCollisionExit(Collision collision)
{
    Debug.Log($"Collision Exit with {collision.gameObject.name}");
}
```

Use cases:

- Start damage on impact, apply friction while in contact, stop effects on exit.

## Trigger callbacks (Is Trigger checked)

```csharp
void OnTriggerEnter(Collider other)
{
    Debug.Log($"Trigger Enter with {other.gameObject.name}");
}

void OnTriggerStay(Collider other)
{
    // Called every physics step while inside trigger
}

void OnTriggerExit(Collider other)
{
    Debug.Log($"Trigger Exit with {other.gameObject.name}");
}
```

Use cases:

- Pickups, area-of-effect zones, detection volumes, doors.

## Common patterns

Identify by tag or component:

```csharp
void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Player entered
    }

    var damageable = other.GetComponent<IDamageable>();
    if (damageable != null)
    {
        damageable.TakeDamage(10);
    }
}
```

Physics notes:

- These callbacks run in the physics loop (FixedUpdate timing).
- Use Rigidbody on at least one of the interacting objects for reliable callbacks.
- 2D physics uses different callbacks: `OnCollisionEnter2D`, `OnTriggerEnter2D`, etc.
