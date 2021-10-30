// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.TCLightMsg
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

namespace Peak.Can.Light
{
  public class TCLightMsg
  {
    public uint ID;
    public MsgTypes MsgType;
    public byte Len;
    public byte[] Data;

    public TCLightMsg() => this.Data = new byte[8];
    public TCLightMsg(PCAN_2ISA.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_PCI.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_2PCI.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_PCC.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_2PCC.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_USB.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_2USB.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_DNG.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }

    public TCLightMsg(PCAN_DNP.TPCANMsg Msg)
    {
      this.ID = Msg.ID;
      this.MsgType = (MsgTypes) Msg.MSGTYPE;
      this.Len = Msg.LEN;
      this.Data = Msg.DATA;
    }
    
    public static implicit operator PCAN_2ISA.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_2ISA.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_PCI.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_PCI.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_2PCI.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_2PCI.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_PCC.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_PCC.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_2PCC.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_2PCC.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_USB.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_USB.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_2USB.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_2USB.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_DNG.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_DNG.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }

    public static implicit operator PCAN_DNP.TPCANMsg(TCLightMsg Msg)
    {
      PCAN_DNP.TPCANMsg tpcanMsg;
      tpcanMsg.ID = Msg.ID;
      tpcanMsg.LEN = Msg.Len;
      tpcanMsg.MSGTYPE = (byte) Msg.MsgType;
      tpcanMsg.DATA = Msg.Data;
      return tpcanMsg;
    }
  }
}
