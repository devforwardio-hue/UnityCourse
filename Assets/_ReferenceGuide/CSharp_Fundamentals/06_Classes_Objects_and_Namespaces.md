# 🧱 Classes, Instances, and Namespaces

## What is a class?

A class defines the blueprint for an object: its data (fields) and behavior (methods).

```csharp
public class Enemy
{
    public int health;
    public void TakeDamage(int amount)
    {
        health -= amount;
    }
}
```

## What is an instance?

An instance (or object) is a specific, created version of a class that lives in memory.

```csharp
Enemy e = new Enemy();   // e is an instance of Enemy
e.health = 100;
e.TakeDamage(10);
```

In Unity, components (scripts deriving from `MonoBehaviour`) are attached to GameObjects and Unity creates/destroys the instances for you. You rarely use `new` on `MonoBehaviour` classes; instead, you add them via the Inspector or `AddComponent<>()`.

```csharp
// Unity-style instance access
public class Player : MonoBehaviour
{
    private Enemy target;

    void Start()
    {
        target = FindObjectOfType<Enemy>();
        target.TakeDamage(5);
    }
}
```

## What is a namespace?

A namespace groups related types to avoid name collisions and organize code.

```csharp
using UnityEngine; // imports the UnityEngine namespace

public class Mover : MonoBehaviour
{
    void Update()
    {
        // Vector3 comes from the UnityEngine namespace
        transform.position += Vector3.right * Time.deltaTime;
    }
}
```

- `using UnityEngine;` allows you to use types like `MonoBehaviour`, `Vector3`, and `Time` without fully qualifying them (`UnityEngine.Vector3`).
- You can define your own namespaces to organize your code:

```csharp
namespace MyGame.Core
{
    public class GameConfig { }
}

// In another file
using MyGame.Core;

GameConfig cfg = new GameConfig();
```

## Class vs instance vs namespace — quick contrasts

- Class: the definition/blueprint (what an Enemy is and can do).
- Instance: a concrete object created from a class (Enemy e1, e2...).
- Namespace: a container for class names to avoid clashes (UnityEngine, System, YourCompany.YourGame).

When NOT to use (use instead):

- Class instance that holds only data and is frequently copied → consider a `struct` (value type) if it’s small and immutable-ish.
- Deeply nested namespaces for few types → keep namespaces shallow for readability.
- Excessive singletons/static state → prefer explicit dependencies (constructor/field injection) to improve testability.
