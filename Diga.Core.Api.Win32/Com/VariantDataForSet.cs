using System;

namespace Diga.Core.Api.Win32.Com
{
    [Serializable]
    public struct VariantDataForSet<T>
    {
        internal VariantDataForSet(T value)
        {
            this._value = value;
        }

        internal T Value
        {

            get => this._value;

            set => this._value = value;
        }

        private T _value;

        public static implicit operator T(VariantDataForSet<T> input)
        {
            return input.Value;
        }

        public static implicit operator VariantDataForSet<T>(T input)
        {
            return new VariantDataForSet<T>(input);
        }
    }
}