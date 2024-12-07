namespace Coban.Application.BusinessRules.Utility;

public static class BusinessRuleValidator
{
    public static async Task CheckRulesAsync(params Func<Task>[] ruleChecks)
    {
        foreach (Func<Task> ruleCheck in ruleChecks)
        {
            await ruleCheck();
        }
    }
}
