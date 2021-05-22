namespace MIW.ADOO.Runtime
{
    public class Token
    {
        public char Value { get; }

        public Token(char value)
        {
            this.Value = value;
        }

        public bool Equals(Token other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((Token) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public Token Clone()
        {
            return new Token(Value);
        }
    }
}