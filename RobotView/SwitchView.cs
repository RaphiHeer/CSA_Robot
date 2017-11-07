using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class SwitchView : UserControl
    {
        private bool state;
        private Switch _switch;

        public SwitchView()
        {
            InitializeComponent();
        }

        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                pictureBox1.Image = state ? Resource.SwitchOn : Resource.SwitchOff;
            }
        }

        public Switch Switch
        {
            get
            {
                return _switch;
            }
            set
            {
                if (_switch != null) _switch.SwitchStateChanged -= Switch_SwitchStateChanged;
                _switch = value;
                if (_switch != null) _switch.SwitchStateChanged += Switch_SwitchStateChanged;
            }
        }

        private void Switch_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (InvokeRequired)
            {
                // Synchronisierung notwendig
                Invoke(new EventHandler<SwitchEventArgs>(Switch_SwitchStateChanged), sender, e);
            }
            else
            {
                State = e.SwitchEnabled;
            }
        }
    }
}