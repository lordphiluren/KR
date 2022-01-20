using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public interface IStorage<TEntity>
    {
        TEntity Load();
        void Save(TEntity data);
    }
}