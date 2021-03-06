using AutoMapper;
using LIB.Domain.Interfaces;
using LIB.Domain.Requests;
using LIB.Infrastructure;
using LIB.Infrastructure.Interfaces;
using LIB.Infrastructure.Repositories;
using LIB.Infrastructure.Services;
using LIB.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LIB.Core
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
            services.AddDbContext<LibDBContext>
       (options => options.UseSqlServer(Configuration.GetConnectionString("LibDb")));
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IEditorRepository, EditorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IEditorService, EditorService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IAuthorRequest, AuthorRequest>();
            services.AddScoped<IBookRequest, BookRequest>();
            services.AddScoped<IEditorRequest, EditorRequest>();
            services.AddScoped<IGenreRequest, GenreRequest>();
            services.AddScoped<IPublisherRequest, PublisherRequest>();
            services.AddScoped<IContactRequest, ContactRequest>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
