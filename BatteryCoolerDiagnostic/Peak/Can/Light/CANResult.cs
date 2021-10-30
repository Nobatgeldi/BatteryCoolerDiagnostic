// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.CANResult
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

using System;

namespace Peak.Can.Light
{
  [Flags]
  public enum CANResult : uint
  {
    ERR_OK = 0,
    ERR_XMTFULL = 1,
    ERR_OVERRUN = 2,
    ERR_BUSLIGHT = 4,
    ERR_BUSHEAVY = 8,
    ERR_BUSOFF = 16, // 0x00000010
    ERR_QRCVEMPTY = 32, // 0x00000020
    ERR_QOVERRUN = 64, // 0x00000040
    ERR_QXMTFULL = 128, // 0x00000080
    ERR_REGTEST = 256, // 0x00000100
    ERR_NOVXD = 512, // 0x00000200
    ERRMASK_ILLHANDLE = 7168, // 0x00001C00
    ERR_HWINUSE = 1024, // 0x00000400
    ERR_NETINUSE = 2048, // 0x00000800
    ERR_ILLHW = 5120, // 0x00001400
    ERR_ILLNET = 6144, // 0x00001800
    ERR_ILLCLIENT = ERR_ILLNET | ERR_HWINUSE, // 0x00001C00
    ERR_RESOURCE = 8192, // 0x00002000
    ERR_PARMTYP = 16384, // 0x00004000
    ERR_PARMVAL = 32768, // 0x00008000
    ERR_ANYBUSERR = ERR_BUSOFF | ERR_BUSHEAVY | ERR_BUSLIGHT, // 0x0000001C
    ERR_NO_DLL = 4294967295, // 0xFFFFFFFF
  }
}
