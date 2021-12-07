namespace Microservice.Service.Core.Domain
{
    public class ValueObjectBase<T> : IEquatable<ValueObjectBase<T>>
    {
        public T Value { get; }
        
        public ValueObjectBase(T value) => Value = value ?? throw new ArgumentNullException(nameof(value)); 

        public bool Equals(ValueObjectBase<T>? other)
        {
            _ = other ?? throw new ArgumentNullException(nameof(other));
            return object.Equals(Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ValueObjectBase<T> && Equals((ValueObjectBase<T>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397);
            }
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public static bool operator ==(ValueObjectBase<T> item, ValueObjectBase<T> other)
        {
            return item.Equals(other);
        }

        public static bool operator !=(ValueObjectBase<T> item, ValueObjectBase<T> other)
        {
            return !(item.Equals(other));
        }        
    }
}
