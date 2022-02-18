using Microsoft.OpenApi.Models;
using TimeSheets.BL.Repositories;
using Microsoft.EntityFrameworkCore;
using TmSheets.DAL;

namespace TimeSheets.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API сервиса работы с персоналом",
                    Description = "Тут можно поиграть с api нашего сервиса",
                    TermsOfService = new Uri("http://some_api_server/controllers"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ivanov",
                        Email = string.Empty,
                        Url = new Uri("http://my_first_site.ru"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "можно указать под какой лицензией все опубликовано",
                        Url = new Uri("http://example.com/license"),
                    }
                });

            });

            var connectionString = Configuration.GetConnectionString("myDB");
            services.AddDbContext<MyDbContext>(options=> options.UseSqlite(connectionString));

            //services.AddEntityFrameworkSqlite()
            //    .AddDbContext<MyDbContext>(options =>
            //      options.UseSqlite(connectionString);
            services.AddScoped<PersonRepository>();

            //            PrepareSchema(connection);
        }

        //private void PrepareSchema(SQLiteConnection connection)
        //{
        //    using (var command = new SQLiteCommand(connection))
        //    {
        //        // Задаём новый текст команды для выполнения
        //        // Удаляем таблицу с метриками, если она есть в базе данных
        //        command.CommandText = "DROP TABLE IF EXISTS persons";
        //        // Отправляем запрос в базу данных
        //        command.ExecuteNonQuery();


        //        command.CommandText = @"CREATE TABLE persons(id INTEGER PRIMARY KEY,
        //            value INT, time INT)";
        //        command.ExecuteNonQuery();
        //    }
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c =>
            //    {
            //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса агента сбора метрик");
            //    });
            //}

            //app.UseRouting();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Включение middleware в пайплайн для обработки Swagger запросов.
            app.UseSwagger();
            // включение middleware для генерации swagger-ui 
            // указываем Swagger JSON эндпоинт (куда обращаться за сгенерированной спецификацией
            // по которой будет построен UI).
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API сервиса работы с персоналом");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
