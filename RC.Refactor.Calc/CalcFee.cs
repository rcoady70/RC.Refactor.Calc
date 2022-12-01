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

    public class UK : ICaculateFee<FeeVariables>
    {
        public decimal Caculate(FeeVariables feeVariables)
        {
            if (feeVariables.revenue < 100000)
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