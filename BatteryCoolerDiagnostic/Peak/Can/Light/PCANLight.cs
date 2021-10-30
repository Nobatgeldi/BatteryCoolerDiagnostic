// Decompiled with JetBrains decompiler
// Type: Peak.Can.Light.PCANLight
// Assembly: CAN Tool, Version=1.0.0.16507, Culture=neutral, PublicKeyToken=null
// MVID: F3CD31CB-7674-4A71-ACFD-3BD33500CAD4
// Assembly location: C:\Program Files (x86)\CAN Tool\CAN Tool.exe

using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Peak.Can.Light
{
  public class PCANLight
  {
    public static CANResult Init(
      HardwareType HWType,
      Baudrates BTR0BTR1,
      FramesType MsgType,
      uint IO_Port,
      ushort Interrupt)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.Init((ushort) BTR0BTR1, (int) MsgType, 9, IO_Port, Interrupt);
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.Init((ushort) BTR0BTR1, (int) MsgType, 7, IO_Port, Interrupt);
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.Init((ushort) BTR0BTR1, (int) MsgType, 5, IO_Port, Interrupt);
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult Init(
      HardwareType HWType,
      Baudrates BTR0BTR1,
      FramesType MsgType)
    {
      try
      {
        switch (HWType)
        {
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.Init((ushort) BTR0BTR1, (int) MsgType);
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.Init((ushort) BTR0BTR1, (int) MsgType);
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.Init((ushort) BTR0BTR1, (int) MsgType);
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.Init((ushort) BTR0BTR1, (int) MsgType);
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.Init((ushort) BTR0BTR1, (int) MsgType);
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.Init((ushort) BTR0BTR1, (int) MsgType);
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult Close(HardwareType HWType)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.Close();
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.Close();
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.Close();
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.Close();
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.Close();
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.Close();
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.Close();
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.Close();
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.Close();
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult Status(HardwareType HWType)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.Status();
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.Status();
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.Status();
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.Status();
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.Status();
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.Status();
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.Status();
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.Status();
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.Status();
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult Write(HardwareType HWType, TCLightMsg MsgToSend)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            PCAN_2ISA.TPCANMsg msg2 = (PCAN_2ISA.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_2ISA.Write(ref msg2);
          case HardwareType.PCI_1CH:
            PCAN_PCI.TPCANMsg msg3 = (PCAN_PCI.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_PCI.Write(ref msg3);
          case HardwareType.PCI_2CH:
            PCAN_2PCI.TPCANMsg msg4 = (PCAN_2PCI.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_2PCI.Write(ref msg4);
          case HardwareType.PCC_1CH:
            PCAN_PCC.TPCANMsg msg5 = (PCAN_PCC.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_PCC.Write(ref msg5);
          case HardwareType.PCC_2CH:
            PCAN_2PCC.TPCANMsg msg6 = (PCAN_2PCC.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_2PCC.Write(ref msg6);
          case HardwareType.USB_1CH:
            PCAN_USB.TPCANMsg msg7 = (PCAN_USB.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_USB.Write(ref msg7);
          case HardwareType.USB_2CH:
            PCAN_2USB.TPCANMsg msg8 = (PCAN_2USB.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_2USB.Write(ref msg8);
          case HardwareType.DNP:
            PCAN_DNP.TPCANMsg msg9 = (PCAN_DNP.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_DNP.Write(ref msg9);
          case HardwareType.DNG:
            PCAN_DNG.TPCANMsg msg10 = (PCAN_DNG.TPCANMsg) MsgToSend;
            return (CANResult) PCAN_DNG.Write(ref msg10);
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult Read(HardwareType HWType, out TCLightMsg Msg)
    {
      Msg = (TCLightMsg) null;
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            PCAN_2ISA.TPCANMsg msg2;
            int num2 = (int) PCAN_2ISA.Read(out msg2);
            Msg = new TCLightMsg(msg2);
            return (CANResult) num2;
          case HardwareType.PCI_1CH:
            PCAN_PCI.TPCANMsg msg3 = new PCAN_PCI.TPCANMsg();
            msg3.DATA = new byte[8];
            int num3 = (int) PCAN_PCI.Read(out msg3);
            Msg = new TCLightMsg(msg3);
            return (CANResult) num3;
          case HardwareType.PCI_2CH:
            PCAN_2PCI.TPCANMsg msg4;
            int num4 = (int) PCAN_2PCI.Read(out msg4);
            Msg = new TCLightMsg(msg4);
            return (CANResult) num4;
          case HardwareType.PCC_1CH:
            PCAN_PCC.TPCANMsg msg5;
            int num5 = (int) PCAN_PCC.Read(out msg5);
            Msg = new TCLightMsg(msg5);
            return (CANResult) num5;
          case HardwareType.PCC_2CH:
            PCAN_2PCC.TPCANMsg msg6;
            int num6 = (int) PCAN_2PCC.Read(out msg6);
            Msg = new TCLightMsg(msg6);
            return (CANResult) num6;
          case HardwareType.USB_1CH:
            PCAN_USB.TPCANMsg msg7;
            int num7 = (int) PCAN_USB.Read(out msg7);
            Msg = new TCLightMsg(msg7);
            return (CANResult) num7;
          case HardwareType.USB_2CH:
            PCAN_2USB.TPCANMsg msg8;
            int num8 = (int) PCAN_2USB.Read(out msg8);
            Msg = new TCLightMsg(msg8);
            return (CANResult) num8;
          case HardwareType.DNP:
            PCAN_DNP.TPCANMsg msg9;
            int num9 = (int) PCAN_DNP.Read(out msg9);
            Msg = new TCLightMsg(msg9);
            return (CANResult) num9;
          case HardwareType.DNG:
            PCAN_DNG.TPCANMsg msg10;
            int num10 = (int) PCAN_DNG.Read(out msg10);
            Msg = new TCLightMsg(msg10);
            return (CANResult) num10;
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult ReadEx(
      HardwareType HWType,
      out TCLightMsg Msg,
      out TCLightTimestamp RcvTime)
    {
      Msg = (TCLightMsg) null;
      RcvTime = (TCLightTimestamp) null;
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            PCAN_2ISA.TPCANMsg msg2;
            PCAN_2ISA.TPCANTimestamp timestamp2;
            int num2 = (int) PCAN_2ISA.ReadEx(out msg2, out timestamp2);
            Msg = new TCLightMsg(msg2);
            RcvTime = new TCLightTimestamp(timestamp2);
            return (CANResult) num2;
          case HardwareType.PCI_1CH:
            PCAN_PCI.TPCANMsg msg3;
            PCAN_PCI.TPCANTimestamp timestamp3;
            int num3 = (int) PCAN_PCI.ReadEx(out msg3, out timestamp3);
            Msg = new TCLightMsg(msg3);
            RcvTime = new TCLightTimestamp(timestamp3);
            return (CANResult) num3;
          case HardwareType.PCI_2CH:
            PCAN_2PCI.TPCANMsg msg4;
            PCAN_2PCI.TPCANTimestamp timestamp4;
            int num4 = (int) PCAN_2PCI.ReadEx(out msg4, out timestamp4);
            Msg = new TCLightMsg(msg4);
            RcvTime = new TCLightTimestamp(timestamp4);
            return (CANResult) num4;
          case HardwareType.PCC_1CH:
            PCAN_PCC.TPCANMsg msg5;
            PCAN_PCC.TPCANTimestamp timestamp5;
            int num5 = (int) PCAN_PCC.ReadEx(out msg5, out timestamp5);
            Msg = new TCLightMsg(msg5);
            RcvTime = new TCLightTimestamp(timestamp5);
            return (CANResult) num5;
          case HardwareType.PCC_2CH:
            PCAN_2PCC.TPCANMsg msg6;
            PCAN_2PCC.TPCANTimestamp timestamp6;
            int num6 = (int) PCAN_2PCC.ReadEx(out msg6, out timestamp6);
            Msg = new TCLightMsg(msg6);
            RcvTime = new TCLightTimestamp(timestamp6);
            return (CANResult) num6;
          case HardwareType.USB_1CH:
            PCAN_USB.TPCANMsg msg7;
            PCAN_USB.TPCANTimestamp timestamp7;
            int num7 = (int) PCAN_USB.ReadEx(out msg7, out timestamp7);
            Msg = new TCLightMsg(msg7);
            RcvTime = new TCLightTimestamp(timestamp7);
            return (CANResult) num7;
          case HardwareType.USB_2CH:
            PCAN_2USB.TPCANMsg msg8;
            PCAN_2USB.TPCANTimestamp timestamp8;
            int num8 = (int) PCAN_2USB.ReadEx(out msg8, out timestamp8);
            Msg = new TCLightMsg(msg8);
            RcvTime = new TCLightTimestamp(timestamp8);
            return (CANResult) num8;
          case HardwareType.DNP:
            PCAN_DNP.TPCANMsg msg9;
            PCAN_DNP.TPCANTimestamp timestamp9;
            int num9 = (int) PCAN_DNP.ReadEx(out msg9, out timestamp9);
            Msg = new TCLightMsg(msg9);
            RcvTime = new TCLightTimestamp(timestamp9);
            return (CANResult) num9;
          case HardwareType.DNG:
            PCAN_DNG.TPCANMsg msg10;
            PCAN_DNG.TPCANTimestamp timestamp10;
            int num10 = (int) PCAN_DNG.ReadEx(out msg10, out timestamp10);
            Msg = new TCLightMsg(msg10);
            RcvTime = new TCLightTimestamp(timestamp10);
            return (CANResult) num10;
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (EntryPointNotFoundException ex)
      {
        int num = (int) MessageBox.Show("Error: Wrong Version. \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult VersionInfo(HardwareType HWType, out string strInfo)
    {
      strInfo = "";
      try
      {
        StringBuilder buffer = new StringBuilder(256);
        CANResult canResult;
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            canResult = (CANResult) PCAN_2ISA.VersionInfo(buffer);
            break;
          case HardwareType.PCI_1CH:
            canResult = (CANResult) PCAN_PCI.VersionInfo(buffer);
            break;
          case HardwareType.PCI_2CH:
            canResult = (CANResult) PCAN_2PCI.VersionInfo(buffer);
            break;
          case HardwareType.PCC_1CH:
            canResult = (CANResult) PCAN_PCC.VersionInfo(buffer);
            break;
          case HardwareType.PCC_2CH:
            canResult = (CANResult) PCAN_2PCC.VersionInfo(buffer);
            break;
          case HardwareType.USB_1CH:
            canResult = (CANResult) PCAN_USB.VersionInfo(buffer);
            break;
          case HardwareType.USB_2CH:
            canResult = (CANResult) PCAN_2USB.VersionInfo(buffer);
            break;
          case HardwareType.DNP:
            canResult = (CANResult) PCAN_DNP.VersionInfo(buffer);
            break;
          case HardwareType.DNG:
            canResult = (CANResult) PCAN_DNG.VersionInfo(buffer);
            break;
          default:
            buffer = new StringBuilder("");
            canResult = CANResult.ERR_ILLHW;
            break;
        }
        strInfo = buffer.ToString();
        return canResult;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult DllVersionInfo(HardwareType HWType, out string strInfo)
    {
      strInfo = "";
      try
      {
        StringBuilder buffer = new StringBuilder(256);
        CANResult canResult;
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            canResult = (CANResult) PCAN_2ISA.DLLVersionInfo(buffer);
            break;
          case HardwareType.PCI_1CH:
            canResult = (CANResult) PCAN_PCI.DLLVersionInfo(buffer);
            break;
          case HardwareType.PCI_2CH:
            canResult = (CANResult) PCAN_2PCI.DLLVersionInfo(buffer);
            break;
          case HardwareType.PCC_1CH:
            canResult = (CANResult) PCAN_PCC.DLLVersionInfo(buffer);
            break;
          case HardwareType.PCC_2CH:
            canResult = (CANResult) PCAN_2PCC.DLLVersionInfo(buffer);
            break;
          case HardwareType.USB_1CH:
            canResult = (CANResult) PCAN_USB.DLLVersionInfo(buffer);
            break;
          case HardwareType.USB_2CH:
            canResult = (CANResult) PCAN_2USB.DLLVersionInfo(buffer);
            break;
          case HardwareType.DNP:
            canResult = (CANResult) PCAN_DNP.DLLVersionInfo(buffer);
            break;
          case HardwareType.DNG:
            canResult = (CANResult) PCAN_DNG.DLLVersionInfo(buffer);
            break;
          default:
            buffer = new StringBuilder("");
            canResult = CANResult.ERR_ILLHW;
            break;
        }
        strInfo = buffer.ToString();
        return canResult;
      }
      catch (EntryPointNotFoundException ex)
      {
        int num = (int) MessageBox.Show("Error: Wrong Version. \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult ResetClient(HardwareType HWType)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.ResetClient();
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.ResetClient();
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.ResetClient();
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.ResetClient();
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.ResetClient();
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.ResetClient();
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.ResetClient();
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.ResetClient();
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.ResetClient();
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult MsgFilter(
      HardwareType HWType,
      uint From,
      uint To,
      MsgTypes MsgType)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.MsgFilter(From, To, (int) MsgType);
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.MsgFilter(From, To, (int) MsgType);
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.MsgFilter(From, To, (int) MsgType);
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.MsgFilter(From, To, (int) MsgType);
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.MsgFilter(From, To, (int) MsgType);
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.MsgFilter(From, To, (int) MsgType);
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.MsgFilter(From, To, (int) MsgType);
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.MsgFilter(From, To, (int) MsgType);
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.MsgFilter(From, To, (int) MsgType);
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult ResetFilter(HardwareType HWType)
    {
      try
      {
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.ResetFilter();
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.ResetFilter();
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.ResetFilter();
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.ResetFilter();
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.ResetFilter();
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.ResetFilter();
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.ResetFilter();
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.ResetFilter();
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.ResetFilter();
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult SetUSBDeviceNr(HardwareType HWType, uint DeviceNumber)
    {
      try
      {
        if (HWType == HardwareType.USB_1CH)
          return (CANResult) PCAN_USB.SetUSBDeviceNr(DeviceNumber);
        return HWType == HardwareType.USB_2CH ? (CANResult) PCAN_2USB.SetUSBDeviceNr(DeviceNumber) : CANResult.ERR_ILLHW;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult GetUSBDeviceNr(HardwareType HWType, out uint DeviceNumber)
    {
      DeviceNumber = uint.MaxValue;
      try
      {
        if (HWType == HardwareType.USB_1CH)
          return (CANResult) PCAN_USB.GetUSBDeviceNr(out DeviceNumber);
        return HWType == HardwareType.USB_2CH ? (CANResult) PCAN_2USB.GetUSBDeviceNr(out DeviceNumber) : CANResult.ERR_ILLHW;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }

    public static CANResult SetRcvEvent(HardwareType HWType, EventWaitHandle EventHandle)
    {
      try
      {
        IntPtr hEvent = EventHandle == null ? IntPtr.Zero : EventHandle.SafeWaitHandle.DangerousGetHandle();
        switch (HWType)
        {
            case HardwareType.ISA_2CH:
            return (CANResult) PCAN_2ISA.SetRcvEvent(hEvent);
          case HardwareType.PCI_1CH:
            return (CANResult) PCAN_PCI.SetRcvEvent(hEvent);
          case HardwareType.PCI_2CH:
            return (CANResult) PCAN_2PCI.SetRcvEvent(hEvent);
          case HardwareType.PCC_1CH:
            return (CANResult) PCAN_PCC.SetRcvEvent(hEvent);
          case HardwareType.PCC_2CH:
            return (CANResult) PCAN_2PCC.SetRcvEvent(hEvent);
          case HardwareType.USB_1CH:
            return (CANResult) PCAN_USB.SetRcvEvent(hEvent);
          case HardwareType.USB_2CH:
            return (CANResult) PCAN_2USB.SetRcvEvent(hEvent);
          case HardwareType.DNP:
            return (CANResult) PCAN_DNP.SetRcvEvent(hEvent);
          case HardwareType.DNG:
            return (CANResult) PCAN_DNG.SetRcvEvent(hEvent);
          default:
            return CANResult.ERR_ILLHW;
        }
      }
      catch (EntryPointNotFoundException ex)
      {
        int num = (int) MessageBox.Show("Error: Wrong Version. \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: \"" + ex.Message + "\"");
        return CANResult.ERR_NO_DLL;
      }
    }
  }
}
