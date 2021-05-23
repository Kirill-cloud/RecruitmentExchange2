using Microsoft.EntityFrameworkCore;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.AppData
{
    public class DBMethods
    {

        #region ForCompany
        public async Task AddCompany(Company company)
        {
            using AppDBContext db = new();
            db.Companies.Add(company);
            await db.SaveChangesAsync();
        }
        public async Task<List<Company>> GetAllCompanies()
        {
            using AppDBContext db = new();

            return await db.Companies.Include(c => c.Vacansies).ToListAsync();
        }

        public async Task EditCompany(Company edited)
        {
            using AppDBContext db = new();
            db.Companies.Update(edited);
            await db.SaveChangesAsync();
        }
        public void RemoveCompany(Company company)
        {
            using AppDBContext db = new();
            if (company != null)
            {
                db.Companies.Remove(company);
                db.SaveChanges();
            }
        }

        #endregion

        #region ForRole
        public void AddRole(Role role)
        {
            using AppDBContext db = new();
            db.Roles.Add(role);
            db.SaveChanges();
        }


        public async Task<List<Role>> GetAllRoles()
        {
            using AppDBContext db = new();
            return await db.Roles.ToListAsync();
        }
        public async Task<string> RemoveRole(Role role)
        {

            using (AppDBContext db = new())
            {
                if (role != null)
                {
                    var x = db.Roles.Find(role.Id);
                    db.Roles.Remove(x);
                    await db.SaveChangesAsync();
                }

            }

            return "Done";
        }



        public async Task EditRole(Role edited)
        {
            using AppDBContext db = new();
            db.Roles.Update(edited);
            await db.SaveChangesAsync();
        }

        #endregion

        #region ForVacancy
        public void AddVacany(Vacancy vacancy)
        {
            using AppDBContext db = new();

            var role = db.Roles.Find(vacancy.Role.Id);
            vacancy.Role = role;
            var company = db.Companies.Find(vacancy.Company.Id);

            vacancy.Company = company;


            db.Vacancies.Add(vacancy);
            db.SaveChanges();
        }
        public void EditVacancy(Vacancy vacancy)
        {
            using AppDBContext db = new();
            db.Vacancies.Update(new Vacancy()
            {
                Id = vacancy.Id,
                CompanyId = vacancy.Company.Id,
                RoleId = vacancy.Role.Id,
                Description = vacancy.Description
            });
            db.SaveChanges();
        }

        public async Task<List<Vacancy>> GetAllVacancies()
        {
            using AppDBContext db = new();
            List<Vacancy> x = await db.Vacancies.Include(x => x.Role).Include(x => x.Company).ToListAsync();
            
            return x;
        }

        public void RemoveVacancy(Vacancy vacancy)
        {
            using AppDBContext db = new();
            if (vacancy != null)
            {
                db.Vacancies.Remove(vacancy);
                db.SaveChanges();
            }
        }

        #endregion

        #region ForApplicant
        public async Task<List<Applicant>> GetAllApplicants()
        {
            using AppDBContext db = new();

            return await db.Applicants.Include(x => x.Role).ToListAsync();
        }
        public void AddApplicant(Applicant applicant)
        {
            using AppDBContext db = new();

            var role = db.Roles.Find(applicant.Role.Id);


            db.Applicants.Add(new Applicant()
            {
                Name = applicant.Name,
                Role = role,
                Description = applicant.Description,
                Salary = applicant.Salary,
                IsActive = applicant.IsActive
            });

            db.SaveChanges();
        }
        public void EditApplicant(Applicant applicant)
        {
            using AppDBContext db = new();
            db.Applicants.Update(new Applicant()
            {
                Id = applicant.Id,
                Name = applicant.Name,
                RoleId = applicant.Role.Id,
                Description = applicant.Description,
                Salary = applicant.Salary,
                IsActive = applicant.IsActive
            });
            db.SaveChanges();
        }

        public void RemoveApplicant(Applicant applicant)
        {
            using AppDBContext db = new();
            if (applicant != null)
            {
                db.Applicants.Remove(applicant);
                db.SaveChanges();
            }
        }

        #endregion

        #region ForDeal
        public Task<List<Deal>> GetAllDeals()
        {


            return Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Deals
                              .Include(x => x.Applicant)
                              .Include(x => x.Vacancy)
                              .Include(x => x.Vacancy.Role)
                              .Include(x => x.Company).ToList();
            }
            );
        }

        internal void EditDeal(Deal deal)
        {
            using AppDBContext db = new();
            db.Deals.Update(new Deal()
            {
                Id = deal.Id,
                ApplicantId = deal.Applicant.Id,
                CompanyId = deal.Company.Id,
                VacancyId = deal.Vacancy.Id,
                Profit = deal.Profit
            });
            db.SaveChanges();
        }

        internal void AddDeal(Deal deal)
        {
            using AppDBContext db = new();
            db.Deals.Add(new Deal()
            {
                ApplicantId = deal.Applicant.Id,
                CompanyId = deal.Company.Id,
                VacancyId = deal.Vacancy.Id,
                Profit= deal.Profit
            });
            db.SaveChanges();
        }
        internal void RemoveDeal(Deal deal)
        {
            using AppDBContext db = new();
            if (deal != null)
            {
                db.Deals.Remove(deal);
                db.SaveChanges();
            }
        }

        #endregion

    }
}
