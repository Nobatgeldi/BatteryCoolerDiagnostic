using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryCoolerDiagnostic.Covisart
{
    class BackupCodes
    {
        //Console.WriteLine("battery_cooler Job " + MyMsg.Data[0].ToString());
        /*
        if (canMessage.Data[0] == 11)
        {

            Console.WriteLine("Job 11:" + ccmsgArray[index].get_Data(2));
            byte[] dataInt = new byte[8];
            dataInt[0] = ccmsgArray[index].get_Data(0);
            dataInt[1] = 128;
            dataInt[2] = ccmsgArray[index].get_Data(2);
            dataInt[3] = ccmsgArray[index].get_Data(3);
            dataInt[4] = ccmsgArray[index].get_Data(4);
            dataInt[5] = ccmsgArray[index].get_Data(5);
            dataInt[6] = ccmsgArray[index].get_Data(6);
            dataInt[7] = ccmsgArray[index].get_Data(7);

            var hg_pre = BitConverter.ToInt16(dataInt, 1);

            send_can_message_canfox(dataInt, true, battery_cooler_send_id);
        }
        if (canMessage.Data[0] == 14)
        {
            byte[] dataInt = new byte[8];
            var data = BitConverter.GetBytes(234);
            dataInt[0] = ccmsgArray[index].get_Data(0);
            dataInt[1] = data[0];
            dataInt[2] = data[1];
            dataInt[3] = ccmsgArray[index].get_Data(3);
            dataInt[4] = ccmsgArray[index].get_Data(4);
            dataInt[5] = ccmsgArray[index].get_Data(5);
            dataInt[6] = ccmsgArray[index].get_Data(6);
            dataInt[7] = ccmsgArray[index].get_Data(7);

            var hg_pre = BitConverter.ToInt16(dataInt, 1);

            Console.WriteLine("Job 14 Byte 1:" + hg_pre);

            send_can_message_canfox(dataInt, true, battery_cooler_send_id);
        }
        if (canMessage.Data[0] == 251)
        {
            //Console.WriteLine("Data:" + Encoding.ASCII.GetString(myMsg.Data, 1, 1));
            Console.WriteLine("Job 251 Data:" + ccmsgArray[index].get_Data(1));
        }
         */

        /*
        
        if (length == 1)
        {
                        
            if (start >= 8 && start < 16)
            {
                bits = new BitArray(CanFrame.Data[1]);
            }
            else if (start > 16 && start < 24)
            {
                bits = new BitArray(CanFrame.Data[2]);
            }
            else if (start > 24 && start < 32)
            {
                bits = new BitArray(CanFrame.Data[3]);
            }
            else if (start > 32 && start < 40)
            {
                bits = new BitArray(CanFrame.Data[4]);
            }
            else if (start > 40 && start < 48)
            {
                bits = new BitArray(CanFrame.Data[5]);
            }
            else if (start > 48 && start < 56)
            {
                bits = new BitArray(CanFrame.Data[6]);
            }
            else
                bits = new BitArray(CanFrame.Data[7]);
            bool power_st = bits.Get(start);

        }
        else if (length == 8 && group != 251 && group != 252 && group != 253)
        {
            if (start > 8 && start < 16)
            {
                var hg_pre = BitConverter.ToInt16(CanFrame.Data, 1);
            }
        }
        else if (length == 16)
        {
        }

         */
    }
}
