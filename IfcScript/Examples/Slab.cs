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
			md.NextObjectRecord = 200;
			IfcMaterial concrete = new IfcMaterial(md, "Concrete", "", "");
			int thickness = 200;
			IfcMaterialLayer materialLayer = new IfcMaterialLayer(md, concrete, thickness, false, "Core", "", "", 0);
			string name = thickness + "mm Concrete";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet(md, materialLayer, name, "");
			md.NextObjectRecord = 300;
			IfcSlabType slabType = new IfcSlabType(md, new IfcElemTypeParams("", name, "", "", ""), materialLayerSet, null, IfcSlabTypeEnum.FLOOR);
			PolyCurve polycurve = new PolyCurve();
			polycurve.Append(new Line(0, 0, 0, 1000, 0, 0));
			polycurve.Append(new Arc(new Point3d(1000, 0, 0), new Point3d(1400, 2000, 0), new Point3d(1000, 4000, 0)));
			polycurve.Append(new Line(1000, 4000, 0, 0, 4000, 0));
			polycurve.Append(new Arc(new Point3d(0, 4000, 0), new Point3d(-400, 2000, 0), new Point3d(0, 0, 0)));
			IfcSlabStandardCase slabStandardCase = new IfcSlabStandardCase(building, null, slabType, polycurve, -200, true, null);
			if (openings)
			{
				IfcCircleProfileDef cpd = new IfcCircleProfileDef(md, IfcProfileTypeEnum.AREA, "100DIA", null, 50);
				IfcExtrudedAreaSolid eas = new IfcExtrudedAreaSolid(cpd,new IfcAxis2Placement3D(md,new Plane(new Point3d(100,300,-200),Vector3d.XAxis,Vector3d.YAxis)),new IfcDirection(md,0,0,1),thickness);
				IfcOpeningStandardCase opening = new IfcOpeningStandardCase(slabStandardCase, new IfcElemParams("","Opening","","",""), null, eas);
				IfcRectangleProfileDef rpd = new IfcRectangleProfileDef(md, IfcProfileTypeEnum.AREA, "RecessRectangle", null, 500, 1000);
				eas = new IfcExtrudedAreaSolid(rpd, new IfcAxis2Placement3D(md, new Plane(new Point3d(500, 1000, -50), Vector3d.XAxis, Vector3d.YAxis)), new IfcDirection(md, 0, 0, 1), 50);
				IfcOpeningElement recess = new IfcOpeningElement(slabStandardCase, new IfcElemParams("", "Recess", "", "", ""), eas, IfcOpeningElementTypeEnum.RECESS);

			}
		}
	}
}
