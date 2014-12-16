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
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			SlabGenerator.GenerateData(md, building, false);
		}
	}
	class SlabOpenings : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			SlabGenerator.GenerateData(md, building, true);
		}
	}
	class SlabGenerator
	{
		internal static void GenerateData(STPModelData md, IfcBuilding building,bool openings)
		{
			IfcMaterial concrete = new IfcMaterial(md, "Concrete", "", "");
			int thickness = 200;
			IfcMaterialLayer materialLayer = new IfcMaterialLayer(md, concrete, thickness, false, "Core", "", "", 0);
			string name = thickness + "mm Concrete";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet(md, materialLayer, name, "");
			materialLayerSet.Associates.GlobalId = "2l_enLhI93reVwnim9gXUq";
			md.NextObjectRecord = 300;
			IfcSlabType slabType = new IfcSlabType(md, new IfcElemTypeParams("0RSW$KKbzCZ9QaSm3GoEan", name, "", "", ""), materialLayerSet, null, IfcSlabTypeEnum.FLOOR);
			slabType.ObjectTypeOf.GlobalId = "3wwDcmW5T3HfafURQewdD0";
			PolyCurve polycurve = new PolyCurve();
			polycurve.Append(new Line(0, 0, 0, 1000, 0, 0));
			polycurve.Append(new Arc(new Point3d(1000, 0, 0), new Point3d(1400, 2000, 0), new Point3d(1000, 4000, 0)));
			polycurve.Append(new Line(1000, 4000, 0, 0, 4000, 0));
			polycurve.Append(new Arc(new Point3d(0, 4000, 0), new Point3d(-400, 2000, 0), new Point3d(0, 0, 0)));
			IfcSlabStandardCase slabStandardCase = new IfcSlabStandardCase(building, new IfcElemParams("1wAj$J2Az2V8wnBiVYd3bU", "", "", "", ""), slabType, polycurve, -200, true, null);
			slabStandardCase.Material.Associates.GlobalId = "3ESAzibgr9BvK9M75iV84w";
			if (openings)
			{
				IfcCircleProfileDef cpd = new IfcCircleProfileDef(md, IfcProfileTypeEnum.AREA, "100DIA", null, 50);
				IfcExtrudedAreaSolid eas = new IfcExtrudedAreaSolid(cpd,new IfcAxis2Placement3D(md,new Plane(new Point3d(100,300,-200),Vector3d.XAxis,Vector3d.YAxis)),new IfcDirection(md,0,0,1),thickness);
				IfcOpeningStandardCase opening = new IfcOpeningStandardCase(slabStandardCase, new IfcElemParams("15RSTHd8nFVQWMRE7og7sd", "Opening", "", "", ""), null, eas);
				opening.VoidsElement.GlobalId = "0gqEDsyEzFXvY$fc_rUxyO";
				IfcRectangleProfileDef rpd = new IfcRectangleProfileDef(md, IfcProfileTypeEnum.AREA, "RecessRectangle", null, 500, 1000);
				eas = new IfcExtrudedAreaSolid(rpd, new IfcAxis2Placement3D(md, new Plane(new Point3d(500, 1000, -50), Vector3d.XAxis, Vector3d.YAxis)), new IfcDirection(md, 0, 0, 1), 50);
				IfcOpeningElement recess = new IfcOpeningElement(slabStandardCase, new IfcElemParams("0w93HZ19H2D99zbAVNb4o2", "Recess", "", "", ""), eas, IfcOpeningElementTypeEnum.RECESS);
				recess.VoidsElement.GlobalId = "3iUkij4q1DmxlXuHzQVJaM";
			}
		}
	}
}
