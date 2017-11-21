using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RobotCtrl;

namespace TestDrive
{
    public partial class Form1 : Form
    {
        private Robot robot;
        private RobotConsole robotConsole;
        private bool isBlinking = false;

        public Form1()
        {
            InitializeComponent();

            // Create and init robot object
            robot = new Robot();
            robot.Drive.Power = true;

            // Set events for robotConsole
            robotConsole = robot.RobotConsole;
            robotConsole[Switches.Switch1].SwitchStateChanged += StartRunLine;
            robotConsole[Switches.Switch2].SwitchStateChanged += StartRunTurn;
            robotConsole[Switches.Switch3].SwitchStateChanged += StartRunArc;

            // Set general event if switch changed
            robotConsole[Switches.Switch1].SwitchStateChanged += SwitchesChanged;
            robotConsole[Switches.Switch2].SwitchStateChanged += SwitchesChanged;
            robotConsole[Switches.Switch3].SwitchStateChanged += SwitchesChanged;
            robotConsole[Switches.Switch4].SwitchStateChanged += SwitchesChanged;

            // Set robotConsole for consoleView
            consoleView.RobotConsole = robot.RobotConsole;

            // Set views for motor commans
            rl.Drive = robot.Drive;
            rt.Drive = robot.Drive;
            ra.Drive = robot.Drive;

            // Set radar
            radar.Radar = robot.Radar;
            radar.ObjectOnRadarTooClose += ObjectOnRadarTooClose;

            // Set common run parameters
            crp.SpeedChanged += SpeedChanged;
            crp.AccelerationChanged += AccelerationChanged;

            // Set drive view
            driveView.Drive = robot.Drive;

            // Init speed and acceleration
            SpeedChanged(this, EventArgs.Empty);
            AccelerationChanged(this, EventArgs.Empty);
        }

        private void ObjectOnRadarTooClose(object sender, EventArgs e)
        {
            if (crp.Speed > 0)
            {
                robot.Drive.Stop();

                if (!isBlinking)
                    new Thread(LedBlinker).Start();
                isBlinking = true;
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            robot.Drive.Halt();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            robot.Drive.Stop();
        }

        private void StartRunLine(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<SwitchEventArgs>(StartRunLine), sender, e);
            }
            else if(robotConsole[Switches.Switch1].SwitchEnabled)
            {
                this.rl.Start();
            }
        }

        private void StartRunTurn(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<SwitchEventArgs>(StartRunTurn), sender, e);
            }
            else if(robotConsole[Switches.Switch2].SwitchEnabled)
            {
                this.rt.Start();
            }
        }

        private void StartRunArc(object sender, EventArgs e)
        {
            if(InvokeRequired)
            {
                Invoke(new EventHandler<SwitchEventArgs>(StartRunArc), sender, e);
            }
            else if(robotConsole[Switches.Switch3].SwitchEnabled)
            {
                this.ra.Start();
            }
        }

        private void SwitchesChanged(object sender, EventArgs e)
        {
            SetLedsToSwitchState();
        }

        private void SpeedChanged(object sender, EventArgs e)
        {
            rl.Speed = crp.Speed;
            rt.Speed = crp.Speed;
            ra.Speed = crp.Speed;
        }
        private void AccelerationChanged(object sender, EventArgs e)
        {
            rl.Acceleration = crp.Acceleration;
            rt.Acceleration = crp.Acceleration;
            ra.Acceleration = crp.Acceleration;
        }


        private void LedBlinker()
        {
            bool ledsEnabled = true;
            while (radar.HasObjectInFront())
            {
                SetAllLeds(ledsEnabled);
                ledsEnabled = !ledsEnabled;
                Thread.Sleep(1000);
            }
            SetAllLeds(false);
            isBlinking = false;
        }

        private void SetAllLeds(bool ledsEnabled)
        {
            robotConsole[Leds.Led1].LedEnabled = ledsEnabled;
            robotConsole[Leds.Led2].LedEnabled = ledsEnabled;
            robotConsole[Leds.Led3].LedEnabled = ledsEnabled;
            robotConsole[Leds.Led4].LedEnabled = ledsEnabled;
        }

        private void SetLedsToSwitchState()
        {
            robotConsole[Leds.Led1].LedEnabled = robotConsole[Switches.Switch1].SwitchEnabled;
            robotConsole[Leds.Led2].LedEnabled = robotConsole[Switches.Switch2].SwitchEnabled;
            robotConsole[Leds.Led3].LedEnabled = robotConsole[Switches.Switch3].SwitchEnabled;
            robotConsole[Leds.Led4].LedEnabled = robotConsole[Switches.Switch4].SwitchEnabled;
        }
    }
}
