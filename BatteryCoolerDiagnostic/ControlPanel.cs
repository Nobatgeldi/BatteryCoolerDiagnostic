using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BatteryCoolerDiagnostic.Covisart;
using BatteryCoolerDiagnostic.Properties;
using Newtonsoft.Json;
using Peak.Can.Light;
using SiE.SiEAPI_Interface;
using SiE.SiEAPI_Interface.SiEAPI_InterfaceTypes;

namespace BatteryCoolerDiagnostic
{
    public partial class ControlPanel : Form
    {
        private readonly CCanChannel _cCanChannelUsbCh1;
        private readonly CDevice _device;
        private delegate void ReadDelegateHandler();
        private ReadDelegateHandler _readDelegate;
        private TCLightMsg _canMessage;
        private readonly BindingList<CANSTATE> _canStateList;
        private List<CANDATA> _canDataList;

        private const int BatteryCoolerSendId = 1501;
        private const int BatteryCoolerReceiveId = 1500;

        private eErrorCodesCanChannel _eRet;
        private uint _uiLen = 1;

        public ControlPanel(CCanChannel canChannelUsbCh1, CDevice device)
        {
            InitializeComponent();
            LoadJson();

            this._cCanChannelUsbCh1 = canChannelUsbCh1;
            this._device = device;

            // Allow new parts to be added, but not removed once committed.        
            _canStateList = new BindingList<CANSTATE>
            {
                AllowNew = true, AllowRemove = true, RaiseListChangedEvents = true
            };
            _canStateList.ListChanged += OnListChanged; ;
            temperatureChart.Series.Clear();
            // Set title
            this.temperatureChart.Titles.Add("Temperature by Time");
            var series = this.temperatureChart.Series.Add("Temperature by Time");
            series.ChartType = SeriesChartType.Spline;
            series.XValueMember="°C";
            series.Points.AddXY("1", 25);
            series.Points.AddXY("2", 30);
            series.Points.AddXY("3", 40);
            series.Points.AddXY("4", 45);
            series.Points.AddXY("5", 48);
            series.Points.AddXY("6", 55);

        }
        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            foreach (var canState in _canStateList)
            {
                Console.WriteLine(canState.ToString());
                //LogBox.AppendText(canState.Name + ": " + canState.Message+ " " + canState.Unit);
                //LogBox.AppendText(Environment.NewLine);
            }
        }

        private void tmrRead_CanFox_Tick()
        {
            var counterData = new CCounterData();

            //The function fetches counter information like number of received messages.
            _eRet = _cCanChannelUsbCh1.CanGetCounterExtended(counterData);
            if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS) return;

            var ccmsgArray = new CCMSG[(int)counterData.RxFrameCtr];

            for (var index = 0; index < counterData.RxFrameCtr + counterData.ErxFrameCtr; ++index)
            {
                ccmsgArray[index] = new CCMSG();
                _eRet = _cCanChannelUsbCh1.CanRead(ccmsgArray[index]);

                if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS) return;

                _canMessage = new TCLightMsg
                {
                    ID = ccmsgArray[index].Id,
                    Len = ccmsgArray[index].Len
                };
                switch (ccmsgArray[index].Extended)
                {
                    case 0:
                        _canMessage.MsgType = MsgTypes.MSGTYPE_STANDARD;
                        break;
                    case 1:
                        _canMessage.MsgType = MsgTypes.MSGTYPE_EXTENDED;
                        break;
                }

                _canMessage.Data[0] = ccmsgArray[index].get_Data(0);
                _canMessage.Data[1] = ccmsgArray[index].get_Data(1);
                _canMessage.Data[2] = ccmsgArray[index].get_Data(2);
                _canMessage.Data[3] = ccmsgArray[index].get_Data(3);
                _canMessage.Data[4] = ccmsgArray[index].get_Data(4);
                _canMessage.Data[5] = ccmsgArray[index].get_Data(5);
                _canMessage.Data[6] = ccmsgArray[index].get_Data(6);
                _canMessage.Data[7] = ccmsgArray[index].get_Data(7);

                //message_parser_battery_cooler(_canMessage);

                if ((int)_canMessage.ID == BatteryCoolerReceiveId)
                    message_parser_battery_cooler(_canMessage);
                else
                    MessageBox.Show(@"This device is not battery cooler:" + (int)_canMessage.ID);
            }
            var num1 = _cCanChannelUsbCh1.CanResetCounter();
            var num2 = _cCanChannelUsbCh1.CanClearBuffer();
        }
        private void message_parser_battery_cooler(TCLightMsg canFrame)
        {
            var tempCanStateList = new BindingList<CANSTATE>();

            if(_canDataList ==null) return;

            foreach (var canData in _canDataList)
            {
                try
                {
                    var group = Convert.ToInt32(canData.MultiplexingGroup, 16);
                    var messageId = Convert.ToInt32(canData.MessageID, 16);
                    var start = int.Parse(canData.Startbit);
                    var length = int.Parse(canData.LengthBit);
                    
                    object value = 0;
                    if (_canMessage.Data[0] != @group) continue;
                    switch (length)
                    {
                        case 1:
                            var bits = new BitArray(canFrame.Data);
                            value = bits.Get(start);
                            break;
                        case 8:
                            value = _canMessage.Data[StartByte(start)];
                            break;

                        case 16:
                            value = BitConverter.ToInt16(_canMessage.Data, StartByte(start));
                            break;
                    }
                    var tempCanState = new CANSTATE
                    {
                        Name = canData.Name, Message = value, Unit = canData.Unit, Length = length
                    };
                    //Console.WriteLine(tempCanState.ToString());
                    tempCanStateList.Add(tempCanState);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            this.Invoke(new Action(() => this.UpdateUi(tempCanStateList)));

        }

        private void UpdateUi(IEnumerable<CANSTATE> dataList)
        {
            _canStateList.Clear();
            foreach (var item in dataList)
            {
                _canStateList.Add(item);
            }
        }

        private void send_can_message_canfox(byte[] dataBytes, bool feedback = true, uint sendId = 0)
        {
            var aCMessage = new CCMSG[1] { new CCMSG() };
            if (sendId == 0U)
                aCMessage[0].Id = BatteryCoolerSendId;
            else if (sendId != 0U)
                aCMessage[0].Id = sendId;

            aCMessage[0].Remote = (byte)0;
            aCMessage[0].Len = (byte)8;
            aCMessage[0].set_Data((ushort)0, dataBytes[0]);
            aCMessage[0].set_Data((ushort)1, dataBytes[1]);
            aCMessage[0].set_Data((ushort)2, dataBytes[2]);
            aCMessage[0].set_Data((ushort)3, dataBytes[3]);
            aCMessage[0].set_Data((ushort)4, dataBytes[4]);
            aCMessage[0].set_Data((ushort)5, dataBytes[5]);
            aCMessage[0].set_Data((ushort)6, dataBytes[6]);
            aCMessage[0].set_Data((ushort)7, dataBytes[7]);
            _eRet = this._cCanChannelUsbCh1.CanSend(aCMessage, ref this._uiLen);
            if (!feedback)
                return;
            if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS)
            {
                Console.WriteLine($"STATUS:{_eRet}");
            }
            else
            {
                Console.WriteLine($"STATUS:{_eRet}");
            }
        }
        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            canbus_thread.CancelAsync();
            this.DialogResult = DialogResult.OK;

        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            if(_device != null)
             Text = Text + @" - Bağlı Cihaz: " + _device.Name;
            var canData = JsonConvert.SerializeObject(_canDataList, Formatting.Indented);
            configDisplay.AppendText(canData);

            canbus_thread.RunWorkerAsync();
        }

        private void LoadJson()
        {
            var tempData= new List<CANDATA>();
            try
            {
                _canDataList = JsonConvert.DeserializeObject<List<CANDATA>>(Resources.Parameters);
                if (_canDataList == null) return;
                /*foreach (var errorLabel in from canData in _canDataList where canData.Name.Contains("err") select new Label
                {
                    AutoSize = true,
                    Name = canData.Name,
                    Text = canData.Name,
                    Margin = new Padding(0,5,0,5)
                })
                {
                    flowLayoutPanelError.Controls.Add(errorLabel);
                }*/
                /*foreach (var canData in _canDataList)
                {
                    var mulGroup = canData.MultiplexingGroup.Split('=');
                    if(mulGroup.Length>0) canData.MultiplexingGroup = mulGroup[1].Replace(" ","");
                    tempData.Add(canData);
                }
                var stringJson = JsonConvert.SerializeObject(_canDataList, Formatting.Indented);
                File.WriteAllText(_configPath + "parametr.json", stringJson);*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            /*using (var r = new StreamReader(Resources.Parameters))
            {
                var data = r.ReadToEnd();
                //configDisplay.Text = data;
                
            }*/
        }

        private static int StartByte(int start)
        {
            return start / 8;
        }

        private void canbus_thread_DoWork(object sender, DoWorkEventArgs e)
        {
            var status = new CStatusData();
            while (_cCanChannelUsbCh1.CanStatus(status) == eErrorCodesCanChannel.CAN_SUCCESS &&
                   !canbus_thread.CancellationPending)
            {
                try
                {
                    tmrRead_CanFox_Tick();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
