using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;

using Coord3d = System.Tuple<double, double, double>;
using CoordIndex = System.Tuple<int, int, int>; 

namespace IFC.Examples
{
	class IndexedColourMap : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc db = building.Database;
			List<Coord3d> points = new List<Coord3d>() { new Coord3d(0, 0, 0), new Coord3d(1000, 0, 0), new Coord3d(1000, 1000, 0), new Coord3d(0, 1000, 0), new Coord3d(0, 0, 2000), new Coord3d(1000, 0, 2000), new Coord3d(1000, 1000, 2000), new Coord3d(0, 1000, 2000) }; 
			IfcCartesianPointList3D cartesianPointList3D = new IfcCartesianPointList3D(db, points);
			List<CoordIndex> coordIndex = new List<CoordIndex>() { new CoordIndex(1, 6, 5), new CoordIndex(1, 2, 6), new CoordIndex(6, 2, 7), new CoordIndex(7, 2, 3), new CoordIndex(7, 8, 6), new CoordIndex(6, 8, 5), new CoordIndex(5, 8, 1), new CoordIndex(1, 8, 4), new CoordIndex(4, 2, 1), new CoordIndex(2, 4, 3), new CoordIndex(4, 8, 7), new CoordIndex(7, 3, 4) };
			IfcTriangulatedFaceSet triangulatedFaceSet = new IfcTriangulatedFaceSet(cartesianPointList3D, true, coordIndex);
			IfcColourRgbList colourRgbList = new IfcColourRgbList(db, new List<Color>() { Color.Red, Color.Green, Color.Yellow });
			IfcIndexedColourMap indexedColourMap = new IfcIndexedColourMap(triangulatedFaceSet, colourRgbList, new List<int>() { 1, 1, 2, 2, 3, 3, 1, 1, 1, 1, 1,1 });

			db.NextObjectRecord = 300;
			IfcBuildingElementProxy buildingElementProxy = new IfcBuildingElementProxy(building,null,new IfcProductDefinitionShape(new IfcShapeRepresentation( triangulatedFaceSet)));

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			buildingElementProxy.GlobalId = "25c34fWeL1NQux73WfnXox";
		}
	}
}
