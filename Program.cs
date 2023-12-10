using ProvaNeoApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSqlContext(builder.Configuration);
builder.Services.AddRepositoryManager();

builder.Services.AddServiceManager();

builder.Services.AddAuthentication();
builder.Services.AddIdentityConfig();
builder.Services.AddJWT(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
