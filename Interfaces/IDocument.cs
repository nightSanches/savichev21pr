using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace savichev21pr.Interfaces
{
    public interface IDocument
    {
        void Save(bool Update = false);
        List<Documents.Classes.DocumentContext> AllDocuments();
        void Delete();
    }
}
