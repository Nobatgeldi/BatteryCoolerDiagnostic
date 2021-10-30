// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.PCAN_DNP
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Peak.Can.Light
{
  public class PCAN_DNP
  {
    public const int HW_DONGLE_PRO = 7;
    public const int HW_DONGLE_PRO_EPP = 8;
    public const int CAN_INIT_TYPE_EX = 1;
    public const int CAN_INIT_TYPE_ST = 0;
    public const int CAN_MAX_STANDARD_ID = 2047;
    public const int CAN_MAX_EXTENDED_ID = 536870911;
    public const int MSGTYPE_STANDARD = 0;
    public const int MSGTYPE_RTR = 1;
    public const int MSGTYPE_EXTENDED = 2;
    public const int MSGTYPE_STATUS = 128;
    public const int CAN_BAUD_1M = 20;
    public const int CAN_BAUD_500K = 28;
    public const int CAN_BAUD_250K = 284;
    public const int CAN_BAUD_125K = 796;
    public const int CAN_BAUD_100K = 17199;
    public const int CAN_BAUD_50K = 18223;
    public const int CAN_BAUD_20K = 21295;
    public const int CAN_BAUD_10K = 26415;
    public const int CAN_BAUD_5K = 32639;
    public const int ERR_OK = 0;
    public const int ERR_XMTFULL = 1;
    public const int ERR_OVERRUN = 2;
    public const int ERR_BUSLIGHT = 4;
    public const int ERR_BUSHEAVY = 8;
    public const int ERR_BUSOFF = 16;
    public const int ERR_QRCVEMPTY = 32;
    public const int ERR_QOVERRUN = 64;
    public const int ERR_QXMTFULL = 128;
    public const int ERR_REGTEST = 256;
    public const int ERR_NOVXD = 512;
    public const int ERR_NODRIVER = 512;
    public const int ERRMASK_ILLHANDLE = 7168;
    public const int ERR_HWINUSE = 1024;
    public const int ERR_NETINUSE = 2048;
    public const int ERR_ILLHW = 5120;
    public const int ERR_ILLNET = 6144;
    public const int ERR_ILLCLIENT = 7168;
    public const int ERR_RESOURCE = 8192;
    public const int ERR_ILLPARAMTYPE = 16384;
    public const int ERR_ILLPARAMVAL = 32768;
    public const int ERR_UNKNOWN = 65536;
    public const int ERR_ANYBUSERR = 28;

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_Init")]
    public static extern uint Init(
      ushort BTR0BTR1,
      int CANMsgType,
      int CANHwType,
      uint IO_Port,
      ushort Interupt);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_Close")]
    public static extern uint Close();

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_Status")]
    public static extern uint Status();

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_Write")]
    public static extern uint Write(ref PCAN_DNP.TPCANMsg msg);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_Read")]
    public static extern uint Read(out PCAN_DNP.TPCANMsg msg);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_ReadEx")]
    public static extern uint ReadEx(
      out PCAN_DNP.TPCANMsg msg,
      out PCAN_DNP.TPCANTimestamp timestamp);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_VersionInfo")]
    public static extern uint VersionInfo(StringBuilder buffer);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_DLLVersionInfo")]
    public static extern uint DLLVersionInfo(StringBuilder buffer);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_ResetClient")]
    public static extern uint ResetClient();

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_MsgFilter")]
    public static extern uint MsgFilter(uint FromID, uint ToID, int Type);

    [DllImport("PCAN_DNP.dll", EntryPoint = "CAN_ResetFilter")]
    public static extern uint ResetFilter();

    [DllImport("PCAN_DNG.dll", EntryPoint = "CAN_SetRcvEvent")]
    public static extern uint SetRcvEvent(IntPtr hEvent);

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TPCANMsg
    {
      public uint ID;
      public byte MSGTYPE;
      public byte LEN;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
      public byte[] DATA;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TPCANTimestamp
    {
      public uint millis;
      public ushort millis_overflow;
      public ushort micros;
    }
  }
}
