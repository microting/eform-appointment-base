/*
The MIT License (MIT)
Copyright (c) 2007 - 2019 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.AppointmentBase.Infrastructure.Data.Entities
{
    public class AppointmentPrefillFieldValue : BaseEntity
    {
        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }

        public int MicrotingSiteUid { get; set; }

        public int FieldId { get; set; }

        public string FieldValue { get; set; }

        public int? AppointmentFvId { get; set; }

        public virtual Appointment Appointment { get; set; }

        public async Task Create(AppointmentPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = eForm.Infrastructure.Constants.Constants.WorkflowStates.Created;
            
            dbContext.AppointmentPrefillFieldValues.Add(this);
            dbContext.SaveChanges();

            dbContext.AppointmentPrefillFieldValueVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(AppointmentPnDbContext dbContext)
        {
            AppointmentPrefillFieldValue appointmentPrefillFieldValue = dbContext.AppointmentPrefillFieldValues.FirstOrDefault(x => x.Id == Id);

            if (appointmentPrefillFieldValue == null)
            {
                throw new NullReferenceException($"Could not find AppointmentPrefillFieldValue with {Id}");
            }

            appointmentPrefillFieldValue.AppointmentId = AppointmentId;
            appointmentPrefillFieldValue.MicrotingSiteUid = MicrotingSiteUid;
            appointmentPrefillFieldValue.FieldId = FieldId;
            appointmentPrefillFieldValue.FieldValue = FieldValue;
            appointmentPrefillFieldValue.AppointmentFvId = AppointmentFvId;
            appointmentPrefillFieldValue.WorkflowState = WorkflowState;
            appointmentPrefillFieldValue.UpdatedByUserId = UpdatedByUserId;
            

            if (dbContext.ChangeTracker.HasChanges())
            {
                appointmentPrefillFieldValue.UpdatedAt = DateTime.UtcNow;
                appointmentPrefillFieldValue.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.AppointmentPrefillFieldValueVersions.Add(MapVersions(appointmentPrefillFieldValue));
                dbContext.SaveChanges();
            }  
        }

        public async Task Delete(AppointmentPnDbContext dbContext)
        {
            AppointmentPrefillFieldValue appointmentPrefillFieldValue = dbContext.AppointmentPrefillFieldValues.FirstOrDefault(x => x.Id == Id);

            if (appointmentPrefillFieldValue == null)
            {
                throw new NullReferenceException($"Could not find AppointmentPrefillFieldValue with {Id}");
            }

            appointmentPrefillFieldValue.WorkflowState = eForm.Infrastructure.Constants.Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                appointmentPrefillFieldValue.UpdatedAt = DateTime.UtcNow;
                appointmentPrefillFieldValue.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.AppointmentPrefillFieldValueVersions.Add(MapVersions(appointmentPrefillFieldValue));
                dbContext.SaveChanges();
            }  
        }

        private AppointmentPrefillFieldValueVersion MapVersions(
            AppointmentPrefillFieldValue appointmentPrefillFieldValue)
        {
            AppointmentPrefillFieldValueVersion appointmentPrefillFieldValueVersion =
                new AppointmentPrefillFieldValueVersion()
                {
                    AppointmentId = appointmentPrefillFieldValue.AppointmentId,
                    MicrotingSiteUid = appointmentPrefillFieldValue.MicrotingSiteUid,
                    FieldId = appointmentPrefillFieldValue.FieldId,
                    FieldValue = appointmentPrefillFieldValue.FieldValue,
                    AppointmentFvId = appointmentPrefillFieldValue.AppointmentFvId,
                    Version = appointmentPrefillFieldValue.Version,
                    CreatedAt = appointmentPrefillFieldValue.CreatedAt,
                    CreatedByUserId = appointmentPrefillFieldValue.CreatedByUserId,
                    UpdatedAt = appointmentPrefillFieldValue.UpdatedAt,
                    UpdatedByUserId = appointmentPrefillFieldValue.UpdatedByUserId,
                    WorkflowState = appointmentPrefillFieldValue.WorkflowState,
                    AppointmentPrefillFieldValueId = appointmentPrefillFieldValue.Id
                };
            return appointmentPrefillFieldValueVersion;
        }
    }
}