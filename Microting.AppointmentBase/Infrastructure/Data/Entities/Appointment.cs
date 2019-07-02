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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.AppointmentBase.Infrastructure.Data.Entities
{
    public class Appointment : BaseEntity
    {
        public Appointment()
        {
            this.AppointmentSites = new HashSet<AppointmentSite>();
            this.AppointmentPrefillFieldValues = new HashSet<AppointmentPrefillFieldValue>();
        }

        public string GlobalId { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? ExpireAt { get; set; }

        public int? Duration { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        [StringLength(255)]
        public string ProcessingState { get; set; }

        public string Body { get; set; }

        public string ExceptionString { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Info { get; set; }

        [StringLength(255)]
        public string MicrotingUuid { get; set; }

        public short? Completed { get; set; }

        public string Replacements { get; set; }

        public int? SdkeFormId { get; set; }

        public string Response { get; set; }

        public short? ColorRule { get; set; }

        public virtual ICollection<AppointmentSite> AppointmentSites { get; set; }

        public virtual ICollection<AppointmentPrefillFieldValue> AppointmentPrefillFieldValues { get; set; }

        public override string ToString()
        {
            string globalId = "";
            string start = "";
            string _title = "";
            string _processing_state = "";

            if (GlobalId != null)
                globalId = GlobalId;

            if (StartAt != null)
                start = StartAt.ToString();

            if (Title != null)
                _title = Title;

            if (ProcessingState != null)
                _processing_state = ProcessingState;

            return "GlobalId:" + globalId + " / Start:" + start + " / Title:" + _title + " / Processing state:" + _processing_state;
        }

        public async Task Create(AppointmentPnDbContext dbContext)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Version = 1;
            WorkflowState = eFormShared.Constants.WorkflowStates.Created;
            
            dbContext.Appointments.Add(this);
            dbContext.SaveChanges();

            dbContext.AppointmentVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(AppointmentPnDbContext dbContext)
        {
            Appointment appointment = dbContext.Appointments.FirstOrDefault(x => x.Id == Id);

            if (appointment == null)
            {
                throw new NullReferenceException($"Could not find Appointment with {Id}");
            }

            appointment.GlobalId = GlobalId;
            appointment.StartAt = StartAt;
            appointment.ExpireAt = ExpireAt;
            appointment.Duration = Duration;
            appointment.Subject = Subject;
            appointment.ProcessingState = ProcessingState;
            appointment.Body = Body;
            appointment.ExceptionString = ExceptionString;
            appointment.Title = Title;
            appointment.Description = Description;
            appointment.Info = Info;
            appointment.MicrotingUuid = MicrotingUuid;
            appointment.Completed = Completed;
            appointment.Replacements = Replacements;
            appointment.SdkeFormId = SdkeFormId;
            appointment.Response = Response;
            appointment.ColorRule = ColorRule;
            appointment.UpdatedByUserId = UpdatedByUserId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                appointment.UpdatedAt = DateTime.UtcNow;
                appointment.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.AppointmentVersions.Add(MapVersions(appointment));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(AppointmentPnDbContext dbContext)
        {
            Appointment appointment = dbContext.Appointments.FirstOrDefault(x => x.Id == Id);

            if (appointment == null)
            {
                throw new NullReferenceException($"Could not find Appointment with {Id}");
            }

            appointment.WorkflowState = eFormShared.Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                appointment.UpdatedAt = DateTime.UtcNow;
                appointment.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.AppointmentVersions.Add(MapVersions(appointment));
                dbContext.SaveChanges();
            }
        }

        private AppointmentVersion MapVersions(Appointment appointment)
        {
            AppointmentVersion appointmentVersion = new AppointmentVersion()
            {
                GlobalId = appointment.GlobalId,
                StartAt = appointment.StartAt,
                ExpireAt = appointment.ExpireAt,
                Duration = appointment.Duration,
                Subject = appointment.Subject,
                ProcessingState = appointment.ProcessingState,
                Body = appointment.Body,
                ExceptionString = appointment.ExceptionString,
                Title = appointment.Title,
                Description = appointment.Description,
                Info = appointment.Info,
                MicrotingUid = appointment.MicrotingUuid,
                Completed = appointment.Completed,
                Replacements = appointment.Replacements,
                SdkeFormId = appointment.SdkeFormId,
                Response = appointment.Response,
                ColorRule = appointment.ColorRule,
                AppointmentId = appointment.Id,
                Version = appointment.Version,
                CreatedAt = appointment.CreatedAt,
                CreatedByUserId = appointment.CreatedByUserId,
                UpdatedAt = appointment.UpdatedAt,
                UpdatedByUserId = appointment.UpdatedByUserId,
                WorkflowState = appointment.WorkflowState
                
            };
            return appointmentVersion;
        }
    }
}