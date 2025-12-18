# 🔵 Functions (Methods)

### Basic Format

```csharp
void FunctionName()
{
    // Code to run
}
```

### Example

```csharp
void Jump()
{
    Debug.Log("Player Jumped!");
}
```

**When to use it:**  
When you want to group a set of instructions to be reused or called by other scripts or events.

---

### Public vs Private Functions

- **Public** → other scripts can call it
  ```csharp
  public void TakeDamage(int amount) { ... }
  ```
- **Private** → only this script can call it
  ```csharp
  private void Heal() { ... }
  ```

When NOT to use (use instead):

- Don’t make everything `public` just to “access it later” → keep methods `private` by default; expose a minimal `public` API.
- Need external control with validation or events → expose a `public` method that wraps `private` logic, or use C# properties/events.
- Pure helpers with no instance state → consider `static` methods in a utility class.

---

### Parameters (passing information)

Parameters are the named inputs in a function definition; arguments are the actual values you pass when calling it.

```csharp
// parameters: amount, multiplier (multiplier has a default value)
public void DealDamage(int amount, float multiplier = 1f)
{
    int final = Mathf.RoundToInt(amount * multiplier);
    TakeDamage(final);
}

// calling with arguments
DealDamage(10);        // uses default multiplier = 1f
DealDamage(10, 1.5f);  // passes 1.5f as the multiplier
```

Notes:

- In C#, parameters are passed by value by default. For value types (like int, float), changes inside the method don’t affect the caller’s variable.
- For reference types (like classes), the reference is passed by value. You can modify the object’s fields, but reassigning the parameter won’t affect the caller’s variable unless you use `ref`.
- Use `ref` or `out` for advanced cases where the method should modify the caller’s variable itself.

When NOT to use (use instead):

- Too many parameters (3–4+) → group into a small config class/struct or expose fields/properties on the class.
- Passing many values by `ref/out` → prefer returning a result object or encapsulating state in a class.
- Repeatedly passing dependencies (player, input, logger) → inject/store them once as fields.

```csharp
// Example: reference type behavior
public class Stats { public int health; }

void Buff(Stats s)
{
    s.health += 10;     // modifies the same object the caller holds
    // s = new Stats(); // would NOT change caller's reference (without ref)
}
```
