﻿using CareExchangeAPI.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace CareExchangeAPI.EntityDataModels;

public class CareExchangeDataModel
{
    public  IEdmModel GetEntityDataModel()
    {
        var builder = new ODataConventionModelBuilder
        {
            Namespace = "CareExchange",
            ContainerName = "CareExchangeContainer"
        };
        builder.EntitySet<CareHomeClient>("CareHomeClients");
        builder.EntitySet<CareHomeClientLocation>("CareHomeClientLocations");
        builder.EntitySet<UserProfile>("UserProfiles");
        builder.EntitySet<Skill>("Skills");
        builder.EntitySet<JobType>("JobTypes");
        builder.EntitySet<Shift>("Shifts");
        builder.EntitySet<ShiftAssignment>("ShiftAssignments");
        builder.EntitySet<ShiftRate>("ShiftRates");
        builder.EntitySet<Timesheet>("Timesheets");
        builder.EntitySet<Document>("Documents");
        builder.EntitySet<CandidateDocument>("CandidateDocuments");
        builder.EntitySet<Notification>("Notifications");
        builder.EntitySet<Message>("Messages");
        builder.EntitySet<CalendarEvent>("CalendarEvents");
        builder.EntitySet<ShiftOffer>("ShiftOffers");
        builder.EntitySet<CandidateAvailability>("CandidateAvailabilities");
        builder.EntitySet<ShiftLog>("ShiftLogs");
        builder.EntitySet<ShiftRating>("ShiftRatings");
        builder.EntitySet<ClientPayment>("ClientPayments");
        builder.EntitySet<CandidatePayout>("CandidatePayouts");




        //var bookingServices = builder.EntitySet<BookingService>("BookingServices");
        //bookingServices.EntityType.HasKey(bs => new { bs.BookingId, bs.ServiceId });



        builder.EnableLowerCamelCase(NameResolverOptions.ProcessReflectedPropertyNames);
        return builder.GetEdmModel();
    }
}
