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
				IfcCartesianPoint cp74 = new IfcCartesianPoint(md,-300.0,150.0,0.0);
				IfcCartesianPoint cp75 = new IfcCartesianPoint(md,0.0,253.099263998677,0.0);
				IfcCartesianPoint cp76 = new IfcCartesianPoint(md,-304.891071307496,109.822256120206,0.0);
				IfcCartesianPoint cp77 = new IfcCartesianPoint(md,-296.940075211924,69.9862810835965,0.0);
				IfcCartesianPoint cp78 = new IfcCartesianPoint(md,-280.922701731312,32.5907488402735,0.0);
				IfcCartesianPoint cp79 = new IfcCartesianPoint(md,-259.608278768049,-2.08529338102262,0.0);
				IfcCartesianPoint cp80 = new IfcCartesianPoint(md,-234.428168068557,-34.0753473673235,0.0);
				IfcCartesianPoint cp81 = new IfcCartesianPoint(md,-206.125816386308,-63.3430855287523,0.0);
				IfcCartesianPoint cp82 = new IfcCartesianPoint(md,-175.071534188435,-89.671802213621,0.0);
				IfcCartesianPoint cp83 = new IfcCartesianPoint(md,-141.412934526735,-112.569598180375,0.0);
				IfcCartesianPoint cp84 = new IfcCartesianPoint(md,-105.215114341225,-131.178510124149,0.0);
				IfcCartesianPoint cp85 = new IfcCartesianPoint(md,-66.7978479682479,-144.600522500239,0.0);
				IfcCartesianPoint cp86 = new IfcCartesianPoint(md,-26.8019125425913,-152.078206375312,0.0);
				IfcCartesianPoint cp87 = new IfcCartesianPoint(md,13.8710862775596,-153.121660363236,0.0);
				IfcCartesianPoint cp88 = new IfcCartesianPoint(md,54.1903326227934,-147.658103330519,0.0);
				IfcCartesianPoint cp89 = new IfcCartesianPoint(md,93.1938862047157,-136.056391059388,0.0);
				IfcCartesianPoint cp90 = new IfcCartesianPoint(md,130.150407237097,-119.008883827061,0.0);
				IfcCartesianPoint cp91 = new IfcCartesianPoint(md,164.629900262907,-97.37165169902,0.0);
				IfcCartesianPoint cp92 = new IfcCartesianPoint(md,196.521914802755,-72.0656434367093,0.0);
				IfcCartesianPoint cp93 = new IfcCartesianPoint(md,225.728273711876,-43.6997637700286,0.0);
				IfcCartesianPoint cp94 = new IfcCartesianPoint(md,251.961645534009,-12.5658965535741,0.0);
				IfcCartesianPoint cp95 = new IfcCartesianPoint(md,274.62087031373,21.2509318856294,0.0);
				IfcCartesianPoint cp96 = new IfcCartesianPoint(md,292.544561947164,57.7814080324017,0.0);
				IfcCartesianPoint cp97 = new IfcCartesianPoint(md,303.485368351088,96.9291090994897,0.0);
				IfcCartesianPoint cp98 = new IfcCartesianPoint(md,303.288957242437,137.460278743209,0.0);
				IfcCartesianPoint cp99 = new IfcCartesianPoint(md,287.369755242598,174.609406522514,0.0);
				IfcCartesianPoint cp100 = new IfcCartesianPoint(md,258.965081713391,203.584218912768,0.0);
				IfcCartesianPoint cp101 = new IfcCartesianPoint(md,224.363000998313,224.953681400811,0.0);
				IfcCartesianPoint cp102 = new IfcCartesianPoint(md,186.818017180943,240.67163971588,0.0);
				IfcCartesianPoint cp103 = new IfcCartesianPoint(md,147.756154156487,252.155742473922,0.0);
				IfcCartesianPoint cp104 = new IfcCartesianPoint(md,107.854433144861,260.280582237886,0.0);
				IfcCartesianPoint cp105 = new IfcCartesianPoint(md,67.4765332607867,265.571769764524,0.0);
				IfcCartesianPoint cp106 = new IfcCartesianPoint(md,26.8458427708863,268.331827033896,0.0);
				IfcCartesianPoint cp107 = new IfcCartesianPoint(md,-13.8771780303431,268.706812331913,0.0);
				IfcCartesianPoint cp108 = new IfcCartesianPoint(md,-54.5530293999268,266.715969920949,0.0);
				IfcCartesianPoint cp109 = new IfcCartesianPoint(md,-95.0316202590492,262.255497380798,0.0);
				IfcCartesianPoint cp110 = new IfcCartesianPoint(md,-135.115612880362,255.077835581894,0.0);
				IfcCartesianPoint cp111 = new IfcCartesianPoint(md,-174.498313981775,244.738726835566,0.0);
				IfcCartesianPoint cp112 = new IfcCartesianPoint(md,-212.631973130034,230.493081814022,0.0);
				IfcCartesianPoint cp113 = new IfcCartesianPoint(md,-248.405687646327,211.118276332925,0.0);
				IfcCartesianPoint cp114 = new IfcCartesianPoint(md,-279.319862190373,184.775801315119,0.0);
				IfcCartesianPoint cp115 = new IfcCartesianPoint(md,38.4756983219429,252.033478287557,0.0);
				IfcCartesianPoint cp116 = new IfcCartesianPoint(md,76.82797079471,248.781505427916,0.0);
				IfcCartesianPoint cp117 = new IfcCartesianPoint(md,114.905040261981,243.168611097888,0.0);
				IfcCartesianPoint cp118 = new IfcCartesianPoint(md,152.483825019629,234.862972697005,0.0);
				IfcCartesianPoint cp119 = new IfcCartesianPoint(md,189.184260308893,223.297735395069,0.0);
				IfcCartesianPoint cp120 = new IfcCartesianPoint(md,224.265826794532,207.523990642274,0.0);
				IfcCartesianPoint cp121 = new IfcCartesianPoint(md,256.087669717028,185.991172830599,0.0);
				IfcCartesianPoint cp122 = new IfcCartesianPoint(md,280.765071736094,156.699063336262,0.0);
				IfcCartesianPoint cp123 = new IfcCartesianPoint(md,291.585141614082,120.093338245881,0.0);
				IfcCartesianPoint cp124 = new IfcCartesianPoint(md,287.786485451514,81.9448662146907,0.0);
				IfcCartesianPoint cp125 = new IfcCartesianPoint(md,274.528157897687,45.8738463140147,0.0);
				IfcCartesianPoint cp126 = new IfcCartesianPoint(md,255.376512280737,12.5180862102588,0.0);
				IfcCartesianPoint cp127 = new IfcCartesianPoint(md,232.162082007755,-18.1641105843033,0.0);
				IfcCartesianPoint cp128 = new IfcCartesianPoint(md,205.82058249047,-46.2135089189517,0.0);
				IfcCartesianPoint cp129 = new IfcCartesianPoint(md,176.831543285532,-71.5181976728152,0.0);
				IfcCartesianPoint cp130 = new IfcCartesianPoint(md,145.419108882987,-93.7387882260769,0.0);
				IfcCartesianPoint cp131 = new IfcCartesianPoint(md,111.672515835794,-112.209605260782,0.0);
				IfcCartesianPoint cp132 = new IfcCartesianPoint(md,75.812198248967,-126.124204222316,0.0);
				IfcCartesianPoint cp133 = new IfcCartesianPoint(md,38.3440539351622,-134.804771445296,0.0);
				IfcCartesianPoint cp134 = new IfcCartesianPoint(md,0.00000562489231925,-137.758996454453,0.0);
				IfcCartesianPoint cp135 = new IfcCartesianPoint(md,-38.3440494938959,-134.804772131387,0.0);
				IfcCartesianPoint cp136 = new IfcCartesianPoint(md,-75.8121974100292,-126.124204482417,0.0);
				IfcCartesianPoint cp137 = new IfcCartesianPoint(md,-111.672515690142,-112.209605328934,0.0);
				IfcCartesianPoint cp138 = new IfcCartesianPoint(md,-145.419108622881,-93.7387883895915,0.0);
				IfcCartesianPoint cp139 = new IfcCartesianPoint(md,-176.831543103321,-71.5181978165611,0.0);
				IfcCartesianPoint cp140 = new IfcCartesianPoint(md,-205.820584751455,-46.2135067401479,0.0);
				IfcCartesianPoint cp141 = new IfcCartesianPoint(md,-232.162080231681,-18.164112680286,0.0);
				IfcCartesianPoint cp142 = new IfcCartesianPoint(md,-255.37651255073,12.5180866141667,0.0);
				IfcCartesianPoint cp143 = new IfcCartesianPoint(md,-274.528157992219,45.8738465115148,0.0);
				IfcCartesianPoint cp144 = new IfcCartesianPoint(md,-287.786482832935,81.9448557189429,0.0);
				IfcCartesianPoint cp145 = new IfcCartesianPoint(md,-291.585141527273,120.093339480335,0.0);
				IfcCartesianPoint cp146 = new IfcCartesianPoint(md,-280.765069841138,156.69906670217,0.0);
				IfcCartesianPoint cp147 = new IfcCartesianPoint(md,-256.087676107765,185.991167334279,0.0);
				IfcCartesianPoint cp148 = new IfcCartesianPoint(md,-224.265825523088,207.523991330957,0.0);
				IfcCartesianPoint cp149 = new IfcCartesianPoint(md,-189.184272565133,223.297730817421,0.0);
				IfcCartesianPoint cp150 = new IfcCartesianPoint(md,-152.483829695455,234.862971464014,0.0);
				IfcCartesianPoint cp151 = new IfcCartesianPoint(md,-114.905033181042,243.168612385642,0.0);
				IfcCartesianPoint cp152 = new IfcCartesianPoint(md,-76.8279738129532,248.781505081298,0.0);
				IfcCartesianPoint cp153 = new IfcCartesianPoint(md,-38.4757029862493,252.0334780278,0.0);
				IfcCartesianPoint cp154 = new IfcCartesianPoint(md,-157.154914340418,175.808617178122,-93.9999999999991);
				IfcCartesianPoint cp155 = new IfcCartesianPoint(md,-159.799786377107,153.46782071584,-93.9999999999991);
				IfcCartesianPoint cp156 = new IfcCartesianPoint(md,-156.563435238971,131.153861277019,-93.9999999999991);
				IfcCartesianPoint cp157 = new IfcCartesianPoint(md,-149.376131896764,109.760102145713,-93.9999999999991);
				IfcCartesianPoint cp158 = new IfcCartesianPoint(md,-139.405144871723,89.5038839334345,-93.9999999999991);
				IfcCartesianPoint cp159 = new IfcCartesianPoint(md,-127.294335499358,70.445523587566,-93.9999999999991);
				IfcCartesianPoint cp160 = new IfcCartesianPoint(md,-113.387459490709,52.6538727330131,-93.9999999999991);
				IfcCartesianPoint cp161 = new IfcCartesianPoint(md,-97.8447661146846,36.2725918775068,-93.9999999999991);
				IfcCartesianPoint cp162 = new IfcCartesianPoint(md,-80.698001162248,21.582584637739,-93.9999999999991);
				IfcCartesianPoint cp163 = new IfcCartesianPoint(md,-61.8871867593298,9.10501350136987,-93.9999999999991);
				IfcCartesianPoint cp164 = new IfcCartesianPoint(md,-41.4394014166823,-0.440153063918815,-93.9999999999991);
				IfcCartesianPoint cp165 = new IfcCartesianPoint(md,-19.662998563232,-6.32985285628291,-93.9999999999991);
				IfcCartesianPoint cp166 = new IfcCartesianPoint(md,2.83012817778957,-7.98927385674093,-93.9999999999991);
				IfcCartesianPoint cp167 = new IfcCartesianPoint(md,25.2161298976784,-5.23363177905661,-93.9999999999991);
				IfcCartesianPoint cp168 = new IfcCartesianPoint(md,46.7052656338443,1.63611866403177,-93.9999999999991);
				IfcCartesianPoint cp169 = new IfcCartesianPoint(md,66.7603568037461,11.9848882796374,-93.9999999999991);
				IfcCartesianPoint cp170 = new IfcCartesianPoint(md,85.1475914236449,25.0817028555501,-93.9999999999991);
				IfcCartesianPoint cp171 = new IfcCartesianPoint(md,101.889510015946,40.2328202653944,-93.9999999999991);
				IfcCartesianPoint cp172 = new IfcCartesianPoint(md,117.029708390029,56.9871779332136,-93.9999999999991);
				IfcCartesianPoint cp173 = new IfcCartesianPoint(md,130.507477385555,75.1059075118196,-93.9999999999991);
				IfcCartesianPoint cp174 = new IfcCartesianPoint(md,142.123444996071,94.4691487187488,-93.9999999999991);
				IfcCartesianPoint cp175 = new IfcCartesianPoint(md,151.473017550452,115.017962619083,-93.9999999999991);
				IfcCartesianPoint cp176 = new IfcCartesianPoint(md,157.807019966901,136.675894195075,-93.9999999999991);
				IfcCartesianPoint cp177 = new IfcCartesianPoint(md,159.780564770642,159.127525554679,-93.9999999999991);
				IfcCartesianPoint cp178 = new IfcCartesianPoint(md,155.311843754385,181.158856579337,-93.9999999999991);
				IfcCartesianPoint cp179 = new IfcCartesianPoint(md,143.527109004701,200.308104946409,-93.9999999999991);
				IfcCartesianPoint cp180 = new IfcCartesianPoint(md,126.728646947386,215.328663366711,-93.9999999999991);
				IfcCartesianPoint cp181 = new IfcCartesianPoint(md,107.202467334812,226.634520930962,-93.9999999999991);
				IfcCartesianPoint cp182 = new IfcCartesianPoint(md,86.2268790106761,234.98230335346,-93.9999999999991);
				IfcCartesianPoint cp183 = new IfcCartesianPoint(md,64.4507343905464,240.958334023702,-93.9999999999991);
				IfcCartesianPoint cp184 = new IfcCartesianPoint(md,42.2218098296953,244.946818741202,-93.9999999999991);
				IfcCartesianPoint cp185 = new IfcCartesianPoint(md,19.7473348710258,247.180277362528,-93.9999999999991);
				IfcCartesianPoint cp186 = new IfcCartesianPoint(md,-2.83037829161053,247.779902642456,-93.9999999999991);
				IfcCartesianPoint cp187 = new IfcCartesianPoint(md,-25.3937160660832,246.777117598331,-93.9999999999991);
				IfcCartesianPoint cp188 = new IfcCartesianPoint(md,-47.8217104720131,244.119106659353,-93.9999999999991);
				IfcCartesianPoint cp189 = new IfcCartesianPoint(md,-69.9604240039862,239.659498513825,-93.9999999999991);
				IfcCartesianPoint cp190 = new IfcCartesianPoint(md,-91.576683901205,233.132310979361,-93.9999999999991);
				IfcCartesianPoint cp191 = new IfcCartesianPoint(md,-112.267364103545,224.107056891456,-93.9999999999991);
				IfcCartesianPoint cp192 = new IfcCartesianPoint(md,-131.264894314891,211.943402767825,-93.9999999999991);
				IfcCartesianPoint cp193 = new IfcCartesianPoint(md,-147.061746316906,195.888143420344,-93.9999999999991);
				IfcCartesianPoint cp194 = new IfcCartesianPoint(md,0.0,247.792422124388,-83.9999999999991);
				IfcCartesianPoint cp195 = new IfcCartesianPoint(md,-22.5714426203723,246.991542511388,-83.9999999999991);
				IfcCartesianPoint cp196 = new IfcCartesianPoint(md,-45.0238143941789,244.546840992317,-83.9999999999991);
				IfcCartesianPoint cp197 = new IfcCartesianPoint(md,-67.2093088278616,240.324720105693,-83.9999999999991);
				IfcCartesianPoint cp198 = new IfcCartesianPoint(md,-88.9083392880943,234.076268171425,-83.9999999999991);
				IfcCartesianPoint cp199 = new IfcCartesianPoint(md,-109.746783760019,225.394569776618,-83.9999999999991);
				IfcCartesianPoint cp200 = new IfcCartesianPoint(md,-129.019214178155,213.666092805292,-83.9999999999991);
				IfcCartesianPoint cp201 = new IfcCartesianPoint(md,-145.336255413146,198.131561931792,-83.9999999999991);
				IfcCartesianPoint cp202 = new IfcCartesianPoint(md,-156.295574267743,178.505166800292,-83.9999999999991);
				IfcCartesianPoint cp203 = new IfcCartesianPoint(md,-159.838406313243,156.297849730896,-83.9999999999991);
				IfcCartesianPoint cp204 = new IfcCartesianPoint(md,-157.217231378449,133.907674702395,-83.9999999999991);
				IfcCartesianPoint cp205 = new IfcCartesianPoint(md,-150.446948503868,112.380106954109,-83.9999999999991);
				IfcCartesianPoint cp206 = new IfcCartesianPoint(md,-140.781370993691,91.9771671791993,-83.9999999999991);
				IfcCartesianPoint cp207 = new IfcCartesianPoint(md,-128.915130782292,72.7659081552236,-83.9999999999991);
				IfcCartesianPoint cp208 = new IfcCartesianPoint(md,-115.221432502533,54.8097171953257,-83.9999999999991);
				IfcCartesianPoint cp209 = new IfcCartesianPoint(md,-99.8796470071603,38.239929890392,-83.9999999999991);
				IfcCartesianPoint cp210 = new IfcCartesianPoint(md,-82.9357654214438,23.3156500424069,-83.9999999999991);
				IfcCartesianPoint cp211 = new IfcCartesianPoint(md,-64.3369337417203,10.5226649501159,-83.9999999999991);
				IfcCartesianPoint cp212 = new IfcCartesianPoint(md,-44.0834019165823,0.569910981625322,-83.9999999999991);
				IfcCartesianPoint cp213 = new IfcCartesianPoint(md,-22.4460832273862,-5.81475796938246,-83.9999999999991);
				IfcCartesianPoint cp214 = new IfcCartesianPoint(md,0.00000176219393597,-8.0243005407274,-83.9999999999991);
				IfcCartesianPoint cp215 = new IfcCartesianPoint(md,22.446084481302,-5.81475772180151,-83.9999999999991);
				IfcCartesianPoint cp216 = new IfcCartesianPoint(md,44.0834024872804,0.569911206685156,-83.9999999999991);
				IfcCartesianPoint cp217 = new IfcCartesianPoint(md,64.3369357795818,10.5226661545967,-83.9999999999991);
				IfcCartesianPoint cp218 = new IfcCartesianPoint(md,82.9357630974296,23.3156482145766,-83.9999999999991);
				IfcCartesianPoint cp219 = new IfcCartesianPoint(md,99.8796474348905,38.2399303092091,-83.9999999999991);
				IfcCartesianPoint cp220 = new IfcCartesianPoint(md,115.221437914664,54.8097236343718,-83.9999999999991);
				IfcCartesianPoint cp221 = new IfcCartesianPoint(md,128.915131219959,72.7659087899957,-83.9999999999991);
				IfcCartesianPoint cp222 = new IfcCartesianPoint(md,140.781372023645,91.9771690603084,-83.9999999999991);
				IfcCartesianPoint cp223 = new IfcCartesianPoint(md,150.44694977305,112.380110135675,-83.9999999999991);
				IfcCartesianPoint cp224 = new IfcCartesianPoint(md,157.217230633118,133.907671395464,-83.9999999999991);
				IfcCartesianPoint cp225 = new IfcCartesianPoint(md,159.838406320187,156.297847499286,-83.9999999999991);
				IfcCartesianPoint cp226 = new IfcCartesianPoint(md,156.295574340587,178.505166588871,-83.9999999999991);
				IfcCartesianPoint cp227 = new IfcCartesianPoint(md,145.336254078924,198.131563599338,-83.9999999999991);
				IfcCartesianPoint cp228 = new IfcCartesianPoint(md,129.019208284081,213.666097201998,-83.9999999999991);
				IfcCartesianPoint cp229 = new IfcCartesianPoint(md,109.746785929842,225.394568694178,-83.9999999999991);
				IfcCartesianPoint cp230 = new IfcCartesianPoint(md,88.90833880495,234.07626833846,-83.9999999999991);
				IfcCartesianPoint cp231 = new IfcCartesianPoint(md,67.2093069026739,240.324720559443,-83.9999999999991);
				IfcCartesianPoint cp232 = new IfcCartesianPoint(md,45.0238122743352,244.546841305597,-83.9999999999991);
				IfcCartesianPoint cp233 = new IfcCartesianPoint(md,22.5714426167356,246.991542511648,-83.9999999999991);
				IfcPolyloop pl234 = new IfcPolyloop(new List<IfcCartesianPoint>() {cp76,cp77,cp78,cp79,cp80,cp81,cp82,cp83,cp84,cp85,cp86,cp87,cp88,cp89,cp90,cp91,cp92,cp93,cp94,cp95,cp96,cp97,cp98,cp99,cp100,cp101,cp102,cp103,cp104,cp105,cp106,cp107,cp108,cp109,cp110,cp111,cp112,cp113,cp114 });
				IfcFaceOuterBound fob235= new IfcFaceOuterBound(pl234,true);
				IfcPolyloop pl236 = new IfcPolyloop(new List<IfcCartesianPoint>() { cp115,cp116,cp117,cp118,cp119,cp120,cp121,cp122,cp123,cp124,cp125,cp126,cp127,cp128,cp129,cp130,cp131,cp132,cp133,cp134,cp135,cp136,cp137,cp138,cp139,cp140,cp141,cp142,cp143,cp144,cp145,cp146,cp147,cp148,cp149,cp150,cp151,cp152,cp153,cp75 });
				IfcFaceBound fb237= new IfcFaceBound(pl236,true);
				IfcFace f238= new IfcFace(fob235,fb237);
				IfcPolyloop pl239 = new IfcPolyloop(new List<IfcCartesianPoint>() { cp155,cp156,cp157,cp158,cp159,cp160,cp161,cp162,cp163,cp164,cp165,cp166,cp167,cp168,cp169,cp170,cp171,cp172,cp173,cp174,cp175,cp176,cp177,cp178,cp179,cp180,cp181,cp182,cp183,cp184,cp185,cp186,cp187,cp188,cp189,cp190,cp191,cp192,cp193,cp154 });
				IfcFace	f241= new IfcFace(new IfcFaceOuterBound(pl239,true));
				IfcPolyloop pl242 = new IfcPolyloop(new List<IfcCartesianPoint>() {cp195,cp196,cp197,cp198,cp199,cp200,cp201,cp202,cp203,cp204,cp205,cp206,cp207,cp208,cp209,cp210,cp211,cp212,cp213,cp214,cp215,cp216,cp217,cp218,cp219,cp220,cp221,cp222,cp223,cp224,cp225,cp226,cp227,cp228,cp229,cp230,cp231,cp232,cp233, cp194 });
				IfcFaceOuterBound fob243 = new IfcFaceOuterBound(pl242,true);
				IfcFace	f244= new IfcFace(fob243);
				IfcFace f247 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp74, cp193, cp154), true));
				IfcFace f250 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp114, cp192, cp193), true));
				IfcFace f253 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp113, cp191, cp192), true));
				IfcFace f256 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp112, cp190, cp191), true));
				IfcFace f259 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp111, cp189, cp190), true));
				IfcFace f262 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp110, cp188, cp189), true));
				IfcFace f265 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp109, cp187, cp188), true));
				IfcFace f268 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp108, cp186, cp187), true));
				IfcFace f271 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp107, cp185, cp186), true));
				IfcFace f274 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp106, cp184, cp185), true));
				IfcFace f277 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp105, cp183, cp184), true));
				IfcFace f280 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp104, cp182, cp183), true));
				IfcFace f283 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp103, cp181, cp182), true));
				IfcFace f286 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp102, cp180, cp181), true));
				IfcFace f289 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp101, cp179, cp180), true));
				IfcFace f292 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp100, cp178, cp179), true));
				IfcFace f295 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp99, cp177, cp178), true));
				IfcFace f298 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp98, cp176, cp177), true));
				IfcFace f301 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp97, cp175, cp176), true));
				IfcFace f304 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp96, cp174, cp175), true));
				IfcFace f307 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp95, cp173, cp174), true));
				IfcFace f310 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp94, cp172, cp173), true));
				IfcFace f313 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp93, cp171, cp172), true));
				IfcFace f316 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp92, cp170, cp171), true));
				IfcFace f319 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp91, cp169, cp170), true));
				IfcFace f322 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp90, cp168, cp169), true));
				IfcFace f325 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp89, cp167, cp168), true));
				IfcFace f328 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp88, cp166, cp167), true));
				IfcFace f331 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp87, cp165, cp166), true));
				IfcFace f334 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp86, cp164, cp165), true));
				IfcFace f337 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp85, cp163, cp164), true));
				IfcFace f340 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp84, cp162, cp163), true));
				IfcFace f343 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp83, cp161, cp162), true));
				IfcFace f346 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp82, cp160, cp161), true));
				IfcFace f349 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp81, cp159, cp160), true));
				IfcFace f352 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp80, cp158, cp159), true));
				IfcFace f355 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp79, cp157, cp158), true));
				IfcFace f358 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp78, cp156, cp157), true));
				IfcFace f361 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp77, cp155, cp156), true));
				IfcFace f364 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp76, cp154, cp155), true));
				IfcFace f367 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp74, cp114, cp193), true));
				IfcFace f370 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp114, cp113, cp192), true));
				IfcFace f373 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp113, cp112, cp191), true));
				IfcFace f376 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp112, cp111, cp190), true));
				IfcFace f379 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp111, cp110, cp189), true));
				IfcFace f382 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp110, cp109, cp188), true));
				IfcFace f385 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp109, cp108, cp187), true));
				IfcFace f388 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp108, cp107, cp186), true));
				IfcFace f391 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp107, cp106, cp185), true));
				IfcFace f394 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp106, cp105, cp184), true));
				IfcFace f397 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp105, cp104, cp183), true));
				IfcFace f400 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp104, cp103, cp182), true));
				IfcFace f403 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp103, cp102, cp181), true));
				IfcFace f406 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp102, cp101, cp180), true));
				IfcFace f409 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp101, cp100, cp179), true));
				IfcFace f412 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp100, cp99, cp178), true));
				IfcFace f415 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp99, cp98, cp177), true));
				IfcFace f418 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp98, cp97, cp176), true));
				IfcFace f421 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp97, cp96, cp175), true));
				IfcFace f424 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp96, cp95, cp174), true));
				IfcFace f427 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp95, cp94, cp173), true));
				IfcFace f430 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp94, cp93, cp172), true));
				IfcFace f433 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp93, cp92, cp171), true));
				IfcFace f436 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp92, cp91, cp170), true));
				IfcFace f439 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp91, cp90, cp169), true));
				IfcFace f442 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp90, cp89, cp168), true));
				IfcFace f445 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp89, cp88, cp167), true));
				IfcFace f448 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp88, cp87, cp166), true));
				IfcFace f451 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp87, cp86, cp165), true));
				IfcFace f454 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp86, cp85, cp164), true));
				IfcFace f457 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp85, cp84, cp163), true));
				IfcFace f460 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp84, cp83, cp162), true));
				IfcFace f463 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp83, cp82, cp161), true));
				IfcFace f466 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp82, cp81, cp160), true));
				IfcFace f469 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp81, cp80, cp159), true));
				IfcFace f472 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp80, cp79, cp158), true));
				IfcFace f475 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp79, cp78, cp157), true));
				IfcFace f478 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp78, cp77, cp156), true));
				IfcFace f481 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp77, cp76, cp155), true));
				IfcFace f484 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp76, cp74, cp154), true));
				IfcFace f487 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp75, cp233, cp194), true));
				IfcFace f490 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp115, cp232, cp233), true));
				IfcFace f493 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp116, cp231, cp232), true));
				IfcFace f496 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp117, cp230, cp231), true));
				IfcFace f499 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp118, cp229, cp230), true));
				IfcFace f502 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp119, cp228, cp229), true));
				IfcFace f505 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp120, cp227, cp228), true));
				IfcFace f508 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp121, cp226, cp227), true));
				IfcFace f511 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp122, cp225, cp226), true));
				IfcFace f514 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp123, cp224, cp225), true));
				IfcFace f517 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp124, cp223, cp224), true));
				IfcFace f520 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp125, cp222, cp223), true));
				IfcFace f523 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp126, cp221, cp222), true));
				IfcFace f526 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp127, cp220, cp221), true));
				IfcFace f529 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp128, cp219, cp220), true));
				IfcFace f532 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp129, cp218, cp219), true));
				IfcFace f535 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp130, cp217, cp218), true));
				IfcFace f538 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp131, cp216, cp217), true));
				IfcFace f541 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp132, cp215, cp216), true));
				IfcFace f544 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp133, cp214, cp215), true));
				IfcFace f547 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp134, cp213, cp214), true));
				IfcFace f550 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp135, cp212, cp213), true));
				IfcFace f553 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp136, cp211, cp212), true));
				IfcFace f556 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp137, cp210, cp211), true));
				IfcFace f559 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp138, cp209, cp210), true));
				IfcFace f562 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp139, cp208, cp209), true));
				IfcFace f565 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp140, cp207, cp208), true));
				IfcFace f568 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp141, cp206, cp207), true));
				IfcFace f571 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp142, cp205, cp206), true));
				IfcFace f574 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp143, cp204, cp205), true));
				IfcFace f577 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp144, cp203, cp204), true));
				IfcFace f580 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp145, cp202, cp203), true));
				IfcFace f583 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp146, cp201, cp202), true));
				IfcFace f586 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp147, cp200, cp201), true));
				IfcFace f589 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp148, cp199, cp200), true));
				IfcFace f592 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp149, cp198, cp199), true));
				IfcFace f595 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp150, cp197, cp198), true));
				IfcFace f598 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp151, cp196, cp197), true));
				IfcFace f601 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp152, cp195, cp196), true));
				IfcFace f604 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp153, cp194, cp195), true));
				IfcFace f607 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp75, cp115, cp233), true));
				IfcFace f610 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp115, cp116, cp232), true));
				IfcFace f613 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp116, cp117, cp231), true));
				IfcFace f616 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp117, cp118, cp230), true));
				IfcFace f619 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp118, cp119, cp229), true));
				IfcFace f622 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp119, cp120, cp228), true));
				IfcFace f625 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp120, cp121, cp227), true));
				IfcFace f628 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp121, cp122, cp226), true));
				IfcFace f631 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp122, cp123, cp225), true));
				IfcFace f634 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp123, cp124, cp224), true));
				IfcFace f637 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp124, cp125, cp223), true));
				IfcFace f640 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp125, cp126, cp222), true));
				IfcFace f643 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp126, cp127, cp221), true));
				IfcFace f646 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp127, cp128, cp220), true));
				IfcFace f649 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp128, cp129, cp219), true));
				IfcFace f652 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp129, cp130, cp218), true));
				IfcFace f655 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp130, cp131, cp217), true));
				IfcFace f658 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp131, cp132, cp216), true));
				IfcFace f661 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp132, cp133, cp215), true));
				IfcFace f664 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp133, cp134, cp214), true));
				IfcFace f667 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp134, cp135, cp213), true));
				IfcFace f670 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp135, cp136, cp212), true));
				IfcFace f673 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp136, cp137, cp211), true));
				IfcFace f676 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp137, cp138, cp210), true));
				IfcFace f679 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp138, cp139, cp209), true));
				IfcFace f682 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp139, cp140, cp208), true));
				IfcFace f685 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp140, cp141, cp207), true));
				IfcFace f688 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp141, cp142, cp206), true));
				IfcFace f691 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp142, cp143, cp205), true));
				IfcFace f694 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp143, cp144, cp204), true));
				IfcFace f697 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp144, cp145, cp203), true));
				IfcFace f700 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp145, cp146, cp202), true));
				IfcFace f703 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp146, cp147, cp201), true));
				IfcFace f706 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp147, cp148, cp200), true));
				IfcFace f709 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp148, cp149, cp199), true));
				IfcFace f712 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp149, cp150, cp198), true));
				IfcFace f715 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp150, cp151, cp197), true));
				IfcFace f718 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp151, cp152, cp196), true));
				IfcFace f721 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp152, cp153, cp195), true));
				IfcFace f724 = new IfcFace(new IfcFaceOuterBound(new IfcPolyloop(cp153, cp75, cp194), true));

				IfcClosedShell closedShell = new IfcClosedShell(new List<IfcFace>() {f238,f241,f244,f247,f250,f253,f256,f259,f262,f265,f268,f271,f274,f277,f280,f283,f286,f289,f292,f295,f298,f301,f304,f307,f310,f313,f316,f319,f322,f325,f328,f331,f334,f337,f340,f343,f346,f349,f352,f355,f358,f361,f364,f367,f370,f373,f376,f379,f382,f385,f388,f391,f394,f397,f400,f403,f406,f409,f412,f415,f418,f421,f424,f427,f430,f433,f436,f439,f442,f445,f448,f451,f454,f457,f460,f463,f466,f469,f472,f475,f478,f481,f484,f487,f490,f493,f496,f499,f502,f505,f508,f511,f514,f517,f520,f523,f526,f529,f532,f535,f538,f541,f544,f547,f550,f553,f556,f559,f562,f565,f568,f571,f574,f577,f580,f583,f586,f589,f592,f595,f598,f601,f604,f607,f610,f613,f616,f619,f622,f625,f628,f631,f634,f637,f640,f643,f646,f649,f652,f655,f658,f661,f664,f667,f670,f673,f676,f679,f682,f685,f688,f691,f694,f697,f700,f703,f706,f709,f712,f715,f718,f721,f724});
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
