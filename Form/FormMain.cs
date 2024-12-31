
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortDebugger
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class FormMain : Form
    {
        #region Ԥ��������Ϣ
        /// <summary>
        /// Ԥ�貨����
        /// </summary>
        private static readonly int[] s_baudrate = new int[]
        {
            1200,
            2400,
            4800,
            9600,
            14400,
            19200,
            38400,
            43000,
            57600,
            115200,
            128000,
            230400,
            256000,
            460800,
            921600,
            1000000,
            2000000
        };
        /// <summary>
        /// Ԥ������λ
        /// </summary>
        private static readonly int[] s_dataBits = new int[]
        {
            5,
            6,
            7,
            8,
        };
        /// <summary>
        /// Ԥ��ֹͣλ
        /// </summary>
        private static readonly Dictionary<StopBits, string> s_stopBits = new Dictionary<StopBits, string>()
        {
            { StopBits.None,            "None"  },
            { StopBits.One,             "1"     },
            { StopBits.OnePointFive,    "1.5"   },
            { StopBits.Two,             "2"     },
        };
        /// <summary>
        /// Ԥ��У��λ
        /// </summary>
        private static readonly Dictionary<Parity, string> s_parity = new Dictionary<Parity, string>()
        {
            { Parity.None,  "��У��λ(None)"   },
            { Parity.Odd,   "��У��(Odd)"      },
            { Parity.Even,  "żУ��(Even)"     },
            { Parity.Mark,  "���У��(Mark)"   },
            { Parity.Space, "�ո�У��(Space)"  },
        };

        #endregion

        #region ˽�г�Ա

        /// <summary>
        /// �����豸������˿ںŶ�Ӧ�ֵ�
        /// </summary>
        private Dictionary<string, string> _serialPortName;
        private Dictionary<string, string> _serialPortNamePast;

        /// <summary>
        /// ����ˢ�´����豸��Ϣ�Ķ�ʱ��
        /// </summary>
        System.Timers.Timer _serialPortReflashTimer;
        #endregion

        #region ���з���

        /// <summary>
        /// ���췽��
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            _serialPortName = new Dictionary<string, string>();
            _serialPortNamePast = new Dictionary<string, string>();
            // ÿ�� 50ms ˢ��һ�ζ˿��豸��Ϣ
            _serialPortReflashTimer = new System.Timers.Timer(100);
            _serialPortReflashTimer.Elapsed += SerialPortReflashTimer_Elapsed;
        }

        #endregion

        #region ˽�з���

        /// <summary>
        /// ˢ�´����豸��Ϣ���ֵ�
        /// </summary>
        private void SerialReflash(ref Dictionary<string, string> target)
        {
            // ���ԭ�ֵ�
            target.Clear();

            // ˢ�´����豸��Ϣ
            foreach (string portName in SerialPort.GetPortNames())
            {
                // SQL ���, ��ѯ�����豸����
                string sql = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + portName + "%'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(sql);

                foreach (ManagementObject obj in searcher.Get())
                {
                    string? deviceName = obj["Name"] as string;

                    if (deviceName != null)
                    {
                        target.Add(deviceName, portName);
                    }
                }
            }
        }

        /// <summary>
        /// ���¶˿���Ϣ
        /// </summary>
        /// <param name="serialPortDic"></param>
        private void PortItemUpdate(Dictionary<string, string> serialPortDic)
        {
            if (toolStrip1.InvokeRequired)
            {
                PortItemsUpdateDelegate stcb = new PortItemsUpdateDelegate(PortItemUpdate);
                Invoke(stcb, new object[] { serialPortDic });
            }
            else
            {
                tscmbxPortSelect.Items.Clear();
                foreach (var v in serialPortDic)
                {
                    tscmbxPortSelect.Items.Add(v.Key);
                }
            }
        }

        /// <summary>
        /// ��ʱ���ص�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SerialPortReflashTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            SerialReflash(ref _serialPortName);
            if (_serialPortName.Count != _serialPortNamePast.Count)
            {
                PortItemUpdate(_serialPortName);
                _serialPortNamePast.Clear();
                foreach (var v in _serialPortName)
                {
                    _serialPortNamePast.Add(v.Key, v.Value);
                }
            }
        }

        #endregion

        #region �ؼ��¼��ص�

        /// <summary>
        /// ���ϲ���ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnTopMost_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                TopMost = false;
                tsBtnTopMost.BackColor = SystemColors.Window;
                tsBtnTopMost.ToolTipText = "�л������ϲ���ʾ";
                tsBtnTopMost.Text = "��";
            }
            else
            {
                TopMost = true;
                tsBtnTopMost.BackColor = Color.LightSkyBlue;
                tsBtnTopMost.ToolTipText = "�л�����ͨ��ʾ��ʾ";
                tsBtnTopMost.Text = "��";
            }
        }

        /// <summary>
        /// ������ػص�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            _serialPortReflashTimer.Start();
            
            foreach (var v in s_baudrate)
            {
                tscmbxBaudrateInput.Items.Add(v);
            }

            foreach (var v in s_dataBits)
            {
                tscmbxDataBitsSelect.Items.Add(v);
            }

            foreach (var v in s_stopBits)
            {
                tscmbxStopBitSelect.Items.Add(v.Value);
            }

            foreach (var v in s_parity)
            {
                tscmbxParitySelect.Items.Add(v.Value);
            }
        }

        #endregion

        #region ���Ͷ���
        /// <summary>
        /// ���¶˿�Ԫ��
        /// </summary>
        private delegate void PortItemsUpdateDelegate(Dictionary<string, string> dic);
        #endregion

    }
}
