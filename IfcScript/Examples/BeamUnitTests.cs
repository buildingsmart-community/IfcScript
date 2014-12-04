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
			IfcMaterial material = new IfcMaterial(md,"S355JR","","Steel");
			md.NextObjectRecord = 100;
			string name = "IPE200";
			IfcIShapeProfileDef ipe200 = new IfcIShapeProfileDef(md,IfcProfileTypeEnum.AREA,name,null,100,200,5.6,8.5,12,0,0);
			IfcMaterialProfile materialProfile = new IfcMaterialProfile(md,name,"",material,ipe200,0,"");
			IfcBeamType beamType = new IfcBeamType(md,new IfcElemTypeParams("",name,"","",""),materialProfile,null,IfcBeamTypeEnum.JOIST);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcElemParams("",name,"","",""), beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.MID,new List<Plane>());

			md.NextObjectRecord = 300;
			name = "CHS219.1x6.3"; 
			IfcCircleHollowProfileDef chs219x6 = new IfcCircleHollowProfileDef(md, IfcProfileTypeEnum.AREA, name, null, 219.1 / 2.0, 6.3);
			IfcMaterialProfile materialProfile2 = new IfcMaterialProfile(md, name, "", material, chs219x6, 0, "");
			IfcBeamType beamType2 = new IfcBeamType(md,new IfcElemTypeParams("",name,"","",""),materialProfile2,null,IfcBeamTypeEnum.BEAM);
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcElemParams("",name,"","",""), beamType2, new Line(500, 0, 0, 500, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.MID, new List<Plane>());
		}
	}
	internal class BeamUnitTestsVaryingPath : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcMaterial material = new IfcMaterial(md, "S355JR", "", "Steel");
			md.NextObjectRecord = 100;
			string name = "IPE200";
			IfcIShapeProfileDef ipe200 = new IfcIShapeProfileDef(md, IfcProfileTypeEnum.AREA, name, null, 100, 200, 5.6, 8.5, 12, 0, 0);
			IfcMaterialProfile materialProfile = new IfcMaterialProfile(md, name, "", material, ipe200, 0, "");
			IfcBeamType beamType = new IfcBeamType(md, new IfcElemTypeParams("", name, "", "", ""), materialProfile, null, IfcBeamTypeEnum.JOIST);
			IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, new IfcElemParams("", "Extrusion", "", "", ""), beamType, new Line(0, 0, 0, 0, 1000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>());
			
			IfcBeamStandardCase beamStandardCase2 = new IfcBeamStandardCase(building, new IfcElemParams("", "Revolution", "", "", ""), beamType, new Arc(new Point3d( 0, 0, 0),new Point3d(  -100,500, 0),new Point3d(0,1000,0)) , Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, new List<Plane>());
		}
	} 
}
