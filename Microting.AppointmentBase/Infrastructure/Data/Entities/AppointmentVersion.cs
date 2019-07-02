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
using System.ComponentModel.DataAnnotations;
using Microting.eFormApi.BasePn.Infrastructure.Database.Base;

namespace Microting.AppointmentBase.Infrastructure.Data.Entities
{
    public class AppointmentVersion : BaseEntity
    {
        public int? AppointmentId { get; set; }

        public string GlobalId { get; set; }

        public DateTime? StartAt { get; set; }

        public DateTime? ExpireAt { get; set; }

        public int? Duration { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        [StringLength(255)]
        public string ProcessingState { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        public string Body { get; set; }

        public string ExceptionString { get; set; }

        public string SiteIds { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Info { get; set; }

        [StringLength(255)]
        public string MicrotingUid { get; set; }

        public short? Connected { get; set; }

        public short? Completed { get; set; }

        public string Replacements { get; set; }

        public int? SdkeFormId { get; set; }

        public string Response { get; set; }

        public short? ColorRule { get; set; }
    }
}