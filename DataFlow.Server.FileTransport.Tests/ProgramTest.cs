using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataFlow.Models;

namespace DataFlow.Server.FileTransport.Tests
{
    [TestClass]
    public class ProgramTest
    {

        [TestMethod]
        public void Test_TimeToExecute()
        {
            Agent mockAgent = new Agent();
            DateTime mockNow = DateTime.Parse("11/30/2017 12:00pm"); // This is a Thursday

            mockAgent.LastExecuted = DateTime.Parse("11/29/2017 12:00pm"); // This is a Wednesday
            AgentSchedule mockSchedule = new AgentSchedule();
            mockSchedule.Day = 4; //Thursday
            mockSchedule.Hour = 12; //12pm
            mockSchedule.Minute = 30; // :30 minutes

            mockAgent.AgentSchedules.Add(mockSchedule);
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("11/30/2017 12:50pm"); // This is a Thursday
            Assert.IsTrue(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockAgent.LastExecuted = DateTime.Parse("11/30/2017 12:50pm"); // This is a Thursday
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            AgentSchedule mockSchedule2 = new AgentSchedule();
            mockSchedule2.Day = 5; //Friday
            mockSchedule2.Hour = 20; //8pm
            mockSchedule2.Minute = 0; // :00 minutes

            mockAgent.AgentSchedules.Add(mockSchedule2);
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("12/01/2017 8:01pm"); // This is a Friday
            Assert.IsTrue(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockAgent.LastExecuted = DateTime.Parse("12/01/2017 8:01pm"); // This is a Friday

            mockNow = DateTime.Parse("12/03/2017 8:01pm"); // This is a Sunday
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("12/07/2017 12:29pm"); // This is a Thursday
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("12/07/2017 12:31pm"); // This is a Thursday
            Assert.IsTrue(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockAgent.LastExecuted = DateTime.Parse("12/07/2017 12:31pm"); // This is a Thursday
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("12/08/2017 08:00am"); // This is a Friday
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("12/08/2017 08:00pm"); // This is a Friday
            Assert.IsTrue(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));

            mockNow = DateTime.Parse("12/10/2017 08:00am"); // This is a Sunday
            Assert.IsFalse(FileTransport.Program.ShouldExecuteOnSchedule(mockAgent, mockNow));
        }
    }
}
