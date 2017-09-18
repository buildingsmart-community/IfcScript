using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Coord3d = System.Tuple<double, double, double>;
using Coord2d = System.Tuple<double, double>;
using GeometryGym.Ifc;

namespace IFC.Examples
{
	internal class CurveParametersDegrees : CurveParameters
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			base.GenerateInstance(building);
		}
	}
	internal class CurveParametersRadians : CurveParameters
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			base.GenerateInstance(building);
		}
	}
	internal abstract class CurveParameters : IFCExampleInstance
	{
		protected override void GenerateInstance(IfcBuilding building)
		{
			DatabaseIfc database = building.Database;
			double angFactor = database.Factory.Options.AngleUnitsInRadians ? 1 : 180 / Math.PI;
			building.Comments.Add("These profile curves are intentionally expressed in a more complicated manner than possible to test parameterization");
			IfcMaterial material = new IfcMaterial(database, "Steel");

			//-IfcBSplineCurve
			//- IfcCompositeCurve
			//- IfcCompositeCurveSegment
			//- IfcIndexedPolyCurve
			//- IfcTrimmedCurve
			//- IfcPCurve ?
			double root2 = Math.Sqrt(2), root2div2 = Math.Sqrt(2) / 2.0, root3 = Math.Sqrt(3), root3div2 = Math.Sqrt(3)/2.0;

			List<IfcCompositeCurveSegment> segments = new List<IfcCompositeCurveSegment>();
			IfcLine line = new IfcLine(new IfcCartesianPoint(database, -1000, 1000), new IfcVector(new IfcDirection(database, 1, -1), 1000 * Math.Sqrt(2)));
			IfcTrimmedCurve trimmedCurve = new IfcTrimmedCurve(line, new IfcTrimmingSelect((root2-1)/root2), new IfcTrimmingSelect(1 + (1/root2)),true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));
			IfcCircle circle = new IfcCircle(database, 1000);
			trimmedCurve = new IfcTrimmedCurve(circle, new IfcTrimmingSelect(7.0 / 4 * Math.PI * angFactor), new IfcTrimmingSelect(3.0 / 4 * Math.PI * angFactor), true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));

			string name = "SemiCircle";
			IfcArbitraryClosedProfileDef profile = new IfcArbitraryClosedProfileDef(name,new IfcCompositeCurve(segments));
			IfcMaterialProfileSet materialProfileSet = new IfcMaterialProfileSet(name, new IfcMaterialProfile(name,material,profile));
			IfcColumnType columnType = new IfcColumnType(name, materialProfileSet, IfcColumnTypeEnum.COLUMN);
			database.Context.AddDeclared(columnType);
			IfcColumnStandardCase column = new IfcColumnStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.MID), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 0, 0, 0)), 2000) { Name = name, RelatingType = columnType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			columnType.GlobalId = "24mq0gwVr7bgEMXPmo$TrF";
			column.GlobalId = "0RGc8lepr7BRF_EtHrWJ45";
			columnType.ObjectTypeOf.GlobalId = "0devdSRyf3uBEQbSqWTDjo";
			columnType.MaterialSelect.Associates.GlobalId = "1gdVo5TjPETPZlW8HSRupM";
			column.MaterialSelect.Associates.GlobalId = "35z8gDFbb6gvrCOz$24tUJ";

			database.NextObjectRecord = 100;
			circle = new IfcCircle(new IfcAxis2Placement2D(new IfcCartesianPoint(database, 0, 1000)) { RefDirection = new IfcDirection(database,-1,0) },root3*1000);
			segments = new List<IfcCompositeCurveSegment>();
			trimmedCurve = new IfcTrimmedCurve(circle, new IfcTrimmingSelect(Math.PI/3 * angFactor), new IfcTrimmingSelect(2*Math.PI/3 * angFactor),true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));
			circle = new IfcCircle(new IfcAxis2Placement2D(new IfcCartesianPoint(database, -1000*root3div2, -500)) { RefDirection = new IfcDirection(database,0,-1) },root3*1000);
			trimmedCurve = new IfcTrimmedCurve(circle, new IfcTrimmingSelect(Math.PI/2 * angFactor), new IfcTrimmingSelect(5*Math.PI/6 * angFactor),true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));
			circle = new IfcCircle(new IfcAxis2Placement2D(new IfcCartesianPoint(database, 1000*root3div2, -500)) { RefDirection = new IfcDirection(database,0,1) },root3*1000);
			trimmedCurve = new IfcTrimmedCurve(circle, new IfcTrimmingSelect(Math.PI/6 * angFactor), new IfcTrimmingSelect(Math.PI/2 * angFactor),true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));

			name = "CurviLinearTriangle";
			profile = new IfcArbitraryClosedProfileDef(name, new IfcCompositeCurve(segments));
			materialProfileSet = new IfcMaterialProfileSet(name, new IfcMaterialProfile(name,material,profile));
			columnType = new IfcColumnType(name, materialProfileSet, IfcColumnTypeEnum.COLUMN);
			database.Context.AddDeclared(columnType);
			column = new IfcColumnStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.MID), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 2500, 0, 0)), 2000) { Name = name, RelatingType = columnType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			columnType.GlobalId = "3N_qc_BjX1hvEgwfRvVcb_";
			column.GlobalId = "0bmIILAwj8$PLHK1jcmad0";
			columnType.ObjectTypeOf.GlobalId = "3tGocD1N51oOvSvHbJI_qD";
			columnType.MaterialSelect.Associates.GlobalId = "1M5oofzjD3IOM43brXW6wT";
			column.MaterialSelect.Associates.GlobalId = "0gnTzVmkbE9hPsJDxOUOL3";

			database.NextObjectRecord = 150;
			IfcEllipse ellipse = new IfcEllipse(new IfcAxis2Placement2D(database),1000,500);
			segments = new List<IfcCompositeCurveSegment>();
			trimmedCurve = new IfcTrimmedCurve(ellipse, new IfcTrimmingSelect(0), new IfcTrimmingSelect(Math.PI/4 * angFactor), true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));
			double x = root2div2, y = 0.5 * root2div2, len = Math.Sqrt(0.5 + Math.Pow(y, 2));
			line = new IfcLine(new IfcCartesianPoint(database, 0, 0), new IfcVector(new IfcDirection(database,x/len,y/len),1));
			trimmedCurve = new IfcTrimmedCurve(line, new IfcTrimmingSelect(0), new IfcTrimmingSelect(len * 1000), false, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));
			line = new IfcLine(new IfcCartesianPoint(database, 0, 0), new IfcVector(new IfcDirection(database,1,0),1));
			trimmedCurve = new IfcTrimmedCurve(line, new IfcTrimmingSelect(0), new IfcTrimmingSelect(1000), true, IfcTrimmingPreference.PARAMETER);
			segments.Add(new IfcCompositeCurveSegment(IfcTransitionCode.CONTINUOUS, true, trimmedCurve));

			name = "PartialEllipse";
			profile = new IfcArbitraryClosedProfileDef(name, new IfcCompositeCurve(segments));
			materialProfileSet = new IfcMaterialProfileSet(name, new IfcMaterialProfile(name,material,profile));
			columnType = new IfcColumnType(name, materialProfileSet, IfcColumnTypeEnum.COLUMN);
			database.Context.AddDeclared(columnType);
			column = new IfcColumnStandardCase(building, new IfcMaterialProfileSetUsage(materialProfileSet, IfcCardinalPointReference.MID), new IfcAxis2Placement3D(new IfcCartesianPoint(database, 5000, 0, 0)), 2000) { Name = name, RelatingType = columnType };

			//Unique ids assigned to generate constant IfcScript  sample files, remove otherwise
			columnType.GlobalId = "0dtemVu1P2682BcO3CPWAy";
			column.GlobalId = "1JCvykjKH71R7_uck4n6hN";
			columnType.ObjectTypeOf.GlobalId = "0rNx6sqCH2mOt1cWOT6zSU";
			columnType.MaterialSelect.Associates.GlobalId = "2OfhB1Dcz2cAdV$CDh9PHV";
			column.MaterialSelect.Associates.GlobalId = "3bTNkVsf9099xrALHA6WhF";
		}
	}
}
