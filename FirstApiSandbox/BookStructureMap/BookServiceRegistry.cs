using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StructureMap;
using FirstApiSandbox.Service;

namespace FirstApiSandbox.BookStructureMap
{
    public class BookServiceRegistry : Registry
    {
        public BookServiceRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<IService>().Use<BookService>();
        }
    }
}
