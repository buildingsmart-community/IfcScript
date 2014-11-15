using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Text;
using GGYM.IFC;

namespace IFC
{
	class IFCExampleBase
	{
		public void GenerateExample(string path) 
		{
			STPModelData md = new STPModelData(false);
			md.IFC4 = true;
			md.NextObjectRecord = 50;
			IfcBuilding building = new IfcBuilding(md, "IfcBuilding", null, "");
			//building.Comment = "if the building is the uppermost spatial structure element it defines the absolute position";
			md.NextObjectRecord = 100;
			IfcProject project = new IfcProject(building, "IfcProject", "", "", null, GGYM.Units.Length.mm);
			GenerateData(md,building); 
			md.writeFile(Path.Combine(path,this.GetType().Name + ".ifc")); 
		}
		protected virtual void GenerateData(STPModelData md,IfcBuilding building) { } 
			
	}
}
