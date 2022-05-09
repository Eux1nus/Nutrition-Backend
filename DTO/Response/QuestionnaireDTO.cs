using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class QuestionnaireDTO
    {
        public double Heigh { get; set; }
        public double CurrentWeight { get; set; }
        public double DesiredWeight { get; set; }
        public double NeckVolume { get; set; }
        public double BreastVolume { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double BloodType { get; set; }

        public QuestionnaireDTO() { }

        public QuestionnaireDTO(Questionnaire questionnaire)
        {
            if (questionnaire == null)
                return;
            Heigh = questionnaire.Heigh;
            CurrentWeight = questionnaire.CurrentWeight;
            DesiredWeight = questionnaire.DesiredWeight;
            NeckVolume = questionnaire.NeckVolume;
            BreastVolume = questionnaire.BreastVolume;
            Waist = questionnaire.Waist;
            Hips = questionnaire.Hips;
        }
    }
}
