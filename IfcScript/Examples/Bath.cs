using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;

namespace IFC.Examples
{
	class Bath : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcBlock block = new IfcBlock(md,Plane.WorldXY,	2000,800,800);
			IfcRoundedRectangleProfileDef roundedRectangle = new IfcRoundedRectangleProfileDef(md, IfcProfileTypeEnum.AREA,"VoidProfile",null,600,1800,200);
			IfcExtrudedAreaSolid extrudedAreaSolid = new IfcExtrudedAreaSolid(roundedRectangle,new IfcAxis2Placement3D(md,new Plane(new Point3d( 1000,400,100),Vector3d.XAxis,Vector3d.YAxis)),new IfcDirection(md,0,0,1),700);
			IfcBooleanResult booleanResult = new IfcBooleanResult(IfcBooleanOperator.DIFFERENCE, block, extrudedAreaSolid);
			IfcCsgSolid csgSolid = new IfcCsgSolid(booleanResult);
			IfcRepresentationMap representationMap = new IfcRepresentationMap(csgSolid);
			IfcMaterial ceramic = new IfcMaterial(md, "Ceramic", "", "");
			IfcSanitaryTerminalType sanitaryTerminalType = new IfcSanitaryTerminalType(md, new IfcElemTypeParams("","Bath","","",""), ceramic, representationMap, null, IfcSanitaryTerminalTypeEnum.BATH);
			sanitaryTerminalType.GenerateMappedItemElement(building, Plane.WorldXY, new IfcElemParams());

		}
	}
}
