using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;
using Services.Account.Default;
using Services.Authorize;
using Services.BloodTestPhoto;
using Services.Code;
using Services.Comments;
using Services.CommentsFile;
using Services.Consultations;
using Services.Email;
using Services.Events;
using Services.FoodDiary;
using Services.GifSertificate;
using Services.Mail;
using Services.Payment;
using Services.Photo;
using Services.Questionnaire;
using Services.Questions;
using Services.QuestionsPhoto;
using Services.Servants;
using Services.SMSC;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class Installer
    {
        public static void AddServices(this IServiceCollection container)
        {
            container
                .AddScoped<IActivationCodeRepository, ActivationCodesRepository>()
                .AddScoped<IApplicationFormsRepository, ApplicationFormsRepository>()
                .AddScoped<IBloodTestPhotoRepository, BloodTestPhotoRepository>()
                .AddScoped<ICalendarOfEventsRepository, CalendarOfEventsRepository>()
                .AddScoped<ICommentsFileRepository, CommentsFileRepository>()
                .AddScoped<ICommentsRepository, CommentsRepository>()
                .AddScoped<IConsultationsRepository, ConsultationsRepository>()
                .AddScoped<ICountryRepository, CountryRepository>()
                .AddScoped<IFoodDiaryRepository, FoodDiaryRepository>()
                .AddScoped<IQuestionsPhotoRepository, QuestionsPhotoRepository>()
                .AddScoped<IQuestionsRepository, QuestionsRepository>()
                .AddScoped<IServantPhotoRepository, ServantPhotoRepository>()
                .AddScoped<IServantRepository, ServantRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserServantRepository, UserServantRepository>()
                .AddScoped<IPaymentRepository, PaymentRepository>()
                .AddScoped<IAdditionalOptionsRepository, AdditionalOptionsRepository>()
                .AddScoped<IAfterBuyAdditionalServantRepository, AfterBuyAdditionalServantRepository>()
                .AddScoped<IAdditionalOptionsServantRepository, AdditionalOptionsServantRepository>()
                .AddScoped<IUserAdditionalOptionsRepository, UserAdditionalOptionsRepository>()
                .AddScoped<IQuestionnaireRepository, QuestionnaireRepository>()
                .AddScoped<IBloodTestPhotoRepository, BloodTestPhotoRepository>()
                .AddScoped<IGiftSertificateRepository, GiftSertificateRepository>()
                .AddScoped<IUserGiftSertificateRepository, UserGiftSertificateRepository>()
                .AddScoped<ICalendarOfEventsRepository, CalendarOfEventsRepository>()

                .AddScoped<IPaymentService, PaymentService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAuthorizeService, AuthorizeService>()
                .AddScoped<ICommentsService, CommentsService>()
                .AddScoped<IQuestionsService, QuestionsService>()
                .AddScoped<IPhotoService, PhotoService>()
                .AddScoped<IQuestionsPhotoService, QuestionsPhotoService>()
                .AddScoped<IActivationCodeService, ActivationCodeService>()
                .AddScoped<IFoodDiaryService, FoodDiaryService>()
                .AddScoped<ISmscService, SmscService>()
                .AddScoped<IConsultationsService, ConsultationsService>()
                .AddScoped<IServantService, ServantService>()
                .AddScoped<IQuestionnaireService, QuestionnaireService>()
                .AddScoped<ICommentsFileService, CommentsFileService>()
                .AddScoped<IGiftSertificateService, GiftSertificateService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<ICalendarOfEventService, CalendarOfEventService>()
                .AddScoped<IBloodTestPhotoService, BloodTestPhotoService>();
        }
    }
}
