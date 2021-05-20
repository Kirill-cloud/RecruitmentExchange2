using Microsoft.EntityFrameworkCore;
using RecruitmentExchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentExchange.AppData
{
    public static class DBMethods
    {

        #region ForCompany
        public static string AddCompany(Company company)
        {

            using (AppDBContext db = new())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }

            return "Done";
        }
        public static List<Company> GetAllCompanies()
        {
            using AppDBContext db = new();

            return db.Companies.Include(c => c.Vacansies).ToList<Company>();
        }
        public static Company GetCompanyById(int id)
        {
            using AppDBContext db = new();

            return db.Companies.Find(id);
        }
        public static async Task EditCompany(Company edited)
        {
            using AppDBContext db = new();
            db.Companies.Update(edited);
            await db.SaveChangesAsync();
        }
        public async static Task RemoveCompany(Company company)
        {
            using (AppDBContext db = new())
            {
                if (company != null)
                {
                    var x = db.Companies.Find(company.Id);
                    db.Companies.Remove(x);
                    await db.SaveChangesAsync();
                }
            }
        }

        #endregion

        #region ForRole
        public static void AddRole(Role role)
        {
            using AppDBContext db = new();
            db.Roles.Add(role);
            db.SaveChanges();
        }
        public static List<Role> GetAllRoles()
        {
            using AppDBContext db = new();
            return db.Roles.ToList<Role>();
        }
        public async static Task<string> RemoveRole(Role role)
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

        public static async Task EditRole(Role edited)
        {
            using AppDBContext db = new();
            db.Roles.Update(edited);
            await db.SaveChangesAsync();
        }

        #endregion

        #region ForVacancy
        public static void AddVacany(Vacancy vacancy)
        {
            using AppDBContext db = new();

            var role = db.Roles.Find(vacancy.Role.Id);
            vacancy.Role = role;
            var company = db.Companies.Find(vacancy.Company.Id);

            vacancy.Company = company;


            db.Vacancies.Add(vacancy);
            db.SaveChanges();
        }
        public static List<Vacancy> GetAllVacancies()
        {
            using AppDBContext db = new();
            var x = db.Vacancies.Include(x => x.Role).Include(x => x.Company).ToList();
            return x;
        }

        public static Role GetRoleById(int id)
        {
            using AppDBContext db = new();

            return db.Roles.FirstOrDefault<Role>(x => x.Id == id);
        }

        #endregion

        #region ForApplicant
        public static List<Applicant> GetAllApplicants()
        {
            using AppDBContext db = new();

            return db.Applicants.Include(x => x.Role).ToList();
        }
        #endregion

        #region ForDeal
        public static Task<List<Deal>> GetAllDeals()
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
