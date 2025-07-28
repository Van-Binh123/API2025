using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitApiOnline.Implement;
using RevitApiOnline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RevitApiOnline.RevitLearnApi
{
    public class RevitLearnApi
    {
        public void Learn(UIDocument uidoc, Document doc)
        {
            ICollection<ElementId> ids = uidoc.Selection.GetElementIds();

            ICurveUtility curveUtility = new CurveUtility();
            List<Curve> listCurveWall = curveUtility.listCurveFromDetailCurve(doc, ids);


            View view = doc.ActiveView;
            Level level = view.GenLevel;

            Parameter levelParameter = view.get_Parameter(BuiltInParameter.PLAN_VIEW_LEVEL);
            string valueLevel = levelParameter.AsString();

            using (Transaction t = new Transaction(doc, "Create Wall"))
            {
                t.Start();
                foreach (Curve curve in listCurveWall)
                {
                    Wall wall = Wall.Create(doc, curve, level.Id, false);
                }

                t.Commit();
            }




            ICollection<ElementId> ids1 = uidoc.Selection.GetElementIds();

            // XYZ point1= uidoc.Selection.PickPoint("pick point 1");
            // XYZ point2 = uidoc.Selection.PickPoint("pick point 2");


            Reference pickFace = uidoc.Selection.PickObject(ObjectType.Face, "Pick Face");

            //ép kiểu qua Face.
            Element elementFace = doc.GetElement(pickFace);
            Face eleFace = elementFace.GetGeometryObjectFromReference(pickFace) as Face;


            //  Reference pickObject = uidoc.Selection.PickObject(ObjectType.Element, "Pick Object");


            //dùng filter. chỉ pick dc Wall
            Reference reference = uidoc.Selection.PickObject(ObjectType.Element, new WallSelect(), "Pick Wall Filter");

            IList<Element> referRactango = uidoc.Selection.PickElementsByRectangle(new WallSelect(), "SelectRactan");
            Element element = doc.GetElement(reference);


        }
    }
}