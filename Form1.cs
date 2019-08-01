using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ABB.Robotics;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.MotionDomain;
using ABB.Robotics.Controllers.ConfigurationDomain;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Internal;
using ABB.Robotics.Controllers.EventLogDomain;

namespace RobotDataAPRA_V1
{
    public partial class Form1 : Form
    {     
        private void Form1_Load(object sender, EventArgs e)
        {
            
            NetworkScanner networkScanner = new NetworkScanner();
            networkScanner.Scan();
            ControllerInfoCollection controllers = networkScanner.Controllers;
            foreach (ControllerInfo controller in controllers)
            {
                ListViewItem item = new ListViewItem(controller.SystemName);
                item.SubItems.Add(controller.IPAddress.ToString());
                item.SubItems.Add(controller.Version.ToString());
                item.Tag = controller;
                this.listView1.Items.Add(item);
                item.Selected = true;
            }

        }

        ABB.Robotics.Controllers.Controller aController; 
        ABB.Robotics.Controllers.Controller objController;
        private NetworkScanner objNetworkWatcher = null;
        RapidData data1;
        RapidData data2;
        RapidData data3;
        RapidData data4;
        RapidData data5;
        RapidData data6;
        RapidData data7;
        RapidData data8;
        RapidData data9;
        RapidData data10;
        RapidData data11;
        RapidData data12;
        RapidData data13;
        RapidData data14;
        ABB.Robotics.Controllers.RapidDomain.Num _num1;
        ABB.Robotics.Controllers.RapidDomain.String _string1;
        ABB.Robotics.Controllers.RapidDomain.Num _num2;
        ABB.Robotics.Controllers.RapidDomain.Num _num3;
        ABB.Robotics.Controllers.RapidDomain.Num _num4;
        ABB.Robotics.Controllers.RapidDomain.RobTarget _robTarget1;
        ABB.Robotics.Controllers.RapidDomain.WobjData _wobjData1;
        ABB.Robotics.Controllers.RapidDomain.LoadData _loadData1;
        ABB.Robotics.Controllers.RapidDomain.JointTarget _jointTarget1;
        ABB.Robotics.Controllers.RapidDomain.Bool _bool1;
        ABB.Robotics.Controllers.RapidDomain.Bool _bool2;
        ABB.Robotics.Controllers.RapidDomain.Bool _bool3;
        ABB.Robotics.Controllers.RapidDomain.Num _num5;
        ABB.Robotics.Controllers.RapidDomain.Num _num6;
        double num1;
        double num2;
        double num3;
        double num4;
        double num5;
        double num6;
        string string1;
        Pos robTarget1;
        Pose wobjData1;
        Orient loadData1;
        RobJoint jointTarget1;
        bool bool1;
        bool bool2;
        bool bool3;
        public Form1()
        {
            InitializeComponent();
            createcontroler();
            listmethod();
        }

        public void createcontroler()
        {
            this.objNetworkWatcher = new NetworkScanner();
            objNetworkWatcher.Scan();

            ControllerInfoCollection objControllerInfoCollection = objNetworkWatcher.Controllers;
            objController = new Controller(objControllerInfoCollection[0]);          
            objController.Logon(UserInfo.DefaultUser);

        }
        public void listmethod()
        {

            data1 = objController.Rapid.GetTask("T_ROB1").GetModule("SWDEFUSR").GetRapidData("Version_SWDEFUSR"); //string
            data1.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data1_ValueChanged); 
            data2 = objController.Rapid.GetTask("T_ROB1").GetModule("URUN_M1").GetRapidData("W_00049"); //robtarget
            data2.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data2_ValueChanged);
            data3 = objController.Rapid.GetTask("T_ROB1").GetModule("SWDEFUSR").GetRapidData("MAX_DEFLECTION"); //num
            data3.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data3_ValueChanged);
            data4 = objController.Rapid.GetTask("T_ROB1").GetModule("SPOTSRV").GetRapidData("nToplamAsinma"); //num
            data4.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data5 = objController.Rapid.GetTask("T_ROB1").GetModule("BASE").GetRapidData("wobj0"); //wobjdata
            data5.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data6 = objController.Rapid.GetTask("T_ROB1").GetModule("BASE").GetRapidData("load0"); //loaddata
            data6.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data7 = objController.Rapid.GetTask("T_ROB1").GetModule("HOME_KONTROL").GetRapidData("delta_position1"); //jointtarget
            data7.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data8 = objController.Rapid.GetTask("T_ROB1").GetModule("SPOTSRV").GetRapidData("bRobot_FrezePrograminda"); //bool
            data8.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data9 = objController.Rapid.GetTask("T_ROB1").GetModule("SWDEFUSR").GetRapidData("spot1"); //spotdata
            data9.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data10 = objController.Rapid.GetTask("T_AutoBackup").GetModule("MainModule").GetRapidData("bCycleOn"); //bool
            data10.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data11 = objController.Rapid.GetTask("T_AutoBackup").GetModule("MainModule").GetRapidData("nHataKodu"); //num
            data11.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data12 = objController.Rapid.GetTask("T_ROB1").GetModule("SPOTSRV").GetRapidData("force_bileme"); //forcedata
            data12.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data13 = objController.Rapid.GetTask("T_AutoBackup").GetModule("MainModule").GetRapidData("bKaynakTamamlandi"); //bool
            data13.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            data14 = objController.Rapid.GetTask("T_ROB1").GetModule("URUN_M1").GetRapidData("nProgNo"); //num
            data14.ValueChanged += new EventHandler<DataValueChangedEventArgs>(data4_ValueChanged);
            _string1 = (ABB.Robotics.Controllers.RapidDomain.String)data1.Value;
            string1 = _string1.Value;
            _robTarget1 = (ABB.Robotics.Controllers.RapidDomain.RobTarget)data2.Value;
            robTarget1 = _robTarget1.Trans;
            _num3 = (ABB.Robotics.Controllers.RapidDomain.Num)data3.Value;
            num3 = _num3.Value;
            _num4 = (ABB.Robotics.Controllers.RapidDomain.Num)data4.Value;
            num4 = _num4.Value;
            _wobjData1 = (WobjData)data5.Value;
            wobjData1 = _wobjData1.Oframe;
            _loadData1 = (LoadData)data6.Value;
            loadData1 = _loadData1.Aom;
            _jointTarget1 = (JointTarget)data7.Value;
            jointTarget1 = _jointTarget1.RobAx;
            _bool1 = (Bool)data8.Value;
            bool1 = _bool1.Value;           
            label4.Text = data9.Value.ToString();
            _bool2 = (Bool)data10.Value;
            bool2 = _bool2.Value;
            _num5 = (ABB.Robotics.Controllers.RapidDomain.Num)data11.Value;
            num5 = _num5.Value;
            _bool3 = (Bool)data13.Value;
            bool3 = _bool3.Value;
            label9.Text = data12.Value.ToString();
            _num6 = (ABB.Robotics.Controllers.RapidDomain.Num)data14.Value;
            num6 = _num6.Value;
            dataGridView1.Rows.Add(data1.Symbol.Scope[0], data1.Symbol.Scope[1], data1.Symbol.Scope[2], string1);
            dataGridView1.Rows.Add(data2.Symbol.Scope[0], data2.Symbol.Scope[1], data2.Symbol.Scope[2], robTarget1);
            dataGridView1.Rows.Add(data3.Symbol.Scope[0], data3.Symbol.Scope[1], data3.Symbol.Scope[2], num3);
            dataGridView1.Rows.Add(data4.Symbol.Scope[0], data4.Symbol.Scope[1], data4.Symbol.Scope[2], num4);
            dataGridView1.Rows.Add(data5.Symbol.Scope[0], data5.Symbol.Scope[1], data5.Symbol.Scope[2], wobjData1);
            dataGridView1.Rows.Add(data6.Symbol.Scope[0], data6.Symbol.Scope[1], data6.Symbol.Scope[2], loadData1);
            dataGridView1.Rows.Add(data7.Symbol.Scope[0], data7.Symbol.Scope[1], data7.Symbol.Scope[2], jointTarget1);
            dataGridView1.Rows.Add(data8.Symbol.Scope[0], data8.Symbol.Scope[1], data8.Symbol.Scope[2], bool1);
            dataGridView1.Rows.Add(data10.Symbol.Scope[0], data10.Symbol.Scope[1], data10.Symbol.Scope[2], bool2);
            dataGridView1.Rows.Add(data11.Symbol.Scope[0], data11.Symbol.Scope[1], data11.Symbol.Scope[2], num5);
            dataGridView1.Rows.Add(data12.Symbol.Scope[0], data12.Symbol.Scope[1], data12.Symbol.Scope[2], data12.Value);
            dataGridView1.Rows.Add(data13.Symbol.Scope[0], data13.Symbol.Scope[1], data13.Symbol.Scope[2], bool3);
            dataGridView1.Rows.Add(data14.Symbol.Scope[0], data14.Symbol.Scope[1], data14.Symbol.Scope[2], num6);
            dataGridView1.AutoGenerateColumns = false;

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void data1_ValueChanged(object sender, DataValueChangedEventArgs e)
        {

            string str = sender.ToString();


        }

        private void data2_ValueChanged(object sender, DataValueChangedEventArgs e)
        {

            string str = sender.ToString();


        }
        private void data3_ValueChanged(object sender, DataValueChangedEventArgs e)
        {

            string str = sender.ToString();


        }
        private void data4_ValueChanged(object sender, DataValueChangedEventArgs e)
        {

            string str = sender.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem itemview = listView1.SelectedItems[0];
            ControllerInfo controllerinfo = (ControllerInfo)itemview.Tag;
            Controller aController = ControllerFactory.CreateFrom(controllerinfo);
            aController.Logon(UserInfo.DefaultUser);         
            EventLog log = aController.EventLog; //
            EventLogCategory cat;
            cat = log.GetCategory(0); 
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    EventLogMessage emsg = cat.Messages[i];
                    dataGridView2.Rows.Add(emsg.Title, emsg.Timestamp);
                }
                catch (IndexOutOfRangeException)
                {

                    MessageBox.Show("EventLog okuması tamamlandı.");
                    break;
                }
                               
            }
                       
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem itemView = listView1.SelectedItems[0];
            if (itemView.Tag != null)
            {
                ControllerInfo controllerInfo = (ControllerInfo)itemView.Tag;

                Controller ctrl = ControllerFactory.CreateFrom(controllerInfo);
                ctrl.Logon(UserInfo.DefaultUser);


                ListViewItem item = new ListViewItem(ctrl.RobotWare.ToString() + "/ " +
                    ctrl.State.ToString() + "/ " + ctrl.OperatingMode.ToString());
                this.listView2.Items.Add(item);

                ctrl.Logoff();
                ctrl.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //OKUMA YAPABİLİRSİN SİNYALİ -> BU SİNYAL ANLIK BİR SİNYAL OLDUĞU İÇİN YAKALANABİLSİN DİYE TİMER A KONUP SÜREKLİ TAKİP EDİLDİ.
            _bool1 = (Bool)data8.Value;
            bool1 = _bool1.Value;
            if (bool1 == true)
            {
                label2.Text = num4.ToString(); 
            }
            else
            {
                label2.Text = "false";
            }
            
            
        }
    }
}
