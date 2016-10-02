using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

namespace BudgetProjectionProject
{
    public interface IXmlSaveable
    {
        string GetReadable();
        string GetXMLSave();
        void GetXMLSave(XmlWriter xw);
        
    }
}
