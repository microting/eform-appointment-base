using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.AppointmentBase.Infrastructure.Data.Constants;
using Microting.AppointmentBase.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace Microting.AppointmentBase.Unit.Tests
{
    [TestFixture]
    public class AppointmentSiteUTest : DbTestFixture
    {
        [Test]
        public void AppointmentSite_Create_DoesCreate()
        {
            //Arrange
            Random rnd = new Random();
            
            Appointment appointment = new Appointment()
            {
                Body = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            };

            appointment.Create(DbContext);
            
            AppointmentSite appointmentSite = new AppointmentSite()
            {
                AppointmentId = appointment.Id,
                MicrotingSiteUid = rnd.Next(1,255),
                ExceptionString = Guid.NewGuid().ToString(),
                SdkCaseId = Guid.NewGuid().ToString(),
                ProcessingState = Constants.ProcessingState.Planned,
                Completed = 0
            };

            //Act
            appointmentSite.Create(DbContext);

            List<AppointmentSite> appointmentSites = DbContext.AppointmentSites.AsNoTracking().ToList();
            List<AppointmentSiteVersion> appointmentSiteVersions =
                DbContext.AppointmentSiteVersions.AsNoTracking().ToList();
            
            //Assert
            Assert.NotNull(appointmentSites);
            Assert.NotNull(appointmentSiteVersions);
            Assert.AreEqual(1, appointmentSites.Count);
            Assert.AreEqual(1, appointmentSiteVersions.Count);
            
            Assert.AreEqual(appointmentSite.Id, appointmentSites[0].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSites[0].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSites[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSites[0].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSites[0].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSites[0].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSites[0].Completed);
            Assert.AreEqual(appointmentSite.Version, appointmentSites[0].Version);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSites[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSites[0].CreatedByUserId);
            Assert.AreEqual(appointmentSite.UpdatedAt.ToString(), appointmentSites[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSites[0].UpdatedByUserId);
            
            Assert.AreEqual(1, appointmentSiteVersions[0].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSiteVersions[0].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSiteVersions[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSiteVersions[0].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSiteVersions[0].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSiteVersions[0].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSiteVersions[0].Completed);
            Assert.AreEqual(appointmentSite.Id, appointmentSiteVersions[0].AppointmentSiteId);
            Assert.AreEqual(appointmentSite.Version, appointmentSiteVersions[0].Version);
            Assert.AreEqual(appointmentSite.WorkflowState, appointmentSiteVersions[0].WorkflowState);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(appointmentSite.UpdatedAt.ToString(), appointmentSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSiteVersions[0].UpdatedByUserId);
        }

        [Test]
        public void AppointmentSite_Update_DoesUpdate()
        {
            //Arrange
            Random rnd = new Random();
            
            Appointment appointment = new Appointment()
            {
                Body = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            };

            appointment.Create(DbContext);
            
            AppointmentSite appointmentSite = new AppointmentSite()
            {
                AppointmentId = appointment.Id,
                MicrotingSiteUid = rnd.Next(1,255),
                ExceptionString = Guid.NewGuid().ToString(),
                SdkCaseId = Guid.NewGuid().ToString(),
                ProcessingState = Constants.ProcessingState.Planned,
                Completed = 0
            };
            appointmentSite.Create(DbContext);

            //Act
            int oldMicrotingSiteUid = appointmentSite.MicrotingSiteUid;
            string oldExceptionString = appointmentSite.ExceptionString;
            string oldSdkCaseId = appointmentSite.SdkCaseId;
            string oldProcessingState = appointmentSite.ProcessingState;
            short? oldCompleted = appointmentSite.Completed;
            DateTime oldUpdatedAt = (DateTime)appointment.UpdatedAt;

            appointmentSite.MicrotingSiteUid = 1;
            appointmentSite.ExceptionString = "noexception";
            appointmentSite.SdkCaseId = "CaseId";
            appointmentSite.ProcessingState = Constants.ProcessingState.Completed;
            appointmentSite.Completed = 1;

            appointmentSite.Update(DbContext);
            
            
            //Assert
            List<AppointmentSite> appointmentSites = DbContext.AppointmentSites.AsNoTracking().ToList();
            List<AppointmentSiteVersion> appointmentSiteVersions =
                DbContext.AppointmentSiteVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointmentSites);
            Assert.NotNull(appointmentSiteVersions);
            Assert.AreEqual(1, appointmentSites.Count);
            Assert.AreEqual(2, appointmentSiteVersions.Count);
            
            Assert.AreEqual(appointmentSite.Id, appointmentSites[0].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSites[0].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSites[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSites[0].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSites[0].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSites[0].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSites[0].Completed);
            Assert.AreEqual(appointmentSite.Version, appointmentSites[0].Version);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSites[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSites[0].CreatedByUserId);
            Assert.AreEqual(appointmentSite.UpdatedAt.ToString(), appointmentSites[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSites[0].UpdatedByUserId);
            
            Assert.AreEqual(1, appointmentSiteVersions[0].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSiteVersions[0].AppointmentId);
            Assert.AreEqual(oldMicrotingSiteUid, appointmentSiteVersions[0].MicrotingSiteUid);
            Assert.AreEqual(oldExceptionString, appointmentSiteVersions[0].ExceptionString);
            Assert.AreEqual(oldSdkCaseId, appointmentSiteVersions[0].SdkCaseId);
            Assert.AreEqual(oldProcessingState, appointmentSiteVersions[0].ProcessingState);
            Assert.AreEqual(oldCompleted, appointmentSiteVersions[0].Completed);
            Assert.AreEqual(appointmentSite.Id, appointmentSiteVersions[0].AppointmentSiteId);
            Assert.AreEqual(1, appointmentSiteVersions[0].Version);
            Assert.AreEqual(appointmentSite.WorkflowState, appointmentSiteVersions[0].WorkflowState);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), appointmentSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSiteVersions[0].UpdatedByUserId);
            
            Assert.AreEqual(2, appointmentSiteVersions[1].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSiteVersions[1].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSiteVersions[1].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSiteVersions[1].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSiteVersions[1].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSiteVersions[1].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSiteVersions[1].Completed);
            Assert.AreEqual(appointmentSite.Id, appointmentSiteVersions[1].AppointmentSiteId);
            Assert.AreEqual(appointmentSite.Version, appointmentSiteVersions[1].Version);
            Assert.AreEqual(appointmentSite.WorkflowState, appointmentSiteVersions[1].WorkflowState);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSiteVersions[1].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSiteVersions[1].CreatedByUserId);
            Assert.AreEqual(appointmentSite.UpdatedAt.ToString(), appointmentSiteVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSiteVersions[1].UpdatedByUserId);

        }

        [Test]
        public void AppointmentSite_Delete_DoesDelete()
        {
            //Arrange
            Random rnd = new Random();
            
            Appointment appointment = new Appointment()
            {
                Body = Guid.NewGuid().ToString(),
                Title = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString()
            };

            appointment.Create(DbContext);
            
            AppointmentSite appointmentSite = new AppointmentSite()
            {
                AppointmentId = appointment.Id,
                MicrotingSiteUid = rnd.Next(1,255),
                ExceptionString = Guid.NewGuid().ToString(),
                SdkCaseId = Guid.NewGuid().ToString(),
                ProcessingState = Constants.ProcessingState.Planned,
                Completed = 0
            };
            appointmentSite.Create(DbContext);

            //Act
            int oldMicrotingSiteUid = appointmentSite.MicrotingSiteUid;
            string oldExceptionString = appointmentSite.ExceptionString;
            string oldSdkCaseId = appointmentSite.SdkCaseId;
            string oldProcessingState = appointmentSite.ProcessingState;
            string oldWorkflowState = appointmentSite.WorkflowState;
            DateTime oldUpdatedAt = (DateTime)appointment.UpdatedAt;


            appointmentSite.Delete(DbContext);
            
            
            //Assert
            List<AppointmentSite> appointmentSites = DbContext.AppointmentSites.AsNoTracking().ToList();
            List<AppointmentSiteVersion> appointmentSiteVersions =
                DbContext.AppointmentSiteVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointmentSites);
            Assert.NotNull(appointmentSiteVersions);
            Assert.AreEqual(1, appointmentSites.Count);
            Assert.AreEqual(2, appointmentSiteVersions.Count);
            
            Assert.AreEqual(appointmentSite.Id, appointmentSites[0].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSites[0].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSites[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSites[0].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSites[0].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSites[0].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSites[0].Completed);
            Assert.AreEqual(appointmentSite.Version, appointmentSites[0].Version);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSites[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSites[0].CreatedByUserId);
            Assert.AreEqual(appointmentSite.UpdatedAt.ToString(), appointmentSites[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSites[0].UpdatedByUserId);
            Assert.AreEqual(eFormShared.Constants.WorkflowStates.Removed, appointmentSites[0].WorkflowState);
            
            Assert.AreEqual(1, appointmentSiteVersions[0].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSiteVersions[0].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSiteVersions[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSiteVersions[0].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSiteVersions[0].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSiteVersions[0].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSiteVersions[0].Completed);
            Assert.AreEqual(appointmentSite.Id, appointmentSiteVersions[0].AppointmentSiteId);
            Assert.AreEqual(1, appointmentSiteVersions[0].Version);
            Assert.AreEqual(oldWorkflowState, appointmentSiteVersions[0].WorkflowState);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSiteVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSiteVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), appointmentSiteVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSiteVersions[0].UpdatedByUserId);
            Assert.AreEqual(eFormShared.Constants.WorkflowStates.Created, appointmentSiteVersions[0].WorkflowState);
            
            Assert.AreEqual(2, appointmentSiteVersions[1].Id);
            Assert.AreEqual(appointmentSite.AppointmentId, appointmentSiteVersions[1].AppointmentId);
            Assert.AreEqual(appointmentSite.MicrotingSiteUid, appointmentSiteVersions[1].MicrotingSiteUid);
            Assert.AreEqual(appointmentSite.ExceptionString, appointmentSiteVersions[1].ExceptionString);
            Assert.AreEqual(appointmentSite.SdkCaseId, appointmentSiteVersions[1].SdkCaseId);
            Assert.AreEqual(appointmentSite.ProcessingState, appointmentSiteVersions[1].ProcessingState);
            Assert.AreEqual(appointmentSite.Completed, appointmentSiteVersions[1].Completed);
            Assert.AreEqual(appointmentSite.Id, appointmentSiteVersions[1].AppointmentSiteId);
            Assert.AreEqual(appointmentSite.Version, appointmentSiteVersions[1].Version);
            Assert.AreEqual(appointmentSite.WorkflowState, appointmentSiteVersions[1].WorkflowState);
            Assert.AreEqual(appointmentSite.CreatedAt.ToString(), appointmentSiteVersions[1].CreatedAt.ToString());
            Assert.AreEqual(appointmentSite.CreatedByUserId, appointmentSiteVersions[1].CreatedByUserId);
            Assert.AreEqual(appointmentSite.UpdatedAt.ToString(), appointmentSiteVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(appointmentSite.UpdatedByUserId, appointmentSiteVersions[1].UpdatedByUserId);
            Assert.AreEqual(eFormShared.Constants.WorkflowStates.Removed, appointmentSiteVersions[1].WorkflowState);
        }
    }
}