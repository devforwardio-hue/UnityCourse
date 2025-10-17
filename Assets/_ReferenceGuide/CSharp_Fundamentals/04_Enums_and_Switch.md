# 🧭 Enums and Switch Statements

Enums help you represent a closed set of named options using meaningful names instead of magic numbers or strings. Switch statements are a clear way to branch logic based on those options (or other types).

## Why use enums?

- Readability: `PowerupType.Jump` is clearer than `2`.
- Safety: limits values to known options.
- Inspector-friendly: Unity shows enum fields as dropdowns.
- Stable IDs: each enum member maps to an underlying integer (0, 1, 2 by default), which you can store or serialize when needed.

```csharp
public enum PowerupType
{
    Movement, // 0
    Jump,     // 1
    Scale     // 2
}

PowerupType t = PowerupType.Movement;
int id = (int)t;         // id == 0
```

You can also assign explicit values to control the mapping:

```csharp
public enum PowerupType { Movement = 10, Jump = 20, Scale = 30 }
```

When to use enums:

- A fixed, closed set of options (states, types, categories).
- You want readable names and an Inspector dropdown.
- You may index arrays or save small IDs via `(int)EnumValue`.

When NOT to use enums (use instead):

- Options change often at runtime or are data‑driven → use `string`/`int` IDs or ScriptableObjects.
- Need behavior per option → consider polymorphism (strategy pattern) instead of long switches.

## Switch on enums (LivePowerup example)

```csharp
switch (type)
{
    case PowerupType.Movement:
        // speed buff
        break;
    case PowerupType.Jump:
        // jump buff
        break;
    case PowerupType.Scale:
        // scale buff
        break;
    default:
        // unknown / not set
        break;
}
```

Tips:

- Always include a `default` for robustness.
- If you add new enum values, update your switch.

Where used in this project:

- `Assets/_Module3/Scripts/Pickup/LivePowerup.cs` uses `switch (type)` where `type` is a `PowerupType` enum.

## Switch can use various types (switch(type))

Classic switch supports integral types, `char`, `string`, and `enum`. C# also supports pattern matching on many types in `switch` expressions/statements.

Examples:

````csharp
// int
switch (scoreTier)
{
    case 0: /* ... */ break;
    case 1: /* ... */ break;
}

// string
switch (input)
{
    case "up":   /* ... */ break;
    case "down": /* ... */ break;
}

// char
switch (key)
{
    case 'W': /* ... */ break;
    case 'S': /* ... */ break;
}

// enum (recommended for closed sets)
switch (state)
{
    case GameState.Playing: /* ... */ break;
    case GameState.Paused:  /* ... */ break;
}

Quick list: `enum`, `int` (and other integral types), `string`, `char`.

When to use switch:
- Multiple branches on the same value (cleaner than many if/else if).
- Branching on `enum`, `int`, `string`, or `char` constants.

When NOT to use switch (use instead):
- Complex conditions, ranges, or overlapping tests → use `if/else` or pattern matching.
- Behavior varies by type hierarchy → use polymorphism/virtual methods.

---

## Switch vs if/else, and what `case` and `break` mean

Think of a `switch` as a cleaner way to write many `if/else if/else` branches that compare the same value.

- `case` — a labeled branch that runs when the `switch` value matches that case’s constant (e.g., `case 1:`, `case "up":`, `case PowerupType.Jump:`).
- `break` — exits the `switch` immediately so later cases don’t run.
- `default` — runs if none of the `case` labels match (similar to the final `else`).

Example side‑by‑side:

```csharp
// if/else if
if (input == "up") {
    MoveUp();
}
else if (input == "down") {
    MoveDown();
}
else {
    Idle();
}

// switch
switch (input)
{
    case "up":
        MoveUp();
        break;               // stop here
    case "down":
        MoveDown();
        break;
    default:
        Idle();
        break;
}
````

Notes:

- In C#, cases do not “fall through” automatically; you must end a case with `break`, `return`, `throw`, or `goto case ...`.
- `default` is optional but recommended.
- Classic `case` labels must be unique compile‑time constants.

```

## When to choose enums

- You have a fixed list of modes/types/states.
- You want clear names and Inspector dropdowns.
- You may need stable numeric IDs `(int)MyEnum.Value` for save/load, analytics, or array indexing.

Cautions:

- Reordering enum members changes their default numeric values. Prefer explicit assignments if numeric IDs matter.
- Don’t persist enum names/values across versions without planning migrations.
```
