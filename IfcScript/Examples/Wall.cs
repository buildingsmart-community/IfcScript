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
		protected override void GenerateData(DatabaseIfc db, IfcBuilding building)
		{
			IfcMaterial masonryFinish = new IfcMaterial(db, "Masonry - Brick - Brown");
			IfcMaterial masonry = new IfcMaterial(db, "Masonry");
			IfcMaterialLayer layerFinish = new IfcMaterialLayer(masonryFinish, 110, "Finish");
			IfcMaterialLayer airInfiltrationBarrier = new IfcMaterialLayer(db, 50, "Air Infiltration Barrier") { IsVentilated = IfcLogicalEnum.TRUE };
			IfcMaterialLayer structure = new IfcMaterialLayer(masonry, 110, "Core");
			string name = "Double Brick - 270";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet( new List<IfcMaterialLayer>() { layerFinish, airInfiltrationBarrier, structure }, name);
			materialLayerSet.Associates.GlobalId = "36U74BIPDD89cYkx9bkV$Y";
			db.NextObjectRecord = 300;
			IfcWallType wallType = new IfcWallType(name, materialLayerSet, IfcWallTypeEnum.NOTDEFINED) { GlobalId = "2aG1gZj7PD2PztLOx2$IVX" };
			wallType.ObjectTypeOf.GlobalId = "1$EkFElNT8TB_VUVG1FtMe";
			IfcWallStandardCase wallStandardCase = new IfcWallStandardCase(building, wallType, new Line(0, 0, 0, 5000, 0, 0), 2000, 0, true, null) { GlobalId = "0DWgwt6o1FOx7466fPk$jl" };
			wallStandardCase.MaterialSelect.Associates.GlobalId = "1BYoVhjtLADPUZYzipA826";
		}
	}
	
}
