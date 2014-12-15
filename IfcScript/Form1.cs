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
using GGYM.IFC;

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
			new BeamExtruded().GenerateExample(path,ModelView.IFC4Reference);
			new BeamTessellated().GenerateExample(path, ModelView.IFC4Reference);
			
			new IndexedColourMap().GenerateExample(path,ModelView.IFC4DesignTransfer);
			new BeamUnitTestsVaryingProfile().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new BeamUnitTestsVaryingPath().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new BeamUnitTestsVaryingCardinal().GenerateExample(path, ModelView.IFC4DesignTransfer);
			//todo tapered
			new Slab().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new SlabOpenings().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new Wall().GenerateExample(path, ModelView.IFC4DesignTransfer);
			//todo wall with Openings
			new Bath().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new BasinAdvancedBrep().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new BasinBrep().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new BasinTessellation().GenerateExample(path, ModelView.IFC4Reference);
			new ReinforcingBar().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new ReinforcingAssembly().GenerateExample(path, ModelView.IFC4DesignTransfer);
			new Column().GenerateExample(path, ModelView.IFC4DesignTransfer);
		}
	}
}
