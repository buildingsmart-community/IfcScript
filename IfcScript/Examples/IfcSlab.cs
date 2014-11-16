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
			md.NextObjectRecord = 200;
			IfcMaterial concrete = new IfcMaterial(md, "Concrete", "", "");
			IfcMaterialLayer materialLayer = new IfcMaterialLayer(md, concrete, 200, false, "Core", "", "", 0);
			string name = "200mm Concrete";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet(md, materialLayer, name, "");
			md.NextObjectRecord = 300;
			IfcSlabType slabType = new IfcSlabType(md, new IfcElemTypeParams("", name, "", "", ""), materialLayerSet, null, IfcSlabTypeEnum.FLOOR);
			PolyCurve polycurve = new PolyCurve();
			polycurve.Append(new Line(0, 0, 0, 1000, 0, 0));
			polycurve.Append(new Arc(new Point3d(1000, 0, 0), new Point3d(1400, 2000, 0), new Point3d(1000, 4000, 0)));
			polycurve.Append(new Line(1000, 4000, 0, 0, 4000, 0));
			polycurve.Append(new Arc(new Point3d(0, 4000, 0), new Point3d(-400, 2000, 0), new Point3d(0, 0, 0)));
			IfcSlabStandardCase slabStandardCase = new IfcSlabStandardCase(building, null, slabType, polycurve, -200, true, null);
		}
	}
}
