using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;

using CoordIndex = System.Tuple<int, int, int>; 

namespace IFC.Examples
{
	class IndexedColourMap : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			List<Point3d> points = new List<Point3d>() { new Point3d(0, 0, 0), new Point3d(1000, 0, 0), new Point3d(1000, 1000, 0), new Point3d(0, 1000, 0), new Point3d(0, 0, 2000), new Point3d(1000, 0, 2000), new Point3d(1000, 1, 2000), new Point3d(0, 1000, 2000) };
			IfcCartesianPointList3D cartesianPointList3D = new IfcCartesianPointList3D(md, points);
			List<CoordIndex> coordIndex = new List<CoordIndex>() { new CoordIndex(1, 6, 5), new CoordIndex(1, 2, 6), new CoordIndex(6, 2, 7), new CoordIndex(7, 2, 3), new CoordIndex(7, 8, 6), new CoordIndex(6, 8, 5), new CoordIndex(5, 8, 1), new CoordIndex(1, 8, 4), new CoordIndex(4, 2, 1), new CoordIndex(2, 4, 3), new CoordIndex(4, 8, 7), new CoordIndex(7, 3, 4) };
			IfcTriangulatedFaceSet triangulatedFaceSet = new IfcTriangulatedFaceSet(md, cartesianPointList3D, null, true, coordIndex, null);
			IfcColourRgbList colourRgbList = new IfcColourRgbList(md, new List<Color>() { Color.Red, Color.Green, Color.Yellow });
			IfcIndexedColourMap indexedColourMap = new IfcIndexedColourMap(md, triangulatedFaceSet, colourRgbList, new List<int>() { 1, 1, 2, 2, 3, 3, 1, 1, 1, 1, 1 });

			md.NextObjectRecord = 300;
			IfcBuildingElementProxy buildingElementProxy = new IfcBuildingElementProxy(building, new IfcElemParams(), triangulatedFaceSet,null);
			
		}
	}
}
