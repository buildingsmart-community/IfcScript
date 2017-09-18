using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;
 
namespace IFC.Examples
{
	class Wall : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc db = building.Database;
			IfcMaterial masonryFinish = new IfcMaterial(db, "Masonry - Brick - Brown");
			IfcMaterial masonry = new IfcMaterial(db, "Masonry");
			IfcMaterialLayer layerFinish = new IfcMaterialLayer(masonryFinish, 110, "Finish");
			IfcMaterialLayer airInfiltrationBarrier = new IfcMaterialLayer(db, 50, "Air Infiltration Barrier") { IsVentilated = IfcLogicalEnum.TRUE };
			IfcMaterialLayer structure = new IfcMaterialLayer(masonry, 110, "Core");
			string name = "Double Brick - 270";
			IfcMaterialLayerSet materialLayerSet = new IfcMaterialLayerSet( new List<IfcMaterialLayer>() { layerFinish, airInfiltrationBarrier, structure }, name);
			db.NextObjectRecord = 300;
			IfcWallType wallType = new IfcWallType(name, materialLayerSet, IfcWallTypeEnum.NOTDEFINED);
			IfcMaterialLayerSetUsage layerSetUsage = new IfcMaterialLayerSetUsage(materialLayerSet, IfcLayerSetDirectionEnum.AXIS2, IfcDirectionSenseEnum.POSITIVE, -materialLayerSet.MaterialLayers.Sum(x => x.LayerThickness) / 2.0);
			IfcWallStandardCase wallStandardCase = new IfcWallStandardCase(building, layerSetUsage, new IfcAxis2Placement3D(new IfcCartesianPoint(db,0,0,0)),5000, 2000);
			db.Context.AddDeclared(wallType);

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			wallType.GlobalId = "2aG1gZj7PD2PztLOx2$IVX";
			wallStandardCase.GlobalId = "0DWgwt6o1FOx7466fPk$jl";
			materialLayerSet.Associates.GlobalId = "36U74BIPDD89cYkx9bkV$Y";
			wallStandardCase.MaterialSelect.Associates.GlobalId = "1BYoVhjtLADPUZYzipA826";
		}
	}
	
}
