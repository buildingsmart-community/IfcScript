using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GGYM.IFC;
using Rhino.Geometry;

namespace IFC.Examples
{
	internal class Column : IFCExampleBase 
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcMaterial material = new IfcMaterial(md, "S355JR", "", "Steel");
			string name = "IPE200";
			IfcIShapeProfileDef ipe200 = new IfcIShapeProfileDef(md, IfcProfileTypeEnum.AREA, name, null, 200, 100, 5.6, 8.5, 12, 0, 0);
			IfcMaterialProfile materialProfile = new IfcMaterialProfile(md, name, "", material, ipe200, 0, "");

			IfcColumnType columnType = new IfcColumnType(md, new IfcElemTypeParams("", name, "", "", ""), materialProfile, null, IfcColumnTypeEnum.COLUMN);
			IfcColumnStandardCase column = new IfcColumnStandardCase(building, columnType, new Line(0, 0, 0, 0, 0, 2000), Vector3d.XAxis, IfcCardinalPointReference.MID, new IfcElemParams(), null);

		}
	}
}
