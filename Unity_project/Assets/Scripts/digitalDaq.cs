using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class digitalDaq : MonoBehaviour
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
    private static extern int DAQmxWriteDigitalScalarU32(ulong taskHandle, bool autoStart, double timeout, uint writeArray, IntPtr reserved);

    [DllImport("nicaiu")]
    private static extern int DAQmxCreateDOChan(ulong taskHandle, string lines, string nameToAssignToLines, int LineGrouping);

    [DllImport("nicaiu")]
    private static extern int DAQmxCreateDIChan(ulong taskHandle, string lines, string nameToAssignToLines, int LineGrouping);

    [DllImport("nicaiu")]
    private static extern int DAQmxCreateCOPulseChanTime(ulong taskHandle, string counter, string nameToAssignToChannel, int units, int idlestate, double initialDelay, double lowTime, double highTime);

    [DllImport("nicaiu")]
    private static extern int DAQmxCreateAIVoltageChan(ulong taskHandle, string physicalChannel, string nameToAssignToChannel, int terminalConfig, double minVal, double maxVal, int units, IntPtr customScaleName);

    [DllImport("nicaiu")]
    private static extern int DAQmxCreateCILinEncoderChan(ulong taskHandle, string counter, string nameToAssignToChannel, int decodingType, bool ZidxEnable, double ZidxVal, int ZidxPhase, int units, double distPerPulse, double initialPos, IntPtr customScaleName);
    //  private static extern int DAQmxCreateCILinEncoderChan(ulong taskHandle, string counter[], string nameToAssignToChannel[], int decodingType, bool ZidxEnable, double ZidxVal, int ZidxPhase, int units, double distPerPulse, double initialPos, IntPtr customScaleName);

    [DllImport("nicaiu")]
    private static extern int DAQmxReadCounterScalarF64(ulong taskHandle, double timeout, ref double value, IntPtr reserved);
    //   private static extern int DAQmxReadCounterScalarF64(ulong taskHandle, double timeout, IntPtr reserved);

    [DllImport("nicaiu")]
    private static extern int DAQmxReadCounterScalarU32(ulong taskHandle, double timeout, ref uint value, IntPtr reserved);

    [DllImport("nicaiu")]
    private static extern int DAQmxReadDigitalLines(ulong taskHandle, int numSampsPerChan, double timeout, bool fillMode, byte[] readArray, uint arraySizeInBytes, ref int sampsPerChanRead, ref int numBytesPerSamp, IntPtr reserved);

    [DllImport("nicaiu")]
    private static extern int DAQmxReadDigitalU8(ulong taskHandle, int numSampsPerChan, double timeout, bool fillMode, uint[] readArray, uint arraySizeInSamps, ref int sampsPerChanRead, IntPtr reserved);

    [DllImport("nicaiu")]
    private static extern int DAQmxCfgSampClkTiming(ulong taskHandle, string source, double rate, int activeEdge, int sampleMode, uint sampsPerChanToAcquire);

    [DllImport("nicaiu")]
    private static extern int DAQmxGetReadAvailSampPerChan(ulong taskHandle, ref uint data);

    [DllImport("nicaiu")]
    private static extern int DAQmxGetReadNumChans(ulong taskHandle, ref uint data);

    [DllImport("nicaiu")]
    private static extern int DAQmxGetReadDigitalLinesBytesPerChan(ulong taskHandle, ref uint data);

    //  ulong taskHandle = 0;
    ulong hEncoder = 0; // handle for encoder
    ulong hReward = 0; // handle for reward delivery
    ulong hAI = 0; // handle for analog input
    ulong hDigitalread = 0; // handle for digital read
                            //   public uint data = 8; // 11
    uint data = 8;
    //ref uint[] dataDigital;
    //    uint[] dataDigital;
   public byte[] dataDigital; // = new byte[] { 5 };
   public byte[] dataRunning; // running array
   public int dataLength = 0; // running track of bytes stored
   public long dataLengthTotal = 0; // total running track of samples stored
    // uint[] dataDigital = new uint[] { 5 };
    //dataDigital = 0;
    public int data2 = 0;
    public int data2old;
    public int data2new;
    uint data_off = 0;
    int written = 0;
    IntPtr reserved = IntPtr.Zero;
    uint DAQmx_Val_Low = 10214;
    uint DAQmx_Val_High = 10192;
    uint DAQmx_Val_Seconds = 10364;
    //DAQmx_Val_Rising = 10280
    // DAQmx_Val_ContSamps                                               10123 // Continuous Samples
    public int statuss = -10;
    public int cstatuss = -10;
    public int sampsRead;
    public int numBytes = 5;
    uint outputVarSampsPerChan = 0;
    public uint numChannels = 0;
    uint bytesPerChan = 0;
    public uint rewardCount = 0;
    double minv = -10;
    double maxv = 10;

    // public uint dataDigitalSize = 0;
    uint numSampsAcquire = 100000;
    public double digitalRate = 1000;

    // Start is called before the first frame update
    void Start()
    {

        DAQmxCreateTask("", ref hEncoder);
        DAQmxCreateCILinEncoderChan(hEncoder, "Dev1/ctr0", "", 10090, true, 0, 10040, 10304, 5000, (double) 0.0f, IntPtr.Zero);
        //  DAQmxCreateCILinEncoderChan(taskHandle, "Dev1/ctr0", "", "DAQmx_Val_X1", true, 0, "DAQmx_Val_AHighBHigh", "DAQmx_Val_Ticks", 5000, 2 ^ 31, IntPtr.Zero);
        DAQmxStartTask(hEncoder);

        DAQmxCreateTask("", ref hReward);
        DAQmxCreateCOPulseChanTime(hReward, "Dev1/ctr1", "", 10364, 10214, 0, 0.001, 0.0140);
        // DAQmxCreateCOPulseChanTime(hReward, "Dev1/ctr1", "", "DAQmx_Val_Seconds", "DAQmx_Val_Low", 1.00, 0.50, 0.0140);

        DAQmxCreateTask("", ref hAI);
        DAQmxCreateAIVoltageChan(hAI,"Dev1/ai0","",-1,minv,maxv,10348,IntPtr.Zero);
        DAQmxCfgSampClkTiming(hAI, "OnboardClock", digitalRate, 10280, 10123, numSampsAcquire);
        cstatuss = DAQmxStartTask(hAI);

        DAQmxCreateTask("", ref hDigitalread);
        DAQmxCreateDIChan(hDigitalread, "Dev1/port0/line5:9", "", 1);
        DAQmxCfgSampClkTiming(hDigitalread, "ai/SampleClock", digitalRate, 10280, 10123, numSampsAcquire);
        //cstatuss = DAQmxCfgSampClkTiming(hDigitalread, "Dev1/ai/SampleClock", 1000, 10280, 10123, 10000);
        statuss = DAQmxStartTask(hDigitalread);
        dataDigital = new byte[100000];

        //cstatuss = DAQmxStartTask(hReward);
        /*
        DAQmxCreateTask("", ref taskHandle);
        DAQmxCreateDOChan(taskHandle, "Dev1/port0/line3", "", 1);
        DAQmxStartTask("digout");
        //  statuss = DAQmxWriteDigitalScalarU32(taskHandle, true, 10.0, data, reserved);
        //   statuss = DAQmxWriteDigitalU32(taskHandle, 4, true, 10.0, true, data, ref written, reserved);

        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DAQmxReadCounterScalarU32(hEncoder, 0.001, ref data, reserved);
        //  statuss = DAQmxReadCounterScalarF64(taskHandle, 10.0, ref data, reserved);
        //  statuss = DAQmxWriteDigitalScalarU32(taskHandle, true, 10.0, data, reserved);
        data2old = data2;
        data2 = (int)data; // - 2 ^ 30;
        data2new = data2;

        // dataDigitalSize should be outputVarSampsPerChan * numChannels * bytesPerChan
         ReadDigital( ref dataDigital);

        // x is first
       byte[] dataTemp = dataRunning;
       dataRunning = new byte[dataLength + sampsRead*numBytes];
       dataTemp.CopyTo(dataRunning, 0);
       Array.Copy(dataDigital,0,dataRunning,dataLength,sampsRead*numBytes);
      // y.CopyTo(dataRunning, x.Length);
       dataLength = dataLength + sampsRead*numBytes;
       dataLengthTotal = dataLengthTotal + sampsRead;
 }
    void Update()
    {
    //ClearDigital();
    }

    public void ReadDigital(ref byte[] tempData)
    {
        int numSamps = -1;
        double tout = 0.001; //-1;

        DAQmxGetReadAvailSampPerChan(hDigitalread, ref outputVarSampsPerChan);
        DAQmxGetReadNumChans(hDigitalread, ref numChannels);
        DAQmxGetReadDigitalLinesBytesPerChan(hDigitalread, ref bytesPerChan);
        uint dataDigitalSize = outputVarSampsPerChan * numChannels * bytesPerChan;
        DAQmxReadDigitalLines(hDigitalread, numSamps, tout, false, tempData, dataDigitalSize, ref sampsRead, ref numBytes, IntPtr.Zero);
    }

    public void ClearDigital()
    {
        dataLength = 0;
        dataRunning = new byte[0];

    }


    public void GiveReward()
    {
        {
        DAQmxStopTask(hReward);
        DAQmxStartTask(hReward);
        rewardCount = rewardCount+1;
        }
    }
    void OnDestroy()
    {

        //  statuss = DAQmxWriteDigitalScalarU32(taskHandle, true, 10.0, data_off, reserved);
        DAQmxStopTask(hEncoder);
        DAQmxStopTask(hReward);
        DAQmxStopTask(hDigitalread);
        DAQmxStopTask(hAI);

        DAQmxClearTask(hEncoder);
        DAQmxClearTask(hReward);
        DAQmxClearTask(hDigitalread);
       DAQmxClearTask(hAI);

        // DAQmxResetDevice(devicename);

    }
}
