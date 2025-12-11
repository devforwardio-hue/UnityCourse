# ⏱️ Time Management in Unity

Understanding Unity's time system helps you create effects that last for a duration, animate smoothly, and behave consistently across frame rates.

## Core properties

- `Time.time` — seconds since the start of the game (scaled by `timeScale`). Useful for timestamps and durations.
  - When NOT to use (use instead): Paused game or UI timers → use `Time.unscaledTime`.
- `Time.deltaTime` — time passed since last frame. Multiply movement/animations by this for frame-rate independent motion (in `Update`).
  - When NOT to use (use instead): Physics calculations → use `FixedUpdate` and `Time.fixedDeltaTime`.
- `Time.fixedDeltaTime` — fixed timestep used by physics (default 0.02s). Physics runs in `FixedUpdate`.
  - When NOT to use (use instead): Rendering/animation code tied to frame rate → use `Update` and `Time.deltaTime`.
- `Time.timeScale` — global time multiplier. Set to 0 to pause, >1 to speed up. Affects `time`, `deltaTime`, and physics.
  - When NOT to use (use instead): Pausing only certain systems → gate logic with your own flags or use `Animator.updateMode = UnscaledTime` selectively.

## Duration pattern (used in buffs)

Pattern: set an "expire at" timestamp once, and compare against `Time.time` every frame.

```csharp
// When activating the buff
float duration = 10f;
expireAt = Time.time + duration;
isActive = true;

// In Update():
if (isActive)
{
    if (Time.time > expireAt)
    {
        // restore defaults and end buff
        isActive = false;
    }
}
```

In your project, this is used in the buff scripts:

- `Buff_Movement`: `buff_movementScript.maxTime = maxTime + Time.time;` then compare `currentTime = Time.time; if (currentTime > maxTime) ...`.
- `Buff_Jump`: same pattern to restore `jumpForce` after the duration.

This approach is robust because it doesn’t accumulate error over frames and gracefully handles low frame rates.

## Update vs FixedUpdate

- Use `Update` with `Time.deltaTime` for input, non-physics animations, and timer checks.
- Use `FixedUpdate` for physics interactions; physics steps at `Time.fixedDeltaTime`.

Timers based on timestamps (`Time.time`) can safely be checked in `Update`. If your effect is strictly physics-based, you can check in `FixedUpdate`.

## Pausing and unscaled time

If you pause the game via `Time.timeScale = 0`, both `Time.time` and `Time.deltaTime` stop advancing. For UI timers or effects that should ignore pause, use:

- `Time.unscaledTime`
- `Time.unscaledDeltaTime`

Then base your duration on `unscaledTime` instead of `time`.

## Common patterns

- Frame-rate independent movement: `transform.position += velocity * Time.deltaTime;`
- Cooldowns: `nextUseAt = Time.time + cooldown; if (Time.time >= nextUseAt) { Use(); }`
- Lerp over duration: keep `startTime = Time.time; t = (Time.time - startTime)/duration;`
