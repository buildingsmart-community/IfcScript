using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;
using Rhino.Geometry;

using CoordIndex = System.Tuple<int, int, int>; 

namespace IFC.Examples
{
	class IndexedColourMap : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			List<Point3d> points = new List<Point3d>() { new Point3d(0, 0, 0), new Point3d(1000, 0, 0), new Point3d(1000, 1000, 0), new Point3d(0, 1000, 0), new Point3d(0, 0, 2000), new Point3d(1000, 0, 2000), new Point3d(1000, 1000, 2000), new Point3d(0, 1000, 2000) }; 
			IfcCartesianPointList3D cartesianPointList3D = new IfcCartesianPointList3D(db, points);
			List<CoordIndex> coordIndex = new List<CoordIndex>() { new CoordIndex(1, 6, 5), new CoordIndex(1, 2, 6), new CoordIndex(6, 2, 7), new CoordIndex(7, 2, 3), new CoordIndex(7, 8, 6), new CoordIndex(6, 8, 5), new CoordIndex(5, 8, 1), new CoordIndex(1, 8, 4), new CoordIndex(4, 2, 1), new CoordIndex(2, 4, 3), new CoordIndex(4, 8, 7), new CoordIndex(7, 3, 4) };
			IfcTriangulatedFaceSet triangulatedFaceSet = new IfcTriangulatedFaceSet(db, cartesianPointList3D, null, true, coordIndex, null);
			IfcColourRgbList colourRgbList = new IfcColourRgbList(db, new List<Color>() { Color.Red, Color.Green, Color.Yellow });
			IfcIndexedColourMap indexedColourMap = new IfcIndexedColourMap(triangulatedFaceSet, colourRgbList, new List<int>() { 1, 1, 2, 2, 3, 3, 1, 1, 1, 1, 1,1 });

			db.NextObjectRecord = 300;
			IfcBuildingElementProxy buildingElementProxy = new IfcBuildingElementProxy(building,null,new IfcProductDefinitionShape(new IfcShapeRepresentation( triangulatedFaceSet))) { GlobalId = "25c34fWeL1NQux73WfnXox" };
			
		}
	}
}
