using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitApiOnline.Implement;
using RevitApiOnline.Interfaces;
using RevitApiOnline.Wpf;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RevitApiOnline
{
    [Transaction (TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            //
            #region CreateWall

            //ICollection<ElementId> ids = uidoc.Selection.GetElementIds();
            //List<Curve> listCurve = new List<Curve>();
            //foreach (ElementId id in ids)
            //{
            //    DetailCurve detailCurve = doc.GetElement(id) as DetailCurve;
            //    Curve curve = detailCurve.GeometryCurve;
            //    if (curve != null)
            //    {
            //        listCurve.Add(curve);
            //    }
            //}
            //View view = doc.ActiveView;
            //Level level = view.GenLevel;

            //using (Transaction t = new Transaction(doc, "Create Wall"))
            //{
            //    t.Start();
            //    foreach (Curve item in listCurve)
            //    {
            //        Wall wall = Wall.Create(doc, item, level.Id, false);
            //    }
            //    t.Commit();
            //}
            #endregion

            #region OffsetWall
            // chọn bằng cách pick chọn nhiều tường.
            //IList<Reference> listRefe= uidoc.Selection.PickObjects(ObjectType.Element, new WallSelect(), "Pick Wall");



            //IList<Element> listElement = uidoc.Selection.PickElementsByRectangle(new WallSelect(), "Pick Wall");

            //List<Wall> listWall = new List<Wall>();
            //foreach (Element eleItem in listElement)
            //{
            //    //Wall wallRefe = doc.GetElement(eleItem) as Wall; //DÙNG CHO PICK TƯỜNG.

            //    Wall wallItem = eleItem as Wall;
            //    if (wallItem != null)
            //    {
            //        listWall.Add(wallItem);
            //    }
            //}

            //double valueOffset = -160;
            //double valueInch = UnitUtils.ConvertToInternalUnits(valueOffset, UnitTypeId.Millimeters);

            //using (Transaction t = new Transaction(doc, "Create Wall"))
            //{
            //    t.Start();
            //    foreach (Wall item in listWall)
            //    {
            //        Parameter paraItem = item.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET);
            //        paraItem.Set(valueInch);
            //    }
            //    t.Commit();
            //}
            #endregion

            #region CreateDimensiom
            //// 　TẠO DIMENSION
            //IList<Reference> listRef= uidoc.Selection.PickObjects(ObjectType.Element, new WallSelect(), "Pick Wall");
            //List<Wall> listWall = new List<Wall>();
            //foreach (Reference reference1 in listRef)
            //{
            //    Wall wall = doc.GetElement(reference1) as Wall;
            //    if (wall != null)
            //    {
            //        listWall.Add(wall);
            //    }
            //}

            //View view = doc.ActiveView;
            //ReferenceArray referenceArray = new ReferenceArray();
            //foreach (Wall wall in listWall)
            //{
            //    Reference refExternal= HostObjectUtils.GetSideFaces(wall, ShellLayerType.Exterior).First();
            //    Reference refInternal = HostObjectUtils.GetSideFaces(wall, ShellLayerType.Interior).First();
            //    referenceArray.Append(refExternal);
            //    referenceArray.Append(refInternal);
            //}

            //Reference refFirst = referenceArray.get_Item(0);
            //Element reference = doc.GetElement(refFirst) as Element;
            //Face face = reference.GetGeometryObjectFromReference(refFirst) as Face;
            //PlanarFace planarFace = face as PlanarFace;
            //XYZ normalFace = planarFace.FaceNormal.Normalize(); ;

            //XYZ pointPutDim= uidoc.Selection.PickPoint("Pick Point");

            //Line line = Line.CreateUnbound(pointPutDim, normalFace);
            //using ( Transaction t = new Transaction(doc,"Create Dim"))
            //{
            //    t.Start();
            //    doc.Create.NewDimension(view, line, referenceArray);
            //    t.Commit();
            //}
            #endregion

            #region OffseFloor
            //// OFFSET FLOOR
            //IList<Reference> listRef= uidoc.Selection.PickObjects(ObjectType.Element, new FloorSelec(), "Pick Floor");
            //List<FloorType> listFloorType = new List<FloorType>();
            //foreach ( Reference reference in listRef)
            //{
            //    Floor floor = doc.GetElement(reference) as Floor;
            //    ElementId elementId = floor.GetTypeId();
            //    FloorType floorType = doc.GetElement(elementId) as FloorType;
            //    if (floorType != null)
            //    {
            //        listFloorType.Add(floorType);
            //    }
            //}
            //using (Transaction t = new Transaction(doc,"Edit TypeMark"))
            //{
            //    t.Start();
            //    foreach ( FloorType item in listFloorType )
            //    {
            //        Parameter para = item.get_Parameter(BuiltInParameter.WINDOW_TYPE_ID);
            //        para.Set("FS2");
            //    }
            //    t.Commit();
            //}
            #endregion

            #region Nghien2DauBeam
            //// NGHIÊNG 2 ĐẦU DẦM
            //IList<Reference> listref= uidoc.Selection.PickObjects(ObjectType.Element, new BeamSelec(), "Pick Beam");
            //List<FamilyInstance> listFamily = new List<FamilyInstance>();
            //foreach (Reference reference in listref)
            //{
            //    FamilyInstance family = doc.GetElement(reference) as FamilyInstance;
            //    listFamily.Add(family);
            //}

            //double valueMilli = -165;
            //double valueInch = UnitUtils.ConvertToInternalUnits(valueMilli, UnitTypeId.Millimeters);

            //using (Transaction t = new Transaction(doc,"Offset Beam"))
            //{
            //    t.Start();
            //    foreach (FamilyInstance item in listFamily)
            //    {
            //        Parameter para = item.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION);
            //        para?.Set(valueInch);

            //        double valueMilli1 = -365;
            //        double valueInch1 = UnitUtils.ConvertToInternalUnits(valueMilli1, UnitTypeId.Millimeters);

            //        Parameter para1 = item.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION);
            //        para1?.Set(valueInch1);

            //    }
            //    t.Commit();
            //}
            #endregion


            #region CacCachFilter
            //// Filter
            //List<Element> typeWall = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Walls)
            //    .WhereElementIsElementType().ToElements().ToList();
            //List<Element> walls = new FilteredElementCollector(doc, doc.ActiveView.Id)
            //    .OfClass(typeof(Wall)).ToElements().ToList();


            // //  CÁCH HAY DÙNG NHẤT:
            //string nameWall = "Generic - 8\"";
            //long id = 1241973;
            //List<Element> name01 = walls.Where(x => x.Name == nameWall && x.Id.Value == id).ToList();

            ////// Viết rõ là câu lệnh bên trên.
            //List<Element> name03 = walls.Where(x =>
            //{
            //    bool isTrueType = x.Name == nameWall;
            //    bool isTrueId = x.Id.Value == id;
            //    return isTrueType && isTrueId;
            //}).ToList();

            ////// Viết rõ là câu lệnh bên dưới. khi không có tìm thêm Id.

            ////List<Element> name02 = new List<Element>();
            ////foreach (var item in walls)
            ////{
            ////    if ( item.Name == nameWall)
            ////    {
            ////        name02.Add(item);
            ////    }
            ////}


            //// Cách viết thứ 3:
            //Func<Element, bool> functionTypeId = (item) =>
            //{
            //    bool isTrue = item.Name == nameWall && item.Id.Value == id;
            //    return isTrue;
            //};
            //List<Element> name4 = walls.Where(functionTypeId).ToList();


            ////Filter Beam
            //List<Element> beamName = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming)
            //    .WhereElementIsNotElementType().ToElements().ToList();
            //string nameValue = "300x600";
            //List<Element> name300x600 = beamName.Where(x => x.Name== nameValue).ToList();
            #endregion

            #region OffsetFloorFromTypeName
            //// Offset Floor

            //IList<Element> listElement = uidoc.Selection.PickElementsByRectangle(new FloorSelec(), "Selec Floor");
            //List<Floor> listFloor = new List<Floor>();
            //foreach (Element element in listElement)
            //{
            //    Floor floor = element as Floor;
            //    if (floor != null)
            //    {
            //        listFloor.Add(floor);
            //    }
            //}
            //double valueMili = 0015;
            //double valueInch = UnitUtils.ConvertToInternalUnits(valueMili, UnitTypeId.Millimeters);

            ////// filter name floor
            ////List<Element> floors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Floors)
            ////    .WhereElementIsNotElementType().ToElements().ToList();

            //string nameFl = "Generic - 12\"";
            //List<Floor> nameFloor = listFloor.Where(x=> x.Name == nameFl).ToList();


            //using ( Transaction t = new Transaction(doc,"Offset Floor"))
            //{
            //    t.Start();
            //    foreach ( Floor item in nameFloor)
            //    {
            //        Parameter para = item.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM);
            //        para?.Set(valueInch);
            //    }
            //    t.Commit();
            //}
            #endregion


            #region Cach1.SelecColumnFromOffsetAndMaterial

            //FilteredElementCollector filterCollector = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns)
            //    .WhereElementIsNotElementType();

            //double valueMili = -1800;
            //double valueInch = UnitUtils.ConvertToInternalUnits(valueMili, UnitTypeId.Millimeters);
            //string materialColum = "Cherry";
            //List<Element> elementOffset = filterCollector.Where(x =>
            //{
            //    Parameter paraOffset = x.get_Parameter(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM);
            //    double doubleOfsset = paraOffset.AsDouble();

            //    Parameter paraMaterial = x.get_Parameter(BuiltInParameter.STRUCTURAL_MATERIAL_PARAM);
            //    string valueMaterial = paraMaterial.AsValueString();

            //    return Math.Abs(doubleOfsset - valueInch) < 0.0001 && valueMaterial == materialColum;
            //}).ToList();

            //IEnumerable<ElementId> selectColumns= elementOffset.Select(x => x.Id);
            //uidoc.Selection.SetElementIds(selectColumns.ToList());

            #endregion

            #region Cach2.SelecColumnFromOffsetAndMaterial

            //double valueMili = -1500;
            //double valueInch = UnitUtils.ConvertToInternalUnits(valueMili, UnitTypeId.Millimeters);

            //FilteredElementCollector filterCollector = new FilteredElementCollector(doc, doc.ActiveView.Id)
            //             .OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType();

            //ElementId elementIdFilter = new ElementId(BuiltInParameter.FAMILY_BASE_LEVEL_OFFSET_PARAM);
            //FilterRule filterRuleOffset = ParameterFilterRuleFactory.CreateEqualsRule(elementIdFilter, valueInch, 0.0001);
            //ElementParameterFilter filterColumnOffset = new ElementParameterFilter(filterRuleOffset);

            //ElementId elementLevel = new ElementId(BuiltInParameter.FAMILY_BASE_LEVEL_PARAM);
            //FilterRule filterRuleLevel = ParameterFilterRuleFactory.CreateEqualsRule(elementLevel, new ElementId((long)9946));
            //ElementParameterFilter filterClumnLevel = new ElementParameterFilter(filterRuleLevel);

            //ElementId elementMate = new ElementId(BuiltInParameter.STRUCTURAL_MATERIAL_PARAM);
            //Material materialChery = new FilteredElementCollector(doc).OfClass(typeof(Material)).Cast<Material>().First(x => x.Name == "Cherry");
            //FilterRule filterRuleMate = ParameterFilterRuleFactory.CreateEqualsRule(elementMate, materialChery.Id);
            //ElementParameterFilter elementFilterMate = new ElementParameterFilter(filterRuleMate);


            //List<ElementFilter> listIdColumn = new List<ElementFilter> { filterColumnOffset, filterClumnLevel };
            //LogicalAndFilter logicalAndFilter = new LogicalAndFilter(listIdColumn);

            //List<ElementFilter> listFilterOr = new List<ElementFilter> { logicalAndFilter, elementFilterMate };
            //LogicalOrFilter logicalOrFilter = new LogicalOrFilter(listFilterOr);

            //IEnumerable<Element> filterColumnOff = filterCollector.WherePasses(elementFilterMate);

            //IEnumerable<ElementId> filterItem = filterColumnOff.Select(x => x.Id);
            //uidoc.Selection.SetElementIds(filterItem.ToList());
            #endregion

            IList<Reference> listRef = uidoc.Selection.PickObjects(ObjectType.Element, new WallSelect(), "Pick Wall");
            List<Wall> listWall = new List<Wall>();
            foreach (Reference reference in listRef)
            {
                Element element = doc.GetElement(reference);
                Wall wall = element as Wall;
                if (wall!= null)
                {
                    listWall.Add(wall);
                }
            }

            double valueMili = 535;
            double valueFeet = UnitUtils.ConvertToInternalUnits(valueMili, UnitTypeId.Millimeters);

            using( Transaction t = new Transaction(doc,"OffsetWall"))
            {
                t.Start();
                foreach (Wall item in listWall)
                {
                    Parameter para = item.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET);
                    para?.Set(valueFeet);
                }
                t.Commit();
            }

            //GridLearn form = new GridLearn();
            //form.ShowDialog();
            return Result.Succeeded;

        }
    }

    public class WallSelect : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem != null && elem is Wall)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;


        }
      
    }
    public class FloorSelec : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
           if (elem !=null && elem is Floor)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    public class BeamSelec : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if(elem != null && elem is FamilyInstance)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }

    
}
