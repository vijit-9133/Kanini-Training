public static class Work_Schedule_Calcy
{
    public static int Calculate(DateTime startDate, DateTime endDate, List<DateTime> holidays)
    {
        if (startDate > endDate)
        {
            throw new ArgumentException("The end date cannot be before the start date.");
        }
        int workingDays = 0;
        for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
        {

            if (date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday &&
                !holidays.Any(h => h.Date == date.Date))
            {
                workingDays++;
            }
        }

        return workingDays;
    }
}