//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//
// The Cassandra supervisor interface
//
// @Author : Farore
// @Date   : 2018/03/23
//
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

namespace Cassandra {
  public delegate void Order ();

  public interface ISupervisor {
    // Add action order to execute in main thread
    // @Param[in] order : the order delegate
    void AddOrder (Order order);
  }
}
