namespace RC.Refactor.Calc
{
    public static class CalcFactory
    {
        public static ICaculateFee<TFee> GetCalc<TFee>(string country)
        {
            switch (country)
            {
                case "UK":
                    return (ICaculateFee<TFee>)new UK();
                case "IE":
                    return (ICaculateFee<TFee>)new IE();
                default:
                    throw new ApplicationException($"No calc {country}");
            }
        }
    }
}
