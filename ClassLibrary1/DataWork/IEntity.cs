using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public interface IEntity<T> 
        where T: IEquatable<T>, IComparable<T>
    {
        T Id { get; set; }
    }
}
