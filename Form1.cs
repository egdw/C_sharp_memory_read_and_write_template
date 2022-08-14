namespace 植物大战僵尸修改器winForm
{
    public partial class Form1 : Form
    {
        private int baseAddress  = 0x007794F8;
        private string processName = "PlantsVsZombies";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PlantsVsZombiesTool.GetPidByProcessName("PlantsVsZombies") == 0)
            {
                MessageBox.Show("未找到对应的游戏进程！");
                return;
            }
            if (button1.Text == "启动-阳光无限")
            {
                timer1.Enabled = true;
                button1.Text = "关闭-阳光无限";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "启动-阳光无限";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PlantsVsZombiesTool.GetPidByProcessName(processName) == 0)
            {
                timer1.Enabled = false;
                return;
            }
            
            int address = PlantsVsZombiesTool.ReadMemoryValue(baseAddress, processName);             //读取基址(该地址不会改变)
            address = address + 0x868;                              //获取2级地址
            address = PlantsVsZombiesTool.ReadMemoryValue(address, processName);
            address = address + 0x5578;                             //获取存放阳光数值的地址
            PlantsVsZombiesTool.WriteMemoryValue(address, processName, 0x1869F);                          //写入数据到地址（0x1869F表示99999）
            timer1.Interval = 100;
        }
    }
}