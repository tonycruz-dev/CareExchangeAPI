using CareExchangeAPI.Models;
using CareExchangeAPI.SeedModel;
using Microsoft.AspNetCore.Identity;

namespace CareExchangeAPI.Data;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context, UserManager<Models.User> userManager)
    {
        if (context.UserProfiles.Any()) return;
        // get washpass.json from data folder
        var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "Seed-data.json");
        var json = await File.ReadAllTextAsync(jsonFilePath);
        var rootobject = System.Text.Json.JsonSerializer.Deserialize<Rootobject>(json);
        var appUsers = rootobject?.CareExchange.Users;

        if (!userManager.Users.Any())
        {
            foreach (var user in appUsers)
            {
                Models.Enums.UserType currentUserType;
                if (user.CurrentUserType == "Candidate")
                {
                    currentUserType = Models.Enums.UserType.Candidate;
                }
                else if (user.CurrentUserType == "CareHome")
                {
                    currentUserType = Models.Enums.UserType.CareHome;
                }
                else if (user.CurrentUserType == "Admin")
                {
                    currentUserType = Models.Enums.UserType.Admin;
                }
                else
                {
                    currentUserType = Models.Enums.UserType.Candidate;
                }

                var newUser = new Models.User
                {
                    UserName = user.Email,
                    Email = user.Email,
                    DisplayName = user.DisplayName,
                    CurrentUserType = currentUserType
                };
                await userManager.CreateAsync(newUser, "Password123!");
            }
            var userProfiles = rootobject?.CareExchange.UserProfiles;
            var profileCountr = 1;
            foreach (var userProfile in userProfiles)
            {
                var user = await userManager.FindByEmailAsync(userProfile.Email);
                if (user == null) continue;
                var newUserProfile = new UserProfile
                {
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    PreferredName = userProfile.PreferredName,
                    Email = user.Email,
                    Mobile = userProfile.Mobile,
                    ProfileUserID = user.Id,
                    HomeAddress = userProfile.HomeAddress,
                    HomeCity = userProfile.HomeCity,
                    HomePostCode = userProfile.HomePostCode,
                    WorkingAddress = userProfile.WorkingAddress,
                    WorkingCity = userProfile.WorkingCity,
                    WorkingPostCode = userProfile.WorkingPostCode,
                    EmploymentType = Models.Enums.EmploymentType.PAYE,
                    DateOfBirth = DateTime.UtcNow.AddYears(-25),
                    CurrentUserType = user.CurrentUserType,
                    StartedAtCX = DateTime.UtcNow,
                    PayrollID = userProfile.PayrollID,
                    ProfilePhoto = $"https://cdn.example.com/profiles/{profileCountr}/image.jpg",
                    User = user
                };
                context.UserProfiles.Add(newUserProfile);
                await context.SaveChangesAsync();
                profileCountr++;
            }
            var careHomeClients = rootobject?.CareExchange.CareHomeClients;
            var careHomeClientCount = 1;
            foreach (var careHomeClient in careHomeClients)
            {
                var user = await userManager.FindByEmailAsync(careHomeClient.Email);
                if (user == null) continue;
                var newCareHomeClient = new CareHomeClient
                {
                    CareHomeClientUserID = user.Id,
                    Name = careHomeClient.Name,
                    Email = careHomeClient.Email,
                    LegalEntity = careHomeClient.LegalEntity,
                    CompanyNumber = careHomeClient.CompanyNumber,
                    Phone = careHomeClient.Phone,
                    CreatedAt = DateTime.UtcNow.ToLocalTime(),
                    User = user
                };
                context.CareHomeClients.Add(newCareHomeClient);
                await context.SaveChangesAsync();
                careHomeClientCount++;
            }
            var careHomeClientLocations = rootobject?.CareExchange.CareHomeClientLocations;
            var careHomeClientLocationCount = 1;
            foreach (var careHomeClientLocation in careHomeClientLocations)
            {
                var careHomeClient = context.CareHomeClients.FirstOrDefault(x => x.Id == careHomeClientLocation.CareHomeClientID);

                if (careHomeClient == null) continue;
                var newCareHomeClientLocation = new CareHomeClientLocation
                {
                    CareHomeClientID = careHomeClient.Id,
                    Name = careHomeClientLocation.Name,
                    Address = careHomeClientLocation.Address,
                    City = careHomeClientLocation.City,
                    PostCode = careHomeClientLocation.PostCode,
                    DefaultStartTime = TimeSpan.Parse(careHomeClientLocation.DefaultStartTime),
                    DefaultEndTime = TimeSpan.Parse(careHomeClientLocation.DefaultEndTime),
                    Latitude = careHomeClientLocation.Latitude,
                    Longitude = careHomeClientLocation.Longitude,
                    Status = Models.Enums.CareHomeLocationStatus.Active,
                    CareHomeClient = careHomeClient
                };

                context.CareHomeClientLocations.Add(newCareHomeClientLocation);
                await context.SaveChangesAsync();
                careHomeClientLocationCount++;
            }
            var jobTypes = rootobject?.CareExchange.JobTypes;
            var jobTypeCount = 1;
            foreach (var jobType in jobTypes)
            {
                var newJobType = new Models.JobType
                {
                    Name = jobType.Name,
                };
                context.JobTypes.Add(newJobType);
                await context.SaveChangesAsync();
                jobTypeCount++;
            }
            var skills = rootobject?.CareExchange.Skills;
            var skillCount = 1;
            foreach (var skill in skills)
            {
                var newSkill = new Models.Skill
                {
                    Name = skill.Name,
                };
                context.Skills.Add(newSkill);
                await context.SaveChangesAsync();
                skillCount++;
            }

            var shifts = rootobject?.CareExchange.Shifts;
            var shiftCount = 1;
            foreach (var shift in shifts)
            {
                var careHomeClientLocation = context.CareHomeClientLocations.FirstOrDefault(x => x.LocationID == shift.LocationID);
               
                var shiftStatus = Enum.TryParse<Models.Enums.ShiftStatus>(shift.Status, out var parsedStatus)
                        ? parsedStatus
                        : Models.Enums.ShiftStatus.NeverFilled;
                var newShift = new Models.Shift
                {
                    LocationID = careHomeClientLocation.LocationID,
                    StartTime = shift.StartTime,
                    EndTime = shift.EndTime,
                    JobTypeID = shift.JobTypeID,
                    Status = shiftStatus,
                    BreakMinutes = shift.BreakMinutes,
                    HourlyRate = (decimal)shift.HourlyRate,
                    Notes = shift.Notes,
                    CreatedByClientUserID =shift.CreatedByClientUserID,
                    //UserProfile = userProfile
                };
                context.Shifts.Add(newShift);
                await context.SaveChangesAsync();
                shiftCount++;
            }
            var shiftRates = rootobject?.CareExchange.ShiftRates;
            var shiftRateCount = 1;
            foreach (var shiftRate in shiftRates)
            {
                var rateType = Enum.TryParse<Models.Enums.RateType>(shiftRate.RateType, out var parsedRateType)
                        ? parsedRateType
                        : Models.Enums.RateType.Base;
                var newShiftRate = new Models.ShiftRate
                {
                    ShiftRateId = shiftRate.ShiftId,
                    HourlyRate = (decimal)shiftRate.HourlyRate,
                    RateType = rateType,
                    // Shift = shift
                };
                context.ShiftRates.Add(newShiftRate);
                await context.SaveChangesAsync();
                shiftRateCount++;
            }
        }
         
       

    }
}
