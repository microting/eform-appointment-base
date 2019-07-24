using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microting.AppointmentBase.Infrastructure.Data.Entities;
using NUnit.Framework;
using Constants = Microting.eForm.Infrastructure.Constants.Constants;

namespace Microting.AppointmentBase.Unit.Tests
{
    [TestFixture]
    public class AppointmentPrefillFieldValueUTest : DbTestFixture
    {

        [Test]
        public void AppointmentPrefillFieldValue_Create_Does_Create()
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
            
            AppointmentPrefillFieldValue appointmentPrefillFieldValue = new AppointmentPrefillFieldValue()
            {
                AppointmentId = appointment.Id,
                MicrotingSiteUid = rnd.Next(1, 256),
                FieldId = rnd.Next(1, 256),
                FieldValue = Guid.NewGuid().ToString(),
                AppointmentFvId = rnd.Next(1, 256)
            };
            
            //Act
            appointmentPrefillFieldValue.Create(DbContext);
            
            //Assert
            List<AppointmentPrefillFieldValue> appointmentPrefillFieldValues =
                DbContext.AppointmentPrefillFieldValues.AsNoTracking().ToList();

            List<AppointmentPrefillFieldValueVersion> appointmentPrefillFieldValueVersions =
                DbContext.AppointmentPrefillFieldValueVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointmentPrefillFieldValues);
            Assert.NotNull(appointmentPrefillFieldValueVersions);
            Assert.AreEqual(1,appointmentPrefillFieldValues.Count);
            Assert.AreEqual(1,appointmentPrefillFieldValueVersions.Count);
            
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValues[0].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Version, appointmentPrefillFieldValues[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, appointmentPrefillFieldValues[0].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValues[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValues[0].CreatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedAt.ToString(), appointmentPrefillFieldValues[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValues[0].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValues[0].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValues[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValues[0].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValues[0].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValues[0].AppointmentFvId);
            
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValueVersions[0].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValueVersions[0].AppointmentPrefillFieldValueId);
            Assert.AreEqual(appointmentPrefillFieldValue.Version, appointmentPrefillFieldValueVersions[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, appointmentPrefillFieldValueVersions[0].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValueVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValueVersions[0].CreatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedAt.ToString(), appointmentPrefillFieldValueVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValueVersions[0].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValueVersions[0].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValueVersions[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValueVersions[0].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValueVersions[0].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValueVersions[0].AppointmentFvId);

        }

        [Test]
        public void AppointmentPrefillFieldValue_Update_DoesUpdate()
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
            
            AppointmentPrefillFieldValue appointmentPrefillFieldValue = new AppointmentPrefillFieldValue()
            {
                AppointmentId = appointment.Id,
                MicrotingSiteUid = rnd.Next(1, 256),
                FieldId = rnd.Next(1, 256),
                FieldValue = Guid.NewGuid().ToString(),
                AppointmentFvId = rnd.Next(1, 256)
            };

            appointmentPrefillFieldValue.Create(DbContext);
            //Act
            int oldMicrotingSiteUid = appointmentPrefillFieldValue.MicrotingSiteUid;
            int oldFieldId = appointmentPrefillFieldValue.FieldId;
            string oldFieldValue = appointmentPrefillFieldValue.FieldValue;
            int? oldAppointmentFvId = appointmentPrefillFieldValue.AppointmentFvId;

            appointmentPrefillFieldValue.MicrotingSiteUid = 1;
            appointmentPrefillFieldValue.FieldId = 2;
            appointmentPrefillFieldValue.FieldValue = "someValue";
            appointmentPrefillFieldValue.AppointmentFvId = 3;
            DateTime oldUpdatedAt = (DateTime)appointmentPrefillFieldValue.UpdatedAt;

            appointmentPrefillFieldValue.Update(DbContext);

            //Assert
            List<AppointmentPrefillFieldValue> appointmentPrefillFieldValues =
                DbContext.AppointmentPrefillFieldValues.AsNoTracking().ToList();

            List<AppointmentPrefillFieldValueVersion> appointmentPrefillFieldValueVersions =
                DbContext.AppointmentPrefillFieldValueVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointmentPrefillFieldValues);
            Assert.NotNull(appointmentPrefillFieldValueVersions);
            Assert.AreEqual(1,appointmentPrefillFieldValues.Count);
            Assert.AreEqual(2,appointmentPrefillFieldValueVersions.Count);
            
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValues[0].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Version, appointmentPrefillFieldValues[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, appointmentPrefillFieldValues[0].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValues[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValues[0].CreatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedAt.ToString(), appointmentPrefillFieldValues[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValues[0].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValues[0].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValues[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValues[0].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValues[0].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValues[0].AppointmentFvId);
            
            Assert.AreEqual(1, appointmentPrefillFieldValueVersions[0].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValueVersions[0].AppointmentPrefillFieldValueId);
            Assert.AreEqual(1, appointmentPrefillFieldValueVersions[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, appointmentPrefillFieldValueVersions[0].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValueVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValueVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), appointmentPrefillFieldValueVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValueVersions[0].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValueVersions[0].AppointmentId);
            Assert.AreEqual(oldMicrotingSiteUid, appointmentPrefillFieldValueVersions[0].MicrotingSiteUid);
            Assert.AreEqual(oldFieldId, appointmentPrefillFieldValueVersions[0].FieldId);
            Assert.AreEqual(oldFieldValue, appointmentPrefillFieldValueVersions[0].FieldValue);
            Assert.AreEqual(oldAppointmentFvId, appointmentPrefillFieldValueVersions[0].AppointmentFvId);
            
            Assert.AreEqual(2, appointmentPrefillFieldValueVersions[1].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValueVersions[1].AppointmentPrefillFieldValueId);
            Assert.AreEqual(2, appointmentPrefillFieldValueVersions[1].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, appointmentPrefillFieldValueVersions[1].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValueVersions[1].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValueVersions[1].CreatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedAt.ToString(), appointmentPrefillFieldValueVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValueVersions[1].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValueVersions[1].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValueVersions[1].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValueVersions[1].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValueVersions[1].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValueVersions[1].AppointmentFvId);

        }

        [Test]
        public void AppointmentPrefillFieldValue_Delete_DoesDelete()
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
            
            AppointmentPrefillFieldValue appointmentPrefillFieldValue = new AppointmentPrefillFieldValue()
            {
                AppointmentId = appointment.Id,
                MicrotingSiteUid = rnd.Next(1, 256),
                FieldId = rnd.Next(1, 256),
                FieldValue = Guid.NewGuid().ToString(),
                AppointmentFvId = rnd.Next(1, 256)
            };

            appointmentPrefillFieldValue.Create(DbContext);

            //Act
            DateTime oldUpdatedAt = (DateTime)appointmentPrefillFieldValue.UpdatedAt;

            appointmentPrefillFieldValue.Delete(DbContext);

            //Assert
            List<AppointmentPrefillFieldValue> appointmentPrefillFieldValues =
                DbContext.AppointmentPrefillFieldValues.AsNoTracking().ToList();

            List<AppointmentPrefillFieldValueVersion> appointmentPrefillFieldValueVersions =
                DbContext.AppointmentPrefillFieldValueVersions.AsNoTracking().ToList();
            
            Assert.NotNull(appointmentPrefillFieldValues);
            Assert.NotNull(appointmentPrefillFieldValueVersions);
            Assert.AreEqual(1,appointmentPrefillFieldValues.Count);
            Assert.AreEqual(2,appointmentPrefillFieldValueVersions.Count);
            
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValues[0].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Version, appointmentPrefillFieldValues[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, appointmentPrefillFieldValues[0].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValues[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValues[0].CreatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedAt.ToString(), appointmentPrefillFieldValues[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValues[0].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValues[0].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValues[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValues[0].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValues[0].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValues[0].AppointmentFvId);
            
            Assert.AreEqual(1, appointmentPrefillFieldValueVersions[0].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValueVersions[0].AppointmentPrefillFieldValueId);
            Assert.AreEqual(1, appointmentPrefillFieldValueVersions[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, appointmentPrefillFieldValueVersions[0].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValueVersions[0].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValueVersions[0].CreatedByUserId);
            Assert.AreEqual(oldUpdatedAt.ToString(), appointmentPrefillFieldValueVersions[0].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValueVersions[0].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValueVersions[0].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValueVersions[0].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValueVersions[0].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValueVersions[0].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValueVersions[0].AppointmentFvId);
            
            Assert.AreEqual(2, appointmentPrefillFieldValueVersions[1].Id);
            Assert.AreEqual(appointmentPrefillFieldValue.Id, appointmentPrefillFieldValueVersions[1].AppointmentPrefillFieldValueId);
            Assert.AreEqual(2, appointmentPrefillFieldValueVersions[1].Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, appointmentPrefillFieldValueVersions[1].WorkflowState);
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedAt.ToString(), appointmentPrefillFieldValueVersions[1].CreatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.CreatedByUserId, appointmentPrefillFieldValueVersions[1].CreatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedAt.ToString(), appointmentPrefillFieldValueVersions[1].UpdatedAt.ToString());
            Assert.AreEqual(appointmentPrefillFieldValue.UpdatedByUserId, appointmentPrefillFieldValueVersions[1].UpdatedByUserId);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentId, appointmentPrefillFieldValueVersions[1].AppointmentId);
            Assert.AreEqual(appointmentPrefillFieldValue.MicrotingSiteUid, appointmentPrefillFieldValueVersions[1].MicrotingSiteUid);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldId, appointmentPrefillFieldValueVersions[1].FieldId);
            Assert.AreEqual(appointmentPrefillFieldValue.FieldValue, appointmentPrefillFieldValueVersions[1].FieldValue);
            Assert.AreEqual(appointmentPrefillFieldValue.AppointmentFvId, appointmentPrefillFieldValueVersions[1].AppointmentFvId);
        }
    }
}