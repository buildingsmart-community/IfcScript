using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeometryGym.Ifc;

namespace IFC.Examples
{
	internal class Column : IFCExampleInstance 
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc database = building.Database;
			IfcMaterialProfile materialProfile = GetParametericIPE200Profile(database);
			IfcColumnType columnType = new IfcColumnType(materialProfile.Name,  materialProfile, IfcColumnTypeEnum.COLUMN);
			IfcMaterialProfileSet materialProfileSet = columnType.MaterialSelect as IfcMaterialProfileSet;
			IfcColumnStandardCase column = new IfcColumnStandardCase(building, new IfcMaterialProfileSetUsage( materialProfileSet,IfcCardinalPointReference.MID), new IfcAxis2Placement3D(new IfcCartesianPoint(database,0,0,0)), 2000) { Name= materialProfile.Name, RelatingType = columnType };
			database.Context.AddDeclared(columnType);

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			columnType.GlobalId = "3qJDCKcPj1tgEHrIL1MUed";
			column.GlobalId = "3S1GK_wA565RDoiWQEJc_l";
			columnType.ObjectTypeOf.GlobalId = "0QSJIMj99DcOpmktgECZT7";
			columnType.MaterialSelect.Associates.GlobalId = "2RR6JzjWrDuRIDIKRwxCJZ";
			column.MaterialSelect.Associates.GlobalId = "2JRmkBe255UBkcHeZrq_Bl";
		}
	}
}
