using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;


public class NIdaq : MonoBehaviour
{

	[DllImport("nicaiu")]
	private static extern int DAQmxCreateTask(string taskName, ref ulong taskHandle);

	[DllImport("nicaiu")]
	private static extern int DAQmxStartTask(ulong taskHandle);

	[DllImport("nicaiu")]
	private static extern int DAQmxStopTask(ulong taskHandle);

	[DllImport("nicaiu")]
	private static extern int DAQmxClearTask(ulong taskHandle);

	[DllImport("nicaiu")]
	private static extern int DAQmxWriteDigitalU32(ulong taskHandle, int numSampsPerChan, bool autoStart, double timeout, bool dataLayout, uint writeArray, ref int sampsPerChanWritten, IntPtr reserved);

	[DllImport("nicaiu")]
	private static extern int DAQmxCreateDOChan(ulong taskHandle, string lines, string nameToAssignToLines, int LineGrouping);

	[DllImport("nicaiu")]
	private static extern int DAQmxCreateAOVoltageChan(ulong taskHandle, byte[] physicalChannel, byte[] nameToAssignToChannel, double minVal, double maxVal, int units, IntPtr customScaleName);

	[DllImport("nicaiu")]
	private static extern int DAQmxWriteAnalogF64(ulong taskHandle, int numSampsPerChan, bool autoStart, double timeout, uint dataLayout, double[] writeArray, ref int sampsPerChanWritten, IntPtr reserved);
	
	public int status = 0;
	/*public float[] data = new float[] { 5.0f, 10.0f };*/
	public double[] data = new double[] { 5.0 };
	//public double[] test = new double[] { 5.0};
	//public double data = 5;
	public int statuss = 0;
	ulong taskHandle = 0;
	int written = 0;
	public double[] timing = new double[] { 3.33, 5.01, 12, 12.12 };



	void Start()
	{

		/*int error = 0;*/

		IntPtr reserved = IntPtr.Zero;
		const uint DAQmx_Val_GroupByChannel = 0;

		// Analog variables
		double vmin = -5;
		double vmax = 5;
	//	data[0] = 0; //data = (0 % 3 == 0) ? 0 : (0 % 3 == 1) ? vmax : vmin;
		byte[] namesToAssignToChannels = System.Text.Encoding.ASCII.GetBytes("" + '\0'); //MakeCString("");
		byte[] physicalchannels = System.Text.Encoding.ASCII.GetBytes("Dev1/ao0" + '\0');
		int volts = 10348;
		/*			string taskName = "Task" + unixMs.ToString();
					byte[] taskNameC = MakeCString(taskName);*/
		/*char errBuff[] = { '\0' };*/
		/*********************************************/
		// DAQmx Configure Code

			DAQmxCreateTask("", ref taskHandle);
		/*DAQmxCreateDOChan(taskHandle, "Dev2/port0/line3", "", 1);*/
		DAQmxCreateAOVoltageChan(taskHandle, physicalchannels, namesToAssignToChannels, vmin, vmax, volts, IntPtr.Zero);
		//DAQmxCreateAOVoltageChan(taskHandle, "Dev1/ao0", "", vmin, vmax, 10348, IntPtr.Zero);


		/*********************************************//*
		// DAQmx Start Code
		*//*********************************************/
		DAQmxStartTask(taskHandle);
		statuss = DAQmxWriteAnalogF64(taskHandle, 1, false, 0, DAQmx_Val_GroupByChannel, data, ref written, reserved);
	}

	void Update()
			{
		if (status == 1)
		{
			/*********************************************//*
			// DAQmx Write Code
			*//*********************************************/
			// statuss = DAQmxWriteDigitalU32(taskHandle, 1, true, 10.0, DAQmx_Val_GroupByChannel, data, ref written, reserved);
			//DAQmxWriteAnalogF64(taskHandle, 1, false, 0, DAQmx_Val_GroupByChannel, test, ref written, reserved);

			//	DAQmxStopTask(taskHandle);
		}
			}

			/*		if (status == 0) {
						*//*	int error = 0;*//*
						TaskHandle taskHandle = 0;
						uInt32 data = 0;
						*//*char errBuff[] = { '\0' };*//*
						int32 written;


						*//*********************************************//*
						 // DAQmx Configure Code

						DAQmxCreateTask("", &taskHandle);
						DAQmxCreateDOChan(taskHandle, "Dev1/port0", "", DAQmx_Val_ChanForAllLines);

						*//*********************************************//*
						 // DAQmx Start Code
						*//*********************************************//*
						DAQmxStartTask(taskHandle);

						*//*********************************************//*
						 // DAQmx Write Code
						*//*********************************************//*
						DAQmxWriteDigitalU32(taskHandle, 1, 1, 10.0, DAQmx_Val_GroupByChannel, &data, &written, reserved);
					} */

	void OnDestroy()
	{
		DAQmxStopTask(taskHandle);
		DAQmxClearTask(taskHandle);


	}

}
