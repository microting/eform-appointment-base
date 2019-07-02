using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.AppointmentBase.Infrastructure.Data.Entities;
using NUnit.Framework;
using Microting.AppointmentBase.Infrastructure.Data.Constants;

namespace Microting.AppointmentBase.Unit.Tests
{
    [TestFixture]
    public class AppointmentUTest : DbTestFixture
    {
        [Test]
        public void Appointment_Create_DoesCreate()
        {
            //Arrange
            Random rnd = new Random();

            Appointment appointment = new Appointment()
            {
                GlobalId = Guid.NewGuid().ToString(),
                StartAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddMonths(2),
                Duration = rnd.Next(1,255),
                Subject = Guid.NewGuid().ToString(),
                ProcessingState = Constants.ProcessingState.Planned,
                Body = Guid.NewGuid().ToString(),
                ExceptionString = "",
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Info = Guid.NewGuid().ToString(),
                MicrotingUuid = Guid.NewGuid().ToString(),
                Completed = 0,
                Replacements = "",
                SdkeFormId = rnd.Next(1,255),
                Response = Guid.NewGuid().ToString(),
                ColorRule = null
            };

            //Act
            appointment.Create(DbContext);

            Appointment dbappointment = DbContext.Appointments.AsNoTracking().First();
            List<Appointment> appointments = DbContext.Appointments.AsNoTracking().ToList();
            AppointmentVersion appointmentVersion = DbContext.AppointmentVersions.AsNoTracking().First();
            List<AppointmentVersion> appointmentVersions = DbContext.AppointmentVersions.AsNoTracking().ToList();

            //Assert
            Assert.NotNull(appointments);
            Assert.NotNull(dbappointment);
            Assert.NotNull(appointmentVersion);
            Assert.AreEqual(1, appointments.Count);
            Assert.AreEqual(1, appointmentVersions.Count);
            
            Assert.AreEqual(appointment.Id, dbappointment.Id);
            Assert.AreEqual(appointment.Version, dbappointment.Version);
            Assert.AreEqual(appointment.WorkflowState, dbappointment.WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), dbappointment.CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, dbappointment.CreatedByUserId);
            Assert.AreEqual(appointment.UpdatedAt.ToString(), dbappointment.UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, dbappointment.UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), dbappointment.StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), dbappointment.ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, dbappointment.Duration);
            Assert.AreEqual(appointment.Subject, dbappointment.Subject);
            Assert.AreEqual(appointment.ProcessingState, dbappointment.ProcessingState);
            Assert.AreEqual(appointment.Body, dbappointment.Body);
            Assert.AreEqual(appointment.ExceptionString, dbappointment.ExceptionString);
            Assert.AreEqual(appointment.Title, dbappointment.Title);
            Assert.AreEqual(appointment.Description, dbappointment.Description);
            Assert.AreEqual(appointment.Info, dbappointment.Info);
            Assert.AreEqual(appointment.MicrotingUuid, dbappointment.MicrotingUuid);
            Assert.AreEqual(appointment.Completed, dbappointment.Completed);
            Assert.AreEqual(appointment.Replacements, dbappointment.Replacements);
            Assert.AreEqual(appointment.SdkeFormId, dbappointment.SdkeFormId);
            Assert.AreEqual(appointment.Response, dbappointment.Response);
            Assert.AreEqual(appointment.ColorRule, dbappointment.ColorRule);
            
            
            Assert.AreEqual(appointment.Id, appointmentVersion.AppointmentId);
            Assert.AreEqual(appointment.Version, appointmentVersion.Version);
            Assert.AreEqual(appointment.WorkflowState, appointmentVersion.WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointmentVersion.CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointmentVersion.CreatedByUserId);
            Assert.AreEqual(appointment.UpdatedAt.ToString(), appointmentVersion.UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointmentVersion.UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointmentVersion.StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointmentVersion.ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointmentVersion.Duration);
            Assert.AreEqual(appointment.Subject, appointmentVersion.Subject);
            Assert.AreEqual(appointment.ProcessingState, appointmentVersion.ProcessingState);
            Assert.AreEqual(appointment.Body, appointmentVersion.Body);
            Assert.AreEqual(appointment.ExceptionString, appointmentVersion.ExceptionString);
            Assert.AreEqual(appointment.Title, appointmentVersion.Title);
            Assert.AreEqual(appointment.Description, appointmentVersion.Description);
            Assert.AreEqual(appointment.Info, appointmentVersion.Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointmentVersion.MicrotingUid);
            Assert.AreEqual(appointment.Completed, appointmentVersion.Completed);
            Assert.AreEqual(appointment.Replacements, appointmentVersion.Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointmentVersion.SdkeFormId);
            Assert.AreEqual(appointment.Response, appointmentVersion.Response);
            Assert.AreEqual(appointment.ColorRule, appointmentVersion.ColorRule);
            
        }

        [Test]
        public void Appointment_Update_DoesUpdate()
        {
            //Arrange
            Random rnd = new Random();

            Appointment appointment = new Appointment()
            {
                GlobalId = Guid.NewGuid().ToString(),
                StartAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddMonths(2),
                Duration = rnd.Next(1,255),
                Subject = Guid.NewGuid().ToString(),
                ProcessingState = Constants.ProcessingState.Planned,
                Body = Guid.NewGuid().ToString(),
                ExceptionString = "",
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Info = Guid.NewGuid().ToString(),
                MicrotingUuid = Guid.NewGuid().ToString(),
                Completed = 0,
                Replacements = "",
                SdkeFormId = rnd.Next(1,255),
                Response = Guid.NewGuid().ToString(),
                ColorRule = null
            };

            appointment.Create(DbContext);
            
            //Act
            string oldBody = appointment.Body;
            DateTime oldUpdatedAt = (DateTime)appointment.UpdatedAt;

            appointment.Body = "bla";

            appointment.Update(DbContext);
            
            //Assert
            List<Appointment> appointments = DbContext.Appointments.AsNoTracking().ToList();
            List<AppointmentVersion> appointmentVersions = DbContext.AppointmentVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointments);
            Assert.NotNull(appointmentVersions);
            Assert.AreEqual(1, appointments.Count);
            Assert.AreEqual(2, appointmentVersions.Count);
            
            Assert.AreEqual(appointment.Id, appointments[0].Id);
            Assert.AreEqual(appointment.Version, appointments[0].Version);
            Assert.AreEqual(appointment.WorkflowState, appointments[0].WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointments[0].CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointments[0].CreatedByUserId);
            Assert.AreEqual(appointment.UpdatedAt.ToString(), appointments[0].UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointments[0].UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointments[0].StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointments[0].ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointments[0].Duration);
            Assert.AreEqual(appointment.Subject, appointments[0].Subject);
            Assert.AreEqual(appointment.ProcessingState, appointments[0].ProcessingState);
            Assert.AreEqual(appointment.Body, appointments[0].Body);
            Assert.AreEqual(appointment.ExceptionString, appointments[0].ExceptionString);
            Assert.AreEqual(appointment.Title, appointments[0].Title);
            Assert.AreEqual(appointment.Description, appointments[0].Description);
            Assert.AreEqual(appointment.Info, appointments[0].Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointments[0].MicrotingUuid);
            Assert.AreEqual(appointment.Completed, appointments[0].Completed);
            Assert.AreEqual(appointment.Replacements, appointments[0].Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointments[0].SdkeFormId);
            Assert.AreEqual(appointment.Response, appointments[0].Response);
            Assert.AreEqual(appointment.ColorRule, appointments[0].ColorRule);
            
            
            Assert.AreEqual(appointment.Id, appointmentVersions[0].AppointmentId);
            Assert.AreEqual(1, appointmentVersions[0].Version);
            Assert.AreEqual(appointment.WorkflowState, appointmentVersions[0].WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointmentVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointmentVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), appointmentVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointmentVersions[0].UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointmentVersions[0].StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointmentVersions[0].ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointmentVersions[0].Duration);
            Assert.AreEqual(appointment.Subject, appointmentVersions[0].Subject);
            Assert.AreEqual(appointment.ProcessingState, appointmentVersions[0].ProcessingState);
            Assert.AreEqual(oldBody, appointmentVersions[0].Body);
            Assert.AreEqual(appointment.ExceptionString, appointmentVersions[0].ExceptionString);
            Assert.AreEqual(appointment.Title, appointmentVersions[0].Title);
            Assert.AreEqual(appointment.Description, appointmentVersions[0].Description);
            Assert.AreEqual(appointment.Info, appointmentVersions[0].Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointmentVersions[0].MicrotingUid);
            Assert.AreEqual(appointment.Completed, appointmentVersions[0].Completed);
            Assert.AreEqual(appointment.Replacements, appointmentVersions[0].Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointmentVersions[0].SdkeFormId);
            Assert.AreEqual(appointment.Response, appointmentVersions[0].Response);
            Assert.AreEqual(appointment.ColorRule, appointmentVersions[0].ColorRule);
            
            
            Assert.AreEqual(appointment.Id, appointmentVersions[1].AppointmentId);
            Assert.AreEqual(2, appointmentVersions[1].Version);
            Assert.AreEqual(appointment.WorkflowState, appointmentVersions[1].WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointmentVersions[1].CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointmentVersions[1].CreatedByUserId);
            Assert.AreEqual(appointment.UpdatedAt.ToString(), appointmentVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointmentVersions[1].UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointmentVersions[1].StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointmentVersions[1].ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointmentVersions[1].Duration);
            Assert.AreEqual(appointment.Subject, appointmentVersions[1].Subject);
            Assert.AreEqual(appointment.ProcessingState, appointmentVersions[1].ProcessingState);
            Assert.AreEqual(appointment.Body, appointmentVersions[1].Body);
            Assert.AreEqual(appointment.ExceptionString, appointmentVersions[1].ExceptionString);
            Assert.AreEqual(appointment.Title, appointmentVersions[1].Title);
            Assert.AreEqual(appointment.Description, appointmentVersions[1].Description);
            Assert.AreEqual(appointment.Info, appointmentVersions[1].Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointmentVersions[1].MicrotingUid);
            Assert.AreEqual(appointment.Completed, appointmentVersions[1].Completed);
            Assert.AreEqual(appointment.Replacements, appointmentVersions[1].Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointmentVersions[1].SdkeFormId);
            Assert.AreEqual(appointment.Response, appointmentVersions[1].Response);
            Assert.AreEqual(appointment.ColorRule, appointmentVersions[1].ColorRule);
        }

        [Test]
        public void Appointment_Delete_DoesDelete()
        {
            //Arrange
            Random rnd = new Random();

            Appointment appointment = new Appointment()
            {
                GlobalId = Guid.NewGuid().ToString(),
                StartAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddMonths(2),
                Duration = rnd.Next(1,255),
                Subject = Guid.NewGuid().ToString(),
                ProcessingState = Constants.ProcessingState.Planned,
                Body = Guid.NewGuid().ToString(),
                ExceptionString = "",
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Info = Guid.NewGuid().ToString(),
                MicrotingUuid = Guid.NewGuid().ToString(),
                Completed = 0,
                Replacements = "",
                SdkeFormId = rnd.Next(1,255),
                Response = Guid.NewGuid().ToString(),
                ColorRule = null
            };

            appointment.Create(DbContext);
            
            //Act
            DateTime oldUpdatedAt = (DateTime)appointment.UpdatedAt;

            appointment.Delete(DbContext);
            
            //Assert
            List<Appointment> appointments = DbContext.Appointments.AsNoTracking().ToList();
            List<AppointmentVersion> appointmentVersions = DbContext.AppointmentVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointments);
            Assert.NotNull(appointmentVersions);
            Assert.AreEqual(1, appointments.Count);
            Assert.AreEqual(2, appointmentVersions.Count);
            
            Assert.AreEqual(appointment.Id, appointments[0].Id);
            Assert.AreEqual(appointment.Version, appointments[0].Version);
            Assert.AreEqual(eFormShared.Constants.WorkflowStates.Removed, appointments[0].WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointments[0].CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointments[0].CreatedByUserId);
            Assert.AreEqual(appointment.UpdatedAt.ToString(), appointments[0].UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointments[0].UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointments[0].StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointments[0].ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointments[0].Duration);
            Assert.AreEqual(appointment.Subject, appointments[0].Subject);
            Assert.AreEqual(appointment.ProcessingState, appointments[0].ProcessingState);
            Assert.AreEqual(appointment.Body, appointments[0].Body);
            Assert.AreEqual(appointment.ExceptionString, appointments[0].ExceptionString);
            Assert.AreEqual(appointment.Title, appointments[0].Title);
            Assert.AreEqual(appointment.Description, appointments[0].Description);
            Assert.AreEqual(appointment.Info, appointments[0].Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointments[0].MicrotingUuid);
            Assert.AreEqual(appointment.Completed, appointments[0].Completed);
            Assert.AreEqual(appointment.Replacements, appointments[0].Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointments[0].SdkeFormId);
            Assert.AreEqual(appointment.Response, appointments[0].Response);
            Assert.AreEqual(appointment.ColorRule, appointments[0].ColorRule);
            
            
            Assert.AreEqual(appointment.Id, appointmentVersions[0].AppointmentId);
            Assert.AreEqual(1, appointmentVersions[0].Version);
            Assert.AreEqual(eFormShared.Constants.WorkflowStates.Created, appointmentVersions[0].WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointmentVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointmentVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), appointmentVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointmentVersions[0].UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointmentVersions[0].StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointmentVersions[0].ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointmentVersions[0].Duration);
            Assert.AreEqual(appointment.Subject, appointmentVersions[0].Subject);
            Assert.AreEqual(appointment.ProcessingState, appointmentVersions[0].ProcessingState);
            Assert.AreEqual(appointment.Body, appointments[0].Body);
            Assert.AreEqual(appointment.ExceptionString, appointmentVersions[0].ExceptionString);
            Assert.AreEqual(appointment.Title, appointmentVersions[0].Title);
            Assert.AreEqual(appointment.Description, appointmentVersions[0].Description);
            Assert.AreEqual(appointment.Info, appointmentVersions[0].Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointmentVersions[0].MicrotingUid);
            Assert.AreEqual(appointment.Completed, appointmentVersions[0].Completed);
            Assert.AreEqual(appointment.Replacements, appointmentVersions[0].Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointmentVersions[0].SdkeFormId);
            Assert.AreEqual(appointment.Response, appointmentVersions[0].Response);
            Assert.AreEqual(appointment.ColorRule, appointmentVersions[0].ColorRule);
            
            
            Assert.AreEqual(appointment.Id, appointmentVersions[1].AppointmentId);
            Assert.AreEqual(2, appointmentVersions[1].Version);
            Assert.AreEqual(eFormShared.Constants.WorkflowStates.Removed, appointmentVersions[1].WorkflowState);
            Assert.AreEqual(appointment.CreatedAt.ToString(), appointmentVersions[1].CreatedAt.ToString());
            Assert.AreEqual(appointment.CreatedByUserId, appointmentVersions[1].CreatedByUserId);
            Assert.AreEqual(appointment.UpdatedAt.ToString(), appointmentVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(appointment.UpdatedByUserId, appointmentVersions[1].UpdatedByUserId);
            Assert.AreEqual(appointment.StartAt.ToString(), appointmentVersions[1].StartAt.ToString());
            Assert.AreEqual(appointment.ExpireAt.ToString(), appointmentVersions[1].ExpireAt.ToString());
            Assert.AreEqual(appointment.Duration, appointmentVersions[1].Duration);
            Assert.AreEqual(appointment.Subject, appointmentVersions[1].Subject);
            Assert.AreEqual(appointment.ProcessingState, appointmentVersions[1].ProcessingState);
            Assert.AreEqual(appointment.Body, appointmentVersions[1].Body);
            Assert.AreEqual(appointment.ExceptionString, appointmentVersions[1].ExceptionString);
            Assert.AreEqual(appointment.Title, appointmentVersions[1].Title);
            Assert.AreEqual(appointment.Description, appointmentVersions[1].Description);
            Assert.AreEqual(appointment.Info, appointmentVersions[1].Info);
            Assert.AreEqual(appointment.MicrotingUuid, appointmentVersions[1].MicrotingUid);
            Assert.AreEqual(appointment.Completed, appointmentVersions[1].Completed);
            Assert.AreEqual(appointment.Replacements, appointmentVersions[1].Replacements);
            Assert.AreEqual(appointment.SdkeFormId, appointmentVersions[1].SdkeFormId);
            Assert.AreEqual(appointment.Response, appointmentVersions[1].Response);
            Assert.AreEqual(appointment.ColorRule, appointmentVersions[1].ColorRule);
        }
    }
}