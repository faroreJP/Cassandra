//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//
// Basic inplementation of ISupervisor
//
// @Author : Farore
// @Date   : 2018/04/20
//
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

using System.Collections;
using System.Collections.Generic;

namespace Cassandra {
  public class OrderSupervisor : IOrderSupervisor {
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Field
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    private Queue<Order> _orders = new Queue<Order>();

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Public Method
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    // Execute 1 order
    // @Return :
    //   true  - order was executed
    //   false - otherwise
    public bool ExecuteOrder () {
      if (OrderCount == 0) return false;
      _orders.Dequeue().Invoke();
      return true;
    }

    // Execute all orders
    public void ExecuteAllOrders () {
      while (ExecuteOrder());
    }

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // IOrderSupervisor
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    public int OrderCount { get { return _orders.Count; } }

    // Add action order to execute in main thread
    // @Param[in] order : the order delegate
    public void AddOrder (Order order) {
      _orders.Enqueue(order);
    }
  }
}
