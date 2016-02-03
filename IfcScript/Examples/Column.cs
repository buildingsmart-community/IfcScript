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
		protected override void GenerateData(DatabaseIfc database, IfcBuilding building)
		{
			IfcMaterialProfile materialProfile = GetParametericIPE200Profile(database);
			IfcColumnType columnType = new IfcColumnType(materialProfile.Name,  materialProfile, IfcColumnTypeEnum.COLUMN) { GlobalId = "3qJDCKcPj1tgEHrIL1MUed" };
			columnType.ObjectTypeOf.GlobalId = "0QSJIMj99DcOpmktgECZT7";
			columnType.Material.Associates.GlobalId = "2RR6JzjWrDuRIDIKRwxCJZ";
			IfcColumnStandardCase column = new IfcColumnStandardCase(building, columnType, new Line(0, 0, 0, 0, 0, 2000), Vector3d.XAxis, IfcCardinalPointReference.MID, null) { GlobalId = "3S1GK_wA565RDoiWQEJc_l", Name= materialProfile.Name };
			column.Material.Associates.GlobalId = "2JRmkBe255UBkcHeZrq_Bl";
		}
	}
}
