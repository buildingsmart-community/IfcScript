using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeometryGym.Ifc;

namespace IFC.Examples
{
	internal class BeamUnitTestsVaryingProfile : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(db);
			IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet,IfcCardinalPointReference.MID), new IfcAxis2Placement3D(new IfcCartesianPoint(db,0,0,0), db.Factory.YAxis, db.Factory.XAxisNegative), 1000) { GlobalId = "0uo2yx7G19uwCu9sIjn6DQ", Name = beamType.Name, RelatingType = beamType };
			db.NextObjectRecord = 300;
			string name = "CHS219.1x6.3";
			IfcCircleHollowProfileDef chs219x6 = new IfcCircleHollowProfileDef(db, name, 219.1 / 2.0, 6.3);
			materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcMaterialProfile materialProfile2 = new IfcMaterialProfile(name, materialProfileSet.MaterialProfiles[0].Material, chs219x6);
			IfcBeamType beamType2 = new IfcBeamType(name, materialProfile2, IfcBeamTypeEnum.BEAM) { GlobalId = "3l_OKNTJr4yBOR5rYl6b9w" };
			materialProfileSet = beamType2.MaterialSelect as IfcMaterialProfileSet;
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.MID), new IfcAxis2Placement3D(new IfcCartesianPoint(db, 500, 0, 0), db.Factory.YAxis,db.Factory.XAxisNegative), 1000) { GlobalId = "3_NFDdmqr7mxekvlvcgwa7", Name = name, RelatingType = beamType2 };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beamStandardCase.MaterialSelect.Associates.GlobalId = "2SL41bR1rCj99SIKuKXeFl";
			beamType.ObjectTypeOf.GlobalId = "3s_DqAVvb3LguudTShJHVo";
			beamType.MaterialSelect.Associates.GlobalId = "3tlx8qcefDouGWiGFgBV8d";
			beamType2.ObjectTypeOf.GlobalId = "3LrutsCpn4DPF9Zt4YdIEU";
			beamType2.MaterialSelect.Associates.GlobalId = "14nDe0n1bErgiI78N83Oxd";
			beamStandardCase2.MaterialSelect.Associates.GlobalId = "1Set5Cyu9BFOWznvoQe1ho";
		}
	}
	internal class BeamUnitTestsVaryingPath : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc database, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcMaterialProfileSetUsage materialProfileSetUsage = new IfcMaterialProfileSetUsage( beamType.MaterialSelect as IfcMaterialProfileSet, IfcCardinalPointReference.TOPMID);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, materialProfileSetUsage, new IfcAxis2Placement3D(new IfcCartesianPoint(database,0, 0, 0),database.Factory.YAxis,database.Factory.XAxisNegative), 1000) { GlobalId = "0a_qfeQLDA8e5qT$Do6J_t", Name = "Extrusion", RelatingType = beamType };
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, materialProfileSetUsage, new IfcAxis2Placement3D(new IfcCartesianPoint(database,0, 0, 400), new IfcDirection(database, -0.38461538, 0.92307692,0),new IfcDirection(database, -0.92307692, -0.38461538, 0)),new Tuple<double,double>(-1300,0), 0.789582239399523) { GlobalId = "1zqFh80l11VgfEm3ZWh6Xv", Name = "Revolution", RelatingType = beamType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beamStandardCase.MaterialSelect.Associates.GlobalId = "2uxxMWfA51AAznk5bQJylf";
		}
	}

	internal class BeamUnitTestsVaryingCardinal : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc database, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcBeamStandardCase beamStandardCase1 = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.TOPMID), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative), 1000) { GlobalId = "2YX3YEaA13qOf$B1iBgAf6", Name = "TopMid", RelatingType = beamType };
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.BOTMID), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative), 1000) { GlobalId = "39IDqhhC14BxCj_Ryk$esj", Name = "BotMid", RelatingType = beamType };
			IfcBeamStandardCase beamStandardCase3 = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.BOTLEFT), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 500, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative), 1000) { GlobalId = "17CqI$IjrDARuaYNcWcoRH", Name = "BotLeft", RelatingType = beamType };
			IfcBeamStandardCase beamStandardCase4 = new IfcBeamStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.TOPRIGHT), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 500, 0, 0), database.Factory.YAxis, database.Factory.XAxisNegative), 1000) { GlobalId = "3TOzuh11rACgRkioYYOjj5", Name = "TopRight", RelatingType = beamType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			beamStandardCase1.MaterialSelect.Associates.GlobalId = "2v53tpkKfC1QI$UVEwGxEy";
			beamStandardCase2.MaterialSelect.Associates.GlobalId = "2GHGDnjC1BI8mr5FS1ysvq";
			beamStandardCase3.MaterialSelect.Associates.GlobalId = "1v094xksfDT9bOdSPNsjLB";
			beamStandardCase4.MaterialSelect.Associates.GlobalId = "0ys4PwYgT5dAduf$ECulk$";
		}
	}
}
