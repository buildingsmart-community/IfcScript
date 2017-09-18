using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;
 
using Coord2d = System.Tuple<double, double>;
using Coord3d = System.Tuple<double, double, double>;
using CoordIndex = System.Tuple<int, int, int>;


namespace IFC.Examples
{
	class Slab : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			SlabGenerator.GenerateInstance( building, false);
		}
	}
	class SlabOpenings : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			SlabGenerator.GenerateInstance(building, true);
		}
	}
	class SlabGenerator
	{
		internal static void GenerateInstance(IfcBuilding building, bool openings)
		{
			DatabaseIfc db = building.Database;
			IfcMaterial concrete = new IfcMaterial(db, "Concrete") { Category = "Concrete" };
			int thickness = 200;
			IfcMaterialLayer materialLayer = new IfcMaterialLayer(concrete, thickness,"Core");
			string name = thickness + "mm Concrete";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet( materialLayer, name);
			db.NextObjectRecord = 300;
			IfcSlabType slabType = new IfcSlabType(name, materialLayerSet, IfcSlabTypeEnum.FLOOR);
			db.Context.AddDeclared(slabType);
			List<Coord2d> points = new List<Coord2d>() { new Coord2d(0,0), new Coord2d(1000,0), new Coord2d(1400,2000), new Coord2d(1000,4000),new Coord2d(0,4000), new Coord2d(-400,2000) };
			
			List<IfcSegmentIndexSelect> segments = new List<IfcSegmentIndexSelect>();
			segments.Add(new IfcLineIndex(1, 2));
			segments.Add(new IfcArcIndex(2, 3, 4));
			segments.Add(new IfcLineIndex(4, 5));
			segments.Add(new IfcArcIndex(5, 6, 1));
			IfcBoundedCurve	boundedCurve = IfcBoundedCurve.Generate(db, points, segments);
			IfcMaterialLayerSetUsage layerSetUsage = new IfcMaterialLayerSetUsage(materialLayerSet, IfcLayerSetDirectionEnum.AXIS3, IfcDirectionSenseEnum.NEGATIVE, 0);
			IfcSlab slabStandardCase = new IfcSlabStandardCase(building, layerSetUsage,new IfcAxis2Placement3D(new IfcCartesianPoint(db,0,0,0)),new IfcArbitraryClosedProfileDef("Slab Perimeter",boundedCurve)) {  RelatingType = slabType };
			slabStandardCase.RelatingType = slabType;
			if (openings)
			{
				IfcCircleProfileDef cpd = new IfcCircleProfileDef(db, "100DIA", 50);
				IfcExtrudedAreaSolid eas = new IfcExtrudedAreaSolid(cpd,new IfcAxis2Placement3D(new IfcCartesianPoint(db,100,300,-200)),new IfcDirection(db,0,0,1),thickness);
				IfcOpeningStandardCase opening = new IfcOpeningStandardCase(slabStandardCase, null, eas) { Name = "Opening" };
				IfcRectangleProfileDef rpd = new IfcRectangleProfileDef(db, "RecessRectangle", 500, 1000);
				eas = new IfcExtrudedAreaSolid(rpd, new IfcAxis2Placement3D(new IfcCartesianPoint(db,500, 1000, -50)), new IfcDirection(db, 0, 0, 1), 50);
				IfcOpeningElement recess = new IfcOpeningElement(slabStandardCase,null,new IfcProductDefinitionShape(new IfcShapeRepresentation( eas))) {  Name = "Recess", PredefinedType = IfcOpeningElementTypeEnum.RECESS };

				//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
				opening.GlobalId = "15RSTHd8nFVQWMRE7og7sd";
				opening.VoidsElement.GlobalId = "0gqEDsyEzFXvY$fc_rUxyO";
				recess.GlobalId = "0w93HZ19H2D99zbAVNb4o2";
				recess.VoidsElement.GlobalId = "3iUkij4q1DmxlXuHzQVJaM";
			}

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			slabType.GlobalId = "0RSW$KKbzCZ9QaSm3GoEan";
			slabStandardCase.GlobalId = "1wAj$J2Az2V8wnBiVYd3bU";
			materialLayerSet.Associates.GlobalId = "2l_enLhI93reVwnim9gXUq";
			slabType.ObjectTypeOf.GlobalId = "3wwDcmW5T3HfafURQewdD0";
			slabStandardCase.MaterialSelect.Associates.GlobalId = "3ESAzibgr9BvK9M75iV84w";
		}
	}
}
