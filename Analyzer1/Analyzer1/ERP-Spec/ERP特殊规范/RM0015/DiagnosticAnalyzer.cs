using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeAnalyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Rm0015Analyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "RM0015";

        private const string Category = "ERP����淶";

        private static readonly string Title = "61.CodeAnalyzer.SPEC:RM0015";

        private static readonly string MessageFormat = "AppService�ķ���\"{0}\"������[ActionDescription]���";

        private static readonly string Description = "ERP����淶>SPEC:RM0015;AppService�ķ���������[ActionDescription]���";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat,
            Category, DiagnosticSeverity.Error, true, Description,
            CommonHelper.helpLinkUri);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var methodSymbol = (IMethodSymbol)context.Symbol;

            //var attributeDatas = methodSymbol.GetAttributes();

            //if (methodSymbol.ContainingType.BaseType != null &&
            //    methodSymbol.ContainingType.BaseType.Name == "AppService" &&
            //    attributeDatas.Any(x => x.AttributeClass.Name == "ActionDescriptionAttribute") == false)
            //{
            if (methodSymbol.Name.EndsWith("AppService"))
            {
                //methodSymbol.ContainingType.BaseType!=null && methodSymbol.ContainingType.BaseType

                var diagnostic = Diagnostic.Create(Rule, methodSymbol.Locations[0], methodSymbol.Name);

                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}