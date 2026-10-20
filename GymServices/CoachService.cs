using GymData;
using GymData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices
{
    public class CoachService
    {
        private readonly GymContextDB _context;

        public CoachService(GymContextDB context)
        {
            _context = context;
        }

        public async Task<List<Instructor>> GetAllCoaches()
        {
            return await _context.instructors.ToListAsync();
        }

        //public async Task<List<Instructor>> GetCoaches( int id)
        //{
        //    return await _context.instructors.ToListAsync();
        //}
        public async Task AddCoach(Instructor coach)
        {
            _context.instructors.Add(coach);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCoach(int id)
        {
            bool hasPackages = await _context.package.AnyAsync(p => p.ins_id == id);
            if (hasPackages)
                throw new InvalidOperationException("This instructor is assigned to packages and cannot be deleted.");

            var coach = await _context.instructors.FindAsync(id);
            if (coach == null)
                return;

            _context.instructors.Remove(coach);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCoach(Instructor coach)
        {
            var existing = await _context.instructors.FindAsync(coach.ins_id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(coach);
                await _context.SaveChangesAsync();
            }
        }


    }
}
