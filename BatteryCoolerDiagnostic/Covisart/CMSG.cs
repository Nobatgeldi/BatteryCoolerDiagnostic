using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryCoolerDiagnostic.Covisart
{
    public class CMSG
    {
        private uint m_lId;
        private byte m_byLen;
        private byte m_byMsgLost;
        private byte m_byExtended;
        private byte m_byRemote;
        private byte[] m_abyData;
        private uint m_ulTstamp;

        public CMSG() => this.m_abyData = new byte[8];

        public uint Id
        {
            get => this.m_lId;
            set => this.m_lId = value;
        }

        public byte Len
        {
            get => this.m_byLen;
            set => this.m_byLen = value;
        }

        public byte MsgLost
        {
            get => this.m_byMsgLost;
            set => this.m_byMsgLost = value;
        }

        public byte Extended
        {
            get => this.m_byExtended;
            set => this.m_byExtended = value;
        }

        public byte Remote
        {
            get => this.m_byRemote;
            set => this.m_byRemote = value;
        }

        public uint Tstamp
        {
            get => this.m_ulTstamp;
            set => this.m_ulTstamp = value;
        }

        public unsafe byte get_Data(ushort usNumber)
        {
            if (usNumber <= (ushort)8)
                return this.m_abyData[(int)usNumber];
            return 0;
        }

        public unsafe void set_Data(ushort usNumber, byte ucDatabyte)
        {
            if (usNumber <= (ushort)8)
                this.m_abyData[(int)usNumber] = ucDatabyte;
        }
    }
}
