using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using BudgetProjectionProject.DateStrategies;

namespace BudgetProjectionProject.Budgets
{

    /// <summary>
    /// Wraps a plan with a fund.
    /// </summary>
    public class FundedPlan : Plan
    {
        public Fund Source;

        public FundedPlan(string id, float amount, DateStrategy strategy, Fund fund) : base(id, amount, strategy)
        {
            Source = fund;
        }



        public override string GetXMLSave()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var sw = new StringWriter())
            {
                using (var xw = XmlWriter.Create(sw, settings))
                {
                    GetXMLSave(xw);
                    return sw.ToString();
                }

            }
        }

        public override void GetXMLSave( XmlWriter xw)
        {
            base.GetXMLSave(xw);
            xw.WriteStartElement("SourceFund");
            Source.GetXMLSave(xw);
            xw.WriteEndElement();
            xw.Flush();
        }
    }
}
