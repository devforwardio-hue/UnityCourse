# 🟢 Primitive Data Types

Memory note: Larger data types generally take more memory. Typical sizes in C# are: `bool` (1 byte), `char` (2 bytes, UTF-16), `int` (4 bytes), `float` (4 bytes), `double` (8 bytes). `string` holds a reference; the characters live on the heap (2 bytes per character).

### int

**Meaning:** An individual number (whole number, no decimals).  
**Example:**

```csharp
int damage = 5;  // Damage will do a total of 5
```

**When to use it:**  
When you need to store or calculate a solid number like health, score, or item count.

**When NOT to use it (use instead):**

- You need decimals → use `float` (Unity-friendly) or `double`.
- You need true/false → use `bool`.
- You need a very small set of named states → use an `enum`.

---

### float

**Meaning:** A number that can include decimals.  
**Example:**

```csharp
float speed = 3.5f;  // Player moves at 3.5 units per second
```

**When to use it:**  
For measurements that require precision, like movement speed, time, or distance.

**When NOT to use it (use instead):**

- You need whole numbers only (IDs, counts) → use `int`.
- You need very high precision (rare in Unity) → use `double`.
- You’re dealing with money/currency → consider `decimal` (C#), not typically used in Unity gameplay.

---

### double

**Meaning:** A larger and more precise version of a float.  
**Example:**

```csharp
double playerAccuracy = 99.9999;
```

**When to use it:**  
When you need very precise decimal numbers (rare in most Unity projects).

**When NOT to use it (use instead):**

- General Unity gameplay values (positions, speeds) → use `float` for compatibility/perf.
- Whole numbers → use `int`.

---

### string

**Meaning:** A group of text characters.  
**Example:**

```csharp
string playerName = "Ryan";
```

**When to use it:**  
Whenever you need to store or display words, sentences, or names.

**When NOT to use it (use instead):**

- Single character → use `char`.
- Numeric values → use `int`, `float`, or `double`.
- A small set of named options → use an `enum`.

---

### bool

**Meaning:** A true or false value.  
**Example:**

```csharp
bool isJumping = false;
```

**When to use it:**  
When something can only have two states, like on/off, open/closed, alive/dead.

**When NOT to use it (use instead):**

- More than two states → use an `enum`.
- Unknown/tri-state (true/false/unknown) → use `bool?` or an `enum`.

---

### char

**Meaning:** A single text character (not a full word).  
**Example:**

```csharp
char grade = 'A';
```

**When to use it:**  
When you only need one letter or symbol, not an entire string.

**When NOT to use it (use instead):**

- Words or sentences → use `string`.
- Numeric code points or counts → use `int`.
