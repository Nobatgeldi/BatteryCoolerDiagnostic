// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.TCLightTimestamp
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

namespace Peak.Can.Light
{
  public class TCLightTimestamp
  {
    public uint millis;
    public ushort millis_overflow;
    public ushort micros;

    public TCLightTimestamp()
    {
      this.millis = 0U;
      this.micros = (ushort) 0;
      this.millis_overflow = (ushort) 0;
    }


    public TCLightTimestamp(PCAN_2ISA.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_PCI.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_2PCI.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_PCC.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_2PCC.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_USB.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_2USB.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_DNG.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public TCLightTimestamp(PCAN_DNP.TPCANTimestamp RcvTime)
    {
      this.millis = RcvTime.millis;
      this.millis_overflow = RcvTime.millis_overflow;
      this.micros = RcvTime.micros;
    }

    public static implicit operator PCAN_2ISA.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_2ISA.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_PCI.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_PCI.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_2PCI.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_2PCI.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_PCC.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_PCC.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_2PCC.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_2PCC.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_USB.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_USB.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_2USB.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_2USB.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_DNG.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_DNG.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };

    public static implicit operator PCAN_DNP.TPCANTimestamp(TCLightTimestamp RcvTime) => new PCAN_DNP.TPCANTimestamp()
    {
      millis = RcvTime.millis,
      millis_overflow = RcvTime.millis_overflow,
      micros = RcvTime.micros
    };
  }
}
