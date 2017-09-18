using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;

namespace IFC.Examples
{
	class Bath : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc db = building.Database;
			IfcBlock block = new IfcBlock(new IfcAxis2Placement3D(new IfcCartesianPoint(db,0,0,0)),	2000,800,800);
			IfcRoundedRectangleProfileDef roundedRectangle = new IfcRoundedRectangleProfileDef(db, "VoidProfile",1800,600,200);
			IfcExtrudedAreaSolid extrudedAreaSolid = new IfcExtrudedAreaSolid(roundedRectangle,new IfcAxis2Placement3D(new IfcCartesianPoint(db, 1000,400,100)),new IfcDirection(db,0,0,1),700);
			IfcBooleanResult booleanResult = new IfcBooleanResult(IfcBooleanOperator.DIFFERENCE, block, extrudedAreaSolid);
			IfcCsgSolid csgSolid = new IfcCsgSolid(booleanResult);
			IfcRepresentationMap representationMap = new IfcRepresentationMap(csgSolid);
			IfcMaterial ceramic = new IfcMaterial(db, "Ceramic");
			IfcSanitaryTerminalType sanitaryTerminalType = new IfcSanitaryTerminalType(db, "Bath", IfcSanitaryTerminalTypeEnum.BATH) { MaterialSelect = ceramic };
			sanitaryTerminalType.AddRepresentationMap(representationMap);
			IfcElement element = sanitaryTerminalType.GenerateMappedItemElement(building, new IfcCartesianTransformationOperator3D(db));
			db.Context.AddDeclared(sanitaryTerminalType);

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			sanitaryTerminalType.GlobalId = "1HarmwaPv3OeJSXpaoPKpg";
			ceramic.Associates.GlobalId = "0Pkhszwjv1qRMYyCFg9fjB";
			sanitaryTerminalType.ObjectTypeOf.GlobalId = "1lO$X3e3j9lfVMhNy4MzKB";
			element.GlobalId = "3$$o7C03j0KQeLnoj018fc";
		}
	}
}
