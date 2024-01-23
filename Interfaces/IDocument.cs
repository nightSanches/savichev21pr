using System.Collections.Generic;

namespace savichev21pr.Interfaces
{
    public interface IDocument
    {
        void Save(bool Update = false);
        List<Classes.DocumentContext> AllDocuments();
        void Delete();
    }
}
