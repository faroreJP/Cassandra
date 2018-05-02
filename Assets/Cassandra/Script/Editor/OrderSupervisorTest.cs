//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//
// Test code for OrderSupervisor
//
// @Author : Farore
// @Date   : 2018/05/02
//
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Cassandra;

public class OrderSupervisorTest {
  [Test]
  public void SupervisorHasNoOrdersOnCreation () {
    var orderSupervisor = new OrderSupervisor();

    Assert.That(orderSupervisor.OrderCount, Is.Zero, "OrderSupervisor has order on creation");
  }

  [Test]
  public void SupervisorAggregatesOrder () {
    var orderSupervisor = new OrderSupervisor();

    orderSupervisor.AddOrder(() => {});
    Assert.That(orderSupervisor.OrderCount, Is.EqualTo(1), "OrderSupervisor has no order");
  }

  [Test]
  public void OrderSupervisorExecutedAllOrdersCorrectly () {
    var orderSupervisor = new OrderSupervisor();
    var orderCount      = 10;
    var executeCount    = 0;

    for (int i = 0;i < orderCount;i++) {
      orderSupervisor.AddOrder(() => executeCount++);
    }
    orderSupervisor.ExecuteAllOrders();

    Assert.That(orderSupervisor.OrderCount, Is.Zero,                "OrderSupervisor has some order");
    Assert.That(executeCount,               Is.EqualTo(orderCount), "OrderSupervisor did not execute orders correctly");
  }

  [Test]
  public void SupervisorExecutesOrderCorrectly () {
    var orderSupervisor = new OrderSupervisor();
    var someFlag        = false;

    orderSupervisor.AddOrder(() => someFlag = true);

    var wasOrderExecuted = orderSupervisor.ExecuteOrder();
    Assert.That(wasOrderExecuted, Is.True, "OrderSupervisor did not execute order");
    Assert.That(someFlag,         Is.True, "OrderSupervisor did not execute order correctly");
  }

  [Test]
  public void OrderCountWillBeZeroAfterOrderExecuted () {
    var orderSupervisor = new OrderSupervisor();
    orderSupervisor.AddOrder(() => {});
    orderSupervisor.ExecuteOrder();

    Assert.That(orderSupervisor.OrderCount, Is.Zero, "OrderSupervisor has some order");
  }
}
