namespace OrderMakerApp.Domain
{
    public record Id
    {
        public int Value { get; init; }
        public Id(int id)
        {
            if (id == 0)
                throw new Exception("Id can not be zero.");

            Value = id;
        }

        public static explicit operator int(Id id) => id.Value;
        public static explicit operator Id(int id) => new(id);
    }

    public record NotEmptyString
    {
        int? maxSize;

        public NotEmptyString(string value, int? maxSize = null)
        {
            this.maxSize = maxSize;

            if (string.IsNullOrEmpty(value))
                throw new Exception("Can not be empty");

            if (maxSize.HasValue && value.Length > maxSize.Value)
                throw new Exception($"Too long value. Shoud has less that {maxSize} chars.");
        }

        public string Value { get; init; } = string.Empty;
    }

    public record String100 : NotEmptyString
    {
        public String100(string value) : base(value, 100)
        {
        }

        public static explicit operator string(String100 id) => id.Value;
        public static explicit operator String100(string id) => new(id);
    }

    public record Email : NotEmptyString
    {
        public Email(string value) : base(value)
        {
            if (!Value.Contains('@'))
                throw new Exception("Invalid email");
        }

        public static explicit operator string(Email id) => id.Value;
        public static explicit operator Email(string id) => new(id);
    }

    public record Number
    {
        private readonly int? minValue;

        public Number(int value, int? minValue = null)
        {
            this.minValue = minValue;

            if (minValue.HasValue && Value < minValue)
                throw new Exception("Should be higher than {}");

            Value = value;
        }

        public int Value { get; init; }
    }

    public record PositiveNumber : Number
    {
        private const int MinValue = 1;

        public PositiveNumber(int value) : base(value, MinValue)
        {
        }

        public static explicit operator int(PositiveNumber id) => id.Value;
        public static explicit operator PositiveNumber(int id) => new(id);
    }
}
