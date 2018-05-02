# About
C# library for unity3d.
It provides classes for aggregating processes and executing on the main thread.

# Installation
1. Open project on unity editor, then export `Assets/Cassandra` as `cassandra.unity3d`
2. Import `cassandra.unity3d` to your project.

# Usage
## Register order
```cs
public void HelloWorld (IOrderSupervisor orderSupervisor) {
  orderSupervisor.AddOrder(() => Debug.Log("hello world"));
}
```

## Execute order
### OrderSupervisor
```cs
var orderSupervisor = new OrderSupervisor();

// some process ...

orderSupervisor.ExecuteOrder();
```

### OrderSupervisorBehaviour
There is no need to think.  
OrderSupervisorBehaviour always executes orders on Update() while it is enabled.
