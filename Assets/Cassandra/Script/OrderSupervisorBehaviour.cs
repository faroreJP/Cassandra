//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//
// Basic inplementation of ISupervisor
//
// @Author : Farore
// @Date   : 2018/03/23
//
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cassandra {
  public class OrderSupervisorBehaviour : MonoBehaviour, IOrderSupervisor {
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Field
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    private Queue<Order>  _orders = new Queue<Order>();

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Unity Callback
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    private void Update () {
      while (_orders.Count > 0) {
        var order = _orders.Dequeue();
        order.Invoke();
      }
    }

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Public Static Method
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    public int OrderCount { get { return _orders.Count; } }

    // Create supervisor object
    // @Return : the supervisor instance
    public static IOrderSupervisor CreateSupervisor () {
      var obj = new GameObject("OrderSupervisor", typeof(OrderSupervisorBehaviour));
      return obj.GetComponent<IOrderSupervisor>();
    }

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // ISupervisor
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    // Add action order to execute in main thread
    // @Param[in] order : the order delegate
    public void AddOrder (Order order) {
      _orders.Enqueue(order);
    }
  }
}
