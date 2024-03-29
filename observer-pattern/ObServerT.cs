using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace observer_pattern
{
    public interface ObServer
    {
        void Update();       
    }
    public interface ObServer<T>
    {
        // วิธีแบบ push เพื่อแยก type ออกจากกัน
        void Update(T value);

    }

}