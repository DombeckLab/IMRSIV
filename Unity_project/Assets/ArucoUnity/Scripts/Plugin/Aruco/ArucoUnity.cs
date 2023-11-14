﻿using System.Runtime.InteropServices;

namespace ArucoUnity
{
  /// \addtogroup aruco_unity_package
  /// \{

  namespace Plugin
  {
    public static partial class Aruco
    {
      // Enums

      public enum PredefinedDictionaryName
      {
        Dict4x4_50 = 0,
        Dict4x4_100,
        Dict4x4_250,
        Dict4x4_1000,
        Dict5x5_50,
        Dict5x5_100,
        Dict5x5_250,
        Dict5x5_1000,
        Dict6x6_50,
        Dict6x6_100,
        Dict6x6_250,
        Dict6x6_1000,
        Dict7x7_50,
        Dict7x7_100,
        Dict7x7_250,
        Dict7x7_1000,
        DictArucoOriginal
      }

      public enum CornerRefineMethod
      {
        None, /// No corner refinement
        Subpix, /// Refine the corners using subpix
        Contour /// Refine the corners using the contour-points
      }

      // Native functions

      [DllImport("ArucoUnity")]
      static extern double au_calibrateCameraAruco(System.IntPtr corners, System.IntPtr ids, System.IntPtr counter, System.IntPtr board,
      System.IntPtr imageSize, System.IntPtr cameraMatrix, System.IntPtr distCoeffs, out System.IntPtr rvecs, out System.IntPtr tvecs, int flags,
      System.IntPtr criteria, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern double au_calibrateCameraCharuco(System.IntPtr charucoCorners, System.IntPtr charucoIds, System.IntPtr board,
        System.IntPtr imageSize, System.IntPtr cameraMatrix, System.IntPtr distCoeffs, out System.IntPtr rvecs, out System.IntPtr tvecs, int flags,
        System.IntPtr criteria, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_detectCharucoDiamond(System.IntPtr image, System.IntPtr markerCorners, System.IntPtr markerIds,
        float squareMarkerLengthRate, out System.IntPtr diamondCorners, out System.IntPtr diamondIds, System.IntPtr cameraMatrix,
        System.IntPtr distCoeffs, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_detectMarkers(System.IntPtr image, System.IntPtr dictionary, out System.IntPtr corners, out System.IntPtr ids,
        System.IntPtr parameters, out System.IntPtr rejectedImgPoints, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_drawAxis(System.IntPtr image, System.IntPtr cameraMatrix, System.IntPtr distCoeffs, System.IntPtr rvec,
        System.IntPtr tvec, float length, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_drawCharucoDiamond(System.IntPtr dictionary, System.IntPtr ids, int squareLength, int markerLength,
        out System.IntPtr img, int marginSize, int borderBits, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_drawDetectedCornersCharuco(System.IntPtr image, System.IntPtr charucoCorners, System.IntPtr charucoIds,
        System.IntPtr cornerColor, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_drawDetectedDiamonds(System.IntPtr image, System.IntPtr diamondCorners, System.IntPtr diamondIds,
        System.IntPtr borderColor, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_drawDetectedMarkers(System.IntPtr image, System.IntPtr corners, System.IntPtr ids, System.IntPtr borderColor,
        System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern int au_estimatePoseBoard(System.IntPtr corners, System.IntPtr ids, System.IntPtr board, System.IntPtr cameraMatrix,
        System.IntPtr distCoeffs, out System.IntPtr rvec, out System.IntPtr tvec, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern bool au_estimatePoseCharucoBoard(System.IntPtr charucoCorners, System.IntPtr charucoIds, System.IntPtr board,
        System.IntPtr cameraMatrix, System.IntPtr distCoeffs, out System.IntPtr rvec, out System.IntPtr tvec, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_estimatePoseSingleMarkers(System.IntPtr corners, float markerLength, System.IntPtr cameraMatrix, System.IntPtr distCoeffs,
        out System.IntPtr rvecs, out System.IntPtr tvecs, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern System.IntPtr au_generateCustomDictionary(int nMarkers, int markerSize, System.IntPtr baseDictionary, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_getBoardObjectAndImagePoints(System.IntPtr board, System.IntPtr detectedCorners, System.IntPtr detectedIds,
        out System.IntPtr objPoints, out System.IntPtr imgPoints, System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern System.IntPtr au_getPredefinedDictionary(PredefinedDictionaryName name);

      [DllImport("ArucoUnity")]
      static extern int au_interpolateCornersCharuco(System.IntPtr markerCorners, System.IntPtr markerIds, System.IntPtr image, System.IntPtr board,
        out System.IntPtr charucoCorners, out System.IntPtr charucoIds, System.IntPtr cameraMatrix, System.IntPtr distCoeffs,
        System.IntPtr exception);

      [DllImport("ArucoUnity")]
      static extern void au_refineDetectedMarkers(System.IntPtr image, System.IntPtr board, System.IntPtr detectedCorners, System.IntPtr detectedIds,
        System.IntPtr rejectedCorners, System.IntPtr cameraMatrix, System.IntPtr distCoeffs, float minRepDistance, float errorCorrectionRate,
        bool checkAllOrders, System.IntPtr recoveredIdxs, System.IntPtr parameters, System.IntPtr exception);

      // Static methods

      public static double CalibrateCameraAruco(Std.VectorVectorPoint2f corners, Std.VectorInt ids, Std.VectorInt counter, Board board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Std.VectorMat rvecs, out Std.VectorMat tvecs, Cv.Calib flags,
        Cv.TermCriteria criteria)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr rvecsPtr, tvecsPtr;

        double reProjectionError = au_calibrateCameraAruco(corners.CppPtr, ids.CppPtr, counter.CppPtr, board.CppPtr, imageSize.CppPtr,
          cameraMatrix.CppPtr, distCoeffs.CppPtr, out rvecsPtr, out tvecsPtr, (int)flags, criteria.CppPtr, exception.CppPtr);
        rvecs = new Std.VectorMat(rvecsPtr);
        tvecs = new Std.VectorMat(tvecsPtr);

        exception.Check();
        return reProjectionError;
      }

      public static double CalibrateCameraAruco(Std.VectorVectorPoint2f corners, Std.VectorInt ids, Std.VectorInt counter, Board board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Std.VectorMat rvecs, out Std.VectorMat tvecs, Cv.Calib flags = 0)
      {
        Cv.TermCriteria criteria = new Cv.TermCriteria(Cv.TermCriteria.Type.Count | Cv.TermCriteria.Type.Eps, 30, Cv.EPSILON);
        return CalibrateCameraAruco(corners, ids, counter, board, imageSize, cameraMatrix, distCoeffs, out rvecs, out tvecs, flags, criteria);
      }

      public static double CalibrateCameraAruco(Std.VectorVectorPoint2f corners, Std.VectorInt ids, Std.VectorInt counter, Board board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Std.VectorMat rvecs)
      {
        Std.VectorMat tvecs;
        return CalibrateCameraAruco(corners, ids, counter, board, imageSize, cameraMatrix, distCoeffs, out rvecs, out tvecs);
      }

      public static double CalibrateCameraAruco(Std.VectorVectorPoint2f corners, Std.VectorInt ids, Std.VectorInt counter, Board board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs)
      {
        Std.VectorMat rvecs;
        return CalibrateCameraAruco(corners, ids, counter, board, imageSize, cameraMatrix, distCoeffs, out rvecs);
      }

      public static double CalibrateCameraCharuco(Std.VectorVectorPoint2f charucoCorners, Std.VectorVectorInt charucoIds, CharucoBoard board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Std.VectorMat rvecs, out Std.VectorMat tvecs, Cv.Calib flags,
        Cv.TermCriteria criteria)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr rvecsPtr, tvecsPtr;

        double reProjectionError = au_calibrateCameraCharuco(charucoCorners.CppPtr, charucoIds.CppPtr, board.CppPtr, imageSize.CppPtr,
          cameraMatrix.CppPtr, distCoeffs.CppPtr, out rvecsPtr, out tvecsPtr, (int)flags, criteria.CppPtr, exception.CppPtr);
        rvecs = new Std.VectorMat(rvecsPtr);
        tvecs = new Std.VectorMat(tvecsPtr);

        exception.Check();
        return reProjectionError;
      }

      public static double CalibrateCameraCharuco(Std.VectorVectorPoint2f charucoCorners, Std.VectorVectorInt charucoIds, CharucoBoard board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Std.VectorMat rvecs, out Std.VectorMat tvecs, Cv.Calib flags = 0)
      {
        Cv.TermCriteria criteria = new Cv.TermCriteria(Cv.TermCriteria.Type.Count | Cv.TermCriteria.Type.Eps, 30, Cv.EPSILON);
        return CalibrateCameraCharuco(charucoCorners, charucoIds, board, imageSize, cameraMatrix, distCoeffs, out rvecs, out tvecs, flags, criteria);
      }

      public static double CalibrateCameraCharuco(Std.VectorVectorPoint2f charucoCorners, Std.VectorVectorInt charucoIds, CharucoBoard board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Std.VectorMat rvecs)
      {
        Std.VectorMat tvecs;
        return CalibrateCameraCharuco(charucoCorners, charucoIds, board, imageSize, cameraMatrix, distCoeffs, out rvecs, out tvecs);
      }

      public static double CalibrateCameraCharuco(Std.VectorVectorPoint2f charucoCorners, Std.VectorVectorInt charucoIds, CharucoBoard board,
        Cv.Size imageSize, Cv.Mat cameraMatrix, Cv.Mat distCoeffs)
      {
        Std.VectorMat rvecs;
        return CalibrateCameraCharuco(charucoCorners, charucoIds, board, imageSize, cameraMatrix, distCoeffs, out rvecs);
      }

      public static void DetectCharucoDiamond(Cv.Mat image, Std.VectorVectorPoint2f markerCorners, Std.VectorInt markerIds,
        float squareMarkerLengthRate, out Std.VectorVectorPoint2f diamondCorners, out Std.VectorVec4i diamondIds, Cv.Mat cameraMatrix,
        Cv.Mat distCoeffs)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr diamondCornersPtr, diamondIdsPtr;

        au_detectCharucoDiamond(image.CppPtr, markerCorners.CppPtr, markerIds.CppPtr, squareMarkerLengthRate, out diamondCornersPtr,
          out diamondIdsPtr, cameraMatrix.CppPtr, distCoeffs.CppPtr, exception.CppPtr);
        diamondCorners = new Std.VectorVectorPoint2f(diamondCornersPtr);
        diamondIds = new Std.VectorVec4i(diamondIdsPtr);

        exception.Check();
      }

      public static void DetectCharucoDiamond(Cv.Mat image, Std.VectorVectorPoint2f markerCorners, Std.VectorInt markerIds,
        float squareMarkerLengthRate, out Std.VectorVectorPoint2f diamondCorners, out Std.VectorVec4i diamondIds, Cv.Mat cameraMatrix)
      {
        Cv.Mat distCoeffs = new Cv.Mat();
        DetectCharucoDiamond(image, markerCorners, markerIds, squareMarkerLengthRate, out diamondCorners, out diamondIds, cameraMatrix, distCoeffs);
      }

      public static void DetectCharucoDiamond(Cv.Mat image, Std.VectorVectorPoint2f markerCorners, Std.VectorInt markerIds,
        float squareMarkerLengthRate, out Std.VectorVectorPoint2f diamondCorners, out Std.VectorVec4i diamondIds)
      {
        Cv.Mat cameraMatrix = new Cv.Mat();
        DetectCharucoDiamond(image, markerCorners, markerIds, squareMarkerLengthRate, out diamondCorners, out diamondIds, cameraMatrix);
      }

      public static void DetectMarkers(Cv.Mat image, Dictionary dictionary, out Std.VectorVectorPoint2f corners, out Std.VectorInt ids,
        DetectorParameters parameters, out Std.VectorVectorPoint2f rejectedImgPoints)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr cornersPtr, idsPtr, rejectedPtr;

        au_detectMarkers(image.CppPtr, dictionary.CppPtr, out cornersPtr, out idsPtr, parameters.CppPtr, out rejectedPtr, exception.CppPtr);
        corners = new Std.VectorVectorPoint2f(cornersPtr);
        ids = new Std.VectorInt(idsPtr);
        rejectedImgPoints = new Std.VectorVectorPoint2f(rejectedPtr);

        exception.Check();
      }

      public static void DetectMarkers(Cv.Mat image, Dictionary dictionary, out Std.VectorVectorPoint2f corners, out Std.VectorInt ids,
        DetectorParameters parameters)
      {
        Std.VectorVectorPoint2f rejectedImgPoints;
        DetectMarkers(image, dictionary, out corners, out ids, parameters, out rejectedImgPoints);
      }

      public static void DetectMarkers(Cv.Mat image, Dictionary dictionary, out Std.VectorVectorPoint2f corners, out Std.VectorInt ids)
      {
        DetectorParameters parameters = new DetectorParameters();
        DetectMarkers(image, dictionary, out corners, out ids, parameters);
      }

      public static void DrawAxis(Cv.Mat image, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, Cv.Vec3d rvec, Cv.Vec3d tvec, float length)
      {
        Cv.Exception exception = new Cv.Exception();
        au_drawAxis(image.CppPtr, cameraMatrix.CppPtr, distCoeffs.CppPtr, rvec.CppPtr, tvec.CppPtr, length, exception.CppPtr);
        exception.Check();
      }
      public static void DrawCharucoDiamond(Dictionary dictionary, Cv.Vec4i ids, int squareLength, int markerLength, out Cv.Mat image,
        int marginSize = 0, int borderBits = 1)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr imagePtr;

        au_drawCharucoDiamond(dictionary.CppPtr, ids.CppPtr, squareLength, markerLength, out imagePtr, marginSize, borderBits, exception.CppPtr);
        image = new Cv.Mat(imagePtr);

        exception.Check();
      }

      public static void DrawDetectedCornersCharuco(Cv.Mat image, Std.VectorPoint2f charucoCorners, Std.VectorInt charucoIds, Cv.Scalar cornerColor)
      {
        Cv.Exception exception = new Cv.Exception();
        au_drawDetectedCornersCharuco(image.CppPtr, charucoCorners.CppPtr, charucoIds.CppPtr, cornerColor.CppPtr, exception.CppPtr);
        exception.Check();
      }

      public static void DrawDetectedCornersCharuco(Cv.Mat image, Std.VectorPoint2f charucoCorners, Std.VectorInt charucoIds)
      {
        Cv.Scalar cornerColor = new Cv.Scalar(255, 0, 0);
        DrawDetectedCornersCharuco(image, charucoCorners, charucoIds, cornerColor);
      }

      public static void DrawDetectedCornersCharuco(Cv.Mat image, Std.VectorPoint2f charucoCorners)
      {
        Std.VectorInt charucoIds = new Std.VectorInt();
        DrawDetectedCornersCharuco(image, charucoCorners, charucoIds);
      }

      public static void DrawDetectedDiamonds(Cv.Mat image, Std.VectorVectorPoint2f diamondCorners, Std.VectorVec4i diamondIds,
        Cv.Scalar borderColor)
      {
        Cv.Exception exception = new Cv.Exception();
        au_drawDetectedDiamonds(image.CppPtr, diamondCorners.CppPtr, diamondIds.CppPtr, borderColor.CppPtr, exception.CppPtr);
        exception.Check();
      }

      public static void DrawDetectedDiamonds(Cv.Mat image, Std.VectorVectorPoint2f diamondCorners, Std.VectorVec4i diamondIds)
      {
        Cv.Scalar borderColor = new Cv.Scalar(0, 0, 255);
        DrawDetectedDiamonds(image, diamondCorners, diamondIds, borderColor);
      }

      public static void DrawDetectedDiamonds(Cv.Mat image, Std.VectorVectorPoint2f diamondCorners)
      {
        Std.VectorVec4i diamondIds = new Std.VectorVec4i();
        DrawDetectedDiamonds(image, diamondCorners, diamondIds);
      }

      public static void DrawDetectedMarkers(Cv.Mat image, Std.VectorVectorPoint2f corners, Std.VectorInt ids, Cv.Scalar borderColor)
      {
        Cv.Exception exception = new Cv.Exception();
        au_drawDetectedMarkers(image.CppPtr, corners.CppPtr, ids.CppPtr, borderColor.CppPtr, exception.CppPtr);
        exception.Check();
      }

      public static void DrawDetectedMarkers(Cv.Mat image, Std.VectorVectorPoint2f diamondCorners, Std.VectorInt ids)
      {
        Cv.Scalar borderColor = new Cv.Scalar(0, 255, 0);
        DrawDetectedMarkers(image, diamondCorners, ids, borderColor);
      }

      public static void DrawDetectedMarkers(Cv.Mat image, Std.VectorVectorPoint2f diamondCorners)
      {
        Std.VectorInt ids = new Std.VectorInt();
        DrawDetectedMarkers(image, diamondCorners, ids);
      }

      public static int EstimatePoseBoard(Std.VectorVectorPoint2f corners, Std.VectorInt ids, Board board, Cv.Mat cameraMatrix, Cv.Mat distCoeffs,
        out Cv.Vec3d rvec, out Cv.Vec3d tvec)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr rvecPtr, tvecPtr;

        int valid = au_estimatePoseBoard(corners.CppPtr, ids.CppPtr, board.CppPtr, cameraMatrix.CppPtr, distCoeffs.CppPtr, out rvecPtr, out tvecPtr,
          exception.CppPtr);
        rvec = new Cv.Vec3d(rvecPtr);
        tvec = new Cv.Vec3d(tvecPtr);

        exception.Check();
        return valid;
      }

      public static bool EstimatePoseCharucoBoard(Std.VectorPoint2f charucoCorners, Std.VectorInt charucoIds, CharucoBoard board,
        Cv.Mat cameraMatrix, Cv.Mat distCoeffs, out Cv.Vec3d rvec, out Cv.Vec3d tvec)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr rvecPtr, tvecPtr;

        bool valid = au_estimatePoseCharucoBoard(charucoCorners.CppPtr, charucoIds.CppPtr, board.CppPtr, cameraMatrix.CppPtr, distCoeffs.CppPtr,
          out rvecPtr, out tvecPtr, exception.CppPtr);
        rvec = new Cv.Vec3d(rvecPtr);
        tvec = new Cv.Vec3d(tvecPtr);

        exception.Check();
        return valid;
      }

      public static void EstimatePoseSingleMarkers(Std.VectorVectorPoint2f corners, float markerLength, Cv.Mat cameraMatrix, Cv.Mat distCoeffs,
        out Std.VectorVec3d rvecs, out Std.VectorVec3d tvecs)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr rvecsPtr, tvecsPtr;

        au_estimatePoseSingleMarkers(corners.CppPtr, markerLength, cameraMatrix.CppPtr, distCoeffs.CppPtr, out rvecsPtr, out tvecsPtr,
          exception.CppPtr);
        rvecs = new Std.VectorVec3d(rvecsPtr);
        tvecs = new Std.VectorVec3d(tvecsPtr);

        exception.Check();
      }

      public static Dictionary GenerateCustomDictionary(int nMarkers, int markerSize, Dictionary baseDictionary)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr dictionaryPtr = au_generateCustomDictionary(nMarkers, markerSize, baseDictionary.CppPtr, exception.CppPtr);
        exception.Check();
        return new Dictionary(dictionaryPtr);
      }

      public static Dictionary GenerateCustomDictionary(int nMarkers, int markerSize)
      {
        Dictionary baseDictionary = new Dictionary();
        return GenerateCustomDictionary(nMarkers, markerSize, baseDictionary);
      }

      public static void GetBoardObjectAndImagePoints(Board board, Std.VectorVectorPoint2f detectedCorners, Std.VectorInt detectedIds,
        out Std.VectorPoint3f objPoints, out Std.VectorPoint2f imgPoints)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr objPointsPtr, imgPointsPtr;

        au_getBoardObjectAndImagePoints(board.CppPtr, detectedCorners.CppPtr, detectedIds.CppPtr, out objPointsPtr, out imgPointsPtr,
          exception.CppPtr);
        objPoints = new Std.VectorPoint3f(objPointsPtr);
        imgPoints = new Std.VectorPoint2f(imgPointsPtr);

        exception.Check();
      }

      public static Dictionary GetPredefinedDictionary(PredefinedDictionaryName name)
      {
        Dictionary dictionary = new Dictionary(au_getPredefinedDictionary(name));
        dictionary.Name = name;
        return dictionary;
      }

      public static int InterpolateCornersCharuco(Std.VectorVectorPoint2f markerCorners, Std.VectorInt markerIds, Cv.Mat image, CharucoBoard board,
        out Std.VectorPoint2f charucoCorners, out Std.VectorInt charucoIds, Cv.Mat cameraMatrix, Cv.Mat distCoeffs)
      {
        Cv.Exception exception = new Cv.Exception();
        System.IntPtr charucoCornersPtr, charucoIdsPtr;

        int interpolateCorners = au_interpolateCornersCharuco(markerCorners.CppPtr, markerIds.CppPtr, image.CppPtr, board.CppPtr,
          out charucoCornersPtr, out charucoIdsPtr, cameraMatrix.CppPtr, distCoeffs.CppPtr, exception.CppPtr);
        charucoCorners = new Std.VectorPoint2f(charucoCornersPtr);
        charucoIds = new Std.VectorInt(charucoIdsPtr);
        exception.Check();

        return interpolateCorners;
      }

      public static int InterpolateCornersCharuco(Std.VectorVectorPoint2f markerCorners, Std.VectorInt markerIds, Cv.Mat image, CharucoBoard board,
        out Std.VectorPoint2f charucoCorners, out Std.VectorInt charucoIds, Cv.Mat cameraMatrix)
      {
        Cv.Mat distCoeffs = new Cv.Mat();
        return InterpolateCornersCharuco(markerCorners, markerIds, image, board, out charucoCorners, out charucoIds, cameraMatrix, distCoeffs);
      }

      public static int InterpolateCornersCharuco(Std.VectorVectorPoint2f markerCorners, Std.VectorInt markerIds, Cv.Mat image, CharucoBoard board,
        out Std.VectorPoint2f charucoCorners, out Std.VectorInt charucoIds)
      {
        Cv.Mat cameraMatrix = new Cv.Mat();
        return InterpolateCornersCharuco(markerCorners, markerIds, image, board, out charucoCorners, out charucoIds, cameraMatrix);
      }

      public static void RefineDetectedMarkers(Cv.Mat image, Board board, Std.VectorVectorPoint2f detectedCorners, Std.VectorInt detectedIds,
        Std.VectorVectorPoint2f rejectedCorners, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, float minRepDistance, float errorCorrectionRate,
        bool checkAllOrders, Std.VectorInt recoveredIdxs, DetectorParameters parameters)
      {
        Cv.Exception exception = new Cv.Exception();
        au_refineDetectedMarkers(image.CppPtr, board.CppPtr, detectedCorners.CppPtr, detectedIds.CppPtr, rejectedCorners.CppPtr, cameraMatrix.CppPtr,
          distCoeffs.CppPtr, minRepDistance, errorCorrectionRate, checkAllOrders, recoveredIdxs.CppPtr, parameters.CppPtr, exception.CppPtr);
        exception.Check();
      }

      public static void RefineDetectedMarkers(Cv.Mat image, Board board, Std.VectorVectorPoint2f detectedCorners, Std.VectorInt detectedIds,
        Std.VectorVectorPoint2f rejectedCorners, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, float minRepDistance, float errorCorrectionRate,
        bool checkAllOrders, Std.VectorInt recoveredIdxs)
      {
        DetectorParameters parameters = new DetectorParameters();
        RefineDetectedMarkers(image, board, detectedCorners, detectedIds, rejectedCorners, cameraMatrix, distCoeffs, minRepDistance,
          errorCorrectionRate, checkAllOrders, recoveredIdxs, parameters);
      }

      public static void RefineDetectedMarkers(Cv.Mat image, Board board, Std.VectorVectorPoint2f detectedCorners, Std.VectorInt detectedIds,
        Std.VectorVectorPoint2f rejectedCorners, Cv.Mat cameraMatrix, Cv.Mat distCoeffs, float minRepDistance = 10f,
        float errorCorrectionRate = 3f, bool checkAllOrders = true)
      {
        Std.VectorInt recoveredIdxs = new Std.VectorInt();
        RefineDetectedMarkers(image, board, detectedCorners, detectedIds, rejectedCorners, cameraMatrix, distCoeffs, minRepDistance,
          errorCorrectionRate, checkAllOrders, recoveredIdxs);
      }

      public static void RefineDetectedMarkers(Cv.Mat image, Board board, Std.VectorVectorPoint2f detectedCorners, Std.VectorInt detectedIds,
        Std.VectorVectorPoint2f rejectedCorners, Cv.Mat cameraMatrix)
      {
        Cv.Mat distCoeffs = new Cv.Mat();
        RefineDetectedMarkers(image, board, detectedCorners, detectedIds, rejectedCorners, cameraMatrix, distCoeffs);
      }

      public static void RefineDetectedMarkers(Cv.Mat image, Board board, Std.VectorVectorPoint2f detectedCorners, Std.VectorInt detectedIds,
        Std.VectorVectorPoint2f rejectedCorners)
      {
        Cv.Mat cameraMatrix = new Cv.Mat();
        RefineDetectedMarkers(image, board, detectedCorners, detectedIds, rejectedCorners, cameraMatrix);
      }
    }
  }

  /// \} aruco_unity_package
}