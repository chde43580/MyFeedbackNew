using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using MyFeedback.Application.Query;
using MyFeedback.Domain.Entities;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace MyFeedback.Test
{
    public class ArchitectureTest
    {
        private static readonly Architecture Architecture = new ArchLoader().LoadAssemblies(typeof(IExitSlipQuery).Assembly, typeof(ExitSlip).Assembly).Build();

        //use As() to give your variables a custom description
        private readonly IObjectProvider<IType> Application =
            Types().That().ResideInAssembly("MyFeedback.Application.Command").As("Application");

        private readonly IObjectProvider<IType> Domain =
           Types().That().ResideInAssembly("MyFeedback.Domain").As("Domain");

        private readonly IObjectProvider<Class> ExitSlipQuery =
            Classes().That().ImplementInterface("IExitSlipQuery").As("ExitSlipQuery");

        private readonly IObjectProvider<IType> Backend =
            Types().That().ResideInNamespace("MyFeedback.Backend").As("Backend Rest API");

        private readonly IObjectProvider<Interface> ForbiddenInterfaces =
            Interfaces().That().HaveFullNameContaining("Query").As("Forbidden Interfaces");


    
            [Fact]
            public void CleanArchitectureForAllProjects()
            {

            // Define the rule for each project in the solution
            IArchRule domainShouldNotDependOnApplication = Types()
                    .That()
                    .ResideInNamespace("MyFeedback.Domain")
                    .Should()
                    .NotDependOnAny(Types()
                    .That()
                    .ResideInNamespace("MyFeedback.Application"))
                    .WithoutRequiringPositiveResults();

                IArchRule applicationShouldNotDependOnBackend = Types()
                    .That()
                    .ResideInNamespace("MyFeedback.Application")
                    .Should()
                    .NotDependOnAny(Types()
                    .That()
                    .ResideInNamespace("MyFeedback.Backend"))
                    .WithoutRequiringPositiveResults();

                IArchRule backendShouldNotDependOnDomain = Types()
                    .That()
                    .ResideInNamespace("MyFeedback.Backend")
                    .Should()
                    .NotDependOnAny(Types()
                    .That()
                    .ResideInNamespace("MyFeedback.Domain"))
                    .WithoutRequiringPositiveResults();

                // Check the rules
                domainShouldNotDependOnApplication.Check(Architecture);
                applicationShouldNotDependOnBackend.Check(Architecture);
                backendShouldNotDependOnDomain.Check(Architecture);
            }





           
        }
    }