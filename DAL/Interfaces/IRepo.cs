using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepo<Type, ID, RET>
    {
        RET Create(Type obj);
        List<Type> Read();
        Type Read(ID id);
        RET Update(Type obj);
        bool Delete(ID id);

        List<Type> ReadByCategory(string category);
        List<Type> ReadByDate(DateTime date);
        List<Type> ReadRecurring();
    }
}
