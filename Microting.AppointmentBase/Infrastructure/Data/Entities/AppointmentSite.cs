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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eFormShared;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.AppointmentBase.Infrastructure.Data.Entities
{
    public class AppointmentSite : BaseEntity
    {
        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }

        public int MicrotingSiteUid { get; set; }

        public string ExceptionString { get; set; }

        [StringLength(255)]
        public string SdkCaseId { get; set; }

        [StringLength(255)]
        public string ProcessingState { get; set; }

        public short? Completed { get; set; }

        public virtual Appointment Appointment { get; set; }
        
        public async Task Create(AppointmentPnDbContext dbContext)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Version = 1;
            WorkflowState = Constants.WorkflowStates.Created;
            
            dbContext.AppointmentSites.Add(this);
            dbContext.SaveChanges();

            dbContext.AppointmentSiteVersions.Add(MapVersions(this));
            dbContext.SaveChanges();
        }

        public async Task Update(AppointmentPnDbContext dbContext)
        {
            AppointmentSite appointmentSite = dbContext.AppointmentSites.FirstOrDefault(x => x.Id == Id);

            if (appointmentSite == null)
            {
                throw new NullReferenceException($"Could not find AppointmentSite with {Id}");
            }

            appointmentSite.AppointmentId = AppointmentId;
            appointmentSite.MicrotingSiteUid = MicrotingSiteUid;
            appointmentSite.ExceptionString = ExceptionString;
            appointmentSite.SdkCaseId = SdkCaseId;
            appointmentSite.ProcessingState = ProcessingState;
            appointmentSite.Completed = Completed;
            appointmentSite.WorkflowState = WorkflowState;
            appointmentSite.UpdatedByUserId = UpdatedByUserId;

            if (dbContext.ChangeTracker.HasChanges())
            {
                appointmentSite.UpdatedAt = DateTime.Now;
                appointmentSite.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.AppointmentSiteVersions.Add(MapVersions(appointmentSite));
                dbContext.SaveChanges();
            }
        }

        public async Task Delete(AppointmentPnDbContext dbContext)
        {
            AppointmentSite appointmentSite = dbContext.AppointmentSites.FirstOrDefault(x => x.Id == Id);

            if (appointmentSite == null)
            {
                throw new NullReferenceException($"Could not find AppointmentSite with {Id}");
            }

            appointmentSite.WorkflowState = eFormShared.Constants.WorkflowStates.Removed;

            if (dbContext.ChangeTracker.HasChanges())
            {
                appointmentSite.UpdatedAt = DateTime.Now;
                appointmentSite.Version += 1;
                dbContext.SaveChanges();
                
                dbContext.AppointmentSiteVersions.Add(MapVersions(appointmentSite));
                dbContext.SaveChanges();
            }
        }

        private AppointmentSiteVersion MapVersions(AppointmentSite appointmentSite)
        {
            AppointmentSiteVersion appointmentSiteVersion = new AppointmentSiteVersion()
            {
                AppointmentId = appointmentSite.AppointmentId,
                MicrotingSiteUid = appointmentSite.MicrotingSiteUid,
                ExceptionString = appointmentSite.ExceptionString,
                SdkCaseId = appointmentSite.SdkCaseId,
                ProcessingState = appointmentSite.ProcessingState,
                Completed = appointmentSite.Completed,
                AppointmentSiteId = appointmentSite.Id,
                Version = appointmentSite.Version,
                CreatedAt = appointmentSite.CreatedAt,
                CreatedByUserId = appointmentSite.CreatedByUserId,
                UpdatedAt = appointmentSite.UpdatedAt,
                UpdatedByUserId = appointmentSite.UpdatedByUserId,
                WorkflowState = appointmentSite.WorkflowState
            };
            return appointmentSiteVersion;
        }
    }
}