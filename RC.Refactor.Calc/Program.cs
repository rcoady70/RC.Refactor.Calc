// See https://aka.ms/new-console-template for more information
using RC.Refactor.Calc;

//
// I need to redactor some fee calculations.
//      -Different fee calculations per country currently about 6 countries 
//      -Some share the same inputs used to calculate the fee some do not
//      -Planning to do something with the rules used to calculate the fee which is a big string of if statements currently, not sure what yet a rules could generate alot of code.  
//      -Easy to unit test as there are quite a few scenarios.
// 
//


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

//
//Factory not sure this is bringing anything to major to the party still need to use if or switch to select the correct calculation
//
var factoryUK = CalcFactory.GetCalc<FeeVariables>("UK");
factoryUK.Caculate(feeUKInfo);

var factoryIE = CalcFactory.GetCalc<FeeVariablesWithNewMember>("IE");
factoryIE.Caculate(feeIEInfo);