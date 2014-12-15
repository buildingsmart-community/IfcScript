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
			//building.Comment = "if the building is the uppermost spatial structure element it defines the absolute position";
			md.NextObjectRecord = 100;
			IfcProject project = new IfcProject(building, "0$WU4A9R19$vKWO$AdOnKA", "IfcProject", "", "", null, GGYM.Units.Length.mm);
			project.IsDecomposedBy[0].GlobalId = "091a6ewbvCMQ2Vyiqspa7a";
			md.NextObjectRecord = 200;
			GenerateData(md,building); 
			md.writeFile(Path.Combine(path,this.GetType().Name + ".ifc")); 
		}
		protected virtual void GenerateData(STPModelData md,IfcBuilding building) { } 
			
	}
}
