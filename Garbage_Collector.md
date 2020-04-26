# Overview of the Garbage Collector
*C# is a managed language that uses a garbage collector to free memory whenever necessary.*
```
When writing applications, users often cross the boundaries and use unmanaged resources such as database connections or file handles.
```
1. **CLR** uses **stack** to keep track of **what's executing** in the code; **HEAP** to keep track of the **objects**.
- The **stack** is automatically cleared at the end of a method. The CLR takes care of it,user don't have to worry.
- The **heap** is managed by the garbage collector.
***
2. The **garbage collector** works with a **Mark and Compact** Algorithm. Tha Mark phase of a collection checks which items on the heap are still being referenced by a root item.
- A **root** can be a static field, a method parameter, a local variable, or a CPU register.
- If the GC finds a "living" item on the heap, it **marks** the item.
- After checking the whole heap, the **Compact** operation starts. 
- The GC then moves all living heap objects close together and frees the memory for all other objects.
***
3. All threads are **frozen** while doing a garbage collect operation.
- The GC starts cleaning up **only when** there's not enough room on the heap to construct a new obj.
- Or when Windows signals that it is low on memory.
***
4. The Garbage Collector removes item from the heap that are not no longer necessary and ensures that no obj can stay alive and occupy memory if it's not in use.
