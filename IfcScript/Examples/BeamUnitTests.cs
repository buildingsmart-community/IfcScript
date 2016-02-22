using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeometryGym.Ifc;
using Rhino.Geometry;

namespace IFC.Examples
{
	internal class BeamUnitTestsVaryingProfile : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(db);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.MID, new List<Plane>()) {GlobalId = "0uo2yx7G19uwCu9sIjn6DQ", Name = beamType.Name };
			db.NextObjectRecord = 300;
			string name = "CHS219.1x6.3";
			IfcCircleHollowProfileDef chs219x6 = new IfcCircleHollowProfileDef(db, name, 219.1 / 2.0, 6.3);
			IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
			IfcMaterialProfile materialProfile2 = new IfcMaterialProfile(name, materialProfileSet.MaterialProfiles[0].Material, chs219x6);
			IfcBeamType beamType2 = new IfcBeamType(name, materialProfile2, IfcBeamTypeEnum.BEAM) { GlobalId = "3l_OKNTJr4yBOR5rYl6b9w" };
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, beamType2, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.MID, new List<Plane>()) { GlobalId = "3_NFDdmqr7mxekvlvcgwa7", Name = name };

			beamStandardCase.Material.Associates.GlobalId = "2SL41bR1rCj99SIKuKXeFl";
			beamType2.ObjectTypeOf.GlobalId = "3LrutsCpn4DPF9Zt4YdIEU";
			beamType2.Material.Associates.GlobalId = "14nDe0n1bErgiI78N83Oxd";
			beamStandardCase2.Material.Associates.GlobalId = "1Set5Cyu9BFOWznvoQe1ho";
		}
	}
	internal class BeamUnitTestsVaryingPath : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc database, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>()) { GlobalId = "0a_qfeQLDA8e5qT$Do6J_t", Name= "Extrusion" };
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, beamType, new Arc(new Point3d(0, 0, 400), new Point3d(-100, 500, 400), new Point3d(0, 1000, 400)), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>()) { GlobalId ="1zqFh80l11VgfEm3ZWh6Xv", Name = "Revolution" };

			beamStandardCase.Material.Associates.GlobalId = "2uxxMWfA51AAznk5bQJylf";
		}
	}

	internal class BeamUnitTestsVaryingCardinal : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc database, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(database);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>()) { GlobalId = "2YX3YEaA13qOf$B1iBgAf6", Name = "TopMid" };
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.BOTMID, new List<Plane>()) { GlobalId = "39IDqhhC14BxCj_Ryk$esj", Name = "BotMid" };
			IfcBeamStandardCase beamStandardCase3 = new IfcBeamStandardCase(building, beamType, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.BOTLEFT, new List<Plane>()) { GlobalId = "17CqI$IjrDARuaYNcWcoRH", Name = "BotLeft" };
			IfcBeamStandardCase beamStandardCase4 = new IfcBeamStandardCase(building, beamType, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPRIGHT, new List<Plane>()) { GlobalId = "3TOzuh11rACgRkioYYOjj5", Name = "TopRight" };

			beamStandardCase.Material.Associates.GlobalId = "2v53tpkKfC1QI$UVEwGxEy";
			beamStandardCase2.Material.Associates.GlobalId = "2GHGDnjC1BI8mr5FS1ysvq";
			beamStandardCase3.Material.Associates.GlobalId = "1v094xksfDT9bOdSPNsjLB";
			beamStandardCase4.Material.Associates.GlobalId = "0ys4PwYgT5dAduf$ECulk$";
		}
	} 
}
