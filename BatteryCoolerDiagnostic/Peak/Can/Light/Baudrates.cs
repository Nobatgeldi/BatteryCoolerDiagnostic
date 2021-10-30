// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.Baudrates
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

namespace Peak.Can.Light
{
  public enum Baudrates : ushort
  {
    BAUD_1M = 20, // 0x0014
    BAUD_500K = 28, // 0x001C
    BAUD_250K = 284, // 0x011C
    BAUD_125K = 796, // 0x031C
    BAUD_100K = 17199, // 0x432F
    BAUD_50K = 18223, // 0x472F
    BAUD_20K = 21295, // 0x532F
    BAUD_10K = 26415, // 0x672F
    BAUD_5K = 32639, // 0x7F7F
  }
}
