using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StructureMap;
using FirstApiSandbox.Database;

namespace FirstApiSandbox.BookStructureMap
{
    public class BookDataRegistry : Registry
    {
        public BookDataRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<IBookDatabase>().Use<BookData>();
        }
    }
}
