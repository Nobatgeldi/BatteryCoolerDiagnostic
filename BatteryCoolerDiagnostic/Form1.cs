using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using BatteryCoolerDiagnostic.Covisart;
using BatteryCoolerDiagnostic.Properties;
using Peak.Can.Light;
using SiE.SiEAPI_Interface;
using SiE.SiEAPI_Interface.SiEAPI_InterfaceTypes;
using Timer = System.Windows.Forms.Timer;

namespace BatteryCoolerDiagnostic
{
    public partial class Form1 : Form
    {
        private string _swName = "Battery Cooler Diagnostic Tool - COVISART";
        private Timer _tmrReadCanFox;
        private CCanChannel _cCanChannelUsbCh1;
        private eErrorCodesCanChannel _eRet;
        private HardwareType _activeHardware;
        private ArrayList _lastMsgsList;
        private AutoResetEvent _rcvEvent;
        private uint _counterNodeIdPing = 1;
        private const uint _batteryCoolerSendId = 1501;
        private const uint _batteryCoolerReceiveId = 1500;
        private uint _uiLen = 1;
        private CDeviceList _deviceList;
        private CDevice _device;
        private List<CANDATA> _canDataList;

        /*state values*/

        public Form1()
        {
            InitializeComponent();
            _activeHardware = ~HardwareType.USB_1CH;
            _lastMsgsList = new ArrayList();

            _cCanChannelUsbCh1 = new CCanChannel();
            _deviceList = new CDeviceList();
            var deviceListState = _cCanChannelUsbCh1.CanGetDeviceList(_deviceList);
            if (deviceListState != eErrorCodesCanChannel.CAN_SUCCESS) return;
            if (_deviceList.Count <= 0) return;

            _device = _deviceList.get_GetDevice(0);
            //MessageBox.Show(_device.Name);
        }

        private void CONNECT_Click(object sender, EventArgs e)
        {
            _eRet = _cCanChannelUsbCh1.CanOpen(eNetNumbers.CAN_FOX_CH1, eEcho.ECHO_OFF, 100U, 100U, "CAN_Tool");

            connectionProgressBar?.PerformStep();

            if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS)
            {
                var num = (int)_cCanChannelUsbCh1.CanClose();
                txtInfo.Clear();
                txtInfo.AppendText("Channel 1 Açık değil");
                txtInfo.AppendText(Environment.NewLine);
                txtInfo.AppendText("Bağlantı kurulmadı");
                txtInfo.AppendText(Environment.NewLine);
                connectionStatus.Text = @"Disconnected";
                
                if (connectionProgressBar != null) connectionProgressBar.Value = 0;
                return;
            }
            else if (_eRet == eErrorCodesCanChannel.CAN_SUCCESS)
            {
                txtInfo.AppendText("Channel 1 açıldı");
                txtInfo.AppendText(Environment.NewLine);
                connectionProgressBar?.PerformStep();

            }

            _eRet = _cCanChannelUsbCh1.CanSetBaudrate(eBaudrates.KBITS250);
            connectionProgressBar?.PerformStep();
            if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS)
            {
                var num = (int)_cCanChannelUsbCh1.CanClose();
                txtInfo.AppendText("Baud hızı ayarlanmadı");
                txtInfo.AppendText(Environment.NewLine);
                txtInfo.AppendText("Bağlantı kurulmadı");
                txtInfo.AppendText(Environment.NewLine);
                connectionStatus.Text = "Disconnected";
                if (connectionProgressBar != null) connectionProgressBar.Value = 0;
                return;
            }
            else if (_eRet == eErrorCodesCanChannel.CAN_SUCCESS)
            {
                txtInfo.AppendText("Baud hızı seti");
                txtInfo.AppendText(Environment.NewLine);
            }

            _eRet = _cCanChannelUsbCh1.CanSetFilterMode(eFilterModes.FILTER_MODE_NOFILTER);
            connectionProgressBar?.PerformStep();
            if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS)
            {
                var num = (int)_cCanChannelUsbCh1.CanClose();
                txtInfo.AppendText("Filtre ayarlanmadı");
                txtInfo.AppendText(Environment.NewLine);
                txtInfo.AppendText("Bağlantı kurulmadı");
                txtInfo.AppendText(Environment.NewLine);
                connectionStatus.Text = "Disconnected";
                if (connectionProgressBar != null) connectionProgressBar.Value = 0;
                return;
            }
            else if (_eRet == eErrorCodesCanChannel.CAN_SUCCESS)
            {
                txtInfo.AppendText(@"Filtre seti");
                txtInfo.AppendText(Environment.NewLine);
                txtInfo.Text = @"Bağlantı başarıyla kuruldu. \r\n";
                var txtInfo1 = txtInfo;
                txtInfo1.Text += @"Active Hardware: CanFox\t";
                var txtInfo2 = txtInfo;
                txtInfo2.Text += @"\r\nBaudrate: 250 Kbit \t";
                var txtInfo3 = txtInfo;
                txtInfo3.Text += @"\r\nMesaj tipi: CanFox\t";
                txtInfo.AppendText(Environment.NewLine);
                if (connectionProgressBar != null) connectionProgressBar.Value = 100;
                connectionStatus.Text = @"Connected";

                var num1 = (int)_cCanChannelUsbCh1.CanResetCounter();
                var num2 = (int)_cCanChannelUsbCh1.CanClearBuffer();

                var controlPanel = new ControlPanel(_cCanChannelUsbCh1,_device);
                notify.Text = @"Connected to Cooler";
                notify.Icon = Icon.FromHandle(Resources.connect_icon.GetHicon());
                notify.BalloonTipText =  @"Connected to Battery Cooler";
                notify.BalloonTipIcon = toolTip1.ToolTipIcon; 
                notify.ShowBalloonTip(30000);
                notify.Visible = true;
                controlPanel.ShowDialog();

                // Determine if the OK button was clicked on the dialog box.
                if (controlPanel.DialogResult == DialogResult.OK)
                {
                    // Display a message box indicating that the OK button was clicked.
                    MessageBox.Show(@"Control panel closed.");
                    // Optional: Call the Dispose method when you are finished with the dialog box.
                    controlPanel.Dispose();
                }

            }

        }

        private void disconnect_canfox()
        {
            var num1 = (int)_cCanChannelUsbCh1.CanResetCounter();
            var num2 = (int)_cCanChannelUsbCh1.CanClearBuffer();

            _eRet = _cCanChannelUsbCh1.CanClose();
            if (_eRet != eErrorCodesCanChannel.CAN_SUCCESS)
            {
                txtInfo.AppendText("Channel 1 açık değil");
                txtInfo.AppendText(Environment.NewLine);
                connectionProgressBar.Value = 0;
                connectionStatus.Text = "Disconnected";
            }
            else
            {
                if (_eRet == eErrorCodesCanChannel.CAN_SUCCESS)
                {
                    txtInfo.AppendText("Channel 1 kapalı");
                    txtInfo.AppendText(Environment.NewLine);
                }
                //this.tmrRead_CanFox.Enabled = false;
                txtInfo.AppendText("bağlantı koptu");
                txtInfo.AppendText(Environment.NewLine);
            }
            connectionStatus.Text = "Disconnected";
            connectionProgressBar.Value = 0;
            notify.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _rcvEvent = new AutoResetEvent(false);
        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            disconnect_canfox();

            /*if (_readThread != null && _readThread.IsAlive) _readThread.Abort();
            try
            {
                var items = JsonConvert.DeserializeObject<List<CANDATA>>(configDisplay.Text);
                File.WriteAllText(config_path + "parametr.json", configDisplay.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                MessageBox.Show("Ayarlarda hata var, kayit edilmeden kapatilacak.");
            }*/
        }
    }
}
