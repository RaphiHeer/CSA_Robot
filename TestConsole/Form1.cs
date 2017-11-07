using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace TestConsole
{
    public partial class Form1 : Form
    {
        private RobotConsole rc;
        private int pos;

        public Form1()
        {
            InitializeComponent();

            rc = new RobotConsole();
            consoleView.RobotConsole = rc;

            rc[Switches.Switch1].SwitchStateChanged += SwitchStateChanged;
            rc[Switches.Switch2].SwitchStateChanged += SwitchStateChanged;
            rc[Switches.Switch3].SwitchStateChanged += SwitchStateChanged;
            rc[Switches.Switch4].SwitchStateChanged += SwitchStateChanged;
        }

        void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            rc[(Leds)(int)e.Swi].LedEnabled = e.SwitchEnabled;
        }
    }
}
