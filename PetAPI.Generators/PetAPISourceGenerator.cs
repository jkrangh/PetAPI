using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Linq;
using System.Text;

namespace PetAPI.Generators
{
    [Generator]
    public class PetAPISourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var entityInterfaces = new[] { "IDog" };

            var interfaceDeclarations = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: static (s, _) => s is InterfaceDeclarationSyntax,
                    transform: static (ctx, _) => ctx.SemanticModel.GetDeclaredSymbol((InterfaceDeclarationSyntax)ctx.Node))
                .Where(symbol => symbol is INamedTypeSymbol namedSymbol &&
                    entityInterfaces.Contains(namedSymbol.Name))
                .Collect();

            context.RegisterSourceOutput(interfaceDeclarations, (ctx, interfaceSymbols) =>
            {
                foreach (var symbol in interfaceSymbols) 
                {
                    if (symbol is INamedTypeSymbol interfaceSymbol)
                    {
                        var repositoryCode = GenerateRepository(interfaceSymbol);
                        ctx.AddSource($"{interfaceSymbol.Name.Substring(1)}Repository.g.cs", SourceText.From(repositoryCode, Encoding.UTF8));
                    }
                }
            });
        }

        private string GenerateRepository(INamedTypeSymbol interfaceSymbol)
        {
            var className = $"{interfaceSymbol.Name.Remove(0, 1)}Repository";
            var dbContextName = "PetAPIContext";

            var code = new StringBuilder();
            code.AppendLine($$"""
                using Microsoft.EntityFrameworkCore;
                using {{interfaceSymbol.ContainingNamespace.ToDisplayString()}}

                namespace PetAPI.Generated
                {
                    public {{className}} : {{interfaceSymbol.Name}}
                    {
                        
                        private readonly {{dbContextName}} _context;

                        public {{className}}({{dbContextName}} context)
                        {
                            _context = context
                        }
                """);
            foreach (var method in interfaceSymbol.GetMembers().OfType<IMethodSymbol>())
            { 
                var methodName = method.Name;
                var returnType = method.ReturnType.ToDisplayString();
                var parameters = string.Join(",", method.Parameters.Select(p => $"{p.Type.ToDisplayString()} {p.Name}"));
                var arguments = string.Join(",", method.Parameters.Select(p => p.Name));
                
            }
            return code.ToString();
        }
    }
}
