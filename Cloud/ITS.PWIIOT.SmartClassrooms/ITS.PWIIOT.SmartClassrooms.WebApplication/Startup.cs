using Hangfire;
using Hangfire.SqlServer;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Calendar_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Classroom_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Course_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Email_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Interfaces.Data;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.IOT_Hub_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Lesson_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Log_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Login_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Microcontroller_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Service_Bus_Services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Subject_services;
using ITS.PWIIOT.SmartClassrooms.ApplicationCore.Teacher_services;
using ITS.PWIIOT.SmartClassrooms.Infrastructure;
using ITS.PWIIOT.SmartClassrooms.Infrastructure.Data;
using ITS.PWIIOT.SmartClassrooms.WebApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.PWIIOT.SmartClassrooms.WebApplication
{ 
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddHostedService<ReceiverWorker>();
            services.AddHostedService<LogWorker>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<IClassroomService, ClassroomService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IIotHubService, IotHubService>();
            services.AddTransient<IMessage, ServiceBusService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICalendarService, CalendarService>();
            services.AddScoped<IMicrocontrollerService, MicrocontrollerService>();
            services.AddScoped<IMicrocontrollerRepository, MicrocontrollerRepository>();
            services.AddSession();
            services.AddDbContext<SmartClassesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBSQL"))); //questo permette di fare richieste
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
