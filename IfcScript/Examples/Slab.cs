using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;
 
using Coord3d = System.Tuple<double, double, double>;
using CoordIndex = System.Tuple<int, int, int>;


namespace IFC.Examples
{
	class Slab : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			SlabGenerator.GenerateData(db, building, false);
		}
	}
	class SlabOpenings : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			SlabGenerator.GenerateData(db, building, true);
		}
	}
	class SlabGenerator
	{
		internal static void GenerateData(DatabaseIfc db, IfcBuilding building, bool openings)
		{
			IfcMaterial concrete = new IfcMaterial(db, "Concrete") { Category = "Concrete" };
			int thickness = 200;
			IfcMaterialLayer materialLayer = new IfcMaterialLayer(concrete, thickness,"Core");
			string name = thickness + "mm Concrete";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet( materialLayer, name);
			materialLayerSet.Associates.GlobalId = "2l_enLhI93reVwnim9gXUq";
			db.NextObjectRecord = 300;
			IfcSlabType slabType = new IfcSlabType(name, materialLayerSet, IfcSlabTypeEnum.FLOOR) { GlobalId = "0RSW$KKbzCZ9QaSm3GoEan" };
			slabType.ObjectTypeOf.GlobalId = "3wwDcmW5T3HfafURQewdD0";
			PolyCurve polycurve = new PolyCurve();
			polycurve.Append(new Line(0, 0, 0, 1000, 0, 0));
			polycurve.Append(new Arc(new Point3d(1000, 0, 0), new Point3d(1400, 2000, 0), new Point3d(1000, 4000, 0)));
			polycurve.Append(new Line(1000, 4000, 0, 0, 4000, 0));
			polycurve.Append(new Arc(new Point3d(0, 4000, 0), new Point3d(-400, 2000, 0), new Point3d(0, 0, 0)));
			IfcSlabStandardCase slabStandardCase = new IfcSlabStandardCase(building, slabType, polycurve, -200, true, null) { GlobalId = "1wAj$J2Az2V8wnBiVYd3bU" };
			slabStandardCase.Material.Associates.GlobalId = "3ESAzibgr9BvK9M75iV84w";
			if (openings)
			{
				IfcCircleProfileDef cpd = new IfcCircleProfileDef(db, "100DIA", 50);
				IfcExtrudedAreaSolid eas = new IfcExtrudedAreaSolid(cpd,new IfcAxis2Placement3D(db,new Plane(new Point3d(100,300,-200),Vector3d.XAxis,Vector3d.YAxis)),new IfcDirection(db,0,0,1),thickness);
				IfcOpeningStandardCase opening = new IfcOpeningStandardCase(slabStandardCase, null, eas) { GlobalId = "15RSTHd8nFVQWMRE7og7sd", Name = "Opening" };
				opening.VoidsElement.GlobalId = "0gqEDsyEzFXvY$fc_rUxyO";
				IfcRectangleProfileDef rpd = new IfcRectangleProfileDef(db, "RecessRectangle", 500, 1000);
				eas = new IfcExtrudedAreaSolid(rpd, new IfcAxis2Placement3D(db, new Plane(new Point3d(500, 1000, -50), Vector3d.XAxis, Vector3d.YAxis)), new IfcDirection(db, 0, 0, 1), 50);
				IfcOpeningElement recess = new IfcOpeningElement(slabStandardCase,null,new IfcProductDefinitionShape(new IfcShapeRepresentation( eas))) {  GlobalId = "0w93HZ19H2D99zbAVNb4o2", Name = "Recess", PredefinedType = IfcOpeningElementTypeEnum.RECESS };
				recess.VoidsElement.GlobalId = "3iUkij4q1DmxlXuHzQVJaM";
			}
		}
	}
}
