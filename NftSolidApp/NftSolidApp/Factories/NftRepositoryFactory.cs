using NftSolidApp.Context;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftRepositoryFactory
    {
        public static NftRepository GetInstance()
        {
            ProjectContext db = ProjectContextFactory.GetInstance();
            return new NftRepository(db);
        }
    }
}
