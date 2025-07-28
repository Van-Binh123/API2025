using Autodesk.Revit.DB;
using RevitApiOnline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitApiOnline.Implement
{
    public class CurveUtility : ICurveUtility
    {
        public List<Curve> listCurveFromDetailCurve(Document doc, ICollection<ElementId> ids)
        {
            List<Curve> listCurveResult= new List<Curve>();
            foreach (ElementId id in ids)
            {
                Element element = doc.GetElement(id);
                bool isCurve = element is DetailCurve;
                if (isCurve)
                {
                    DetailCurve detailCurve = element as DetailCurve;
                    Curve curve = detailCurve.GeometryCurve;
                    listCurveResult.Add(curve);
                }
            }

           return listCurveResult;
        }
    }
}
