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
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			ReinfocingExample.GenerateData(md, building, true);
		}
	}
	internal class ReinforcingBar : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			ReinfocingExample.GenerateData(md, building, false);
		}
	}
	internal class ReinfocingExample
	{
		internal static void GenerateData(STPModelData md, IfcBuilding building,bool assembly)
		{
			IfcDocumentReference documentReference = new IfcDocumentReference(md, "", "MyReinforcementCode", "MyCodeISO3766", "", null);
			IfcRelAssociatesDocument associatesDocument = new IfcRelAssociatesDocument(md.Project, documentReference);	

			IfcMaterial material = new IfcMaterial(md, "ReinforcingSteel", "", "");
			List<Point3d> points = new List<Point3d>() { new Point3d(-69.0, 0.0, -122.0), new Point3d(-69.0, 0.0, -79.0), new Point3d(-54.9411254969541, 0.0, -45.0588745030455), new Point3d(-21.0, 0.0, -31.0), new Point3d(21.0, 0.0, -31.0), new Point3d(54.9411254969541, 0.0, -45.0588745030455), new Point3d(69.0, 0.0, -78.9999999999999), new Point3d(69.0, 0.00000000000000089, -321.0), new Point3d(54.9939785957165, 1.21791490472034, -354.941125496954), new Point3d(21.1804517666074, 4.15822158551252, -369.0), new Point3d(-20.6616529376114, 7.79666547283599, -369.0), new Point3d(-54.4751797667207, 10.7369721536282, -354.941125496954), new Point3d(-68.4812011710042, 11.9548870583485, -321.0), new Point3d(-69.0, 12.0, -79.0), new Point3d(-54.9411254969541, 12.0, -45.0588745030455), new Point3d(-21.0, 12.0, -31.0), new Point3d(21.0, 12.0, -31.0), new Point3d(54.9411254969541, 12.0, -45.0588745030455), new Point3d(69.0, 12.0, -78.9999999999999) };
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
			pc.Append(new Line(points[18],points[0]));
			IfcBoundedCurve directrix = IfcBoundedCurve.ConvertCurve(md,pc);

			double barDiameter = 12, area = Math.PI * Math.Pow( barDiameter,2) / 4;
			IfcSweptDiskSolid sweptDiskSolid = new IfcSweptDiskSolid(directrix, barDiameter/2.0, 0);
			IfcRepresentationMap representationMap = new IfcRepresentationMap(sweptDiskSolid);
			string shapeCode = ""; //Todo
			IfcReinforcingBarType reinforcingBarType = new IfcReinforcingBarType(md, new IfcElemTypeParams("", "12 Diameter Ligature", "", "", ""), material,representationMap, null, IfcReinforcingBarTypeEnum.LIGATURE, barDiameter, area, 1150, IfcReinforcingBarSurfaceEnum.TEXTURED, shapeCode, null);

			if (assembly)
			{
				IfcMaterial concrete = new IfcMaterial(md,"Concrete","","Concrete");
				string name = "400x200RC";
				IfcRectangleProfileDef rectangleProfileDef = new IfcRectangleProfileDef(md, IfcProfileTypeEnum.AREA, name, null, 400, 200);
				IfcMaterialProfile materialProfile = new IfcMaterialProfile(md,name,"",concrete,rectangleProfileDef,0,"");

				IfcBeamType beamType = new IfcBeamType(md, new IfcElemTypeParams("", name, "", "", ""), materialProfile, null, IfcBeamTypeEnum.BEAM);
				IfcBeamStandardCase beamStandardCase = new IfcBeamStandardCase(building,new IfcElemParams(), beamType, new Line(0, 0, 0, 0, 5000, 0), Vector3d.ZAxis, IfcCardinalPointReference.TOPMID, null);
				IfcElementAssembly elementAssembly = new IfcElementAssembly(building, new IfcElemParams(), IfcAssemblyPlaceEnum.FACTORY, IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT);
				for (int icounter = 25; icounter < 5000; icounter += 150)
				{
					reinforcingBarType.GenerateMappedItemElement(elementAssembly, new Plane(new Point3d(0,icounter,0),Vector3d.XAxis,Vector3d.YAxis), new IfcElemParams());
				}
			}
			else
				reinforcingBarType.GenerateMappedItemElement(building, Plane.WorldXY, new IfcElemParams());
		}
	}
	
}
