# 🟠 Access Modifiers

### public

**Meaning:** Can be accessed or changed by other scripts or shown in the Unity Inspector.  
**Example:**

```csharp
public int health = 100;
```

**When to use it:**  
When you want the variable visible or editable from other classes or in the Inspector.

---

### private

**Meaning:** Only used inside the same script it’s written in.  
**Example:**

```csharp
private float stamina = 50f;
```

**When to use it:**  
When you want to keep a variable protected and only changed by this script.
