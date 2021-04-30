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
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Microting.AppointmentBase.Infrastructure.Data.Factories
{
    public class AppointmentPnContextFactory : IDesignTimeDbContextFactory<AppointmentPnDbContext>
    {
        public AppointmentPnDbContext CreateDbContext(string[] args)
        {
            var defaultCs = "Server = localhost; port = 3306; Database = appointments-pn; user = root; Convert Zero Datetime = true;";
            var optionsBuilder = new DbContextOptionsBuilder<AppointmentPnDbContext>();
            optionsBuilder.UseMySql(args.Any() ? args[0] : defaultCs, new MariaDbServerVersion(
                new Version(10, 4, 0)), mySqlOptionsAction: builder =>
            {
                builder.EnableRetryOnFailure();
            });

            return new AppointmentPnDbContext(optionsBuilder.Options);
        }
    }
}