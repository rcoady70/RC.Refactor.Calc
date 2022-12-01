// See https://aka.ms/new-console-template for more information
using RC.Refactor.Calc;

Console.WriteLine("Hello, World!");
FeeVariables feeUKInfo = new()
{
    membership = "X",
    revenue = 100
};
FeeVariablesWithNewMember feeIEInfo = new()
{
    membership = "X",
    revenue = 100,
    newMember = true,
};
UK ukCalc = new UK();
ukCalc.Caculate(feeUKInfo);

//Factory
//
var factoryUK = CalcFactory.GetCalc<FeeVariables>("UK");
factoryUK.Caculate(feeUKInfo);

var factoryIE = CalcFactory.GetCalc<FeeVariablesWithNewMember>("IE");
factoryUK.Caculate(feeIEInfo);