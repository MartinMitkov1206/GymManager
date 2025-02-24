namespace GymManager.Helpers
{
    public static class CalcAgeHelper
    {
        public static int CalceAge(DateTime dob)
        {
            var today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
