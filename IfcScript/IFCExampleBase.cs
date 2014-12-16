using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Text;
using GGYM.IFC;

namespace IFC
{
	internal abstract class IFCExampleBase
	{
		internal void GenerateExample(string path,ModelView modelView) 
		{
			STPModelData md = new STPModelData(false,modelView);
			md.NextObjectRecord = 50;
			IfcBuilding building = new IfcBuilding(md, "39t4Pu3nTC4ekXYRIHJB9W", "IfcBuilding", null, "");
			building.ContainsElements[0].GlobalId = "3Sa3dTJGn0H8TQIGiuGQd5";
			building.Comment = "each IFC data set containing elements in a building context has to include a building";
			md.NextObjectRecord = 100;
			IfcProject project = new IfcProject(building, "0$WU4A9R19$vKWO$AdOnKA", "IfcProject", "", "", null, GGYM.Units.Length.mm);
			project.IsDecomposedBy[0].GlobalId = "091a6ewbvCMQ2Vyiqspa7a";
			project.RepresentationContexts[0].Comment = "general entities required for all IFC data sets, defining the context for the exchange";
			md.NextObjectRecord = 200;
			GenerateData(md,building);
			string filePath = Path.Combine(path,this.GetType().Name + ".ifc");
			if (File.Exists(filePath))
			{
				string[] newLines = md.ToString().Split(new char[] { '\r' , '\n' },StringSplitOptions.RemoveEmptyEntries);
				List<string> existingLines = new List<string>( File.ReadAllLines(filePath));
				existingLines.RemoveAll(x => string.IsNullOrEmpty(x));
				
				if (newLines.Length == existingLines.Count)
				{
					bool identical = true;
					for (int icounter = 0; icounter < newLines.Length; icounter++)
					{
						string s1 = newLines[icounter], s2 = existingLines[icounter];
						if (s1.StartsWith("/* time_stamp */ ") && s2.StartsWith("/* time_stamp */ "))
							continue;
						if (string.Compare(s1, s2, true) != 0)
						{
							identical = false;
							break;
						}
					}
					if (identical)
						return;
				}
			}
			md.writeFile(filePath); 
		}
		protected virtual void GenerateData(STPModelData md,IfcBuilding building) { }

		protected IfcBeamType GetParametericIPE200(STPModelData md)
		{
			IfcMaterialProfile materialProfile = GetParametericIPE200Profile(md);
			IfcBeamType beamType = new IfcBeamType(md, new IfcElemTypeParams("32b2OtzCP30umNyY5LsCfN", materialProfile.Name, "", "", ""), materialProfile, null, IfcBeamTypeEnum.JOIST);
			beamType.ObjectTypeOf.GlobalId = "3s_DqAVvb3LguudTShJHVo";
			beamType.Material.Associates.GlobalId = "0NkGSIHVT3SeAR6bnw7pSa";
			return beamType;
		}
		protected IfcMaterialProfile GetParametericIPE200Profile(STPModelData md)
		{
			IfcMaterial material = new IfcMaterial(md, "S355JR", "", "Steel");
			material.Associates.GlobalId = "1oJeVe14nCYf5cL0Mka0KL";
			string name = "IPE200";
			IfcIShapeProfileDef ipe200 = new IfcIShapeProfileDef(md, IfcProfileTypeEnum.AREA, name, null, 200, 100, 5.6, 8.5, 12, 0, 0);
			return new IfcMaterialProfile(md, name, "", material, ipe200, 0, "");
		}
	}
}
