# 🧩 Referencing Components or Scripts

### Accessing a Component on the Same Object

```csharp
Rigidbody rb = GetComponent<Rigidbody>();
```

**When to use it:**  
To interact with Unity’s built-in systems (physics, audio, rendering, etc.).

---

### Accessing Another Script

```csharp
PlayerHealth health = FindObjectOfType<PlayerHealth>();
health.TakeDamage(10);
```

**When to use it:**  
When you need to communicate between scripts — for example, when an enemy damages the player.

---

### Accessing Another GameObject

```csharp
GameObject player = GameObject.Find("Player");
```

**When to use it:**  
When you need to find or affect another object in your scene.
