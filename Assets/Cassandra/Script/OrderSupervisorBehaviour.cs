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

    private OrderSupervisor _orderSupervisor = new OrderSupervisor();

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Unity Callback
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    private void Update () {
      _orderSupervisor.ExecuteAllOrders();
    }

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // Public Static Method
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    // Create supervisor object
    // @Return : the supervisor instance
    public static IOrderSupervisor CreateSupervisor () {
      var obj = new GameObject("OrderSupervisor", typeof(OrderSupervisorBehaviour));
      return obj.GetComponent<IOrderSupervisor>();
    }

    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    // IOrderSupervisor
    //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    public int OrderCount { get { return _orderSupervisor.OrderCount; } }

    // Add action order to execute in main thread
    // @Param[in] order : the order delegate
    public void AddOrder (Order order) {
      _orderSupervisor.AddOrder(order);
    }
  }
}
