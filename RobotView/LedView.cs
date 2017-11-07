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
    public partial class LedView : UserControl
    {
        private bool state;
        private Led led;
        
        public LedView()
        {
            InitializeComponent();
            this.state = false;
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
                pictureBox1.Image = state ? Resource.LedOn : Resource.LedOff;
            }
        }

        public RobotCtrl.Led Led
        {
            get
            {
                return led;
            }
            set
            {
                if (led != null) led.LedStateChanged -= Led_LedStateChanged;
                led = value;
                if (led != null) led.LedStateChanged += Led_LedStateChanged;
            }
        }

        private void Led_LedStateChanged(object sender, LedEventArgs e)
        {
            if(InvokeRequired) // Pr�ft ob Thread != GUI-Thread
            {
                // Synchronisierung notwendig
                Invoke(new EventHandler<LedEventArgs>(Led_LedStateChanged), sender, e);
            }
            else
            {
                State = e.LedEnabled;
            }
        }
    }
}