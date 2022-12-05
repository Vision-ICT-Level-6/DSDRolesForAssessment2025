using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using RolesForAssessment.AuthorizationHandlers;
using RolesForAssessment.AuthorizationRequirements;
using RolesForAssessment.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//the default identity of the user
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


// All 3 handlers need to the registered with the service container in program.cs: 
builder.Services.AddSingleton<IAuthorizationHandler, IsInRoleHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, HasClaimHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, ViewRolesHandler>();



builder.Services.AddRazorPages();

//The AddPolicy method takes the name of the policy, and an AuthorizationPolicyBuilder which has a RequireRole method, enabling us to state which roles are required
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policyBuilder => policyBuilder.RequireRole("Admin"));
    options.AddPolicy("AdminPolicy", policyBuilder => policyBuilder.RequireClaim("Admin"));

    //We use the RequireAssertion method, which takes an AuthorizationHandlerContext as a parameter providing access to the current user
    options.AddPolicy("ViewRolesPolicy", policyBuilder => policyBuilder.RequireAssertion(context =>
    {
        // We use the FindFirst method to access a claim and obtain its value(if there is one) and convert it to a DateTime
        var joiningDateClaim = context.User.FindFirst(c => c.Type == "Joining Date")?.Value;
        var joiningDate = Convert.ToDateTime(joiningDateClaim);

        //We use the HasClaim method to establish that a claim with the specified value exists 
        //We compare the joining date value with DateTime.MinValue and the current date to ensure that the claim is not null, and that the date is earlier than six months ago
        return context.User.HasClaim("Permission", "View Roles") && joiningDate > DateTime.MinValue && joiningDate < DateTime.Now.AddMonths(-6);

    }));
    options.AddPolicy("ViewRolesPolicy", policyBuilder => policyBuilder.AddRequirements(new ViewRolesRequirement(months: -6)));
});




//Having configured the policy named AdminPolicy, we can apply it to the AuthorizeFolder method to ensure that only members of the Admin role can access the content: 
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/RolesManager", "AdminPolicy");

});


//=======NEW SECURITY============

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;


    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;

});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

//=============END NEW SECURITY================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
