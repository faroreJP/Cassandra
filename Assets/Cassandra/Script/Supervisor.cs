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

    private const string        SupervisorPrefabPath  = "Cassandra/Supervisor";
    private       Queue<Order>  _orders               = new Queue<Order>();

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
      var prefab = Resources.Load<GameObject>(SupervisorPrefabPath);
      if (prefab == null) {
        throw new System.ApplicationException("[Cassandra] Prefab not found! : " + SupervisorPrefabPath);
      }

      var obj = GameObject.Instantiate(prefab);
      if (obj == null) {
        throw new System.ApplicationException("[Cassandra] Failed to instantiate supervisor!" + SupervisorPrefabPath);
      }

      var supervisor = obj.GetComponent<ISupervisor>();
      if (supervisor == null) {
        throw new System.ApplicationException("[Cassandra] The instantiated supervisor doesn't has ISupervisor!" + SupervisorPrefabPath);
      }

      return supervisor;
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
