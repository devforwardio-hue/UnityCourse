# 🟠 Access Modifiers

### public

**Meaning:** Can be accessed or changed by other scripts or shown in the Unity Inspector.  
**Example:**

```csharp
public int health = 100;
```

**When to use it:**  
When you want the variable visible or editable from other classes or in the Inspector.

**When NOT to use it (use instead):**

- Internal implementation details → use `private` and expose via methods/properties.
- Inspector-only editing without public access → keep it `private` and add `[SerializeField]`.
- Shared across many classes without instance state → consider `static` members sparingly.

---

### private

**Meaning:** Only used inside the same script it’s written in.  
**Example:**

```csharp
private float stamina = 50f;
```

**When to use it:**  
When you want to keep a variable protected and only changed by this script.

**When NOT to use it (use instead):**

- Needs to be read/edited by other scripts → use `public` or keep `private` with a public property.
- Designer must tweak in Inspector → keep `private` with `[SerializeField]`.
