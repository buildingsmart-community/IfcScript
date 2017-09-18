using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GeometryGym.Ifc;
 
namespace IFC.Examples
{
	class WindowType : IFCExampleLibrary
	{
		protected override void GenerateLibrary(DatabaseIfc db)
		{
			IfcWindowType windowType = new IfcWindowType(db, "WindowType", IfcWindowTypeEnum.WINDOW);

		}
	}
}
