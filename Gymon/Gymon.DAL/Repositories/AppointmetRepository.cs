using Gymon.Core.Entities;
using Gymon.Core.Enums;
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
        public async Task<List<Appointment>> GetPendingAppointmentsAsync()
        {
            var result = await FindAsync(a => a.Status == AppointmentStatus.Pending); // Önce bekle
            return result.ToList(); // Sonra listeye çevir
        }


        public async Task<bool> ConfirmAppointmentAsync(int id)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment == null) return false;

            appointment.Status = AppointmentStatus.Confirmed;
            await UpdateAsync(appointment);
            await SaveChangesAsync();

            return true;
        }
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Set<Appointment>()
                .Include(a => a.Trainer) // Include Trainer
                .Include(a => a.SportType) // Include SportType
                .ToListAsync();
        }


        public async Task<bool> CancelAppointmentAsync(int id)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment == null) return false;

            appointment.Status = AppointmentStatus.Canceled;
            await UpdateAsync(appointment);
            await SaveChangesAsync();

            return true;
        }
    }
}
