namespace RC.Refactor.Calc
{
    //public interface IFeeVariables
    //{
    //    string membership { get; set; }
    //    string membershipBand { get; set; }
    //    decimal revenue { get; set; }
    //}
    public class FeeVariables //: IFeeVariables
    {
        public decimal revenue { get; set; }
        public string membership { get; set; }
        public string membershipBand { get; set; }
    }
    public class FeeVariablesWithNewMember //: IFeeVariables
    {
        public decimal revenue { get; set; }
        public string membership { get; set; }
        public string membershipBand { get; set; }
        public bool newMember { get; set; }
    }
    public interface ICaculateFee<IFeeVariables>
    {
        decimal Caculate(IFeeVariables feeParms);
    }
    /// <summary>
    /// UK calculator
    /// </summary>
    public class UK : ICaculateFee<FeeVariables>
    {
        public Dictionary<decimal, Func<FeeVariables, bool>> _feeRules { get; set; } = new();

        public decimal Caculate(FeeVariables feeVariables)
        {
            //Rules as a lambda
            _feeRules.Add(100, f => f.revenue < 100000);
            _feeRules.Add(200, f => feeVariables.membership == "X");
            _feeRules.Add(300, f => feeVariables.membership == "X" && feeVariables.revenue < 100010 && feeVariables.membershipBand == "A");
            _feeRules.Add(400, f => f.revenue > 100000);
            foreach (var rule in _feeRules)
            {
                if ((bool)rule.Value.DynamicInvoke(feeVariables))
                {
                    return rule.Key;
                }
            }
            //Assuming up to 10 rules at least
            return 0;
        }
    }
    /// <summary>
    /// IE calculator
    /// </summary>
    public class IE : ICaculateFee<FeeVariablesWithNewMember>
    {
        public decimal Caculate(FeeVariablesWithNewMember feeVariables)
        {
            if (feeVariables.revenue < 100000 || feeVariables.newMember)
                return 0;
            if (feeVariables.membership == "X")
                return 100.00M;
            if (feeVariables.membership == "X" && feeVariables.revenue > 100000)
                return 200.00M;
            if (feeVariables.membership == "X" && feeVariables.revenue > 100000 && feeVariables.membershipBand == "A")
                return 300.00M;
            //ETC... 
            return 0;
        }
    }

}