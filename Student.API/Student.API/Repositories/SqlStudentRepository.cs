﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Student.API.DataModels;

namespace Student.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;
        public SqlStudentRepository(StudentAdminContext context) {
        
            this.context = context;
        }

        public async Task<List<DataModels.Student>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }


        public async Task<DataModels.Student> GetStudentAsync(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(
                x => x.Id == studentId);

        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await context.Gender.ToListAsync();

        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<DataModels.Student> UpdateStudent(Guid studentId, DataModels.Student request)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName=request.FirstName;
                existingStudent.LastName=request.LastName;
                existingStudent.DateOfBirth=request.DateOfBirth;
                existingStudent.Email=request.Email;
                existingStudent.Mobile=request.Mobile;
                existingStudent.GenderId=request.GenderId;
                existingStudent.Address.PhysicalAdress=request.Address.PhysicalAdress;
                existingStudent.Address.PostalAdress =request.Address.PostalAdress;

                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<DataModels.Student> DeleteStudent(Guid studentId)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if (existingStudent != null)
            {
                context.Student.Remove(existingStudent);

                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<DataModels.Student> AddStudent(DataModels.Student request)
        {
            var student = await context.Student.AddAsync(request);
            await context.SaveChangesAsync();
            return student.Entity;

        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student = await GetStudentAsync(studentId);
            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

