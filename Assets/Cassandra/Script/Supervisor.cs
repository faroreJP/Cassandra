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
  public class Supervisor : MonoBehaviour, ISupervisor {
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

    // Create supervisor object
    // @Return : the supervisor instance
    public static ISupervisor CreateSupervisor () {
      var obj = new GameObject("CassandraSupervisor", typeof(Supervisor));
      return obj.GetComponent<ISupervisor>();
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
