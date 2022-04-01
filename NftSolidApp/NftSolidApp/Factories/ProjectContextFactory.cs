using NftSolidApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class ProjectContextFactory
    {
        public static ProjectContext GetInstance()
        {
            return new ProjectContext();
        }
    }
}
