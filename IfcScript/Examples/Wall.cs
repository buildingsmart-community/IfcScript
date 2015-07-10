using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;
 
namespace IFC.Examples
{
	class Wall : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			IfcMaterial masonryFinish = new IfcMaterial(md, "Masonry - Brick - Brown", "", "");
			IfcMaterial masonry = new IfcMaterial(md, "Masonry", "", "");
			IfcMaterialLayer layerFinish = new IfcMaterialLayer(md, masonryFinish, 110, false, "Finish", "", "", 0);
			IfcMaterialLayer airInfiltrationBarrier = new IfcMaterialLayer(md, null, 50, true, "Air Infiltration Barrier", "", "", 0);
			IfcMaterialLayer structure = new IfcMaterialLayer(md, masonry, 110, false, "Core", "", "", 0);
			string name = "Double Brick - 270";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet(md, new List<IfcMaterialLayer>() { layerFinish, airInfiltrationBarrier, structure }, name, "");
			materialLayerSet.Associates.GlobalId = "36U74BIPDD89cYkx9bkV$Y";
			md.NextObjectRecord = 300;
			IfcWallType wallType = new IfcWallType(md, new IfcElemTypeParams("2aG1gZj7PD2PztLOx2$IVX", name, "", "", ""), materialLayerSet, null, IfcWallTypeEnum.NOTDEFINED);
			wallType.ObjectTypeOf.GlobalId = "1$EkFElNT8TB_VUVG1FtMe";
			IfcWallStandardCase wallStandardCase = new IfcWallStandardCase(building, new IfcElemParams("0DWgwt6o1FOx7466fPk$jl","","","",""), wallType, new Line(0, 0, 0, 5000, 0, 0), 2000, 0, true, null);
			wallStandardCase.MaterialSelect.Associates.GlobalId = "1BYoVhjtLADPUZYzipA826";
		}
	}
	
}
