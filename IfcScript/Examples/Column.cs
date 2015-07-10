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
			IfcMaterialProfile materialProfile = GetParametericIPE200Profile(md);
			IfcColumnType columnType = new IfcColumnType(md, new IfcElemTypeParams("3qJDCKcPj1tgEHrIL1MUed", materialProfile.Name, "", "", ""), materialProfile, null, IfcColumnTypeEnum.COLUMN);
			columnType.ObjectTypeOf.GlobalId = "0QSJIMj99DcOpmktgECZT7";
			columnType.Material.Associates.GlobalId = "2RR6JzjWrDuRIDIKRwxCJZ";
			IfcColumnStandardCase column = new IfcColumnStandardCase(building, new IfcElemParams("3S1GK_wA565RDoiWQEJc_l", materialProfile.Name, "", "", ""), columnType, new Line(0, 0, 0, 0, 0, 2000), Vector3d.XAxis, IfcCardinalPointReference.MID, null);
			column.Material.Associates.GlobalId = "2JRmkBe255UBkcHeZrq_Bl";
		}
	}
}
