using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
public class NIdaq_RF2 : MonoBehaviour
{
	//imports
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

	[DllImport("nicaiu")]
	private static extern int DAQmxResetDevice(byte[] deviceName);

	/*	[DllImport("nicaiu")]
		private static extern int DAQmxCfgSampClkTiming(ulong taskHandle, byte[] source, double rate, int activeEdge, int sampleMode, ulong sampsPerChanToAcquire);*/

	//variables
	public double[] data = new double[] { 5.0 };
	public int statuss = 0;
	ulong taskHandle = 0;
	int written = 0;
	//these were in the start section with the functions
	IntPtr reserved = IntPtr.Zero;
	const uint DAQmx_Val_GroupByChannel = 0;
	double vmin = -5;
	double vmax = 5;
	byte[] namesToAssignToChannels = System.Text.Encoding.ASCII.GetBytes("" + '\0'); //MakeCString("");
	byte[] physicalchannels = System.Text.Encoding.ASCII.GetBytes("Dev1/ao0" + '\0');
	int volts = 10348;
	byte[] devicename = System.Text.Encoding.ASCII.GetBytes("Dev1");
	// digital variables

	
	void Start()
    {
		DAQmxCreateTask("", ref taskHandle);
		DAQmxCreateAOVoltageChan(taskHandle, physicalchannels, namesToAssignToChannels, vmin, vmax, volts, IntPtr.Zero);
		DAQmxStartTask(taskHandle);
	}
	public void LED(int feed)
	{

		//turn on function
		if (feed == 1)
		{
			//	DAQmxCfgSampClkTiming(taskHandle, source, samplesPerSec, DAQmx_Val_Rising, DAQmx_Val_ContSamps, sampleBufferSize);
			data[0] = 5.0;
		
			statuss = DAQmxWriteAnalogF64(taskHandle, 1, false, 0, DAQmx_Val_GroupByChannel, data, ref written, reserved);
		}
		else
			//turnoff function
			if (feed == 2)
		{

            data[0] = 0.0;

            statuss = DAQmxWriteAnalogF64(taskHandle, 1, false, 0, DAQmx_Val_GroupByChannel, data, ref written, reserved);

        } }




        void OnDestroy()
        {
            DAQmxStopTask(taskHandle);
            DAQmxClearTask(taskHandle);
		// DAQmxResetDevice(devicename);

	}
    }

