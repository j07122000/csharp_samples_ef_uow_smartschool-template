using System;

namespace SmartSchool.Core.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();

        void DeleteDatabase();

        void MigrateDatabase();
    }
}
