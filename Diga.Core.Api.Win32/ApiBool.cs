namespace Diga.Core.Api.Win32
{
    public class ApiBool
    {
        private bool _Value;

        public ApiBool()
        {
            this._Value = false;
        }
        public ApiBool(int value)
        {
            this.Value = value;
        }

        public ApiBool(bool value)
        {
            this._Value = value;
        }

        public static implicit operator bool(ApiBool input)
        {
            return input._Value;
        }

        public static implicit operator ApiBool(bool input)
        {
            return new ApiBool(input);
        }
        public static implicit operator int(ApiBool input)
        {
            return input.Value;
        }
        public static implicit operator ApiBool(int input)
        {
            return new ApiBool(input);
        }

        public int Value
        {
            get
            {
                if (this._Value)
                    return 1;
                else
                    return 0;
            }
            set
            {
                if (value == 0)
                    this._Value = false;
                else
                    this._Value = true;

            }
        }

    }
}