using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GGYM.IFC;
using Rhino.Geometry;

namespace IFC.Examples
{
	internal class BeamUnitTestsVaryingProfile : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(md);  
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcElemParams("0uo2yx7G19uwCu9sIjn6DQ", beamType.Name, "", "", ""), beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.MID, new List<Plane>());
			beamStandardCase.Material.Associates.GlobalId = "2SL41bR1rCj99SIKuKXeFl";
			md.NextObjectRecord = 300;
			string name = "CHS219.1x6.3"; 
			IfcCircleHollowProfileDef chs219x6 = new IfcCircleHollowProfileDef(md, IfcProfileTypeEnum.AREA, name, null, 219.1 / 2.0, 6.3);
			IfcMaterialProfileSet materialProfileSet = beamType.Material as IfcMaterialProfileSet;
			IfcMaterialProfile materialProfile2 = new IfcMaterialProfile(md, name, "", materialProfileSet.MaterialProfiles[0].Material, chs219x6, 0, ""); 
			IfcBeamType beamType2 = new IfcBeamType(md, new IfcElemTypeParams("3l_OKNTJr4yBOR5rYl6b9w", name, "", "", ""), materialProfile2, null, IfcBeamTypeEnum.BEAM);
			beamType2.ObjectTypeOf.GlobalId = "3LrutsCpn4DPF9Zt4YdIEU";
			beamType2.Material.Associates.GlobalId = "14nDe0n1bErgiI78N83Oxd";
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcElemParams("3_NFDdmqr7mxekvlvcgwa7", name, "", "", ""), beamType2, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.MID, new List<Plane>());
			beamStandardCase2.Material.Associates.GlobalId = "1Set5Cyu9BFOWznvoQe1ho";
		}
	}
	internal class BeamUnitTestsVaryingPath : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(md);  
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcElemParams("0a_qfeQLDA8e5qT$Do6J_t", "Extrusion", "", "", ""), beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>());
			beamStandardCase.Material.Associates.GlobalId = "2uxxMWfA51AAznk5bQJylf";
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcElemParams("1zqFh80l11VgfEm3ZWh6Xv", "Revolution", "", "", ""), beamType, new Arc(new Point3d(0, 0,400), new Point3d(-100, 500, 400), new Point3d(0, 1000, 400)), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>());
		}
	}

	internal class BeamUnitTestsVaryingCardinal : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcBeamType beamType = GetParametericIPE200(md);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcElemParams("2YX3YEaA13qOf$B1iBgAf6", "TopMid", "", "", ""), beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>());
			beamStandardCase.Material.Associates.GlobalId = "2v53tpkKfC1QI$UVEwGxEy";
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcElemParams("39IDqhhC14BxCj_Ryk$esj", "BotMid", "", "", ""), beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.BOTMID, new List<Plane>());
			beamStandardCase2.Material.Associates.GlobalId = "2GHGDnjC1BI8mr5FS1ysvq";
			IfcBeamStandardCase beamStandardCase3 = new IfcBeamStandardCase(building, new IfcElemParams("17CqI$IjrDARuaYNcWcoRH", "BotLeft", "", "", ""), beamType, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.BOTLEFT, new List<Plane>());
			beamStandardCase3.Material.Associates.GlobalId = "1v094xksfDT9bOdSPNsjLB";
			IfcBeamStandardCase beamStandardCase4 = new IfcBeamStandardCase(building, new IfcElemParams("3TOzuh11rACgRkioYYOjj5", "TopRight", "", "", ""), beamType, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPRIGHT, new List<Plane>());
			beamStandardCase4.Material.Associates.GlobalId = "0ys4PwYgT5dAduf$ECulk$";
		}
	} 
}
