# 🧮 Variables and Scope (Fields vs Local Variables)

Understanding where a variable lives and who can access it helps you write clean, bug-free code.

## Fields (a.k.a. member variables)

- Declared inside a class, but outside any method.
- Hold state for the entire object (instance) or class (static).
- In Unity, `public` fields are visible in the Inspector by default.

```csharp
public class Player : MonoBehaviour
{
    // Field (instance variable)
    public int health = 100;

    // Field (private)
    private float stamina = 50f;
}
```

When to use:

- You need data to persist across method calls (e.g., health, score, speed).
- You want to expose tunable values in the Inspector (use `public` or `[SerializeField] private`).

## Local variables

- Declared inside a method or a block `{ }`.
- Only exist while that method/block is running.
- Not visible to other methods.

```csharp
void Heal()
{
    int amount = 10; // local variable
    health += amount;
}
```

When to use:

- Temporary values used to compute something within a single method.
- Avoids polluting the object’s long-term state.

## Choosing between a field and a local variable

- Is the value part of the object’s state? → Field.
- Only needed temporarily to perform a calculation? → Local variable.
- Should a designer tweak it in the Inspector? → Field (public or `[SerializeField]`).
- Is it derived from other fields every frame? → Local (compute on demand), unless profiling says otherwise.

## Scope tips and gotchas

- Variables declared inside `for`, `if`, or `{ }` blocks are not visible outside.
- Shadowing: avoid using the same name for a local variable and a field. Use `this.health` to be explicit when needed.

```csharp
public int health = 50;

void Heal(int health) // parameter named the same as the field
{
    // `health` here refers to the parameter; use `this.health` for the field
    this.health += health;
}
```
