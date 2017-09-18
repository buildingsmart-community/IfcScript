using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeometryGym.Ifc;

namespace IFC.Examples
{
	internal class BeamUnitTestsVaryingProfile : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc database = building.Database;
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcAxis2Placement3D axis2dPlacement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet,IfcCardinalPointReference.MID), axis2dPlacement3d, 1000) { Name = beamType.Name, RelatingType = beamType };
			database.NextObjectRecord = 300;
			string name = "CHS219.1x6.3";
			IfcCircleHollowProfileDef chs219x6 = new IfcCircleHollowProfileDef(database, name, 219.1 / 2.0, 6.3);
			materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcMaterialProfile materialProfile2 = new IfcMaterialProfile(name, materialProfileSet.MaterialProfiles[0].Material, chs219x6);
			IfcBeamType beamType2 = new IfcBeamType(name, materialProfile2, IfcBeamTypeEnum.BEAM);
			materialProfileSet = beamType2.MaterialSelect as IfcMaterialProfileSet;
			axis2dPlacement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 500, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.MID),axis2dPlacement3d, 1000) { Name = name, RelatingType = beamType2 };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beamType.ObjectTypeOf.GlobalId = "3s_DqAVvb3LguudTShJHVo";
			beamType.MaterialSelect.Associates.GlobalId = "3tlx8qcefDouGWiGFgBV8d";
			beamStandardCase.GlobalId = "0uo2yx7G19uwCu9sIjn6DQ";
			beamStandardCase.MaterialSelect.Associates.GlobalId = "2SL41bR1rCj99SIKuKXeFl";
			beamType2.GlobalId = "3l_OKNTJr4yBOR5rYl6b9w";
			beamType2.ObjectTypeOf.GlobalId = "3LrutsCpn4DPF9Zt4YdIEU";
			beamType2.MaterialSelect.Associates.GlobalId = "14nDe0n1bErgiI78N83Oxd";
			beamStandardCase2.GlobalId = "3_NFDdmqr7mxekvlvcgwa7";
			beamStandardCase2.MaterialSelect.Associates.GlobalId = "1Set5Cyu9BFOWznvoQe1ho";
		}
	}
	internal class BeamUnitTestsVaryingPath : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc database = building.Database;
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcMaterialProfileSetUsage materialProfileSetUsage = new IfcMaterialProfileSetUsage( beamType.MaterialSelect as IfcMaterialProfileSet, IfcCardinalPointReference.TOPMID);
			IfcAxis2Placement3D axis2Placement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, materialProfileSetUsage, axis2Placement3d, 1000) { Name = "Extrusion", RelatingType = beamType };
			axis2Placement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 400), new IfcDirection(database, -0.38461538, 0.92307692, 0), new IfcDirection(database, -0.92307692, -0.38461538, 0));
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, materialProfileSetUsage, axis2Placement3d, new Tuple<double,double>(-1300,0), 0.789582239399523) { Name = "Revolution", RelatingType = beamType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beamStandardCase.GlobalId = "0a_qfeQLDA8e5qT$Do6J_t";
			beamStandardCase.MaterialSelect.Associates.GlobalId = "2uxxMWfA51AAznk5bQJylf";
			beamStandardCase2.GlobalId = "1zqFh80l11VgfEm3ZWh6Xv";
		}
	}

	internal class BeamUnitTestsVaryingCardinal : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc database = building.Database;
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;

			IfcAxis2Placement3D axis2Placement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			IfcMaterialProfileSetUsage materialProfileSetUsage = new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.TOPMID);
			IfcBeamStandardCase beamStandardCase1 = new IfcBeamStandardCase(building, materialProfileSetUsage, axis2Placement3d, 1000) { Name = "TopMid", RelatingType = beamType };
			axis2Placement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			materialProfileSetUsage = new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.BOTMID);
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, materialProfileSetUsage, axis2Placement3d, 1000) { Name = "BotMid", RelatingType = beamType };
			axis2Placement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 500, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			materialProfileSetUsage = new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.BOTLEFT);
			IfcBeamStandardCase beamStandardCase3 = new IfcBeamStandardCase(building, materialProfileSetUsage, axis2Placement3d, 1000) { Name = "BotLeft", RelatingType = beamType };
			axis2Placement3d = new IfcAxis2Placement3D(new IfcCartesianPoint(database, 500, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative);
			materialProfileSetUsage = new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.TOPRIGHT);
			IfcBeamStandardCase beamStandardCase4 = new IfcBeamStandardCase(building, materialProfileSetUsage, axis2Placement3d, 1000) { Name = "TopRight", RelatingType = beamType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beamStandardCase1.GlobalId = "2YX3YEaA13qOf$B1iBgAf6";
			beamStandardCase1.MaterialSelect.Associates.GlobalId = "2v53tpkKfC1QI$UVEwGxEy";
			beamStandardCase2.GlobalId = "39IDqhhC14BxCj_Ryk$esj";
			beamStandardCase2.MaterialSelect.Associates.GlobalId = "2GHGDnjC1BI8mr5FS1ysvq";
			beamStandardCase3.GlobalId = "17CqI$IjrDARuaYNcWcoRH";
			beamStandardCase3.MaterialSelect.Associates.GlobalId = "1v094xksfDT9bOdSPNsjLB";
			beamStandardCase4.GlobalId = "3TOzuh11rACgRkioYYOjj5"; 
			beamStandardCase4.MaterialSelect.Associates.GlobalId = "0ys4PwYgT5dAduf$ECulk$";
		}
	}
}
