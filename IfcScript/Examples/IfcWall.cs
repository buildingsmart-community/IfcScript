using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;
 
using Coord3d = System.Tuple<double, double, double>;
using CoordIndex = System.Tuple<int, int, int>;


namespace IFC.Examples
{
	class Wall : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			md.NextObjectRecord = 200;
			IfcMaterial masonryFinish = new IfcMaterial(md, "Masonry - Brick - Brown", "", "");
			IfcMaterial masonry = new IfcMaterial(md, "Masonry", "", "");
			IfcMaterialLayer layerFinish = new IfcMaterialLayer(md, masonryFinish, 110, false, "Finish", "", "", 0);
			IfcMaterialLayer airInfiltrationBarrier = new IfcMaterialLayer(md, null, 50, true, "Air Infiltration Barrier", "", "", 0);
			IfcMaterialLayer structure = new IfcMaterialLayer(md, masonry, 110, false, "Core", "", "", 0);
			string name = "Double Brick - 270";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet(md, new List<IfcMaterialLayer>() { layerFinish, airInfiltrationBarrier, structure }, name, "");
			md.NextObjectRecord = 300;
			IfcWallType wallType = new IfcWallType(md, new IfcElemTypeParams("", name, "", "", ""), materialLayerSet, null, IfcWallTypeEnum.NOTDEFINED);
			IfcWallStandardCase wallStandardCase = new IfcWallStandardCase(building, null, wallType, new Line(0, 0, 0, 5000, 0, 0), 2000, 0, true, null);
		}
	}
}
