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
        public string AddCompany(Company company)
        {

            using (AppDBContext db = new())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }

            return "Done";
        }
        public List<Company> GetAllCompanies()
        {
            using AppDBContext db = new();

            return db.Companies.Include(c => c.Vacansies).ToList<Company>();
        }



        public Company GetCompanyById(int id)
        {
            using AppDBContext db = new();

            return db.Companies.Find(id);
        }
        public async Task EditCompany(Company edited)
        {
            using AppDBContext db = new();
            db.Companies.Update(edited);
            await db.SaveChangesAsync();
        }
        public void RemoveCompany(Company company)
        {
            using (AppDBContext db = new())
            {
                if (company != null)
                {
                    db.Companies.Remove(company);
                    db.SaveChanges();
                }
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



        public List<Role> GetAllRoles()
        {
            using AppDBContext db = new();
            return db.Roles.ToList<Role>();
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

        public List<Vacancy> GetAllVacancies()
        {
            using AppDBContext db = new();
            var x = db.Vacancies.Include(x => x.Role).Include(x => x.Company).ToList();
            return x;
        }

        //public Role GetRoleById(int id)
        //{
        //    using AppDBContext db = new();

        //    return db.Roles.FirstOrDefault<Role>(x => x.Id == id);
        //}
        public void RemoveVacancy(Vacancy vacancy)
        {
            using (AppDBContext db = new())
            {
                if (vacancy != null)
                {
                    db.Vacancies.Remove(vacancy);
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region ForApplicant
        public List<Applicant> GetAllApplicants()
        {
            using AppDBContext db = new();

            return db.Applicants.Include(x => x.Role).ToList();
        }
        internal void AddApplicant(Applicant applicant)
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
        internal void EditApplicant(Applicant applicant)
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
        #endregion

        #region ForDeal
        public Task<List<Deal>> GetAllDeals()
        {


            return Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Deals.Include(x => x.Applicant).Include(x => x.Vacancy).Include(x => x.Vacancy.Role).ToList();
            }
            );
        }


        #endregion

    }
}
