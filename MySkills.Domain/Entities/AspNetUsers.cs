using System;
using System.Collections.Generic;

namespace MySkills.Domain.Entities
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            ExcelExports = new HashSet<ExcelExports>();
            ImportFiles = new HashSet<ImportFiles>();
            PropCertifications = new HashSet<PropCertifications>();
            PropSkills = new HashSet<PropSkills>();
            Ptlcertifications = new HashSet<Ptlcertifications>();
            Ptlskills = new HashSet<Ptlskills>();
            Staffs = new HashSet<Staffs>();
            Tumranks = new HashSet<Tumranks>();
            UserCertifications = new HashSet<UserCertifications>();
            UserSkillL3 = new HashSet<UserSkillL3>();
            UserSkills = new HashSet<UserSkills>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adident { get; set; }
        public string Login { get; set; }
        public DateTime? DateCreation { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Statut { get; set; }
        public int? RankId { get; set; }

        public virtual Ranks Rank { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<ExcelExports> ExcelExports { get; set; }
        public virtual ICollection<ImportFiles> ImportFiles { get; set; }
        public virtual ICollection<PropCertifications> PropCertifications { get; set; }
        public virtual ICollection<PropSkills> PropSkills { get; set; }
        public virtual ICollection<Ptlcertifications> Ptlcertifications { get; set; }
        public virtual ICollection<Ptlskills> Ptlskills { get; set; }
        public virtual ICollection<Staffs> Staffs { get; set; }
        public virtual ICollection<Tumranks> Tumranks { get; set; }
        public virtual ICollection<UserCertifications> UserCertifications { get; set; }
        public virtual ICollection<UserSkillL3> UserSkillL3 { get; set; }
        public virtual ICollection<UserSkills> UserSkills { get; set; }
    }
}
