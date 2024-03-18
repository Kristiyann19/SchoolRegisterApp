namespace SchoolRegisterApp.Repositories.CustomExceptionMessages
{
    public static class ExceptionMessages
    {
        // Login
        public const string LoginInvalidUsernameOrPassword = "Невалидно потребителско име или парола";

        // Register
        public const string AlreadyUsedUsername = "Потребителското име е заето";
        public const string AlreadyUsedPhone = "Телефонният номер е зает";

        // User
        public const string InvalidSchoolForUser = "Потребителят не отговаря за никое училище";

        // Person
        public const string InvalidPerson = "Невалиден преподавател";
        public const string InvalidSchoolForPerson = "Преподавателят не преподава все още никъде";

        // School
        public const string InvalidSchool = "Невалидно училище";

        // PersonSchool
        public const string InvalidPersonSchool = "Невалидна преподавателска длъжност";
        public const string CannotChangePersonForPersonSchool = "Не може да промените преподавателя";
        public const string CannotChangeSchoolForPersonSchool = "Не може да промените училището";
    }
}
