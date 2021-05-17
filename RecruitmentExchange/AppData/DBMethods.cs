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
        public async static Task<string> RemoveCompany(Company company)
        {

            using (AppDBContext db = new())
            {
                if (company != null)
                {
                    db.Companies.Remove(company);
                    await db.SaveChangesAsync();
                }

            }

            return "Done";
        }
        public static List<Company> GetAllCompanies()
        {
            using AppDBContext db = new();

            return db.Companies.ToList<Company>();
        }
        public static Company GetCompanyById(int id)
        {
            using AppDBContext db = new();

            return db.Companies.Find(id);
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
            AddRole(new Role() { Name = "Чел" + DateTime.Now.TimeOfDay });

            using AppDBContext db = new();
            return db.Roles.ToList<Role>();
        }

        #endregion

        #region ForVacancy
        public static void AddVacany(Vacancy vacancy)
        {
            using AppDBContext db = new();
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
    

    }
}
