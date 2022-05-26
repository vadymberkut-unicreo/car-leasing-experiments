using CarLeasingExperiments.Car;
using CarLeasingExperiments.Controllers;
using CarLeasingExperiments.Entities;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.State;
using CarLeasingExperiments.Transitions;

namespace CarLeasingExperiments
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // register specific state trees
            services.AddSingleton<ICarStateTree, CarStateTree>((sp) =>
            {
                var tree = new CarStateTree(StateEnum.Initial);
                tree.AddNextState(
                    typeof(ToATransition),
                    new CarStateTree(StateEnum.StateA)
                        .AddNextState(
                            typeof(AToBTransition),
                            new CarStateTree(StateEnum.StateB)
                                .AddNextState(
                                    typeof(BToCTransition),
                                    new CarStateTree(StateEnum.StateC)
                                )
                                .AddNextState(
                                    typeof(BToDTransition),
                                    new CarStateTree(StateEnum.StateD)
                                )
                        )
                );
                return tree;
            });

            services.AddTransient<ICarTransitionManager, CarTransitionManager>();
            services.AddTransient<IStateDataStore, StateDataStore>();

            // register transitions
            services.AddTransient<ToATransition>();
            services.AddTransient<AToBTransition>();
            services.AddTransient<BToCTransition>();
            services.AddTransient<BToDTransition>();

            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if(environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();
            app.UseEndpoints(endpoints => 
                endpoints.MapControllers()
            );

            Test(app);
        }

        private void Test(IApplicationBuilder app)
        {
            var carTransitionManager = app.ApplicationServices.GetRequiredService<ICarTransitionManager>();

            UserEntity currentUserEntity = new UserEntity()
            {
                Roles = new string[] { "SuperAdmin" },
            };
            CarEntity carEntity = new CarEntity();
            
            carTransitionManager.Transit(currentUserEntity, carEntity, StateEnum.StateA);
            carTransitionManager.Transit(currentUserEntity, carEntity, StateEnum.StateB);
            
            // next state can be C or D
            carTransitionManager.Transit(currentUserEntity, carEntity, StateEnum.StateC, new BToCTransitionData() { Limit = 10 });
            // carTransitionManager.Transit(currentUserEntity, carEntity, StateEnum.StateD);
        }
    }
}
