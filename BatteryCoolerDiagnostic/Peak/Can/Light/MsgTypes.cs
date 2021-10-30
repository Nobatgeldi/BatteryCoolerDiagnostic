// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.MsgTypes
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

using System;

namespace Peak.Can.Light
{
  [Flags]
  public enum MsgTypes
  {
    MSGTYPE_STANDARD = 0,
    MSGTYPE_RTR = 1,
    MSGTYPE_EXTENDED = 2,
    MSGTYPE_STATUS = 128, // 0x00000080
  }
}
