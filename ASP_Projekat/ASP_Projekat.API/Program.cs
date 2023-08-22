using ASP_Projekat.API;
using ASP_Projekat.API.Core;
using ASP_Projekat.API.DTO;
using ASP_Projekat.API.Email;
using ASP_Projekat.API.Extensions;
using ASP_Projekat.API.Jwt.TokenStorage;
using ASP_Projekat.API.Middleware;
using ASP_Projekat.Application;
using ASP_Projekat.Application.Emails;
using ASP_Projekat.Application.Logging;
using ASP_Projekat.Application.UseCaseHandling;
using ASP_Projekat.Application.UseCases.Commands.Blog;
using ASP_Projekat.Application.UseCases.Commands.Comment;
using ASP_Projekat.Application.UseCases.Commands.Image;
using ASP_Projekat.Application.UseCases.Commands.Reaction;
using ASP_Projekat.Application.UseCases.Commands.ReactOnBlog;
using ASP_Projekat.Application.UseCases.Commands.Role;
using ASP_Projekat.Application.UseCases.Commands.Tag;
using ASP_Projekat.Application.UseCases.Commands.User;
using ASP_Projekat.Application.UseCases.Queries.Blog;
using ASP_Projekat.Application.UseCases.Queries.Comment;
using ASP_Projekat.Application.UseCases.Queries.Image;
using ASP_Projekat.Application.UseCases.Queries.LogEntries;
using ASP_Projekat.Application.UseCases.Queries.Reaction;
using ASP_Projekat.Application.UseCases.Queries.Role;
using ASP_Projekat.Application.UseCases.Queries.Tag;
using ASP_Projekat.Application.UseCases.Queries.User;
using ASP_Projekat.DataAccess;
using ASP_Projekat.Domain;
using ASP_Projekat.Implementation.Emails;
using ASP_Projekat.Implementation.Logging;
using ASP_Projekat.Implementation.UseCases.Commands.Blog;
using ASP_Projekat.Implementation.UseCases.Commands.Comment;
using ASP_Projekat.Implementation.UseCases.Commands.Image;
using ASP_Projekat.Implementation.UseCases.Commands.Reaction;
using ASP_Projekat.Implementation.UseCases.Commands.ReactOnBlog;
using ASP_Projekat.Implementation.UseCases.Commands.Role;
using ASP_Projekat.Implementation.UseCases.Commands.Tag;
using ASP_Projekat.Implementation.UseCases.Commands.User;
using ASP_Projekat.Implementation.UseCases.Queries.Blog;
using ASP_Projekat.Implementation.UseCases.Queries.Comment;
using ASP_Projekat.Implementation.UseCases.Queries.Image;
using ASP_Projekat.Implementation.UseCases.Queries.LogEntry;
using ASP_Projekat.Implementation.UseCases.Queries.Reaction;
using ASP_Projekat.Implementation.UseCases.Queries.Role;
using ASP_Projekat.Implementation.UseCases.Queries.Tag;
using ASP_Projekat.Implementation.UseCases.Queries.User;
using ASP_Projekat.Implementation.Validators.Blog;
using ASP_Projekat.Implementation.Validators.Comment;
using ASP_Projekat.Implementation.Validators.Image;
using ASP_Projekat.Implementation.Validators.LogEntry;
using ASP_Projekat.Implementation.Validators.Reaction;
using ASP_Projekat.Implementation.Validators.ReactOnBlog;
using ASP_Projekat.Implementation.Validators.Role;
using ASP_Projekat.Implementation.Validators.Tag;
using ASP_Projekat.Implementation.Validators.User;
using Bugsnag.AspNet.Core;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<BlogDbContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);   
}); 
builder.Services.AddBugsnag(configuration => {
    configuration.ApiKey = appSettings.BugSnagKey;
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IApplicationUser>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];

    var data = header.ToString().Split("Bearer ");

    if (data.Length < 2)
    {
        return new AnonimousUser();
    }

    var handler = new JwtSecurityTokenHandler();

    var tokenObj = handler.ReadJwtToken(data[1].ToString());

    var claims = tokenObj.Claims;

    var email = claims.First(x => x.Type == "Email").Value;
    var id = claims.First(x => x.Type == "Id").Value;
    var username = claims.First(x => x.Type == "Username").Value;
    var useCases = claims.First(x => x.Type == "UseCases").Value;

    List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

    return new JwtUser
    {
        Email = email,
        UseCaseIds = useCaseIds,
        Id = int.Parse(id),
        Username = username,
    };
});
builder.Services.AddJwt(appSettings);

builder.Services.AddTransient<BlogDbContext>();
//Dependency za Blogove
builder.Services.AddTransient<ISearchBlogsQuery, EfSearchBlogQuery>();
builder.Services.AddTransient<ICreateBlogCommand, EfCreateBlogCommand>();
builder.Services.AddTransient<IUpdateBlogCommand, EfUpdateBlogCommand>();
builder.Services.AddTransient<IDeleteBlogCommand, EfDeleteBlogCommand>();
builder.Services.AddTransient<IGetBlogQuery, EfGetBlogQuery>();

//Dependency za Korisnike
builder.Services.AddTransient<ISearchUsersQuery, EfSearchUsersQuery>();
builder.Services.AddTransient<IGetUserQuery, EfGetUserQuery>();
builder.Services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
builder.Services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

//Dependency Za Komentare
builder.Services.AddTransient<ISearchCommentQuery, EfSearchCommentQuery>();
builder.Services.AddTransient<ICreateCommentCommand, EfCreateCommentCommand>();
builder.Services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
builder.Services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();

//Dependency Za Slike
builder.Services.AddTransient<IGetImageQuery, EfGetImageQuery>();
builder.Services.AddTransient<ICreateImageCommand, EfCreateImageCommand>();
builder.Services.AddTransient<IDeleteImageCommand, EfDeleteImageCommand>();

//Dependency za Reakcije
builder.Services.AddTransient<IGetReactionQuery, EfGetReactionQuery>();
builder.Services.AddTransient<ICreateReactionCommand, EfCreateReactionCommand>();
builder.Services.AddTransient<IDeleteReactionCommand, EfDeleteReactionCommand>();

//Dependency za Role
builder.Services.AddTransient<IGetRoleQuery, EfGetRoleQuery>();
builder.Services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
builder.Services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();

//Dependency za Tagove
builder.Services.AddTransient<IGetTagQuery, EfGetTagQuery>();
builder.Services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
builder.Services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();

//Dependency za Reakcije Na Blogove
builder.Services.AddTransient<IReactOnBlogCommand, EfReactOnBlogCommand>();
builder.Services.AddTransient<IDeleteReactionOnBlogCommand, EfDeleteReactOnBlogCommand>();

//Dependency za Log Entries
builder.Services.AddTransient<IGetLogEntriesQuery, EfLogEntryQuery>();

//Loggeri
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();

//Email
builder.Services.AddTransient<IEmailSender, EmailSend>();

//Validatori za Blogove
builder.Services.AddTransient<CreateBlogValidator>();
builder.Services.AddTransient<UpdateBlogValidator>();
builder.Services.AddTransient<DeleteBlogValidator>();
builder.Services.AddTransient<GetBlogValidator>();

//Validatori za Usere
builder.Services.AddTransient<CreateUserValidator>();
builder.Services.AddTransient<SearchUserIdValidator>();
builder.Services.AddTransient<UpdateUserValidator>();
builder.Services.AddTransient<DeleteUserValidator>();

//Validatori za komentare
builder.Services.AddTransient<CreateCommentValidator>();
builder.Services.AddTransient<UpdateCommentValidator>();
builder.Services.AddTransient<DeleteCommentValidator>();

//Validatori za Slike
builder.Services.AddTransient<GetImageValidator>();
builder.Services.AddTransient<CreateImageValidator>();
builder.Services.AddTransient<DeleteImageValidator>();

//Validatori za Reakcije
builder.Services.AddTransient<GetReactionValidator>();
builder.Services.AddTransient<CreateReactionValidator>();
builder.Services.AddTransient<DeleteReactionValidator>();

//Validatori Za Role
builder.Services.AddTransient<GetRoleValidator>();
builder.Services.AddTransient<CreateRoleValidator>();
builder.Services.AddTransient<DeleteRoleValidator>();

//Validatori Za Tagove
builder.Services.AddTransient<GetTagValidator>();
builder.Services.AddTransient<CreateTagValidator>();
builder.Services.AddTransient<DeleteTagValidator>();

//Validatori za Reakcije Na blogove
builder.Services.AddTransient<ReactOnBlogValidator>();
builder.Services.AddTransient<DeleteReactionOnBlogValidator>();

//Validatori za Log Entries
builder.Services.AddTransient<LogEntryValidator>();

builder.Services.AddTransient<ICommandHandler, CommandHandler>();
builder.Services.AddTransient<IQueryHandler, QueryHandler>();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>(); builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP_Projekat.API", Version = "v1" });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
