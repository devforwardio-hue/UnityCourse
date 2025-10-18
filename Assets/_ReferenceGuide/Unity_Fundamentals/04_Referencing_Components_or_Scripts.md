# 🧩 Referencing Components or Scripts

### Accessing a Component on the Same Object

```csharp
Rigidbody rb = GetComponent<Rigidbody>();
```

**When to use it:**  
To interact with Unity’s built-in systems (physics, audio, rendering, etc.).

**When NOT to use it (use instead):**

- You call `GetComponent` every frame → cache the reference (store it in `Awake`/`Start`).
- Component might not exist → use `TryGetComponent` and handle nulls gracefully.

---

### Accessing Another Script

```csharp
PlayerHealth health = FindObjectOfType<PlayerHealth>();
health.TakeDamage(10);
```

**When to use it:**  
When you need to communicate between scripts — for example, when an enemy damages the player.

**When NOT to use it (use instead):**

- Using `FindObjectOfType` repeatedly or in `Update` → cache once or assign via Inspector/serialization.
- Many-to-many relationships → consider events, interfaces, or a manager/service for decoupling.

---

### Accessing Another GameObject

```csharp
GameObject player = GameObject.Find("Player");
```

**When to use it:**  
When you need to find or affect another object in your scene.

**When NOT to use it (use instead):**

- Relying on names (`GameObject.Find("Player")`) → prefer tags, serialized fields, or scene references.
- Frequent lookups → cache or wire references in the Inspector.
