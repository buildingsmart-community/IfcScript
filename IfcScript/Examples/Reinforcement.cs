using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;
 
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
			List<Tuple<double, double, double>> points = new List<Tuple<double, double, double>>() { new Tuple<double, double, double>(-69.0, 0.0, -122.0), new Tuple<double,double,double>(-69.0, 0.0, -79.0), new Tuple<double,double,double>(-54.9411254969541, 0.0, -45.0588745030455), new Tuple<double,double,double>(-21.0, 0.0, -31.0), new Tuple<double,double,double>(21.0, 0.0, -31.0), new Tuple<double,double,double>(54.9411254969541, 0.0, -45.0588745030455), new Tuple<double,double,double>(69.0, 0.0, -78.9999999999999), new Tuple<double,double,double>(69.0, 0.00000000000000089, -321.0), new Tuple<double,double,double>(54.9939785957165, 1.21791490472034, -354.941125496954), new Tuple<double,double,double>(21.1804517666074, 4.15822158551252, -369.0), new Tuple<double,double,double>(-20.6616529376114, 7.79666547283599, -369.0), new Tuple<double,double,double>(-54.4751797667207, 10.7369721536282, -354.941125496954), new Tuple<double,double,double>(-68.4812011710042, 11.9548870583485, -321.0), new Tuple<double,double,double>(-69.0, 12.0, -79.0), new Tuple<double,double,double>(-54.9411254969541, 12.0, -45.0588745030455), new Tuple<double,double,double>(-21.0, 12.0, -31.0), new Tuple<double,double,double>(21.0, 12.0, -31.0), new Tuple<double,double,double>(54.9411254969541, 12.0, -45.0588745030455), new Tuple<double,double,double>(69.0, 12.0, -78.9999999999999),new Tuple<double,double,double>(69.0, 12.0, -122.0), };
			IfcBoundedCurve directrix = null;
			if (db.Release == ReleaseVersion.IFC2x3)
				directrix = new IfcPolyline(db, points);
			else
			{
				List<IfcSegmentIndexSelect> segments = new List<IfcSegmentIndexSelect>();
				segments.Add(new IfcLineIndex(1, 2));
				segments.Add(new IfcArcIndex(2,3,4));
				segments.Add(new IfcLineIndex(4,5));
				segments.Add(new IfcArcIndex(5,6,7));
				segments.Add(new IfcLineIndex(7,8));
				segments.Add(new IfcArcIndex(8,9,10));
				segments.Add(new IfcLineIndex(10,11));
				segments.Add(new IfcArcIndex(11,12,13));
				segments.Add(new IfcLineIndex(13,14));
				segments.Add(new IfcArcIndex(14,15,16));
				segments.Add(new IfcLineIndex(16,17));
				segments.Add(new IfcArcIndex(17,18,19));
				segments.Add(new IfcLineIndex(19,20));
				directrix = new IfcIndexedPolyCurve(new IfcCartesianPointList3D(db, points), segments);
			}
			double barDiameter = 12, area = Math.PI * Math.Pow( barDiameter,2) / 4;
			IfcSweptDiskSolid sweptDiskSolid = new IfcSweptDiskSolid(directrix, barDiameter/2.0);
			IfcRepresentationMap representationMap = new IfcRepresentationMap(sweptDiskSolid);
			string shapeCode = ""; //Todo
			IfcReinforcingBarType reinforcingBarType = new IfcReinforcingBarType(db, "12 Diameter Ligature", IfcReinforcingBarTypeEnum.LIGATURE, barDiameter, area, 1150, IfcReinforcingBarSurfaceEnum.TEXTURED, shapeCode, null) { GlobalId = "0jMRtfHYXE7u4s_CQ2uVE9", MaterialSelect = material, RepresentationMaps = new List<IfcRepresentationMap>() { representationMap} };
			db.Context.AddDeclared(reinforcingBarType);
			if (assembly)
			{
				IfcMaterial concrete = new IfcMaterial(db,"Concrete") { Category = "Concrete" };
				string name = "400x200RC";
				IfcRectangleProfileDef rectangleProfileDef = new IfcRectangleProfileDef(db, name, 200, 400);
				IfcMaterialProfile materialProfile = new IfcMaterialProfile(name,concrete,rectangleProfileDef);

				IfcBeamType beamType = new IfcBeamType(name, materialProfile, IfcBeamTypeEnum.BEAM);
				db.Context.AddDeclared(beamType);
				IfcMaterialProfileSet materialProfileSet = beamType.MaterialSelect as IfcMaterialProfileSet;
				IfcBeam beam = new IfcBeam(building, new IfcLocalPlacement(building.Placement, new IfcAxis2Placement3D(new IfcCartesianPoint(db, 0, 0, 0))), null) { Description = "Reinforced Beam" };
				IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(beam, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.TOPMID), new IfcAxis2Placement3D(new IfcCartesianPoint(db, 0, 0, 0), new IfcDirection(db, 0, 1, 0), new IfcDirection(db, -1, 0, 0)), 5000) { GlobalId = "1yjQ2DwLnCC8k3i3X6D_ut", RelatingType = beamType };
				IfcElementAssembly elementAssembly = new IfcElementAssembly(beam, IfcAssemblyPlaceEnum.FACTORY, IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT);
				List<string> ids = new List<string>() { "0ohBfsArr3ruXYxacT4yl5","3YrK7RbE122fNRsP5djFAe","0wxAc63nj5AezFhfks7wLL","0bsov2wZL6tRRZmKy4vuUU","3qrgfIBb92ZegJTle7jou3","16m6R3JeT83fJPCze2yU$a","2SGIIYjSbCuu3HVwoLt1yh","0PsLby6eL8_hVEt4QwK0lZ","1325VJou5AngWp1djcV0hL","20zj_$BcH74xRgR4bDrLNb","3M4SfEMtHEJukgZR4hw$eV","23BYnIaOLBZPVTrKVEDJiy","2XulRByDL8ugyo4Uqv9rJr","2xvQMSga96XOT3VeCS6ZsK","2gUE6_w3j77f8YJGz_2RMl","0J0dRL4tT93REAabfASDom","048RJ151b81PqODsTMD4EA","3hXx9Kb6b5bvjgr9pwvpz0","0FmUHg8ZX0ZfY$0f5nkM2l","2_zvpwRdvAuRiTlHXX$Qp8","1mhkXHKfX6PxdS2vZn17wX","0CeIQzUqP5qOOeAjMtH2OX","3shtoAQL5BAhvwA_1Ph$lC","22j4RNKqD2IBRDGig5eaCF","3Wvu6qGJH4ChhTV3pl9CGh","37Qrf07Iz3tRMbSxEA4ynH","2gelqZ1Wv8BvCy6TstVGkd","1Q21dHc_X7eRppCHrT69Vb","0e6Wc08NLD59ueqCAK1gxp","3xdMOSZMj3cBOV_QTbXZha","1r_U9JTkHDWwkv_nfWFHVe","29I7_S2fT3WRD4zPH4YjmD","0$ciATTaP17PJMHQD0$N3Y","1irBeCCUf82wdGg7qTPCbW" };
				int jcounter = 0;
				for (int icounter = 25; icounter < 5000; icounter += 150)
				{
					IfcElement element = reinforcingBarType.GenerateMappedItemElement(elementAssembly, new IfcCartesianTransformationOperator3D(db) { LocalOrigin = new IfcCartesianPoint(db, 0, icounter, 0) } );
					//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
					element.GlobalId = ids[jcounter++];
				}

				//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
				beam.GlobalId = "1_KSmTR8T8bO37iRs24GkM";
				beamType.GlobalId = "3bdpqVuWTCbxJ2S3ODYv6q";
				beamType.ObjectTypeOf.GlobalId = "2oaQVVf79BrwRouvtRuQVg";
				beamType.MaterialSelect.Associates.GlobalId = "2ZEgyI2v184hwa$_diRqS9";
				beamStandardCase.MaterialSelect.Associates.GlobalId = "3DWeleqqjEG9KshbOZXUdY";
				elementAssembly.GlobalId = "0Q1tCJWdj4kOkZUg7rkf2h";
				elementAssembly.IsDecomposedBy[0].GlobalId = "1WdB196Kb72f_pKgj5rklU";
				beam.IsDecomposedBy[0].GlobalId = "1b1SnKocD0WRevlg8Aqhj5";
			}
			else
			{ 
				IfcElement element = reinforcingBarType.GenerateMappedItemElement(building, new IfcCartesianTransformationOperator3D(db));

				//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
				element.GlobalId = "0WUveBtSTDbunNjDLsuRn$";
			}

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			
			reinforcingBarType.ObjectTypeOf.GlobalId = "1iAfl2ERbFmwi7uniy1H7j";
			reinforcingBarType.MaterialSelect.Associates.GlobalId = "3gfVO40P5EfQyKZ_bF0R$6";
		}
	}
	
}
