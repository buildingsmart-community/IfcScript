using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GGYM.IFC;
using Rhino.Geometry;
 
using CoordIndex = System.Tuple<int, int, int>;


namespace IFC.Examples
{
	class BasinAdvancedBrep : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			Basin.GenerateBasin(Basin.ShapeRep.AdvancedBrep, md, building);
		}
	}
	class BasinBrep : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			Basin.GenerateBasin(Basin.ShapeRep.Brep, md, building);
		}
	}

	class BasinTessellation : IFCExampleBase
	{
		protected override void GenerateData(STPModelData md, IfcBuilding building)
		{
			Basin.GenerateBasin(Basin.ShapeRep.Tessellation, md, building);
		}
	}
	internal class Basin
	{
		internal enum ShapeRep { AdvancedBrep, Brep, Tessellation } //,CSG, ClosedShell
		internal static void GenerateBasin(ShapeRep shapeRep, STPModelData md, IfcBuilding building)
		{
			IfcRepresentationMap representationMap = null;
			if (shapeRep == ShapeRep.AdvancedBrep)
			{
				#region advancedBrep
				IfcCartesianPoint cp1 = new IfcCartesianPoint(md, 0.0, 253.099263998677, 0.0);
				IfcCartesianPoint cp2 = new IfcCartesianPoint(md, 0.0, 247.792422124388, -83.9999999999991);
				IfcCartesianPoint cp3 = new IfcCartesianPoint(md, 0.0, 268.843232748677, 0.0);
				IfcCartesianPoint cp4 = new IfcCartesianPoint(md, 0.0, 247.792422124388, -93.9999999999991);
				IfcVertexPoint vp1 = new IfcVertexPoint(cp1), vp2 = new IfcVertexPoint(cp2), vp3 = new IfcVertexPoint(cp3),vp4 = new IfcVertexPoint(cp4);

				IfcEdgeCurve edgeCurve1 = new IfcEdgeCurve(vp1, vp2, new IfcPolyline(cp1, cp2), true); //140
				List<Point3d> points3d = new List<Point3d>() { new Point3d(239.758213537139, 192.193559404919, -83.9999999999991), new Point3d(0.0, 275.591853484122, -83.9999999999991), new Point3d(-239.75821353295, 192.193559404918, -83.9999999999991), new Point3d(0.0, -108.13323051355, -83.9999999999991), new Point3d(239.758213537139, 192.193559404919, -83.9999999999991), new Point3d(0.0, 275.591853484122, -83.9999999999991), new Point3d(-239.75821353295, 192.193559404918, -83.9999999999991) };
				IfcBSplineCurveWithKnots nurbsCurve = new IfcBSplineCurveWithKnots(md, 3, points3d, IfcBSplineCurveForm.UNSPECIFIED, IfcLogicalEnum.TRUE, IfcLogicalEnum.TRUE, new List<int>() { 1,1, 1, 1, 1, 1, 1, 1, 1, 1,1 }, new List<double>() { -7.0, -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, 0.0, 1.0, 2.0,3.0 }, IfcKnotType.UNSPECIFIED);
				IfcEdgeCurve edgeCurve2 = new IfcEdgeCurve(vp2, vp2, nurbsCurve, true); //149
				List<Point2d> points2d = new List<Point2d>() { new Point2d(-437.751000004175, 168.150654933496), new Point2d(0.0, 295.573568531267), new Point2d(437.751000006541, 168.150654933498), new Point2d(0.0, -290.713822148428), new Point2d(-437.751000004175, 168.150654933496), new Point2d(0.0, 295.573568531267), new Point2d(437.751000006541, 168.150654933498) };
				nurbsCurve = new IfcBSplineCurveWithKnots(md, 3, points2d, IfcBSplineCurveForm.UNSPECIFIED, IfcLogicalEnum.TRUE, IfcLogicalEnum.TRUE, new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1}, new List<double>() { -7.0, -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, 0.0, 1.0, 2.0, 3.0 }, IfcKnotType.UNSPECIFIED);
				IfcEdgeCurve edgeCurve3 = new IfcEdgeCurve(vp1, vp1, nurbsCurve, true); //158
				IfcEdgeCurve edgeCurve4 = new IfcEdgeCurve(vp3, vp4, new IfcPolyline(cp3, cp4), true); //162
				points3d = new List<Point3d>() { new Point3d(-239.758213535044, 192.193559378247, -93.9999999999991), new Point3d(0.0, 275.591853497458, -93.9999999999991), new Point3d(239.758213535045, 192.193559378248, -93.9999999999991), new Point3d(0.0, -108.133230500215, -93.9999999999991), new Point3d(-239.758213535044, 192.193559378247, -93.9999999999991), new Point3d(0.0, 275.591853497458, -93.9999999999991), new Point3d(239.758213535045, 192.193559378248, -93.9999999999991) };
				nurbsCurve = new IfcBSplineCurveWithKnots(md, 3, points3d, IfcBSplineCurveForm.UNSPECIFIED, IfcLogicalEnum.TRUE, IfcLogicalEnum.TRUE, new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new List<double>() { -7.0, -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, 0.0, 1.0, 2.0, 3.0 }, IfcKnotType.UNSPECIFIED);
				IfcEdgeCurve edgeCurve5 = new IfcEdgeCurve(vp4, vp4, nurbsCurve, true); //171
				points2d = new List<Point2d>() { new Point2d(457.685108750143, 177.051077752302), new Point2d(0.0, 314.739310246865), new Point2d(-457.685108750141, 177.051077752299), new Point2d(0.0, -318.77998625438), new Point2d(457.685108750143, 177.051077752302), new Point2d(0.0, 314.739310246865), new Point2d(-457.685108750141, 177.051077752299) };
				nurbsCurve = new IfcBSplineCurveWithKnots(md, 3, points2d, IfcBSplineCurveForm.UNSPECIFIED, IfcLogicalEnum.TRUE, IfcLogicalEnum.TRUE, new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new List<double>() { -7.0, -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, 0.0, 1.0, 2.0, 3.0 }, IfcKnotType.UNSPECIFIED);
				IfcEdgeCurve edgeCurve6 = new IfcEdgeCurve(vp3, vp3, nurbsCurve, true); //181

				List<IfcOrientedEdge> orientedEdges = new List<IfcOrientedEdge>();
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve1, true));
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve2, true));
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve1, false));
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve3, true));
				IfcFaceOuterBound faceOuterBound = new IfcFaceOuterBound(new IfcEdgeLoop(orientedEdges), true);
				List<List<Point3d>> surfaceControlPoints = new List<List<Point3d>>();
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(437.751000006541, 168.150654933498, 0.0), new Point3d(0.0, 295.573568531267, 0.0), new Point3d(-437.751000004175, 168.150654933496, 0.0), new Point3d(0.0, -290.713822148428, 0.0), new Point3d(437.751000006541, 168.150654933498, 0.0), new Point3d(0.0, 295.573568531267, 0.0), new Point3d(-437.751000004175, 168.150654933496, 0.0) });
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(371.75340451674, 176.164956423972, -27.9999999999997), new Point3d(0.0, 288.912996848885, -27.9999999999997), new Point3d(-371.753404513767, 176.16495642397, -27.9999999999997), new Point3d(0.0, -229.853624936802, -27.9999999999997), new Point3d(371.75340451674, 176.164956423972, -27.9999999999997), new Point3d(0.0, 288.912996848885, -27.9999999999997), new Point3d(-371.753404513767, 176.16495642397, -27.9999999999997) });
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(305.75580902694, 184.179257914445, -55.9999999999994), new Point3d(0.0, 282.252425166504, -55.9999999999994), new Point3d(-305.755809023358, 184.179257914444, -55.9999999999994), new Point3d(0.0, -168.993427725176, -55.9999999999994), new Point3d(305.75580902694, 184.179257914445, -55.9999999999994), new Point3d(0.0, 282.252425166504, -55.9999999999994), new Point3d(-305.755809023358, 184.179257914444, -55.9999999999994) });
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(239.758213537139, 192.193559404919, -83.9999999999991), new Point3d(0.0, 275.591853484122, -83.9999999999991), new Point3d(-239.75821353295, 192.193559404918, -83.9999999999991), new Point3d(0.0, -108.13323051355, -83.9999999999991), new Point3d(239.758213537139, 192.193559404919, -83.9999999999991), new Point3d(0.0, 275.591853484122, -83.9999999999991), new Point3d(-239.75821353295, 192.193559404918, -83.9999999999991) });
				List<int> uMults = new List<int>() { 4, 4 }, vMults = new List<int>() {1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1 };
				List<double> uKnots = new List<double>() { 0.0, 14.7110308353668 };
				List<double> vKnots = new List<double>() { -7, -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, 0.0, 1.0, 2.0,3.0 };
				IfcBSplineSurfaceWithKnots nurbsSurface = new IfcBSplineSurfaceWithKnots(md, 3, 3, surfaceControlPoints, IfcBSplineSurfaceForm.UNSPECIFIED, IfcLogicalEnum.FALSE, IfcLogicalEnum.TRUE, IfcLogicalEnum.FALSE, uMults, vMults, uKnots, vKnots, IfcKnotType.UNSPECIFIED);
				IfcAdvancedFace face1 = new IfcAdvancedFace(faceOuterBound, nurbsSurface, false);

				orientedEdges = new List<IfcOrientedEdge>();
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve4, true));
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve5, true));
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve4, false));
				orientedEdges.Add(new IfcOrientedEdge(edgeCurve6, true));
				faceOuterBound = new IfcFaceOuterBound(new IfcEdgeLoop(orientedEdges), true);
				surfaceControlPoints = new List<List<Point3d>>();
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(-457.685108750141, 177.051077752299, 0.0), new Point3d(0.0, 314.739310246865, 0.0), new Point3d(457.685108750143, 177.051077752302, 0.0), new Point3d(0.0, -318.77998625438, 0.0), new Point3d( -457.685108750141, 177.051077752299, 0.0), new Point3d(0.0, 314.739310246865, 0.0), new Point3d(457.685108750143, 177.051077752302, 0.0) });
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(-385.042810345109, 182.098571627615, -31.333333333333), new Point3d(0.0, 301.690157997063, -31.333333333333), new Point3d(385.04281034511, 182.098571627617, -31.333333333333), new Point3d(0.0, -248.564401002992, -31.333333333333), new Point3d(-385.042810345109, 182.098571627615, -31.333333333333), new Point3d(0.0, 301.690157997063, -31.333333333333), new Point3d(385.04281034511, 182.098571627617, -31.333333333333) });
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(-312.400511940076, 187.146065502931, -62.666666666666), new Point3d(0.0, 288.64100574726, -62.666666666666), new Point3d(312.400511940078, 187.146065502933, -62.666666666666), new Point3d(0.0, -178.348815751603, -62.6666666666661), new Point3d(-312.400511940076, 187.146065502931, -62.666666666666), new Point3d(0.0, 288.64100574726, -62.666666666666), new Point3d(312.400511940078, 187.146065502933, -62.666666666666) });
				surfaceControlPoints.Add(new List<Point3d>() { new Point3d(-239.758213535044, 192.193559378247, -93.9999999999991), new Point3d(0.0, 275.591853497458, -93.9999999999991), new Point3d(239.758213535045, 192.193559378248, -93.9999999999991), new Point3d(0.0, -108.133230500215, -93.9999999999991), new Point3d(-239.758213535044, 192.193559378247, -93.9999999999991), new Point3d(0.0, 275.591853497458, -93.9999999999991), new Point3d(239.758213535045, 192.193559378248, -93.9999999999991) });
				uMults = new List<int>() { 4, 4 };
				vMults = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1 };
				uKnots = new List<double>() { 0.0, 15.4213505620632 };
				vKnots = new List<double>() { -3.0, -2.0, -1.0, 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0 };
				nurbsSurface = new IfcBSplineSurfaceWithKnots(md, 3, 3, surfaceControlPoints, IfcBSplineSurfaceForm.UNSPECIFIED, IfcLogicalEnum.FALSE, IfcLogicalEnum.TRUE, IfcLogicalEnum.FALSE, uMults, vMults, uKnots, vKnots, IfcKnotType.UNSPECIFIED);
				IfcAdvancedFace face2 = new IfcAdvancedFace(faceOuterBound, nurbsSurface, false);
				
				IfcOrientedEdge orientedEdge = new IfcOrientedEdge(edgeCurve2, false);
				faceOuterBound = new IfcFaceOuterBound(new IfcEdgeLoop(orientedEdge), true);
				IfcPlane plane = new IfcPlane(new IfcAxis2Placement3D(cp2, null,null));
				IfcAdvancedFace face3 = new IfcAdvancedFace(faceOuterBound, plane, true);
			
				orientedEdge = new IfcOrientedEdge(edgeCurve5, true);
				faceOuterBound = new IfcFaceOuterBound(new IfcEdgeLoop(orientedEdge),true);
				plane = new IfcPlane(new IfcAxis2Placement3D(cp4, null, null));
				IfcAdvancedFace face4 = new IfcAdvancedFace(faceOuterBound, plane, false);

				orientedEdge = new IfcOrientedEdge(edgeCurve6, false);
				faceOuterBound = new IfcFaceOuterBound(new IfcEdgeLoop(orientedEdge),true);
				orientedEdge = new IfcOrientedEdge(edgeCurve3, false);
				IfcFaceBound facebound = new IfcFaceBound(new IfcEdgeLoop(orientedEdge), true);
				plane = new IfcPlane(new IfcAxis2Placement3D(cp1, null, null));
				IfcAdvancedFace face5 = new IfcAdvancedFace(faceOuterBound,facebound, plane, true);

				IfcAdvancedBrep advancedBrep = new IfcAdvancedBrep(new List<IfcAdvancedFace>() { face1, face2, face3, face4, face5 });
				representationMap = new IfcRepresentationMap(advancedBrep);
				#endregion
			}
			else if (shapeRep == ShapeRep.Brep)
			{
				#region facetedBrep
				List<IfcCartesianPoint> cps = new List<IfcCartesianPoint>();

				List<IfcFace> faces = new List<IfcFace>();

				cps.Add(new IfcCartesianPoint(md, 8.5265128291212E-11, 268843.232748677, 0)); // Outer
				cps.Add(new IfcCartesianPoint(md, -40656.5545240771, 267741.230885222, 0));
				cps.Add(new IfcCartesianPoint(md, -81184.4472420703, 264337.146165631, 0));
				cps.Add(new IfcCartesianPoint(md, -121414.523219646, 258379.966740374, 0));
				cps.Add(new IfcCartesianPoint(md, -161084.488243579, 249439.282575701, 0));
				cps.Add(new IfcCartesianPoint(md, -199732.402407963, 236816.640911423, 0));
				cps.Add(new IfcCartesianPoint(md, -236448.287386336, 219398.404238099, 0));
				cps.Add(new IfcCartesianPoint(md, -269269.780991348, 195519.340118616, 0));
				cps.Add(new IfcCartesianPoint(md, -294036.921021401, 163504.056083023, 0));
				cps.Add(new IfcCartesianPoint(md, -304879.990220018, 124598.157305706, 0));
				cps.Add(new IfcCartesianPoint(md, -300744.331060112, 84299.1194842604, 0));
				cps.Add(new IfcCartesianPoint(md, -286871.978591033, 46128.0924370721, 0));
				cps.Add(new IfcCartesianPoint(md, -267003.97578777, 10670.5825582408, 0));
				cps.Add(new IfcCartesianPoint(md, -242914.17242145, -22078.9599923818, 0));
				cps.Add(new IfcCartesianPoint(md, -215497.37582355, -52103.8389186614, 0));
				cps.Add(new IfcCartesianPoint(md, -185233.564258487, -79257.7607647334, 0));
				cps.Add(new IfcCartesianPoint(md, -152394.753430662, -103231.127678777, 0));
				cps.Add(new IfcCartesianPoint(md, -117162.752124351, -123516.605031891, 0));
				cps.Add(new IfcCartesianPoint(md, -79732.7064970238, -139366.465926728, 0));
				cps.Add(new IfcCartesianPoint(md, -40449.4524879168, -149766.330003707, 0));
				cps.Add(new IfcCartesianPoint(md, -8.5265128291212E-11, -153502.96491882, 0));
				cps.Add(new IfcCartesianPoint(md, 40449.4508793845, -149766.330296203, 0));
				cps.Add(new IfcCartesianPoint(md, 79732.7043771191, -139366.466661145, 0));
				cps.Add(new IfcCartesianPoint(md, 117162.756918928, -123516.602630764, 0));
				cps.Add(new IfcCartesianPoint(md, 152394.751766558, -103231.128764915, 0));
				cps.Add(new IfcCartesianPoint(md, 185233.56996992, -79257.7561301781, 0));
				cps.Add(new IfcCartesianPoint(md, 215497.373929206, -52103.840795184, 0));
				cps.Add(new IfcCartesianPoint(md, 242914.167878755, -22078.965508489, 0));
				cps.Add(new IfcCartesianPoint(md, 267003.976250216, 10670.5832692101, 0));
				cps.Add(new IfcCartesianPoint(md, 286871.977954697, 46128.0910808867, 0));
				cps.Add(new IfcCartesianPoint(md, 300744.329678325, 84299.1139637225, 0));
				cps.Add(new IfcCartesianPoint(md, 304879.990112863, 124598.158883845, 0));
				cps.Add(new IfcCartesianPoint(md, 294036.920669161, 163504.056764251, 0));
				cps.Add(new IfcCartesianPoint(md, 269269.779973882, 195519.341068674, 0));
				cps.Add(new IfcCartesianPoint(md, 236448.28639794, 219398.404808304, 0));
				cps.Add(new IfcCartesianPoint(md, 199732.40148445, 236816.641271916, 0));
				cps.Add(new IfcCartesianPoint(md, 161084.487568103, 249439.282758701, 0));
				cps.Add(new IfcCartesianPoint(md, 121414.531991753, 258379.965126806, 0));
				cps.Add(new IfcCartesianPoint(md, 81184.4476691385, 264337.146116746, 0));
				cps.Add(new IfcCartesianPoint(md, 40656.5563813857, 267741.230783552, 0)); 

				IfcPolyloop polyloop = new IfcPolyloop(cps.GetRange(0,40));
				IfcFaceOuterBound faceOuterBound = new IfcFaceOuterBound(polyloop,true);

				cps.Add(new IfcCartesianPoint(md, -2.36369146477955E-06, 253099.263998677, 0)); //40  inner
				cps.Add(new IfcCartesianPoint(md, 38427.4900386849, 252103.548079205, 0));
				cps.Add(new IfcCartesianPoint(md, 76743.9433401587, 249028.666176807, 0));
				cps.Add(new IfcCartesianPoint(md, 114803.789550381, 243649.797844599, 0));
				cps.Add(new IfcCartesianPoint(md, 152382.048016624, 235580.438211911, 0));
				cps.Add(new IfcCartesianPoint(md, 189083.091558087, 224189.69850467, 0));
				cps.Add(new IfcCartesianPoint(md, 224125.137689733, 208456.936531179, 0));
				cps.Add(new IfcCartesianPoint(md, 255793.363304913, 186795.125569967, 0));
				cps.Add(new IfcCartesianPoint(md, 280260.264776878, 157383.008003324, 0));
				cps.Add(new IfcCartesianPoint(md, 291499.069651162, 120929.075349148, 0));
				cps.Add(new IfcCartesianPoint(md, 287781.794186053, 82843.9932251812, 0));
				cps.Add(new IfcCartesianPoint(md, 274333.349777552, 46897.6139888769, 0));
				cps.Add(new IfcCartesianPoint(md, 255041.935323226, 13680.4471549583, 0));
				cps.Add(new IfcCartesianPoint(md, 231718.321168942, -16855.0204261573, 0));
				cps.Add(new IfcCartesianPoint(md, 205264.90842152, -44728.71539005, 0));
				cps.Add(new IfcCartesianPoint(md, 176167.01831263, -69830.7253653909, 0));
				cps.Add(new IfcCartesianPoint(md, 144705.875892003, -91896.6701176456, 0));
				cps.Add(new IfcCartesianPoint(md, 111075.533913924, -110483.174825384, 0));
				cps.Add(new IfcCartesianPoint(md, 75479.2575648176, -124936.88849428, 0));
				cps.Add(new IfcCartesianPoint(md, 38248.0241625981, -134377.886037238, 0));
				cps.Add(new IfcCartesianPoint(md, -1.27897692436818E-10, -137758.996454453, 0));
				cps.Add(new IfcCartesianPoint(md, -38248.0094096726, -134377.888604729, 0));
				cps.Add(new IfcCartesianPoint(md, -75479.2556281902, -124936.889137129, 0));
				cps.Add(new IfcCartesianPoint(md, -111075.539062433, -110483.172351871, 0));
				cps.Add(new IfcCartesianPoint(md, -144705.874376312, -91896.6710674264, 0));
				cps.Add(new IfcCartesianPoint(md, -176167.011118929, -69830.7309751331, 0));
				cps.Add(new IfcCartesianPoint(md, -205264.906834, -44728.7169020584, 0));
				cps.Add(new IfcCartesianPoint(md, -231718.318258428, -16855.023827089, 0));
				cps.Add(new IfcCartesianPoint(md, -255041.934669669, 13680.4461875579, 0));
				cps.Add(new IfcCartesianPoint(md, -274333.348315742, 46897.6109786559, 0));
				cps.Add(new IfcCartesianPoint(md, -287781.793945095, 82843.992280873, 0));
				cps.Add(new IfcCartesianPoint(md, -291499.069558299, 120929.076449465, 0));
				cps.Add(new IfcCartesianPoint(md, -280260.264225365, 157383.008985549, 0));
				cps.Add(new IfcCartesianPoint(md, -255793.362494351, 186795.126279187, 0));
				cps.Add(new IfcCartesianPoint(md, -224125.13653713, 208456.93715988, 0));
				cps.Add(new IfcCartesianPoint(md, -189083.091723532, 224189.698444526, 0));
				cps.Add(new IfcCartesianPoint(md, -152382.036267776, 235580.441242109, 0));
				cps.Add(new IfcCartesianPoint(md, -114803.784949771, 243649.798652405, 0));
				cps.Add(new IfcCartesianPoint(md, -76743.9536078398, 249028.665054834, 0));
				cps.Add(new IfcCartesianPoint(md, -38427.4901357192, 252103.548074371, 0));
				
				polyloop = new IfcPolyloop(cps.GetRange(40,40));
				IfcFaceBound faceBound = new IfcFaceBound(polyloop,true);
				faces.Add(new IfcFace(faceOuterBound,faceBound));

				cps.Add(new IfcCartesianPoint(md, 7.105427357601E-11, 247792.422124388, -93999.9999999991)); //80 base
				cps.Add(new IfcCartesianPoint(md, 22543.570345102, 247043.703986819, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 44979.6137172465, 244728.140008744, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 67165.0892668505, 240670.010701811, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 88875.8496727837, 234574.313720423, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 109718.194276454, 225983.554212619, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 128945.156504883, 214242.543022066, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 145131.083023098, 198617.02521984, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 156028.264873931, 178980.157903609, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 159834.545208795, 156846.549510419, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 157205.129966729, 134492.794130245, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 150333.031384556, 113029.267864972, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 140585.417581734, 92698.690766237, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 128649.651812238, 73566.1983153641, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 114880.81683599, 55705.9230027226, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 99457.2081299554, 39253.7668954707, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 82455.7792492348, 24440.1234195301, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 63901.5117223512, 11630.5834057239, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 43825.812852227, 1381.78464649553, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 22374.1376569279, -5505.26474040419, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 1.4210854715202E-11, -8024.30054072738, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -22374.1369000302, -5505.26490804053, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -43825.8109334306, 1381.78384202005, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -63901.5107453348, 11630.5828171828, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -82455.7778416754, 24440.1223202192, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -99457.2071589388, 39253.7659566927, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -114880.815789293, 55705.9217719804, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -128649.650827451, 73566.1969013759, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -140585.419271271, 92698.6938201311, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -150333.030863305, 113029.266577227, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -157205.128832971, 134492.789207233, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -159834.545214161, 156846.549002985, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -156028.266010736, 178980.154672375, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -145131.082712872, 198617.025613766, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -128945.159904117, 214242.540461469, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -109718.192999937, 225983.554847043, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -88875.8510792069, 234574.313243064, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -67165.08882249, 240670.010803143, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -44979.6135673833, 244728.140029868, -93999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -22543.5788308204, 247043.703417137, -93999.9999999991));

				polyloop = new IfcPolyloop(cps.GetRange(80, 40));
				faceOuterBound = new IfcFaceOuterBound(polyloop, true);
				faces.Add(new IfcFace(faceOuterBound));

				cps.Add(new IfcCartesianPoint(md, -4.18794598999739E-06, 247792.422124388, -83999.9999999991)); //120 Bowl face
				cps.Add(new IfcCartesianPoint(md, -22543.5703494529, 247043.703987136, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -44979.6137218369, 244728.140009905, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -67165.0892718133, 240670.010704167, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -88875.8496782756, 234574.313724111, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -109718.194282579, 225983.554217461, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -128945.156511477, 214242.54302742, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -145131.083029256, 198617.025224586, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -156028.264877734, 178980.157906939, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -159834.545208922, 156846.549512965, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -157205.129964107, 134492.794132934, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -150333.031380544, 113029.267867934, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -140585.417577166, 92698.6907692923, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -128649.651807611, 73566.1983182769, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -114880.81683159, 55705.9230052684, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -99457.2081259275, 39253.7668974612, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -82455.77924561, 24440.1234208308, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -63901.5117190564, 11630.5834062858, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -43825.8128490947, 1381.78464641787, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -22374.137653742, -5505.26474077583, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, -5.6843418860808E-11, -8024.30054072741, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 22374.136903413, -5505.26490696816, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 43825.8109365215, 1381.78384447853, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 63901.5107478721, 11630.5828210529, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 82455.7778435065, 24440.1223253757, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 99457.2071600111, 39253.7659629489, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 114880.815789634, 55705.9217791287, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 128649.65082716, 73566.1969092022, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 140585.419270523, 92698.6938284213, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 150333.030862371, 113029.266585776, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 157205.128832256, 134492.789215875, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 159834.545214197, 156846.549011699, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 156028.266011557, 178980.154681359, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 145131.082713423, 198617.025622727, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 128945.159903547, 214242.540469453, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 109718.192998164, 225983.554853335, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 88875.8510764901, 234574.313247461, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 67165.0888191183, 240670.01080579, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 44979.6135636075, 244728.140031113, -83999.9999999991));
				cps.Add(new IfcCartesianPoint(md, 22543.5788267922, 247043.703417465, -83999.9999999991));

				polyloop = new IfcPolyloop(cps.GetRange(120, 40));
				faceOuterBound = new IfcFaceOuterBound(polyloop, true);
				faces.Add(new IfcFace(faceOuterBound));

				for (int icounter = 0; icounter < 40; icounter++)
				{
					polyloop = new IfcPolyloop(cps[icounter == 39 ? 0 : icounter + 1], cps[icounter], cps[icounter == 0 ? 80 : 120 - icounter]);
					faceOuterBound = new IfcFaceOuterBound(polyloop, true);
					faces.Add(new IfcFace(faceOuterBound));
					polyloop = new IfcPolyloop(cps[80 + (icounter == 39 ? 0 : icounter + 1)], cps[80 + icounter], cps[icounter == 0 ? 0 : 40 - icounter]);
					faceOuterBound = new IfcFaceOuterBound(polyloop, true);
					faces.Add(new IfcFace(faceOuterBound));

					polyloop = new IfcPolyloop(cps[40+( icounter == 39 ? 0 : icounter + 1)], cps[40+icounter], cps[icounter == 0 ? 120 : 160 - icounter]);
					faceOuterBound = new IfcFaceOuterBound(polyloop, true);
					faces.Add(new IfcFace(faceOuterBound));
					polyloop = new IfcPolyloop(cps[120 + (icounter == 39 ? 0 : icounter + 1)], cps[120 + icounter], cps[icounter == 0 ? 40 : 80 - icounter]);
					faceOuterBound = new IfcFaceOuterBound(polyloop, true);
					faces.Add(new IfcFace(faceOuterBound));
				}
				 
				IfcClosedShell closedShell = new IfcClosedShell(faces);
				IfcFacetedBrep facetedBrep = new IfcFacetedBrep(closedShell);
				representationMap = new	IfcRepresentationMap(facetedBrep);
				#endregion
			}
			else if (shapeRep == ShapeRep.Tessellation)
			{
				List<Point3d> points = new List<Point3d>() { new Point3d(-300.0, 150.0, 0.0), new Point3d(-260.012578, 202.771984, 0.0), new Point3d(-200.897703, 235.427328, 0.0), new Point3d(-135.653172, 254.960516, 0.0), new Point3d(-68.351281, 265.485063, 0.0), new Point3d(2.288734, 268.839531, 0.0), new Point3d(72.81782, 265.023844, 0.0), new Point3d(139.786906, 254.038063, 0.0), new Point3d(201.174906, 235.317031, 0.0), new Point3d(259.220938, 203.387031, 0.0), new Point3d(300.0, 150.0, 0.0), new Point3d(301.12175, 84.866148, 0.0), new Point3d(274.727594, 21.433672, 0.0), new Point3d(235.605922, -32.723826, 0.0), new Point3d(186.088641, -80.939688, 0.0), new Point3d(130.136258, -119.016594, 0.0), new Point3d(67.084977, -144.523266, 0.0), new Point3d(1.477218, -153.498641, 0.0), new Point3d(-64.392137, -145.234375, 0.0), new Point3d(-128.935, -119.668008, 0.0), new Point3d(-185.4365, -81.474469, 0.0), new Point3d(-235.751609, -32.555805, 0.0), new Point3d(-275.439625, 22.660475, 0.0), new Point3d(-301.2465, 85.400219, 0.0), new Point3d(0.0, 253.099266, 0.0), new Point3d(-65.777992, 249.952375, 0.0), new Point3d(-128.508695, 240.511688, 0.0), new Point3d(-189.983266, 222.998141, 0.0), new Point3d(-246.840234, 193.330969, 0.0), new Point3d(-286.93375, 143.116359, 0.0), new Point3d(-288.338563, 84.231891, 0.0), new Point3d(-263.388344, 25.178932, 0.0), new Point3d(-224.986906, -26.382564, 0.0), new Point3d(-176.642109, -71.667547, 0.0), new Point3d(-122.550633, -106.846461, 0.0), new Point3d(-61.391031, -130.155953, 0.0), new Point3d(1.00923, -137.756953, 0.0), new Point3d(63.202145, -129.69757, 0.0), new Point3d(123.138398, -106.540977, 0.0), new Point3d(176.955734, -71.42018, 0.0), new Point3d(224.650078, -26.756678, 0.0), new Point3d(262.387781, 23.516443, 0.0), new Point3d(288.070906, 83.103938, 0.0), new Point3d(286.93375, 143.116359, 0.0), new Point3d(248.344641, 192.212875, 0.0), new Point3d(191.622094, 222.376281, 0.0), new Point3d(129.659992, 240.269531, 0.0), new Point3d(64.742059, 250.052203, 0.0), new Point3d(-157.154922, 175.808609, -94.0), new Point3d(-136.207516, 207.772813, -94.0), new Point3d(-105.240203, 227.552281, -94.0), new Point3d(-71.061875, 239.383609, -94.0), new Point3d(-35.805801, 245.758375, -94.0), new Point3d(1.198953, 247.790172, -94.0), new Point3d(38.145594, 245.479016, -94.0), new Point3d(73.227336, 238.824875, -94.0), new Point3d(105.385414, 227.485469, -94.0), new Point3d(135.792813, 208.145344, -94.0), new Point3d(157.154922, 175.808609, -94.0), new Point3d(157.742547, 136.356797, -94.0), new Point3d(143.915969, 97.9355, -94.0), new Point3d(123.422102, 65.13209, -94.0), new Point3d(97.482477, 35.927559, -94.0), new Point3d(68.171844, 12.864227, -94.0), new Point3d(35.142449, -2.585266, -94.0), new Point3d(0.77384, -8.021682, -94.0), new Point3d(-33.731801, -3.015985, -94.0), new Point3d(-67.542563, 12.469661, -94.0), new Point3d(-97.140859, 35.603637, -94.0), new Point3d(-123.498414, 65.233859, -94.0), new Point3d(-144.288969, 98.678578, -94.0), new Point3d(-157.807906, 136.680281, -94.0), new Point3d(-300.0, 150.0, 0.0), new Point3d(-228.577453, 162.904313, -47.0), new Point3d(-157.154922, 175.808609, -94.0), new Point3d(-260.012578, 202.771984, 0.0), new Point3d(-136.207516, 207.772813, -94.0), new Point3d(-200.897703, 235.427328, 0.0), new Point3d(-105.240203, 227.552281, -94.0), new Point3d(-135.653172, 254.960516, 0.0), new Point3d(-71.061875, 239.383609, -94.0), new Point3d(-68.351281, 265.485063, 0.0), new Point3d(-35.805801, 245.758375, -94.0), new Point3d(2.288734, 268.839531, 0.0), new Point3d(1.198953, 247.790172, -94.0), new Point3d(72.81782, 265.023844, 0.0), new Point3d(38.145594, 245.479016, -94.0), new Point3d(139.786906, 254.038063, 0.0), new Point3d(73.227336, 238.824875, -94.0), new Point3d(201.174906, 235.317031, 0.0), new Point3d(105.385414, 227.485469, -94.0), new Point3d(259.220938, 203.387031, 0.0), new Point3d(135.792813, 208.145344, -94.0), new Point3d(300.0, 150.0, 0.0), new Point3d(157.154922, 175.808609, -94.0), new Point3d(301.12175, 84.866148, 0.0), new Point3d(157.742547, 136.356797, -94.0), new Point3d(274.727594, 21.433672, 0.0), new Point3d(143.915969, 97.9355, -94.0), new Point3d(235.605922, -32.723826, 0.0), new Point3d(123.422102, 65.13209, -94.0), new Point3d(186.088641, -80.939688, 0.0), new Point3d(97.482477, 35.927559, -94.0), new Point3d(130.136258, -119.016594, 0.0), new Point3d(68.171844, 12.864227, -94.0), new Point3d(67.084977, -144.523266, 0.0), new Point3d(35.142449, -2.585266, -94.0), new Point3d(1.477218, -153.498641, 0.0), new Point3d(0.77384, -8.021682, -94.0), new Point3d(-64.392137, -145.234375, 0.0), new Point3d(-33.731801, -3.015985, -94.0), new Point3d(-128.935, -119.668008, 0.0), new Point3d(-67.542563, 12.469661, -94.0), new Point3d(-185.4365, -81.474469, 0.0), new Point3d(-97.140859, 35.603637, -94.0), new Point3d(-235.751609, -32.555805, 0.0), new Point3d(-123.498414, 65.233859, -94.0), new Point3d(-275.439625, 22.660475, 0.0), new Point3d(-144.288969, 98.678578, -94.0), new Point3d(-301.2465, 85.400219, 0.0), new Point3d(-157.807906, 136.680281, -94.0), new Point3d(-300.0, 150.0, 0.0), new Point3d(-228.577453, 162.904313, -47.0), new Point3d(-157.154922, 175.808609, -94.0), new Point3d(-103.357523, 247.172063, -47.0), new Point3d(-153.068953, 231.489813, -47.0), new Point3d(-52.078543, 255.621719, -47.0), new Point3d(1.743843, 258.314844, -47.0), new Point3d(55.481707, 255.251438, -47.0), new Point3d(106.507117, 246.431469, -47.0), new Point3d(197.506875, 205.766188, -47.0), new Point3d(153.280156, 231.40125, -47.0), new Point3d(228.577453, 162.904313, -47.0), new Point3d(229.432141, 110.611469, -47.0), new Point3d(209.321781, 59.684586, -47.0), new Point3d(179.514016, 16.204132, -47.0), new Point3d(141.785563, -22.506064, -47.0), new Point3d(51.113715, -73.554266, -47.0), new Point3d(99.154047, -53.076184, -47.0), new Point3d(1.125529, -80.760164, -47.0), new Point3d(-49.061969, -74.12518, -47.0), new Point3d(-98.238781, -53.599176, -47.0), new Point3d(-141.288688, -22.935416, -47.0), new Point3d(-209.864297, 60.669523, -47.0), new Point3d(-179.625016, 16.339027, -47.0), new Point3d(-229.527203, 111.04025, -47.0), new Point3d(0.0, 247.792422, -84.0), new Point3d(35.45952, 245.798125, -84.0), new Point3d(71.015367, 239.395359, -84.0), new Point3d(104.952289, 227.684234, -84.0), new Point3d(136.019484, 207.942281, -84.0), new Point3d(157.154922, 175.808609, -84.0), new Point3d(157.77775, 136.530484, -84.0), new Point3d(143.710984, 97.530469, -84.0), new Point3d(123.041867, 64.626715, -84.0), new Point3d(96.919461, 35.394453, -84.0), new Point3d(67.443461, 12.407895, -84.0), new Point3d(34.616102, -2.748099, -84.0), new Point3d(0.55276, -8.022964, -84.0), new Point3d(-33.624148, -3.048111, -84.0), new Point3d(-67.121539, 12.207951, -84.0), new Point3d(-96.747688, 35.232555, -84.0), new Point3d(-123.226352, 64.87157, -84.0), new Point3d(-144.259, 98.61857, -84.0), new Point3d(-157.924344, 137.268734, -84.0), new Point3d(-157.154922, 175.808609, -84.0), new Point3d(-135.195516, 208.674078, -84.0), new Point3d(-104.054703, 228.091234, -84.0), new Point3d(-70.384797, 239.553859, -84.0), new Point3d(-36.026906, 245.732781, -84.0), new Point3d(0.0, 247.792422, -84.0), new Point3d(0.0, 253.099266, 0.0), new Point3d(64.742059, 250.052203, 0.0), new Point3d(129.659992, 240.269531, 0.0), new Point3d(191.622094, 222.376281, 0.0), new Point3d(248.344641, 192.212875, 0.0), new Point3d(286.93375, 143.116359, 0.0), new Point3d(288.070906, 83.103938, 0.0), new Point3d(262.387781, 23.516443, 0.0), new Point3d(224.650078, -26.756678, 0.0), new Point3d(176.955734, -71.42018, 0.0), new Point3d(123.138398, -106.540977, 0.0), new Point3d(63.202145, -129.69757, 0.0), new Point3d(1.00923, -137.756953, 0.0), new Point3d(-61.391031, -130.155953, 0.0), new Point3d(-122.550633, -106.846461, 0.0), new Point3d(-176.642109, -71.667547, 0.0), new Point3d(-224.986906, -26.382564, 0.0), new Point3d(-263.388344, 25.178932, 0.0), new Point3d(-288.338563, 84.231891, 0.0), new Point3d(-286.93375, 143.116359, 0.0), new Point3d(-246.840234, 193.330969, 0.0), new Point3d(-189.983266, 222.998141, 0.0), new Point3d(-128.508695, 240.511688, 0.0), new Point3d(-65.777992, 249.952375, 0.0), new Point3d(0.0, 253.099266, 0.0), new Point3d(0.0, 247.792422, -84.0), new Point3d(35.45952, 245.798125, -84.0), new Point3d(71.015367, 239.395359, -84.0), new Point3d(104.952289, 227.684234, -84.0), new Point3d(136.019484, 207.942281, -84.0), new Point3d(157.154922, 175.808609, -84.0), new Point3d(157.77775, 136.530484, -84.0), new Point3d(143.710984, 97.530469, -84.0), new Point3d(123.041867, 64.626715, -84.0), new Point3d(96.919461, 35.394453, -84.0), new Point3d(67.443461, 12.407895, -84.0), new Point3d(34.616102, -2.748099, -84.0), new Point3d(0.55276, -8.022964, -84.0), new Point3d(-33.624148, -3.048111, -84.0), new Point3d(-67.121539, 12.207951, -84.0), new Point3d(-96.747688, 35.232555, -84.0), new Point3d(-123.226352, 64.87157, -84.0), new Point3d(-144.259, 98.61857, -84.0), new Point3d(-157.924344, 137.268734, -84.0), new Point3d(-157.154922, 175.808609, -84.0), new Point3d(-135.195516, 208.674078, -84.0), new Point3d(-104.054703, 228.091234, -84.0), new Point3d(-70.384797, 239.553859, -84.0), new Point3d(-36.026906, 245.732781, -84.0) };
				IfcCartesianPointList3D cartesianPointList3D = new IfcCartesianPointList3D(md, points);
				List<CoordIndex> coordIndex = new List<CoordIndex>() { new CoordIndex(28, 2, 29), new CoordIndex(1, 29, 2), new CoordIndex(30, 1, 24), new CoordIndex(29, 1, 30), new CoordIndex(24, 31, 30), new CoordIndex(3, 2, 28), new CoordIndex(5, 4, 27), new CoordIndex(6, 5, 25), new CoordIndex(25, 5, 26), new CoordIndex(4, 28, 27), new CoordIndex(5, 27, 26), new CoordIndex(3, 28, 4), new CoordIndex(23, 32, 31), new CoordIndex(33, 32, 23), new CoordIndex(24, 23, 31), new CoordIndex(34, 22, 21), new CoordIndex(23, 22, 33), new CoordIndex(22, 34, 33), new CoordIndex(21, 20, 35), new CoordIndex(36, 35, 20), new CoordIndex(34, 21, 35), new CoordIndex(37, 36, 19), new CoordIndex(20, 19, 36), new CoordIndex(18, 37, 19), new CoordIndex(7, 6, 48), new CoordIndex(8, 7, 47), new CoordIndex(7, 48, 47), new CoordIndex(8, 47, 46), new CoordIndex(46, 9, 8), new CoordIndex(46, 45, 10), new CoordIndex(11, 10, 45), new CoordIndex(12, 11, 44), new CoordIndex(45, 44, 11), new CoordIndex(10, 9, 46), new CoordIndex(12, 44, 43), new CoordIndex(15, 39, 16), new CoordIndex(40, 39, 15), new CoordIndex(38, 16, 39), new CoordIndex(18, 17, 37), new CoordIndex(16, 38, 17), new CoordIndex(17, 38, 37), new CoordIndex(13, 43, 42), new CoordIndex(12, 43, 13), new CoordIndex(14, 13, 42), new CoordIndex(15, 14, 40), new CoordIndex(14, 41, 40), new CoordIndex(42, 41, 14), new CoordIndex(48, 6, 25), new CoordIndex(50, 72, 49), new CoordIndex(51, 72, 50), new CoordIndex(71, 72, 52), new CoordIndex(51, 52, 72), new CoordIndex(53, 71, 52), new CoordIndex(69, 70, 63), new CoordIndex(71, 54, 70), new CoordIndex(66, 67, 65), new CoordIndex(67, 68, 65), new CoordIndex(68, 69, 64), new CoordIndex(71, 53, 54), new CoordIndex(54, 55, 61), new CoordIndex(55, 56, 61), new CoordIndex(58, 60, 57), new CoordIndex(60, 56, 57), new CoordIndex(59, 60, 58), new CoordIndex(65, 68, 64), new CoordIndex(69, 63, 64), new CoordIndex(62, 63, 70), new CoordIndex(62, 54, 61), new CoordIndex(61, 56, 60), new CoordIndex(62, 70, 54), new CoordIndex(74, 73, 76), new CoordIndex(80, 125, 126), new CoordIndex(126, 76, 78), new CoordIndex(126, 77, 76), new CoordIndex(76, 77, 74), new CoordIndex(82, 127, 125), new CoordIndex(127, 82, 84), new CoordIndex(127, 83, 81), new CoordIndex(125, 81, 79), new CoordIndex(128, 84, 129), new CoordIndex(88, 130, 86), new CoordIndex(92, 131, 90), new CoordIndex(90, 132, 88), new CoordIndex(94, 133, 92), new CoordIndex(96, 134, 94), new CoordIndex(98, 135, 96), new CoordIndex(128, 85, 83), new CoordIndex(77, 75, 74), new CoordIndex(77, 126, 79), new CoordIndex(85, 128, 87), new CoordIndex(87, 129, 89), new CoordIndex(131, 93, 132), new CoordIndex(134, 97, 133), new CoordIndex(97, 134, 99), new CoordIndex(133, 95, 131), new CoordIndex(132, 91, 130), new CoordIndex(135, 98, 136), new CoordIndex(102, 137, 100), new CoordIndex(106, 138, 104), new CoordIndex(104, 139, 102), new CoordIndex(137, 103, 136), new CoordIndex(108, 140, 106), new CoordIndex(138, 107, 139), new CoordIndex(139, 105, 137), new CoordIndex(99, 135, 101), new CoordIndex(141, 110, 112), new CoordIndex(114, 143, 142), new CoordIndex(141, 111, 109), new CoordIndex(110, 141, 140), new CoordIndex(118, 144, 145), new CoordIndex(120, 146, 144), new CoordIndex(116, 145, 143), new CoordIndex(122, 123, 146), new CoordIndex(140, 109, 138), new CoordIndex(111, 141, 142), new CoordIndex(113, 142, 143), new CoordIndex(145, 117, 115), new CoordIndex(146, 121, 119), new CoordIndex(123, 124, 121), new CoordIndex(144, 119, 117), new CoordIndex(148, 173, 172), new CoordIndex(149, 174, 173), new CoordIndex(151, 176, 175), new CoordIndex(152, 177, 176), new CoordIndex(150, 175, 174), new CoordIndex(154, 179, 178), new CoordIndex(155, 180, 179), new CoordIndex(157, 182, 181), new CoordIndex(158, 183, 182), new CoordIndex(156, 181, 180), new CoordIndex(153, 178, 177), new CoordIndex(160, 185, 159), new CoordIndex(161, 186, 160), new CoordIndex(163, 188, 162), new CoordIndex(164, 189, 163), new CoordIndex(162, 187, 161), new CoordIndex(166, 191, 165), new CoordIndex(167, 192, 166), new CoordIndex(169, 194, 168), new CoordIndex(171, 196, 170), new CoordIndex(170, 195, 169), new CoordIndex(168, 193, 167), new CoordIndex(165, 190, 164), new CoordIndex(159, 184, 183), new CoordIndex(217, 216, 215), new CoordIndex(217, 215, 218), new CoordIndex(220, 219, 214), new CoordIndex(215, 219, 218), new CoordIndex(197, 220, 214), new CoordIndex(214, 213, 197), new CoordIndex(219, 215, 214), new CoordIndex(210, 208, 211), new CoordIndex(213, 212, 205), new CoordIndex(212, 211, 207), new CoordIndex(197, 213, 205), new CoordIndex(198, 204, 199), new CoordIndex(200, 199, 203), new CoordIndex(203, 202, 201), new CoordIndex(200, 203, 201), new CoordIndex(203, 199, 204), new CoordIndex(209, 208, 210), new CoordIndex(208, 207, 211), new CoordIndex(206, 212, 207), new CoordIndex(212, 206, 205), new CoordIndex(197, 205, 204), new CoordIndex(197, 204, 198), new CoordIndex(80, 126, 78), new CoordIndex(82, 125, 80), new CoordIndex(127, 84, 128), new CoordIndex(127, 81, 125), new CoordIndex(125, 79, 126), new CoordIndex(84, 86, 129), new CoordIndex(130, 129, 86), new CoordIndex(131, 132, 90), new CoordIndex(132, 130, 88), new CoordIndex(133, 131, 92), new CoordIndex(134, 133, 94), new CoordIndex(135, 134, 96), new CoordIndex(128, 83, 127), new CoordIndex(128, 129, 87), new CoordIndex(129, 130, 89), new CoordIndex(93, 91, 132), new CoordIndex(97, 95, 133), new CoordIndex(134, 135, 99), new CoordIndex(95, 93, 131), new CoordIndex(91, 89, 130), new CoordIndex(98, 100, 136), new CoordIndex(137, 136, 100), new CoordIndex(138, 139, 104), new CoordIndex(139, 137, 102), new CoordIndex(103, 101, 136), new CoordIndex(140, 138, 106), new CoordIndex(107, 105, 139), new CoordIndex(105, 103, 137), new CoordIndex(135, 136, 101), new CoordIndex(141, 112, 142), new CoordIndex(114, 142, 112), new CoordIndex(141, 109, 140), new CoordIndex(110, 140, 108), new CoordIndex(118, 145, 116), new CoordIndex(120, 144, 118), new CoordIndex(116, 143, 114), new CoordIndex(122, 146, 120), new CoordIndex(109, 107, 138), new CoordIndex(111, 142, 113), new CoordIndex(113, 143, 115), new CoordIndex(145, 115, 143), new CoordIndex(146, 119, 144), new CoordIndex(123, 121, 146), new CoordIndex(144, 117, 145), new CoordIndex(148, 172, 147), new CoordIndex(149, 173, 148), new CoordIndex(151, 175, 150), new CoordIndex(152, 176, 151), new CoordIndex(150, 174, 149), new CoordIndex(154, 178, 153), new CoordIndex(155, 179, 154), new CoordIndex(157, 181, 156), new CoordIndex(158, 182, 157), new CoordIndex(156, 180, 155), new CoordIndex(153, 177, 152), new CoordIndex(185, 184, 159), new CoordIndex(186, 185, 160), new CoordIndex(188, 187, 162), new CoordIndex(189, 188, 163), new CoordIndex(187, 186, 161), new CoordIndex(191, 190, 165), new CoordIndex(192, 191, 166), new CoordIndex(194, 193, 168), new CoordIndex(196, 195, 170), new CoordIndex(195, 194, 169), new CoordIndex(193, 192, 167), new CoordIndex(190, 189, 164), new CoordIndex(159, 183, 158) };
				IfcTriangulatedFaceSet triangulatedFaceSet = new IfcTriangulatedFaceSet(md, cartesianPointList3D, null, true, coordIndex, null);
				representationMap = new IfcRepresentationMap(triangulatedFaceSet);
			}
			IfcMaterial ceramic = new IfcMaterial(md, "Ceramic", "", "");
			ceramic.Associates.GlobalId = "0Pkhszwjv1qRMYyCFg9fjB";
			IfcSanitaryTerminalType sanitaryTerminalType = new IfcSanitaryTerminalType(md, new IfcElemTypeParams("2Vk5O9OO94lfvLVH2WXKBZ", "Wash Hand Basin", "", "", ""), ceramic, representationMap, null, IfcSanitaryTerminalTypeEnum.WASHHANDBASIN);
			sanitaryTerminalType.ObjectTypeOf.GlobalId = "01OIK6g$5EVxvitdj$pQSU";
			sanitaryTerminalType.GenerateMappedItemElement(building, Plane.WorldXY, new IfcElemParams("0dOOwKTsn8I8gwbP3LM1Yz","","","",""));
		}
		
	}

}
