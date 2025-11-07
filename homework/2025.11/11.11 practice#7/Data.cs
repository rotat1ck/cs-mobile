namespace practice7 {
    internal class Data {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Sex Sex { get; set; }
        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        public bool IsMarried { get; set; } = false;
        public string? AdditionalInfo { get; set; }

        public override string ToString() {
            return @$"Фамилия: {LastName},
                Имя: {FirstName},
                Отчество: {MiddleName}, 
                Пол: {Sex}, 
                Дата рождения: {BirthDate.ToLongDateString()}
                Семейный статус: {(IsMarried ? "Замужем" : "Холост")}
                {(AdditionalInfo != null ? $"Дополнительная информация: {AdditionalInfo}" : string.Empty)}";
        }
    }

    internal enum Sex {
        Ignore,
        Male,
        Female
    }
}
