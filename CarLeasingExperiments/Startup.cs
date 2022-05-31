using Autofac;
using CarLeasingExperiments.Car;
using CarLeasingExperiments.Constants;
using CarLeasingExperiments.Controllers;
using CarLeasingExperiments.Entities;
using CarLeasingExperiments.Infrustructure;
using CarLeasingExperiments.Mocks;
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

            services.AddSingleton<ITransitionRegister, TransitionRegister>();
            services.AddTransient<ITransitionResolver, TransitionResolver>();
            services.AddTransient<IFlowStore, FlowStore>();

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

            TestAutofac();
            Test(app);
        }

        private void TestAutofac()
        {
            var builder = new ContainerBuilder();
            //var container = builder.Build();
        }

        private void Test(IApplicationBuilder app)
        {
            var flowStore = app.ApplicationServices.GetRequiredService<IFlowStore>();
            var carTransitionManager = app.ApplicationServices.GetRequiredService<ICarTransitionManager>();

            UserEntity currentUserEntity = new UserEntity()
            {
                Roles = new string[] { "SuperAdmin", "Admin", "Dealer" },
            };

            FlowEntity mainCarFlow = DbMock.Flows.Single(x => x.Id == "MainCarFlow");
            FlowEntity alternativeCarFlow = DbMock.Flows.Single(x => x.Id == "AlternativeCarFlow");

            CarEntity car1 = DbMock.Cars.Single(x => x.Id == "Car1");
            CarEntity car2 = DbMock.Cars.Single(x => x.Id == "Car2");
            CarEntity car3 = DbMock.Cars.Single(x => x.Id == "Car3");

            flowStore.SetEntityFlow(car1.Id, mainCarFlow.Id);
            flowStore.SetEntityFlow(car2.Id, alternativeCarFlow.Id);
            // car3 has no explicit flow set

            // car1
            carTransitionManager.Transit(currentUserEntity, car1, StateNameIds.StateA);
            carTransitionManager.Transit(currentUserEntity, car1, StateNameIds.StateB, new AToBTransitionData() { Message = "Test" });
            
            // next state can be C or D
            carTransitionManager.Transit(currentUserEntity, car1, StateNameIds.StateC, new BToCTransitionData() { Limit = 10 });
            // carTransitionManager.Transit(currentUserEntity, carEntity, StateNameIds.StateD);

            // car2
            carTransitionManager.Transit(currentUserEntity, car2, StateNameIds.StateA);
            carTransitionManager.Transit(currentUserEntity, car2, StateNameIds.StateB, new AToBTransitionData() { Message = "Test" });
            //carTransitionManager.Transit(currentUserEntity, car2, StateNameIds.StateC); // error

            // car3
            carTransitionManager.Transit(currentUserEntity, car3, StateNameIds.StateA);
            carTransitionManager.Transit(currentUserEntity, car3, StateNameIds.StateB, new AToBTransitionData() { Message = "Test" });
            carTransitionManager.Transit(currentUserEntity, car3, StateNameIds.StateD);
        }
    }
}
