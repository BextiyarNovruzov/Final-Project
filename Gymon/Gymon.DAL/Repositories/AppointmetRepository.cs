using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class AppointmetRepository : GenericRepository<Appointment>, IAppointmentRepository
    {

        private readonly GymonDbContext _context;

        public AppointmetRepository(GymonDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task CreateAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        // Aynı tarih ve saatte daha önce randevu alıp almadığını kontrol eder
        public async Task<bool> IsDuplicateAppointmentAsync(int userId, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            return await _context.Appointments
                .AnyAsync(a => a.UserId == userId && a.AppointmentDate.Date == appointmentDate.Date && a.AppointmentTime == appointmentTime);
        }
    }
}
