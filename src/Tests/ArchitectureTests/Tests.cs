using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Npu.Domain.Tokens;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace Npu.Tests.ArchitectureTests;

public class Tests
{
    private readonly Architecture _architecture;
    private readonly System.Reflection.Assembly _apiProject;
    private readonly System.Reflection.Assembly _infrastructureProject;
    private readonly System.Reflection.Assembly _applicationProject;
    private readonly System.Reflection.Assembly _domainProject;

    public Tests()
    {
        _apiProject = typeof(Api.DependencyInjection).Assembly;
        _infrastructureProject = typeof(Infrastructure.DependencyInjection).Assembly;
        _applicationProject = typeof(Application.DependencyInjection).Assembly;
        _domainProject = typeof(Class1).Assembly;

        _architecture = new ArchLoader()
            .LoadAssemblies(
                _apiProject,
                _infrastructureProject,
                _applicationProject,
                _domainProject
            )
            .Build();
    }

    [Fact]
    public void DtoMappers_Should_BeInternal()
    {
        IArchRule mapperRule = Classes()
            .That()
            .ResideInAssembly(_apiProject)
            .And()
            .HaveNameEndingWith("Mapper")
            .Should().NotBePublic()
            .Because("they should be internal")
            ;

        mapperRule.Check(_architecture);
    }

    [Fact]
    public void Repositories_Should_BeCorrectlyImplemented()
    {
        var implementationAssemblyRule =
            Classes().That()
            .AreNotAbstract().And().HaveNameEndingWith("Repository")
            .Should().ResideInAssembly(_infrastructureProject)
            .Because("that is where nasty dependencies go")
            ;
        var implementationInternalRule = 
            Classes().That()
            .AreNotAbstract().And().HaveNameEndingWith("Repository")
            .Should().BeInternal()
            .Because("they should only be exposed through their interfaces")
            ;
        var interfaceAssemblyrule =
            Interfaces().That()
            .HaveNameEndingWith("Repository")
            .Should().ResideInAssembly(_applicationProject)
            .Because("that is required by Clean Architecture")
            ;

        implementationAssemblyRule
            .And(implementationInternalRule)
            .And(interfaceAssemblyrule)
            .Check(_architecture);
    }
}