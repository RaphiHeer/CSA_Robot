using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;

namespace RobotServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Track> commandQueue = new Queue<Track>();

            Console.WriteLine("Welcome to C# on Windows Embedded Systems");

            // Create and init robot object
            Robot robot = new Robot();
            robot.Drive.Power = true;


            Drive drive = robot.Drive;
            Track track;

            // Logs while the robot is driving
            RobotLogger logger = new RobotLogger("C:\\tmp\\file.csv", drive.DriveInfo);
            logger.LogTrip();

            while (commandQueue.Count > 0)
            {
                track = commandQueue.Dequeue();

                drive.RunTrack(track);

                // Wait while track is running...
                while (!drive.Done) ;
                
            }
            logger.StopLogging();

        }
    }
}
