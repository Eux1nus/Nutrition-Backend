using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Request
{
    public class CreateQuestionnaireDTO
    {
        public AlcoholDrink AlcoholDrink { get; set; }
        public CoffeeDependence CoffeeDependence { get; set; }
        public EndOfTheDayEnergy EndOfTheDayEnergy { get; set; }
        public Pressure Pressure { get; set; }
        public RegularStool RegularStool { get; set; }
        public SleepTime SleepTime { get; set; }
        public Smoking Smoking { get; set; }
        public SupplySystem SupplySystem { get; set; }
        public AboutMeInfo AboutMeInfo { get; set; }

        public double Heigh { get; set; }
        public double CurrentWeight { get; set; }
        public double DesiredWeight { get; set; }
        public double NeckVolume { get; set; }
        public double BreastVolume { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double BloodType { get; set; }

        public string SportActivities { get; set; }
        public string ConsultationPurpose { get; set; }
        public string MealsPerDay { get; set; }
        public string DietarySupplements { get; set; }
        public string DailyDiet { get; set; }
        public string Allergies { get; set; }
        public string ChronicDiseases { get; set; }
        public string Diabetes { get; set; }
        public string TonguePlaque { get; set; }
        public string SkinManifestations { get; set; }
    }
}
