using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using RobotCtrl;

namespace RobotServer
{
    class RobotLogger
    {
        private string path;
        private StreamWriter file;
        private bool robotIsRunning;
        private DriveInfo driveInfo;

        public RobotLogger(string path, DriveInfo driveInfo)
        {
            this.path = path;
            this.file = new StreamWriter(path);
            this.robotIsRunning = false;
            this.driveInfo = driveInfo;
        }

        public void LogTrip()
        {
            this.robotIsRunning = true;

            file.WriteLine("Start of trip");
            
            while (this.robotIsRunning)
            {
                DateTime now = DateTime.Today;

                file.WriteLine(now.ToLongDateString() + now.ToLongTimeString() + ";" + driveInfo.Position.X + ";" + driveInfo.Position.Y);
            }

            file.WriteLine("End of trip");
        }

        public void StopLogging()
        {
            this.robotIsRunning = false;
        }
    }
}
