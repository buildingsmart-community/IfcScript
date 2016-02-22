using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IFC.Examples;
using GeometryGym.Ifc;

namespace IFCExamples
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DirectoryInfo di = Directory.GetParent(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
			di = Directory.GetParent(di.FullName);
			di = Directory.GetParent(di.FullName);
			di = Directory.GetParent(di.FullName);

			string path = Path.Combine(di.FullName, "examples");
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
			new BeamExtruded().GenerateExample(path,ModelView.Ifc4Reference);
			new BeamTessellated().GenerateExample(path, ModelView.Ifc4Reference);
			
			new IndexedColourMap().GenerateExample(path,ModelView.Ifc4DesignTransfer);
			new BeamUnitTestsVaryingProfile().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new BeamUnitTestsVaryingPath().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new BeamUnitTestsVaryingCardinal().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			//todo tapered
			new Slab().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new SlabOpenings().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new Wall().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			//todo wall with Openings
			new Bath().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new BasinAdvancedBrep().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new BasinBrep().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new BasinTessellation().GenerateExample(path, ModelView.Ifc4Reference);
			new ReinforcingBar().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new ReinforcingAssembly().GenerateExample(path, ModelView.Ifc4DesignTransfer);
			new Column().GenerateExample(path, ModelView.Ifc4DesignTransfer);

			//Possible Examples to add
			// IfcBuildingStorey with datums and local placements relative to building
			// IfcProjectLibrary
			// GeoSpatial SetOut of Building
			//
		}
	}
}
