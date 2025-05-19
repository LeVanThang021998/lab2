using System;
using System.Collections.Generic;

namespace WebBanHang.Controllers
{
    internal class ApplicationDbContext
    {
        public object Products { get; internal set; }
        public IEnumerable<object> Categories { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}