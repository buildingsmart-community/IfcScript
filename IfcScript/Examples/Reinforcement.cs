using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;
 
namespace IFC.Examples
{
	internal class ReinforcingAssembly : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			ReinforcingExample.GenerateData(db, building, true);
		}
	}
	internal class ReinforcingBar : IFCExampleBase
	{
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			ReinforcingExample.GenerateData(db, building, false);
		}
	}
	internal class ReinforcingExample
	{
		internal static void GenerateData(DatabaseIfc db, IfcBuilding building, bool assembly)
		{
			IfcDocumentReference documentReference = new IfcDocumentReference(db) {Name = "MyReinforcementCode", Identification = "MyCodeISO3766" };
			IfcRelAssociatesDocument associatesDocument = new IfcRelAssociatesDocument(db.Project, documentReference) { GlobalId = "1R7R97$uLAAv4wci$KGwn8" }; 
			IfcMaterial material = new IfcMaterial(db, "ReinforcingSteel");
			List<Point3d> points = new List<Point3d>() { new Point3d(-69.0, 0.0, -122.0), new Point3d(-69.0, 0.0, -79.0), new Point3d(-54.9411254969541, 0.0, -45.0588745030455), new Point3d(-21.0, 0.0, -31.0), new Point3d(21.0, 0.0, -31.0), new Point3d(54.9411254969541, 0.0, -45.0588745030455), new Point3d(69.0, 0.0, -78.9999999999999), new Point3d(69.0, 0.00000000000000089, -321.0), new Point3d(54.9939785957165, 1.21791490472034, -354.941125496954), new Point3d(21.1804517666074, 4.15822158551252, -369.0), new Point3d(-20.6616529376114, 7.79666547283599, -369.0), new Point3d(-54.4751797667207, 10.7369721536282, -354.941125496954), new Point3d(-68.4812011710042, 11.9548870583485, -321.0), new Point3d(-69.0, 12.0, -79.0), new Point3d(-54.9411254969541, 12.0, -45.0588745030455), new Point3d(-21.0, 12.0, -31.0), new Point3d(21.0, 12.0, -31.0), new Point3d(54.9411254969541, 12.0, -45.0588745030455), new Point3d(69.0, 12.0, -78.9999999999999),new Point3d(69.0, 12.0, -122.0), };
			PolyCurve pc = new PolyCurve();
			pc.Append(new Line(points[0],points[1]));
			pc.Append(new Arc(points[1],points[2],points[3] ));
			pc.Append(new Line(points[3],points[4]));
			pc.Append(new Arc(points[4],points[5],points[6] ));
			pc.Append(new Line(points[6],points[7]));
			pc.Append(new Arc(points[7],points[8],points[9] ));
			pc.Append(new Line(points[9],points[10]));
			pc.Append(new Arc(points[10],points[11],points[12] ));
			pc.Append(new Line(points[12],points[13]));
			pc.Append(new Arc(points[13],points[14],points[15] ));
			pc.Append(new Line(points[15],points[16]));
			pc.Append(new Arc(points[16],points[17],points[18] ));
			pc.Append(new Line(points[18],points[19]));
			IfcBoundedCurve directrix = IfcBoundedCurve.ConvertCurve(db,pc);

			double barDiameter = 12, area = Math.PI * Math.Pow( barDiameter,2) / 4;
			IfcSweptDiskSolid sweptDiskSolid = new IfcSweptDiskSolid(directrix, barDiameter/2.0, 0);
			IfcRepresentationMap representationMap = new IfcRepresentationMap(sweptDiskSolid);
			string shapeCode = ""; //Todo
			IfcReinforcingBarType reinforcingBarType = new IfcReinforcingBarType(db, "12 Diameter Ligature", IfcReinforcingBarTypeEnum.LIGATURE, barDiameter, area, 1150, IfcReinforcingBarSurfaceEnum.TEXTURED, shapeCode, null) { GlobalId = "0jMRtfHYXE7u4s_CQ2uVE9", MaterialSelect = material, RepresentationMaps = new List<IfcRepresentationMap>() { representationMap} };
			reinforcingBarType.ObjectTypeOf.GlobalId = "1iAfl2ERbFmwi7uniy1H7j";
			reinforcingBarType.MaterialSelect.Associates.GlobalId = "3gfVO40P5EfQyKZ_bF0R$6";
			if (assembly)
			{
				IfcMaterial concrete = new IfcMaterial(db,"Concrete") { Category = "Concrete" };
				string name = "400x200RC";
				IfcRectangleProfileDef rectangleProfileDef = new IfcRectangleProfileDef(db, name, 400, 200);
				IfcMaterialProfile materialProfile = new IfcMaterialProfile(name,concrete,rectangleProfileDef);

				IfcBeamType beamType = new IfcBeamType(name, materialProfile, IfcBeamTypeEnum.BEAM) { GlobalId = "3bdpqVuWTCbxJ2S3ODYv6q"};
				beamType.ObjectTypeOf.GlobalId = "2oaQVVf79BrwRouvtRuQVg";
				beamType.MaterialSelect.Associates.GlobalId = "2ZEgyI2v184hwa$_diRqS9";
				IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building, beamType, new Line(0, 0, 0, 0, 5000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, null) { GlobalId = "1yjQ2DwLnCC8k3i3X6D_ut" };
				beamStandardCase.MaterialSelect.Associates.GlobalId = "3DWeleqqjEG9KshbOZXUdY";
				IfcElementAssembly elementAssembly = new IfcElementAssembly(beamStandardCase, IfcAssemblyPlaceEnum.FACTORY, IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT) { GlobalId = "0Q1tCJWdj4kOkZUg7rkf2h" };
				List<string> ids = new List<string>() { "0ohBfsArr3ruXYxacT4yl5","3YrK7RbE122fNRsP5djFAe","0wxAc63nj5AezFhfks7wLL","0bsov2wZL6tRRZmKy4vuUU","3qrgfIBb92ZegJTle7jou3","16m6R3JeT83fJPCze2yU$a","2SGIIYjSbCuu3HVwoLt1yh","0PsLby6eL8_hVEt4QwK0lZ","1325VJou5AngWp1djcV0hL","20zj_$BcH74xRgR4bDrLNb","3M4SfEMtHEJukgZR4hw$eV","23BYnIaOLBZPVTrKVEDJiy","2XulRByDL8ugyo4Uqv9rJr","2xvQMSga96XOT3VeCS6ZsK","2gUE6_w3j77f8YJGz_2RMl","0J0dRL4tT93REAabfASDom","048RJ151b81PqODsTMD4EA","3hXx9Kb6b5bvjgr9pwvpz0","0FmUHg8ZX0ZfY$0f5nkM2l","2_zvpwRdvAuRiTlHXX$Qp8","1mhkXHKfX6PxdS2vZn17wX","0CeIQzUqP5qOOeAjMtH2OX","3shtoAQL5BAhvwA_1Ph$lC","22j4RNKqD2IBRDGig5eaCF","3Wvu6qGJH4ChhTV3pl9CGh","37Qrf07Iz3tRMbSxEA4ynH","2gelqZ1Wv8BvCy6TstVGkd","1Q21dHc_X7eRppCHrT69Vb","0e6Wc08NLD59ueqCAK1gxp","3xdMOSZMj3cBOV_QTbXZha","1r_U9JTkHDWwkv_nfWFHVe","29I7_S2fT3WRD4zPH4YjmD","0$ciATTaP17PJMHQD0$N3Y","1irBeCCUf82wdGg7qTPCbW" };
				int jcounter = 0;
				for (int icounter = 25; icounter < 5000; icounter += 150)
				{
					IfcElement element = reinforcingBarType.GenerateMappedItemElement(elementAssembly, new Plane(new Point3d(0, icounter, 0), Vector3d.XAxis, Vector3d.YAxis));
					element.GlobalId = ids[jcounter++];
				}
				elementAssembly.IsDecomposedBy[0].GlobalId = "1WdB196Kb72f_pKgj5rklU";
			}
			else
			{ 
				IfcElement element = reinforcingBarType.GenerateMappedItemElement(building, Plane.WorldXY);
				element.GlobalId = "0WUveBtSTDbunNjDLsuRn$";
			}
		}
	}
	
}
