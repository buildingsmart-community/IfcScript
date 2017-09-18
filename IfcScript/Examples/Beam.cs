using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeometryGym.Ifc;

using CoordIndex = System.Tuple<int, int, int>;
using Coord2d = System.Tuple<double, double>;

namespace IFC.Examples
{
	internal class BeamTessellated : Beam
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			base.GenerateInstance(building, true);
		}
	}
	internal class BeamExtruded : Beam
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			base.GenerateInstance(building, false);
		}
	}

	internal class BeamFixedReferenceSweep : Beam
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc database = building.Database;
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcAxis2Placement3D axis2dPlacement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			IfcMaterialProfileSetUsage materialProfileSetUsage = new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.TOPMID);

			//IfcBeam beam = new IfcBeam(building,materialProfileSetUsage, axis2dPlacement3d, 1000) { Name = beamType.Name, RelatingType = beamType };
		}
	}

	internal abstract class Beam: IFCExampleInstance
	{
		protected void GenerateInstance(IfcBuilding building, bool tessellated)
		{	 
			IfcBeam beam = GenerateIPE200(building, tessellated);
		}

		private IfcBeam GenerateIPE200(IfcBuilding building, bool tessellated)
		{
			DatabaseIfc db = building.Database;
			if (tessellated)
			{
				List<Tuple<double, double, double>> coords = new List<Tuple<double,double,double>>() { new Tuple<double, double, double>(1000.0, 50.0, -91.5), new Tuple<double,double,double>(1000.0, 14.8, -91.5), new Tuple<double,double,double>(1000.0, 50.0, -100.0), new Tuple<double,double,double>(1000.0, -50.0, -100.0), new Tuple<double,double,double>(1000.0, -50.0, -91.5), new Tuple<double,double,double>(1000.0, -14.8, -91.5), new Tuple<double,double,double>(1000.0, -2.8, 79.5), new Tuple<double,double,double>(1000.0, -2.8, -79.5), new Tuple<double,double,double>(1000.0, -50.0, 91.5), new Tuple<double,double,double>(1000.0, -14.8, 91.5), new Tuple<double,double,double>(1000.0, -50.0, 100.0), new Tuple<double,double,double>(1000.0, 50.0, 100.0), new Tuple<double,double,double>(1000.0, 50.0, 91.5), new Tuple<double,double,double>(1000.0, 14.8, 91.5), new Tuple<double,double,double>(1000.0, 2.8, -79.5), new Tuple<double,double,double>(1000.0, 2.8, 79.5), new Tuple<double,double,double>(0.0, 2.8, 79.5), new Tuple<double,double,double>(0.0, 2.8, -79.5), new Tuple<double,double,double>(0.0, 50.0, 91.5), new Tuple<double,double,double>(0.0, 14.8, 91.5), new Tuple<double,double,double>(0.0, 50.0, 100.0), new Tuple<double,double,double>(0.0, -50.0, 100.0), new Tuple<double,double,double>(0.0, -50.0, 91.5), new Tuple<double,double,double>(0.0, -14.8, 91.5), new Tuple<double,double,double>(0.0, -2.8, -79.5), new Tuple<double,double,double>(0.0, -2.8, 79.5), new Tuple<double,double,double>(0.0, -50.0, -91.5), new Tuple<double,double,double>(0.0, -14.8, -91.5), new Tuple<double,double,double>(0.0, -50.0, -100.0), new Tuple<double,double,double>(0.0, 50.0, -100.0), new Tuple<double,double,double>(0.0, 50.0, -91.5), new Tuple<double,double,double>(0.0, 14.8, -91.5), new Tuple<double,double,double>(0.0, 14.8, -91.5), new Tuple<double,double,double>(0.0, 2.8, -79.5), new Tuple<double,double,double>(1000.0, 14.8, -91.5), new Tuple<double,double,double>(1000.0, 2.8, -79.5), new Tuple<double,double,double>(500.0, 2.8, -79.5), new Tuple<double,double,double>(500.0, 14.8, -91.5), new Tuple<double,double,double>(0.0, 2.8, -79.5), new Tuple<double,double,double>(0.0, 2.8, 79.5), new Tuple<double,double,double>(1000.0, 2.8, -79.5), new Tuple<double,double,double>(1000.0, 2.8, 79.5), new Tuple<double,double,double>(500.0, 2.8, -79.5), new Tuple<double,double,double>(500.0, 2.8, 79.5), new Tuple<double,double,double>(0.0, 2.8, 79.5), new Tuple<double,double,double>(0.0, 14.8, 91.5), new Tuple<double,double,double>(1000.0, 2.8, 79.5), new Tuple<double,double,double>(1000.0, 14.8, 91.5), new Tuple<double,double,double>(500.0, 2.8, 79.5), new Tuple<double,double,double>(500.0, 14.8, 91.5), new Tuple<double,double,double>(0.0, 14.8, 91.5), new Tuple<double,double,double>(0.0, 50.0, 91.5), new Tuple<double,double,double>(1000.0, 14.8, 91.5), new Tuple<double,double,double>(1000.0, 50.0, 91.5), new Tuple<double,double,double>(500.0, 14.8, 91.5), new Tuple<double,double,double>(500.0, 50.0, 91.5), new Tuple<double,double,double>(0.0, 50.0, 91.5), new Tuple<double,double,double>(0.0, 50.0, 100.0), new Tuple<double,double,double>(1000.0, 50.0, 91.5), new Tuple<double,double,double>(1000.0, 50.0, 100.0), new Tuple<double,double,double>(500.0, 50.0, 91.5), new Tuple<double,double,double>(500.0, 50.0, 100.0), new Tuple<double,double,double>(0.0, 50.0, 100.0), new Tuple<double,double,double>(0.0, -50.0, 100.0), new Tuple<double,double,double>(1000.0, 50.0, 100.0), new Tuple<double,double,double>(1000.0, -50.0, 100.0), new Tuple<double,double,double>(500.0, 50.0, 100.0), new Tuple<double,double,double>(500.0, -50.0, 100.0), new Tuple<double,double,double>(0.0, -50.0, 100.0), new Tuple<double,double,double>(0.0, -50.0, 91.5), new Tuple<double,double,double>(1000.0, -50.0, 100.0), new Tuple<double,double,double>(1000.0, -50.0, 91.5), new Tuple<double,double,double>(500.0, -50.0, 100.0), new Tuple<double,double,double>(500.0, -50.0, 91.5), new Tuple<double,double,double>(0.0, -50.0, 91.5), new Tuple<double,double,double>(0.0, -14.8, 91.5), new Tuple<double,double,double>(1000.0, -50.0, 91.5), new Tuple<double,double,double>(1000.0, -14.8, 91.5), new Tuple<double,double,double>(500.0, -50.0, 91.5), new Tuple<double,double,double>(500.0, -14.8, 91.5), new Tuple<double,double,double>(0.0, -14.8, 91.5), new Tuple<double,double,double>(0.0, -2.8, 79.5), new Tuple<double,double,double>(1000.0, -14.8, 91.5), new Tuple<double,double,double>(1000.0, -2.8, 79.5), new Tuple<double,double,double>(500.0, -14.8, 91.5), new Tuple<double,double,double>(500.0, -2.8, 79.5), new Tuple<double,double,double>(0.0, -2.8, 79.5), new Tuple<double,double,double>(0.0, -2.8, -79.5), new Tuple<double,double,double>(1000.0, -2.8, 79.5), new Tuple<double,double,double>(1000.0, -2.8, -79.5), new Tuple<double,double,double>(500.0, -2.8, 79.5), new Tuple<double,double,double>(500.0, -2.8, -79.5), new Tuple<double,double,double>(0.0, -2.8, -79.5), new Tuple<double,double,double>(0.0, -14.8, -91.5), new Tuple<double,double,double>(1000.0, -2.8, -79.5), new Tuple<double,double,double>(1000.0, -14.8, -91.5), new Tuple<double,double,double>(500.0, -2.8, -79.5), new Tuple<double,double,double>(500.0, -14.8, -91.5), new Tuple<double,double,double>(0.0, -14.8, -91.5), new Tuple<double,double,double>(0.0, -50.0, -91.5), new Tuple<double,double,double>(1000.0, -14.8, -91.5), new Tuple<double,double,double>(1000.0, -50.0, -91.5), new Tuple<double,double,double>(500.0, -14.8, -91.5), new Tuple<double,double,double>(500.0, -50.0, -91.5), new Tuple<double,double,double>(0.0, -50.0, -91.5), new Tuple<double,double,double>(0.0, -50.0, -100.0), new Tuple<double,double,double>(1000.0, -50.0, -91.5), new Tuple<double,double,double>(1000.0, -50.0, -100.0), new Tuple<double,double,double>(500.0, -50.0, -91.5), new Tuple<double,double,double>(500.0, -50.0, -100.0), new Tuple<double,double,double>(0.0, -50.0, -100.0), new Tuple<double,double,double>(0.0, 50.0, -100.0), new Tuple<double,double,double>(1000.0, -50.0, -100.0), new Tuple<double,double,double>(1000.0, 50.0, -100.0), new Tuple<double,double,double>(500.0, -50.0, -100.0), new Tuple<double,double,double>(500.0, 50.0, -100.0), new Tuple<double,double,double>(0.0, 50.0, -100.0), new Tuple<double,double,double>(0.0, 50.0, -91.5), new Tuple<double,double,double>(1000.0, 50.0, -100.0), new Tuple<double,double,double>(1000.0, 50.0, -91.5), new Tuple<double,double,double>(500.0, 50.0, -100.0), new Tuple<double,double,double>(500.0, 50.0, -91.5), new Tuple<double,double,double>(0.0, 50.0, -91.5), new Tuple<double,double,double>(0.0, 14.8, -91.5), new Tuple<double,double,double>(1000.0, 50.0, -91.5), new Tuple<double,double,double>(1000.0, 14.8, -91.5), new Tuple<double,double,double>(500.0, 50.0, -91.5), new Tuple<double,double,double>(500.0, 14.8, -91.5) };
				IfcCartesianPointList3D cartesianPointList3D = new IfcCartesianPointList3D(db, coords);
				cartesianPointList3D.Comments.Add("the geometric representation of the beam is provided as a triangulated face set");
				cartesianPointList3D.Comments.Add("the meshing depends on the creating software system");

				List<CoordIndex> coordIndex = new List<CoordIndex>() { new CoordIndex(6, 5, 4), new CoordIndex(15, 8, 6), new CoordIndex(6, 4, 3), new CoordIndex(10, 11, 9), new CoordIndex(16, 10, 7), new CoordIndex(14, 11, 10), new CoordIndex(7, 8, 16), new CoordIndex(6, 2, 15), new CoordIndex(2, 3, 1), new CoordIndex(3, 2, 6), new CoordIndex(10, 16, 14), new CoordIndex(14, 13, 12), new CoordIndex(11, 14, 12), new CoordIndex(8, 15, 16), new CoordIndex(24, 23, 22), new CoordIndex(17, 26, 24), new CoordIndex(22, 21, 20), new CoordIndex(28, 29, 27), new CoordIndex(32, 28, 25), new CoordIndex(30, 29, 28), new CoordIndex(18, 25, 26), new CoordIndex(24, 20, 17), new CoordIndex(20, 21, 19), new CoordIndex(32, 31, 30), new CoordIndex(28, 32, 30), new CoordIndex(33, 34, 37), new CoordIndex(36, 35, 38), new CoordIndex(40, 44, 43), new CoordIndex(41, 43, 44), new CoordIndex(46, 50, 49), new CoordIndex(47, 49, 50), new CoordIndex(56, 55, 51), new CoordIndex(55, 56, 54), new CoordIndex(57, 58, 62), new CoordIndex(60, 59, 61), new CoordIndex(63, 64, 68), new CoordIndex(66, 65, 67), new CoordIndex(69, 70, 74), new CoordIndex(72, 71, 73), new CoordIndex(80, 79, 75), new CoordIndex(79, 80, 78), new CoordIndex(81, 82, 86), new CoordIndex(84, 83, 85), new CoordIndex(88, 92, 91), new CoordIndex(89, 91, 92), new CoordIndex(94, 98, 97), new CoordIndex(95, 97, 98), new CoordIndex(104, 103, 99), new CoordIndex(103, 104, 102), new CoordIndex(105, 106, 110), new CoordIndex(108, 107, 109), new CoordIndex(111, 112, 116), new CoordIndex(114, 113, 115), new CoordIndex(117, 118, 122), new CoordIndex(120, 119, 121), new CoordIndex(128, 127, 123), new CoordIndex(127, 128, 126), new CoordIndex(22, 20, 24), new CoordIndex(32, 25, 18), new CoordIndex(18, 26, 17), new CoordIndex(33, 37, 38), new CoordIndex(36, 38, 37), new CoordIndex(40, 43, 39), new CoordIndex(41, 44, 42), new CoordIndex(46, 49, 45), new CoordIndex(47, 50, 48), new CoordIndex(56, 51, 52), new CoordIndex(55, 54, 53), new CoordIndex(57, 62, 61), new CoordIndex(60, 61, 62), new CoordIndex(63, 68, 67), new CoordIndex(66, 67, 68), new CoordIndex(69, 74, 73), new CoordIndex(72, 73, 74), new CoordIndex(80, 75, 76), new CoordIndex(79, 78, 77), new CoordIndex(81, 86, 85), new CoordIndex(84, 85, 86), new CoordIndex(88, 91, 87), new CoordIndex(89, 92, 90), new CoordIndex(94, 97, 93), new CoordIndex(95, 98, 96), new CoordIndex(104, 99, 100), new CoordIndex(103, 102, 101), new CoordIndex(105, 110, 109), new CoordIndex(108, 109, 110), new CoordIndex(111, 116, 115), new CoordIndex(114, 115, 116), new CoordIndex(117, 122, 121), new CoordIndex(120, 121, 122), new CoordIndex(128, 123, 124), new CoordIndex(127, 126, 125) };
				IfcTriangulatedFaceSet triangulatedFaceSet = new IfcTriangulatedFaceSet(cartesianPointList3D, true, coordIndex);

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
				return new IfcBeam(building,null, new IfcProductDefinitionShape(new IfcShapeRepresentation(triangulatedFaceSet))) { GlobalId = "0EF5_zZRv0pQPddeofU3KT", Name = "ExampleBeamName",Description = "ExampleBeamDescription",Tag = "Tag" };
			}

			List<Coord2d> points = new List<Coord2d>() {new Coord2d(2.8,-79.5),new Coord2d(2.8,79.5),new Coord2d(6.314719,87.985281),new Coord2d(14.8,91.5), new Coord2d(50.0,91.5), new Coord2d(50.0,100.0), new Coord2d(-50.0,100.0), new Coord2d(-50.0,91.5), new Coord2d(-14.8,91.5), new Coord2d(-6.314719,87.985281), new Coord2d(-2.8,79.5), new Coord2d(-2.8,-79.5), new Coord2d(-6.314719,-87.985281), new Coord2d(-14.8,-91.5), new Coord2d(-50.0,-91.5), new Coord2d(-50.0,-100.0), new Coord2d(50.0,-100.0), new Coord2d(50.0,-91.5), new Coord2d(14.8,-91.5), new Coord2d(6.314719,-87.985281) };
			List<IfcSegmentIndexSelect> segments = new List<IfcSegmentIndexSelect>();
			segments.Add(new IfcLineIndex(1, 2));
			segments.Add(new IfcArcIndex(2, 3, 4));
			segments.Add(new IfcLineIndex(4, 5));
			segments.Add(new IfcLineIndex(5, 6));
			segments.Add(new IfcLineIndex(6, 7));
			segments.Add(new IfcLineIndex(7, 8));
			segments.Add(new IfcLineIndex(8, 9));
			segments.Add(new IfcArcIndex(9, 10, 11));
			segments.Add(new IfcLineIndex(11, 12));
			segments.Add(new IfcArcIndex(12, 13, 14));
			segments.Add(new IfcLineIndex(14, 15));
			segments.Add(new IfcLineIndex(15, 16));
			segments.Add(new IfcLineIndex(16, 17));
			segments.Add(new IfcLineIndex(17, 18));
			segments.Add(new IfcLineIndex(18, 19));
			segments.Add(new IfcArcIndex(19, 20, 1));
			IfcBoundedCurve boundedCurve = IfcBoundedCurve.Generate(db,points, segments);
			IfcArbitraryClosedProfileDef arbitraryClosedProfileDef = new IfcArbitraryClosedProfileDef("IPE200",boundedCurve);
			IfcAxis2Placement3D axis2Placement3D = new IfcAxis2Placement3D(new IfcCartesianPoint(db,0,0,0),new IfcDirection(db,0,1,0),new IfcDirection(db,1,0,0));
			IfcExtrudedAreaSolid extrudedAreaSolid = new IfcExtrudedAreaSolid(arbitraryClosedProfileDef, axis2Placement3D,new IfcDirection(db,0,0,1),1000);
			IfcBeam beam = new IfcBeam(building,null,new IfcProductDefinitionShape(new IfcShapeRepresentation (extrudedAreaSolid))) { Name = "ExampleBeamName",Description = "ExampleBeamDescription", Tag = "Tag" };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beam.GlobalId = "0EF5_zZRv0pQPddeofU3KT";

			return beam;
		}
	}
}
