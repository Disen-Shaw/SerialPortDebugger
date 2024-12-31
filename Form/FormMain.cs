
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
    /// 主界面类
    /// </summary>
    public partial class FormMain : Form
    {
        #region 预设配置信息
        /// <summary>
        /// 预设波特率
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
        /// 预设数据位
        /// </summary>
        private static readonly int[] s_dataBits = new int[]
        {
            5,
            6,
            7,
            8,
        };
        /// <summary>
        /// 预设停止位
        /// </summary>
        private static readonly Dictionary<StopBits, string> s_stopBits = new Dictionary<StopBits, string>()
        {
            { StopBits.None,            "None"  },
            { StopBits.One,             "1"     },
            { StopBits.OnePointFive,    "1.5"   },
            { StopBits.Two,             "2"     },
        };
        /// <summary>
        /// 预设校验位
        /// </summary>
        private static readonly Dictionary<Parity, string> s_parity = new Dictionary<Parity, string>()
        {
            { Parity.None,  "无校验位(None)"   },
            { Parity.Odd,   "奇校验(Odd)"      },
            { Parity.Even,  "偶校验(Even)"     },
            { Parity.Mark,  "标记校验(Mark)"   },
            { Parity.Space, "空格校验(Space)"  },
        };

        #endregion

        #region 私有成员

        /// <summary>
        /// 串口设备名称与端口号对应字典
        /// </summary>
        private Dictionary<string, string> _serialPortName;
        private Dictionary<string, string> _serialPortNamePast;

        /// <summary>
        /// 用于刷新串口设备信息的定时器
        /// </summary>
        System.Timers.Timer _serialPortReflashTimer;
        #endregion

        #region 公有方法

        /// <summary>
        /// 构造方法
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            _serialPortName = new Dictionary<string, string>();
            _serialPortNamePast = new Dictionary<string, string>();
            // 每隔 50ms 刷新一次端口设备信息
            _serialPortReflashTimer = new System.Timers.Timer(100);
            _serialPortReflashTimer.Elapsed += SerialPortReflashTimer_Elapsed;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 刷新串口设备信息到字典
        /// </summary>
        private void SerialReflash(ref Dictionary<string, string> target)
        {
            // 清空原字典
            target.Clear();

            // 刷新串口设备信息
            foreach (string portName in SerialPort.GetPortNames())
            {
                // SQL 语句, 查询串口设备名称
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
        /// 更新端口信息
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
        /// 定时器回调
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

        #region 控件事件回调

        /// <summary>
        /// 最上层显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnTopMost_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                TopMost = false;
                tsBtnTopMost.BackColor = SystemColors.Window;
                tsBtnTopMost.ToolTipText = "切换到最上层显示";
                tsBtnTopMost.Text = "↑";
            }
            else
            {
                TopMost = true;
                tsBtnTopMost.BackColor = Color.LightSkyBlue;
                tsBtnTopMost.ToolTipText = "切换到普通显示显示";
                tsBtnTopMost.Text = "↓";
            }
        }

        /// <summary>
        /// 界面加载回调
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

        #region 类型定义
        /// <summary>
        /// 更新端口元素
        /// </summary>
        private delegate void PortItemsUpdateDelegate(Dictionary<string, string> dic);
        #endregion

    }
}
