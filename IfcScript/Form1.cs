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
			new BeamExtruded().GenerateExample(path);
			new BeamTessellated().GenerateExample(path);
			new IndexedColourMap().GenerateExample(path);
			new BeamUnitTestsVaryingProfile().GenerateExample(path);
			new BeamUnitTestsVaryingPath().GenerateExample(path);
			new BeamUnitTestsVaryingCardinal().GenerateExample(path);
			//todo tapered
			new Slab().GenerateExample(path);
			new SlabOpenings().GenerateExample(path);
			new Wall().GenerateExample(path);
			//todo wall with Openings
			new BasinAdvancedBrep().GenerateExample(path);
			new BasinBrep().GenerateExample(path);
			new BasinCSG().GenerateExample(path);
			new BasinTessellation().GenerateExample(path);
			new ReinforcingBar().GenerateExample(path);
			new ReinforcingAssembly().GenerateExample(path);
		}
	}
}
