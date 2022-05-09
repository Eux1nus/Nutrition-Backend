using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class AppDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Questions> Questions { get; set; } 
        public DbSet<QuestionsPhoto> QuestionsPhotos { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
        public DbSet<RequestForm> ApplicationForms { get; set; }
        public DbSet<BloodTestPhoto> BloodTestPhotos { get; set; }
        public DbSet<CalendarOfEvent> CalendarOfEvents { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CommentsFile > CommentsFile { get; set; }
        public DbSet<Consultations> Consultations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FoodDiary> FoodDiaries { get; set; }
        public DbSet<Servant> Servants { get; set; }
        public DbSet<ServantPhoto> ServantPhotos { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserServant> UserServants { get; set; }
        public DbSet<AdditionalOptions> AdditionalOptions { get; set; }
        public DbSet<AdditionalOptionsServant> AdditionalOptionsServants { get; set; }
        public DbSet<GiftSertificate> GiftSertificates { get;set; }
        public DbSet<RequestForm> RequestForms { get; set; }
        public DbSet<UserAdditionalOptions> UserAdditionalOptions { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<UserGiftSertificate> UserGiftSertificates { get; set; }
        public DbSet<AfterBuyAdditionalServant> AfterBuyAdditionalServants { get; set; }
        public AppDBContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Nutrition;Username=postgres;Password=Ivan230691");
        }
    }
}
