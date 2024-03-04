using AgremiacionOdontologica.Data;
using AgremiacionOdontologica.Dtos;
using AgremiacionOdontologica.Models;
using AgremiacionOdontologica.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;
using AgremiacionOdontologica.Controllers.Models;

namespace AgremiacionOdontologica
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Bono, BonoDto>()
                    .ForMember(dto => dto.odontologo, opt => opt.MapFrom(src => src.odontologo.nombre))
                    .ForMember(dto => dto.paciente, opt => opt.MapFrom(src => src.paciente.nombre))
                    .ForMember(dto => dto.bonoEstado, opt => opt.MapFrom(src => src.estado.nombre))
                    .ForMember(dto => dto.practica, opt => opt.MapFrom(src => src.practica.nombre))
                    .ForMember(dto => dto.obraSocial, opt => opt.MapFrom(src => src.obraSocial.nombre));

                CreateMap<Entrega, EntregaDto>()
                   .ForMember(dto => dto.odontologoNombre, opt => opt.MapFrom(src => src.odontologo.nombre))
                   .ForMember(dto => dto.odontologoApellido, opt => opt.MapFrom(src => src.odontologo.apellido))
                   .ForMember(dto => dto.obraSocial, opt => opt.MapFrom(src => src.obraSocial.nombre));



                CreateMap<Domicilio, DomicilioDto>()
                    .ForMember(dto => dto.localidad, opt => opt.MapFrom(src => src.localidad.nombre))
                    .ForMember(dto => dto.odontologoNombre, opt => opt.MapFrom(src => src.odontologoNombre))
                    .ForMember(dto => dto.odontologoNombre, opt => opt.MapFrom(src => src.odontologoApellido));

                CreateMap<Localidad, LocalidadDto>()
                    .ForMember(dto => dto.provincia, opt => opt.MapFrom(src => src.provincia.nombre));
                 
                
                ////////////////////////////////
                 /// DTOS a MODELOS:

                CreateMap<EntregaDto, Entrega>()
                   .ForMember(dest => dest.odontologo, opt => opt.Ignore())
                   .ForMember(dest => dest.obraSocial, opt => opt.Ignore());
                
                CreateMap<ObraSocialDto, ObraSocial>()
                    .ForMember(dest => dest.id, opt => opt.Ignore());

                CreateMap<BonoDto, Bono>()
                    .ForMember(dest => dest.odontologo, opt => opt.Ignore()); // Ignora la propiedad de navegación para evitar problemas de seguimiento de Entity Framework

                CreateMap<PracticaDto, Practica>()
                    .ForMember(dest => dest.id, opt => opt.Ignore());

                CreateMap<PacienteDto, Paciente>()
                    .ForMember(dest => dest.id, opt => opt.Ignore());

                CreateMap<OdontologoDto, Odontologo>()
                  .ForMember(dest => dest.id, opt => opt.Ignore());

                CreateMap<ProvinciaDto, Provincia>()
                    .ForMember(dest => dest.id, opt => opt.Ignore());
               
                CreateMap<LocalidadDto,Localidad>()
                   .ForMember(dest => dest.provincia, opt => opt.Ignore());

                CreateMap<DomicilioDto, Domicilio>()
                   .ForMember(dest => dest.odontologoNombre, opt => opt.Ignore())
                   .ForMember(dest => dest.odontologoApellido, opt => opt.Ignore())
                   .ForMember(dest => dest.localidad, opt => opt.Ignore());
            }
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDb>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnection")));
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<BonoService>();
            services.AddScoped<OdontologoService>();
            services.AddScoped<ObraSocialService>();
            services.AddScoped<PacienteService>();
            services.AddScoped<PracticaService>();
            services.AddScoped<DomicilioService>();
            services.AddScoped<LocalidadService>();
            services.AddScoped<ProvinciaService>();
            services.AddScoped<EntregaService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgremiacionOdontologica", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgremiacionOdontologica v1"));
            }
            // interfaz grafica swagger:https://localhost:5002/swagger/index.html

            app.UseCors("AllowAllOrigins");

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
